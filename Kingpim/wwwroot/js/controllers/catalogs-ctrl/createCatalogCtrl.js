app.controller('createCatalogCtrl', function ($scope, $http) {

    //Create a new catalog
    $scope.createCatalog = function () {

        var inputModel = {
            'Name': $scope.catalog.name
        };

        $http({
            method: 'POST',
            url: '/api/Catalogs/CreateCatalog',
            data: inputModel
        }).then(function successCallback(response) {

            Swal.fire({
                title: 'Katalog har blivit skapad!',
                type: 'success'
            }).then(function () {
                location.reload();
            });

        }, function errorCallback(response) {
            $scope.checkStatusMessage(response);
        });


        $scope.checkStatusMessage = function (response) {
            var errorMessage = "Server fel";
            if (response.status === 500) {
                errorMessage = "Du måste vara inloggad för att kunna skapa en katalog";
            }

            Swal.fire({
                title: 'OBS!',
                text: errorMessage,
                type: 'error'
            }).then(function () {
                return;
            });

        };
    };
});