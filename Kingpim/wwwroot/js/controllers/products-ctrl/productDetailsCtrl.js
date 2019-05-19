app.controller('productDetailsCtrl', ['$scope','$http', '$routeParams', 'mediaTypeService', 'productService',
    function ($scope, $http, $routeParams, mediaTypeService, productService) {

        //Get all media types
        mediaTypeService.getAllMediaTypes(function (data) {
            $scope.mediaTypes = data;
        });

        //Set media type on product
        $scope.changeMediaType = function (selectedMediaType, fileId) {
            mediaTypeService.setMediaTypeOnProduct(selectedMediaType, fileId, function (statusCode) {
                if (statusCode !== 200) {
                    location.reload();
                }

            });
        };


        //Get product by Id
        productService.getProductById($routeParams.id, function (data) {

            let published = "Nej";
            if (data.isPublished === true) {
                published = "Ja";
            }

            $scope.productObj = {
                'productId': data.productId,
                'productName': data.productName,
                'isPublished': published,
                'lastModified': data.lastModified,
                'lastModifiedBy': data.lastModifiedBy,
                'versioNumber': data.versioNumber,
                'Files': data.files
            };
        });


        $scope.setMainImage = function (fileId) {
            $http({
                method: 'POST',
                url: '/api/Products/SetMainImage/' + fileId
            }).then(function successCallback(response) {
                location.reload();
            }, function errorCallback(response) { });
        };

    }]);