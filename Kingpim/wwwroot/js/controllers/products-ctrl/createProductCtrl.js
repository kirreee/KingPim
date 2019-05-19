app.controller('createProductCtrl', ['$scope', 'SwalService', 'productService', 'subcategoryService',
    function ($scope, SwalService, productService, subcategoryService) {

        subcategoryService.getAllSubcategories(function (data) {
            $scope.subcategories = data;
        });

        //Create product
        $scope.createProduct = function () {

            let inputData = {
                'ProductName': $scope.product.name,
                'SubcategoryId': $scope.selectedSubcategory,
                'IsProductPublished': $scope.product.IsPublished
            };

            productService.createProduct(inputData, function (statusCode) {

                if (statusCode === 200) {
                    $scope.swalObj = {
                        'title': 'Produkt skapad!',
                        'type': 'success'
                    };

                    SwalService.swalShow($scope.swalObj);
                }
                else {
                    $scope.swalObj = {
                        'title': 'Gick inte skapa produkt',
                        'type': 'error'
                    };

                    SwalService.swalShow($scope.swalObj);
                }

            });

        };
    }]);