(function () {
    'use strict';

    angular.module('app', [
        // Angular modules 
        'ngRoute'
        ])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider
                .when('/', {
                    controller: 'employeeCtrl',
                    templateUrl: 'js/app/templates/employee.html'
                })
                .otherwise({redirectTo:'/'});
        }]);
})();