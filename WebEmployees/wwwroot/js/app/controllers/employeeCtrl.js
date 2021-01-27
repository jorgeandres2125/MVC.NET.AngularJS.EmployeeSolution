(function () {
    'use strict';

    angular
        .module('app')
        .controller('employeeCtrl', ['$scope', 'dataService', function ($scope, dataService) { 
            $scope.employees = [];
            $scope.txtSearch = '';
            
            function getAllEmployees() {
                dataService.getEmployees().then(function (result) {
                    $scope.employees = result;
                });
            }

            function getEmployeeById(employeeId) {
                dataService.getEmployeeById(employeeId).then(function (result) {
                    if (!jQuery.isEmptyObject(result)) {
                        $scope.employees.push(result);
                        $scope.txtSearch = '';
                    }
                });
            }
            function buildEmployeeIdsParam(valueSearch) {
                var array = valueSearch.split(',');
                var arrayIds = [];
                array.forEach(function (emplId) {
                    if (emplId != "") {
                        var obj = {};
                        obj["Id"] = parseInt(emplId);
                        arrayIds.push(obj);
                    }
                });
                return arrayIds;
            }
            function getEmployeeByIds(arrayEmployeeIds) {
                dataService.getEmployeeByIds(arrayEmployeeIds).then(function (result) {
                    if (result != null && result.length > 0) {
                        $scope.employees = result;
                        $scope.txtSearch = '';
                    }
                });
            }

            $scope.searchKeyPress = function (event) {
                if (!((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 44))) {
                    event.preventDefault();
                }
            }
            $scope.handlePaste = function (event) {
                event.preventDefault();
            }
            $scope.searchEmployees = function () {
                var valueSearch = $.trim($scope.txtSearch);
                $scope.employees = [];
                if (valueSearch == "") {
                    getAllEmployees();
                } else {
                    if (valueSearch.indexOf(',') > -1) {
                        var arrayEmployeeIds = buildEmployeeIdsParam(valueSearch);
                        getEmployeeByIds(arrayEmployeeIds);
                    } else {
                        getEmployeeById(valueSearch);
                    }
                }
                
            }
            
        }]);

})();
