app.service('categoryService', function ($http) {

    //Get all categories.
    this.getAllCategories = function (data, responseMessage) {
        $http({
            method: 'GET',
            url: '/api/Categories/GetAllCategories'
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { responseMessage(response.status); });
    };

    //Get category by Id
    this.getCategoryById = function (categoryId, data, responseMessage) {

        $http({
            method: 'GET',
            url: '/api/Categories/GetCategoryById/' + categoryId
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { responseMessage(response.status); });
    };

    //Create category
    this.createCategory = function (inputData, responseMessage) {

        $http({
            method: 'POST',
            url: '/api/Categories/CreateCategory',
            data: inputData
        }).then(function successCallback(response) {
            responseMessage(response.status);
        }, function errorCallback(response) {
            responseMessage(response.status);
        });

    };

    //Update category
    this.updateCategory = function (categoryId, inputData, responseMessage) {

        $http({
            method: 'POST',
            url: '/api/Categories/UpdateCategory/' + categoryId,
            data: inputData
        }).then(function successCallback(response) {
            responseMessage(response.status);
        }, function errorCallback(response) {
            responseMessage(response.status);
        });

    };

    //Remove category
    this.removeCategory = function (categoryId, responseMessage) {

        $http({
            method: 'DELETE',
            url: '/api/Categories/DeleteCategory/' + categoryId
        }).then(function successCallback(response) {
            responseMessage(response.status);
        }, function errorCallback(response) { responseMessage(response.status); });

    };


});