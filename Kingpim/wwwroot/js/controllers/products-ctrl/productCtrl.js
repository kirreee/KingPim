app.controller('productCtrl', ['$scope', 'SwalService', 'productService', 'subcategoryService',
    function ($scope, SwalService, productService, subcategoryService) {

        //Get all products
        productService.getAllProducts(function (data, statusCode) {
            $scope.productList = data;

            if (statusCode === 505) {
                $scope.swalObj = {
                    'title': 'Gick inte hämta produkternas',
                    'type': 'error'
                };

                SwalService.swalShow($scope.swalObj);
            }
        });

        //Get all subcategories.
        subcategoryService.getAllSubcategories, function (data) {
            $scope.subcategories = data;
        };


        //Get ProductById
        $scope.getProductById = function (productId) {
            productService.getProductById(productId, data, function (statusCode) {
                $scope.productObj = {
                    'productId': data.productId,
                    'productName': data.productName,
                    'isPublished': data.isPublished
                };

                if (statusCode !== 200) {
                    $scope.swalObj = {
                        'title': 'Gick inte hämta produkten',
                        'type': 'error'
                    };

                    SwalService.swalShow($scope.swalObj);
                }
            });
        };


        //Update product
        $scope.updateProduct = function (productId) {

            let inputData = {
                'ProductName': $scope.productObj.productName,
                'IsProductPublished': $scope.productObj.isPublished,
                'SubcategoryId': $scope.selectedSubcategory
            };

            productService.updateProduct(productId, inputData, function (statusCode) {
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

        //Delete product
        $scope.deleteProduct = function (productId) {

            productService.deleteProduct(productId, function (statusCode) {
                if (statusCode === 200) {
                    $scope.swalMessage = {
                        'title': 'Produkt blev borttagen',
                        'type': 'success'
                    };

                    SwalService.swalShow($scope.swalObj);
                }
                else {
                    $scope.swalMessage = {
                        'title': 'Gick inte ta bort produkt',
                        'type': 'error'
                    };

                    SwalService.swalShow($scope.swalObj);
                }
            });
        };


        //trigger File upload
        $scope.triggerFileUpload = function () {
            $('#fileUpload').click();
        };

        $scope.uploadFile = function (productId) {

            var fd = new FormData();
            var file = $('#fileUpload')[0].files[0];
            fd.append('file', file);

            $.ajax({
                type: 'POST',
                url: '/api/Products/FileUpload/' + productId,
                data: fd,
                contentType: false,
                processData: false

            }).then(function successCallback(response) {

                $scope.swalMessage = {
                    'title': 'Fil har laddats upp!',
                    'type': 'success'
                };

                SwalService.swalShow($scope.v);

            }, function errorCallback(response) {

                $scope.swalMessage = {
                    'title': 'Gick inte ladda upp filen!',
                    'type': 'error'
                };

                SwalService.swalShow($scope.swalMessage);

            });

        };
    }]);