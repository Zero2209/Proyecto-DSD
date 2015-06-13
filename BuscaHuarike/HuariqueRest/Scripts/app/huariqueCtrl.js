(function () {
    'use strict'
    var app = angular.module('app', []);//set and get the angular module
    app.controller('huariqueController', ['$scope', '$http', huariqueController]);

    //angularjs controller method
    function huariqueController($scope, $http) {

        //declare variable for mainain ajax load and entry or edit mode
        $scope.loading = true;
        $scope.addMode = false;

        //get all customer information
        $http.get('/api/Huarique/').success(function (data) {
            $scope.huariques = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });

        //by pressing toggleEdit button ng-click in html, this method will be hit
        $scope.toggleEdit = function () {
            this.huarique.editMode = !this.huarique.editMode;
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
        };
        $scope.huariques = Array()
        //Inser Customer
        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/Huarique/', this.newhuarique).success(function (data) {
                alert("Added Successfully!!");
                $scope.addMode = false;
                $scope.huariques.push(data);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding Huarique! " + data;
                $scope.loading = false;
            });
        };

        //Edit Customer
        $scope.save = function () {
            //alert("Edit");
            $scope.loading = true;
            var frien = this.huarique;
            alert(frien);
            $http.put('/api/Huarique/' + frien.Id, frien).success(function (data) {
                alert("Saved Successfully!!");
                frien.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Huarique! " + data;
                $scope.loading = false;
            });
        };

        //Delete Customer
        $scope.delete = function () {
            $scope.loading = true;
            var Id = this.huarique.Id;
            $http.delete('/api/Huarique/' + Id).success(function (data) {
                alert("Deleted Successfully!!");
                $.each($scope.huariques, function (i) {
                    if ($scope.huariques[i].Id === Id) {
                        $scope.huariques.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Review! " + data;
                $scope.loading = false;
            });
        };
    }
})();
