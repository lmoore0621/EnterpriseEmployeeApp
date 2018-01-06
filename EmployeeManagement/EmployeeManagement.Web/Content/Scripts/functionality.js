/// <reference path="Libs/angular.js" />

var app = angular.module('app', ['ngRoute']);


// #region Configuration

app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider
        .when('/employee', { templateUrl: '/employee/Home', controller: function () { } })
        .when('/employee/home', { redirectTo: '/employee' })
        .when('/employee/create', { templateUrl: '/Home/Create', controller: function () { } })
        .when('/employee/update/:id', { templateUrl: '/Home/Update', controller: function () { } })
        .when('/', {redirectTo: '/employee'})
        .otherwise({ redirectTo: '/employee' })
}]);

// #endregion

// #region Services

// #region Employee Service

app.factory('employeeService', ['$http', function ($http) {

    var baseUrl = "localhost:51424/api/employee/";

    return {
        getAll: function (pageNum, pageSize) {
            var url = baseUrl + 'all/' + ((pageNum && pageSize) ? +pageNum + '/' + pageSize : '');

            return $http.get(url);
        },

        create: function (employee) {
            return $http.post(baseUrl, employee);
        },

        update: function (employee) {
            return $http.put(baseUrl, employee);
        },

        remove: function (id) {
            return $http.delete(baseUrl, { employeeId: id })
        }
    };
}]);

// #endregion

// #region General Service

app.factory('generalService', ['$http', function ($http) {
    var baseUrl = "localhost:51424/api/general/";

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