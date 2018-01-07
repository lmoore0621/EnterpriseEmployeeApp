/// <reference path="Libs/angular.js" />

var app = angular.module('app', ['ngRoute']);

// #region Configuration

app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider
        .when('/employee', { template: '<employees></employees>'})
        .when('/employee/home', { redirectTo: '/employee' })
        .when('/employee/create', { template: '<create-employee></create-employee>'})
        .when('/employee/update/:id', { template: '<update-employee></update-employee>' })
        .when('/', {redirectTo: '/employee'})
        .otherwise({ redirectTo: '/employee' })
}]);

// #endregion

// #region Services

// #region Employee Service

app.factory('employeeService', ['$http', function ($http) {

    var baseUrl = "http://localhost:51424/api/employee/";

    return {
        getAll: function (pageNum, pageSize) {
            var url = baseUrl + 'all/' + ((pageNum && pageSize) ? +pageNum + '/' + pageSize : '');

            return $http.get(url);
        },

        get: function(id) {
            return $http.get(baseUrl + id);
        },

        create: function (employee) {
            return $http.post(baseUrl, employee);
        },

        update: function (employee) {
            return $http.put(baseUrl, employee);
        },

        remove: function (id) {
            return $http.delete(baseUrl + id)
        }
    };
}]);

// #endregion

// #region General Service

app.factory('generalService', ['$http', function ($http) {
    var baseUrl = "http://localhost:51424/api/general/";

    return {

        getStateOptions() {
            return $http.get(baseUrl + 'options/states');
        },
        
        getDegreeOptions() {
            return $http.get(baseUrl + 'options/degrees');
        },

        getGenderOptions() {
            return $http.get(baseUrl + 'options/genders');
        }
    };
}]);

// #endregion 

// #endregion

// #region Components

app.component('employees', {
    
    templateUrl: '/employee/home',
    controller: ['$scope', 'employeeService', function ($scope, employeeService) {
        $scope.employeesLoading = true;
        $scope.pageNumber = 1;
        $scope.pageSize = 2;
        $scope.employees = [];
        $scope.pagingInfo = {};
        $scope.pageEmployees = function (pageNum, pageSize) {
            $scope.pageNumber = pageNum;
            $scope.pageSize = pageSize;
            getAllEmployees();
        }
        $scope.deleteEmployee = function(employeeId) {
            employeeService.remove(employeeId)
                .then(function (response) {
                    resObj = response.data;

                    if (resObj.successful) {
                        $scope.pageNumber = 1;
                        getAllEmployees()
                    } else {
                        alert(resObj.message);
                    }

                })
        }

        // #region Helper Functions

        function getAllEmployees() {
            employeesLoading = true;
            employeeService.getAll($scope.pageNumber, $scope.pageSize)
                .then(function (response) {
                    resObj = response.data;
                    $scope.employeesLoading = false;
                    if (resObj.successful) {
                        $scope.employees = resObj.employees;
                        $scope.pagingInfo = resObj.pagingInfo;
                    } else {
                        alert(resObj.message);
                    }


                });
        }

        // #endregion

        // #region Initialization 

        getAllEmployees();

        // #endregion

    }]
});

app.component('pagingLinks', {
    templateUrl: '/home/paginglinks',
    bindings: {
        onPageItems: '&',
        pagingInfo: '<'
    },
    controller: ['$scope', function ($scope) {
        var self = this;
        $scope.pages = [];
        $scope.onPageItems = function(pageNum, pageSize) {
            self.onPageItems({ pageNum: pageNum, pageSize: pageSize });
        }

        this.$onChanges = function (changes) {
            if (changes.pagingInfo) {
                $scope.pagingInfo = angular.copy(self.pagingInfo);
                addPages();
            }
        }

        function addPages() {
            $scope.pages.splice(0, $scope.pages.length);
            for (var i = $scope.pagingInfo.startPage; i <= $scope.pagingInfo.endPage; i++) {
                $scope.pages.push(i);
            }
        }
    }]
});

app.component('createEmployee', {
    templateUrl: '/Home/Create',
    controller: ['employeeService', 'generalService', '$scope', '$location', function (employeeService, generalService, $scope, $location) {
        $scope.employee = {};
        $scope.genders = [];
        $scope.states = [];
        $scope.degrees = [];

        $scope.createEmployee = function () {
            employeeService.create($scope.employee)
                .then(function (response) {
                    var resObj = response.data;

                    if (resObj.successful) {
                        $scope.employee = {};
                        $location.url('/');
                    } else {
                        alert(resObj.message);
                    }
                });
        };

        // #region Helpers Functions

        function getOptions() {
            generalService.getGenderOptions()
                .then(function (response) {
                    var resObj = response.data;

                    if (resObj.successful) {
                        $scope.genders = resObj.genderOptions;
                    } else {
                        alert(resObj.message);
                    }
                });

            generalService.getStateOptions()
                .then(function (response) {
                    var resObj = response.data;

                    if (resObj.successful) {
                        $scope.states = resObj.stateOptions;
                    } else {
                        alert(resObj.message);
                    }
                });

            generalService.getDegreeOptions()
                .then(function (response) {
                    var resObj = response.data;

                    if (resObj.successful) {
                        $scope.degrees = resObj.degreeOptions;
                    } else {
                        alert(resObj.message);
                    }
                });
        }

        // #endregion

        // #region Initialization

        getOptions();

        // #endregion
    }
    ]
});

app.component('updateEmployee', {
    templateUrl: '/Home/Update',
    controller: ['employeeService', 'generalService', '$scope', '$location', '$routeParams', function (employeeService, generalService, $scope, $location, $routeParams) {
        $scope.employee = {};
        $scope.genders = [];
        $scope.states = [];
        $scope.degrees = [];

        $scope.updateEmployee = function () {
            employeeService.update($scope.employee)
                .then(function (response) {
                    var resObj = response.data;

                    if (resObj.successful) {
                        $scope.employee = {};
                        $location.url('/');
                    } else {
                        alert(resObj.message);
                    }
                });
        }

        // #region Helpers Functions

        function getEmployeeToUpdate() {
            employeeService.get($routeParams.id)
                .then(function(response) {
                    var resObj = response.data;

                    if (resObj.successful) {
                        $scope.employee = resObj.employee;
                    } else {
                        alert(resObj.message);
                    }
                });
        }

        function getOptions() {
            generalService.getGenderOptions()
                .then(function (response) {
                    var resObj = response.data;

                    if (resObj.successful) {
                        $scope.genders = resObj.genderOptions;
                    } else {
                        alert(resObj.message);
                    }
                });

            generalService.getStateOptions()
                .then(function (response) {
                    var resObj = response.data;

                    if (resObj.successful) {
                        $scope.states = resObj.stateOptions;
                    } else {
                        alert(resObj.message);
                    }
                });

            generalService.getDegreeOptions()
                .then(function (response) {
                    var resObj = response.data;

                    if (resObj.successful) {
                        $scope.degrees = resObj.degreeOptions;
                    } else {
                        alert(resObj.message);
                    }
                });
        }

        // #endregion

        // #region Initialization

        getOptions();
        getEmployeeToUpdate();

        // #endregion
    }]
});

// #endregion