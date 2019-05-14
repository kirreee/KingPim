app.controller('createProductCtrl', ['$scope', '$http', 'SwalService', function ($scope, $http, SwalService) {

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

    //Create product
    $scope.createProduct = function () {

        let inputData = {
            'ProductName': $scope.product.name,
            'SubcategoryId': $scope.selectedSubcategory,
            'IsProductPublished': $scope.product.IsPublished
        };

        $http({
            method: 'POST',
            url: '/api/Products/CreateProduct',
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

}]);