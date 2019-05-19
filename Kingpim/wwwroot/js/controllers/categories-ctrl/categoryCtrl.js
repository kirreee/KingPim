app.controller('categoryCtrl', ['$scope', 'categoryService', function ($scope, categoryService) {


    //Get all categories
    categoryService.getAllCategories(function (data) {
        $scope.categories = data;
    });


    //Get category by id
    $scope.getCategoryById = function (categoryId) {

        categoryService.getCategoryById(categoryId, function (data) {
            $scope.categoryObj = {
                'CategoryId': categoryId,
                'CategoryName': data.categoryName,
                'CatalogName': data.catalogName,
                'CreatedBy': data.userName,
                'IsPublished': data.isPublished
            };
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

        categoryService.updateCategory(categoryId, inputModel, function (statusCode) {
            if (statusCode === 200) {
                Swal.fire({
                    title: 'Kategori har updaterats!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            }
            else {
                var errorMessage = response.status === 500 ? "Du måste vara inloggad för att kunna skapa en catalog."
                    : "Något gick fel försök igen!";

                Swal.fire({
                    title: errorMessage,
                    type: 'error'
                }).then(function () {
                    location.reload();
                });
            }
        });
    };

    //Remove category 
    $scope.removeCateory = function (categoryId) {

        categoryService.removeCategory(categoryId, function (responseMessage) {
            if (responseMessage === 200) {
                Swal.fire({
                    title: 'Kategori bortagen!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            } else {
                Swal.fire({
                    title: 'Kategori bortagen!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            }
        });

    };

}]);