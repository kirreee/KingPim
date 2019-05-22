app.controller('productDetailsCtrl', ['$scope', '$http', '$routeParams', 'mediaTypeService', 'productService',
    function ($scope, $http, $routeParams, mediaTypeService, productService) {

        //File upload
        //trigger File upload
        $scope.triggerFileUpload = function () {
            $('#fileUpload').click();
        };

        //File upload
        $scope.uploadFile = function (productId) {

            var formData = new FormData();
            var file = $('#fileUpload')[0].files[0];
            formData.append('file', file);

            productService.fileUpload(formData, productId, function (statusMessage) {

                switch (statusMessage) {
                    case 200:
                        Swal.fire({
                            title: 'Fil har laddats upp!',
                            type: 'success'
                        });
                        break;
                    case 500:
                        Swal.fire({
                            title: 'Gick inte ladda upp fil!',
                            type: 'error'
                        });
                        break;
                    default:
                }

            });
        };

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

            console.log(data);

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