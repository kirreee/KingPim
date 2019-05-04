app.controller('createCategoryCtrl', function ($scope, $http) {


    //Get all catalogs
    $http({
        method: 'GET',
        url: '/api/Catalogs/GetAllCatalogs'
    }).then(function successCallback(response) {
       
        $scope.catalogList = response.data;

        }, function errorCallback(response) {

    });


    //Create a new category
    $scope.createCategory = function () {

        let catalogId = $('#selectListCatalog option:selected').attr('id');

        var inputModel = {
            'CategoryName': $scope.category.name,
            'IsPublished': $scope.category.isPublished,
            'CatalogId': catalogId
        };

        $http({
            method: 'POST',
            url: '/api/Categories/CreateCategory',
            data: inputModel
        }).then(function successCallback(response) {
            Swal.fire({
                title: 'Kategori har blivit skapad!',
                type: 'success'
            }).then(function () {
                location.reload();
            });
        }, function errorCallback(response) {
            Swal.fire({
                title: 'Gick inte skapa kategori!',
                type: 'error'
            }).then(function () {
                location.reload();
            });
        });
    };
});