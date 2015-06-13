
(function () {
    'use strict'
    var app = angular.module('app', []);//set and get the angular module
    app.controller('usuarioController', ['$scope', '$http', usuarioController]);

    //angularjs controller method
    function usuarioController($scope, $http) {

        //declare variable for mainain ajax load and entry or edit mode
        $scope.loading = true;
        $scope.addMode = false;

        //get all customer information
        $http.get('/api/Usuario/').success(function (data) {
            $scope.usuarios = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });

        //by pressing toggleEdit button ng-click in html, this method will be hit
        $scope.toggleEdit = function () {
            this.usuario.editMode = !this.usuario.editMode;
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        //Inser Customer
        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/Usuario/', this.newusuario).success(function (data) {
                alert("Added Successfully!!");
                $scope.addMode = false;
                $scope.usuarios.push(data);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding Customer! " + data;
                $scope.loading = false;
            });
        };

        //Edit Customer
        $scope.save = function () {
            //alert("Edit");
            $scope.loading = true;
            var frien = this.usuario;
            alert(frien);
            $http.put('/api/Usuario/' + frien.Id, frien).success(function (data) {
                alert("Saved Successfully!!");
                frien.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving customer! " + data;
                $scope.loading = false;
            });
        };

        //Delete Customer
        $scope.deletecustomer = function () {
            $scope.loading = true;
            var Id = this.usuario.Id;
            $http.delete('/api/Usuario/' + Id).success(function (data) {
                alert("Deleted Successfully!!");
                $.each($scope.usuarios, function (i) {
                    if ($scope.usuarios[i].Id === Id) {
                        $scope.usuarios.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Customer! " + data;
                $scope.loading = false;
            });
        };
    }
})();
