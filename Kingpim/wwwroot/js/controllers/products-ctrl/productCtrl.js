app.controller('productCtrl', ['$scope', '$http', 'SwalService', function ($scope, $http, SwalService) {

    //Get all products
    $http({
        method: 'GET',
        url: '/api/Products/GetAllProducts'
    }).then(function successCallback(response) {

        $scope.productList = response.data;

    }, function errorCallback(response) {

        $scope.swalObj = {
            'title': 'Gick inte hämta produkternas',
            'type': 'error'
        };

        SwalService.swalShow($scope.swalObj);

    });


    //Get all subcategories.
    $http({
        method: 'GET',
        url: '/api/Subcategories/GetAllSubcategories'
    }).then(function successCallback(response) {
        $scope.subcategories = response.data;


    }, function errorCallback(response) {

        $scope.swalObj = {
            'title': 'Server error!',
            'type': 'error'
        };

        SwalService.swalShow($scope.swalObj);

    });

    //Get ProductById
    $scope.getProductById = function (productId) {
        $http({
            method: 'GET',
            url: '/api/Products/GetProductById/' + productId
        }).then(function successCallback(response) {

            $scope.productObj = {
                'productId': response.data.productId,
                'productName': response.data.productName,
                'isPublished': response.data.isPublished
            };

        }, function errorCallback(response) {

            $scope.swalObj = {
                'title': 'Gick inte hämta produkten',
                'type': 'error'
            };

            SwalService.swalShow($scope.swalObj);

        });
    };

    //Update product
    $scope.updateProduct = function (productId) {

        let inputData = {
            'ProductName': $scope.productObj.productName,
            'IsProductPublished': $scope.productObj.isPublished,
            'SubcategoryId': $scope.selectedSubcategory
        };

        $http({
            method: 'POST',
            url: '/api/Products/UpdateProduct/' + productId,
            data: inputData
        }).then(function successCallback(response) {

            $scope.swalObj = {
                'title': 'Produkt skapad!',
                'type': 'success'
            };

            SwalService.swalShow($scope.swalObj);

        }, function errorCallback(response) {

            $scope.swalObj = {
                'title': 'Gick inte skapa produkt',
                'type': 'error'
            };

            SwalService.swalShow($scope.swalObj);

        });

    };

    //Delete product
    $scope.deleteProduct = function (productId) {

        $http({
            method: 'DELETE',
            url: '/api/Products/DeleteProduct/' + productId
        }).then(function successCallback(response) {

            $scope.swalObj = {
                'title': 'Produkt blev borttagen',
                'type': 'success'
            };

            SwalService.swalShow($scope.swalObj);

        }, function erroCallback(response) {

            $scope.swalObj = {
                'title': 'Gick inte ta bort produkt',
                'type': 'error'
            };

            SwalService.swalShow($scope.swalObj);

        });

    };

}]);