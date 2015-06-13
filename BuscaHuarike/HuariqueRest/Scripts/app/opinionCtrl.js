(function () {
    'use strict'
    var app = angular.module('app', []);//set and get the angular module
    app.controller('opinionController', ['$scope', '$http', opinionController]);

    //angularjs controller method
    function opinionController($scope, $http) {

        //declare variable for mainain ajax load and entry or edit mode
        $scope.loading = true;
        $scope.addMode = false;

        //get all customer information
        $http.get('/api/Opinion/').success(function (data) {
            $scope.opinions = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });

        //by pressing toggleEdit button ng-click in html, this method will be hit
        $scope.toggleEdit = function () {
            this.opinion.editMode = !this.opinion.editMode;
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
        };
        $scope.opinions = Array()
        //Inser Customer
        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/Opinion/', this.newopinion).success(function (data) {
                alert("Added Successfully!!");
                $scope.addMode = false;
                console.log($scope.opinions);
                $scope.opinions.push(data);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding Review! " + data;
                $scope.loading = false;
            });
        };

        //Edit Customer
        $scope.save = function () {
            //alert("Edit");
            $scope.loading = true;
            var frien = this.opinion;
            alert(frien);
            $http.put('/api/Opinion/' + frien.Id, frien).success(function (data) {
                alert("Saved Successfully!!");
                frien.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Review! " + data;
                $scope.loading = false;
            });
        };

        //Delete Customer
        $scope.delete = function () {
            $scope.loading = true;
            var Id = this.opinion.Id;
            $http.delete('/api/Opinion/' + Id).success(function (data) {
                alert("Deleted Successfully!!");
                $.each($scope.opinions, function (i) {
                    if ($scope.opinions[i].Id === Id) {
                        $scope.opinions.splice(i, 1);
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
