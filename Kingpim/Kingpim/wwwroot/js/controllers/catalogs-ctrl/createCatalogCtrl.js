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
            Swal.fire({
                title: 'Gick inte skapa katalog!',
                type: 'error'
            }).then(function () {
                location.reload();
            });
        });
    };
});