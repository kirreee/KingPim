app.service('productService', function ($http) {

    //Get all products
    this.getAllProducts = function (data, statusCode) {
        $http({
            method: 'GET',
            url: '/api/Products/GetAllProducts'
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { statusCode(response.status); });
    };

    //Get Product by Id
    this.getProductById = function (productId, data, statusCode) {
        $http({
            method: 'GET',
            url: '/api/Products/GetProductById/' + productId
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { statusCode(response.status) });

    };

    //Create Product
    this.createProduct = function (inputData, statusCode) {
        $http({
            method: 'POST',
            url: '/api/Products/CreateProduct',
            data: inputData
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) { statusCode(response.status); });
    };

    //Delete Product
    this.deleteProduct = function (productId, statusCode) {
        $http({
            method: 'DELETE',
            url: '/api/Products/DeleteProduct/' + productId
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function erroCallback(response) { statusCode(response.status); });
    };

    this.fileUpload = function (file, productId, statusMessage) {

        $.ajax({
            type: 'POST',
            url: '/api/Products/FileUpload/' + productId,
            data: file,
            contentType: false,
            processData: false

        }).then(function successCallback(response) {
            statusMessage(response.data);
        }, function errorCallback(response) { statusMessage(response.data); });
    };

});