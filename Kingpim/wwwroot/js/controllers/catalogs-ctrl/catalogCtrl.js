app.controller('catalogCtrl', function ($scope, $http) {





    //Get all catalogs
    $http({
        method: 'GET',
        url: '/api/Catalogs/GetAllCatalogs'
    }).then(function successCallback(response) {
        console.log('Categories:' + response.data);
        $scope.catalogs = response.data;
    }, function errorCallback(response) { });

    //Remove catalog
    $scope.removeCatalog = function (catalogId) {
        $http({
            method: 'DELETE',
            url: '/api/Catalogs/DeleteCatalog/' + catalogId
        }).then(function successCallback(response) {
            Swal.fire({
                title: 'Katalog har raderats!',
                type: 'success'
            }).then(function () {
                location.reload();
            });
        }, function errorCallback(response) {
            Swal.fire({
                title: 'Gick inte radera katalog',
                type: 'error'
            }).then(function () {
                location.reload();
            });
        });
    };

    //Get Catalog by id
    $scope.getCatalogById = function (catalogId) {

        $http({
            method: 'GET',
            url: '/api/Catalogs/GetCatalogById/' + catalogId
        }).then(function successCallback(response) {
            $scope.catalogObj = {
                'CatalogName': response.data.catalogName,
                'catalogId': response.data.catalogId,
                'creationDate': response.data.creationDate
            };

        }, function errorCallback(response) {

            Swal.fire({
                title: 'Gick inte hitta katalogen.',
                type: 'error'
            }).then(function () {
                location.reload();
            });

        });
    };


    //Update catalog
    $scope.updateCatalog = function (catalogId) {

        var inputModel = {
            'Name': $scope.catalogObj.CatalogName
        };

        $http({
            method: 'POST',
            url: '/api/Catalogs/UpdateCatalog/' + catalogId,
            data: inputModel
        }).then(function successCallback(response) {
            Swal.fire({
                title: 'Katalog har updaterats!',
                type: 'success'
            }).then(function () {
                location.reload();
            });
        }, function errorCallback(response) {
            Swal.fire({
                title: 'Gick inte updatera katalog',
                type: 'error'
            }).then(function () {
                return;
            });
        });
    };

});