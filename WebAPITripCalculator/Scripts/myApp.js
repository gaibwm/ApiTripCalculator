
var app = angular.module("myApp", []);

app.controller('StudentCtrl', ['$scope', 'myService',
    function ($scope, myService) {
        $scope.ID = '';
        $scope.PayName = ''; //using for label in expense form
        $scope.FinalTrip = '';
        getAllStudent();
        
        function getAllStudent() {
            var servCall = myService.get();
            servCall.then(function (d) {
                $scope.students = d.data;
            }, function (error) {
                alert('Oops! Something went wrong while fetching data.')
            });
        }

        $scope.Final = function () {
            var servCall = myService.getAll();
            servCall.then(function (d) {
                $scope.FinalTrip = d.data;
            }, function (error) {
                alert('Oops! Something went wrong while fetching data.') 
            });
        }

        $scope.Save = function () {

            if ($scope.ID === '') {
                alert('Please select who pay !');
            }
            else
            {
                var expense = {
                    ID: "",
                    StudentID: $scope.ID,
                    Amount: $scope.Amount
                }

                var result = myService.post(expense);
                result.then(function (response) {
                    $scope.students = response.data;        
                }, function (error) {
                    console.log("Error: " + error);
                });
            }
            $scope.Clear();
        }

        $scope.FillTable = function (dataModel) {           
            $scope.ID = dataModel.ID;
            $scope.PayName = dataModel.Name + ' pay:';           
        }

        $scope.Clear = function () {
            $scope.ID = "";
            $scope.PayName = "";
            $scope.Amount = "";
        }
    }
]);

app.service('myService', function ($http) {
    var apiRoute = '/api/Student';

    this.post = function (Model) {
        var request = $http({
            method: "post",
            url: apiRoute,
            data: Model
        });
        return request;
    }

    this.get = function () {
        return $http.get(apiRoute);
    }

    this.getAll = function () {
        return $http.get(apiRoute + '/0');
    }
}); 