(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataService', ['$http', '$q', function($http, $q) {
            var service = {};
            service.getEmployees = function () {
                var deferred = $q.defer();
                $http.get(currentHost + '/api/Employee')
                    .then(function (result) {
                        deferred.resolve(result.data);
                    }, function () {
                        deferred.reject();
                    });
                return deferred.promise;
            };
            service.getEmployeeById = function (employeeId) {
                var deferred = $q.defer();
                $http.get(currentHost + '/api/Employee/' + employeeId)
                    .then(function (result) {
                        deferred.resolve(result.data);
                    }, function () {
                        deferred.reject();
                    });
                return deferred.promise;
            };
            service.getEmployeeByIds = function (arrayEmployeeIds) {
                var deferred = $q.defer();
                var data = JSON.stringify(arrayEmployeeIds);
                var config = {
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8;'
                    }
                }
                $http.post(currentHost + '/api/Employee', data, config)
                    .then(function (result) {
                        deferred.resolve(result.data);
                    }, function () {
                        deferred.reject();
                    });
                return deferred.promise;
            };
            return service;
        }]);
    
})();
