app.controller('createCategoryCtrl', ['$scope', 'catalogService', 'categoryService',
    function ($scope, catalogService, categoryService) {


        //Get all catalogs
        catalogService.getAllCatalogs(function (data) {
            console.log(data);
            $scope.catalogs = data;
        });


        //Create a new category
        $scope.createCategory = function () {

            let catalogId = $('#selectListCatalog option:selected').attr('id');

            var inputModel = {
                'CategoryName': $scope.category.name,
                'IsPublished': $scope.category.isPublished,
                'CatalogId': catalogId
            };

            categoryService.createCategory(inputModel, function (statusCode) {
                if (statusCode === 200) {
                    Swal.fire({
                        title: 'Kategori har blivit skapad!',
                        type: 'success'
                    }).then(function () {
                        location.reload();
                    });
                }
                else {
                    Swal.fire({
                        title: 'Gick inte skapa kategori!',
                        type: 'error'
                    }).then(function () {
                        location.reload();
                    });
                }
            });
        };
    }]);