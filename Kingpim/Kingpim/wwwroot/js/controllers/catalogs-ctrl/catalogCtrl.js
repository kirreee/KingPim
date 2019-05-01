app.controller('catalogCtrl', function ($scope, $http) {

    //Get all catalogs
    $http({
        method: 'GET',
        url: '/api/Catalogs/GetAllCatalogs'
    }).then(function successCallback(response) {
        console.log(response);
        $scope.catalogs = response.data;
    }, function errorCallback(response) {

    });

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

});