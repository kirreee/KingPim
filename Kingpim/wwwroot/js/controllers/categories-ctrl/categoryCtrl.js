app.controller('categoryCtrl', function ($scope, $http) {


    //Get all categories
    $http({
        method: 'GET',
        url: '/api/Categories/GetAllCategories'
    }).then(function successCallback(response) {
        $scope.categories = response.data;
    }, function errorCallback(response) {

    });


    //Get category by id
    $scope.getCategoryById = function (categoryId) {
        $http({
            method: 'GET',
            url: '/api/Categories/GetCategoryById/' + categoryId
        }).then(function successCallback(response) {
            $scope.categoryObj = {
                'CategoryId': categoryId,
                'CategoryName': response.data.categoryName,
                'CatalogName': response.data.catalogName,
                'CreatedBy': response.data.userName,
                'IsPublished': response.data.isPublished
            };
            

        }, function errorCallback(response) {

        });
    };

    //Update category
    $scope.updateCategory = function (categoryId) {

        let catalogId = $('#selectListCatalog :selected').attr('id');
        var inputModel = {
            'CategoryName': $scope.categoryObj.CategoryName,
            'CatalogId': catalogId,
            'IsPublished': $scope.categoryObj.IsPublished
        };

        
        

        $http({
            method: 'POST',
            url: '/api/Categories/UpdateCategory/' + categoryId,
            data: inputModel
        }).then(function successCallback(response) {

            Swal.fire({
                title: 'Kategori har updaterats!',
                type: 'success'
            }).then(function () {
                location.reload();
            });

        }, function errorCallback(response) {

            var errorMessage = response.status === 500 ? "Du måste vara inloggad för att kunna skapa en catalog."
                : "Något gick fel försök igen!";

            Swal.fire({
                title: errorMessage,
                type: 'error'
            }).then(function () {
                location.reload();
            });

        });
    };
});