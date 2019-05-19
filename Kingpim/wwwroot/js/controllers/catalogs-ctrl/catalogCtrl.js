app.controller('catalogCtrl', ['$scope', 'catalogService', function ($scope, catalogService) {

    //Get all catalogs
    catalogService.getAllCatalogs(function (data) {
        $scope.catalogs = data;
    });

    //Remove catalog
    $scope.removeCatalog = function (catalogId) {

        catalogService.removeCatalog(catalogId, function (responseStatus) {
           
            if (responseStatus === 200) {

                Swal.fire({
                    title: 'Katalog har updaterats!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            }
            else {
                Swal.fire({
                    title: 'Gick inte radera katalog',
                    type: 'error'
                }).then(function () {
                    return;
                });
            }
        });
    };

    //Get Catalog by id
    $scope.getCatalogById = function (catalogId) {

        catalogService.getCatalogById(catalogId, function (data) {
            $scope.catalogObj = {
                'CatalogName': data.catalogName,
                'catalogId': data.catalogId,
                'creationDate': data.creationDate
            };
        });
    };


    //Update catalog
    $scope.updateCatalog = function (catalogId) {

        var inputModel = {
            'Name': $scope.catalogObj.CatalogName
        };

        catalogService.updateCatalog(catalogId, inputModel, function (statusCode) {
            if (statusCode === 200) {
                Swal.fire({
                    title: 'Katalog har updaterats!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            }
            else {
                Swal.fire({
                    title: 'Gick inte updatera katalog',
                    type: 'error'
                }).then(function () {
                    return;
                });
            }
        });
    };

}]);