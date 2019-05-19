app.controller('createCatalogCtrl', ['$scope', 'catalogService', function ($scope, catalogService) {

    //Create a new catalog
    $scope.createCatalog = function () {

        var inputModel = {
            'Name': $scope.catalog.name
        };

        catalogService.createCatalog(inputModel, function (statusCode) {
            if (statusCode === 200) {
                Swal.fire({
                    title: 'Katalog har blivit skapad!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            }
            else {
                Swal.fire({
                    title: 'Gick inte skapa katalog',
                    type: 'error'
                }).then(function () {
                    location.reload();
                });
            }
        });
    };
}]);