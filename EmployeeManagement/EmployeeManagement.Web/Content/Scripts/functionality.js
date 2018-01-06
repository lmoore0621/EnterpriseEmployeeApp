var app = angular.module('app', ['ngRoute']);


// #region Configuration

app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider
        .when('/employee', { templateUrl: '/employee/Home', controller: function () { } })
        .when('/employee/Home', { redirectTo: '/employee' })
        .when('/employee/create', { templateUrl: '/Home/Create', controller: function () { } })
        .when('/employee/update/:id', { templateUrl: '/Home/Update', controller: function () { } })
        .when('/', {redirectTo: '/employee'})
        .otherwise({ redirectTo: '/employee' })
}]);

// #endregion