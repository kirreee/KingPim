app.service('subcategoryService', function ($http) {

    //Get all subcategories
    this.getAllSubcategories = function (data) {
        $http({
            method: 'GET',
            url: '/api/AttributeGroups/GetAllAttributeGroups'
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { });
    };

    //Get subcategory by Id
    this.getSubcategoryById = function (subcategoryId, data, statusCode) {
        $http({
            method: 'GET',
            url: '/api/Subcategories/GetSubcategoryById/' + subcategoryId
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { statusCode(response.status); });
    };

    //CreateSubcategory
    this.createSubcategory = function (inputData, statusCode) {
        $http({
            method: 'POST',
            url: '/api/Subcategories/CreateSubcategory',
            data: inputData
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) { statusCode(response.status); });
    };

    //Update subcategory
    this.updateSubcategory = function (subcategoryId, inputData, statusCode) {
        $http({
            method: 'POST',
            url: '/api/Subcategories/UpdateSubcategory/' + subcategoryId,
            data: inputData
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) { statusCode(response.status); });
    };

    //Delete subcategory
    this.deleteSubcategory = function (subcateogryId, statusCode) {

        $http({
            method: 'DELETE',
            url: '/api/Subcategories/DeleteSubcategory/' + subcategoryId
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) {
            statusCode(response.status);
        });

    };



});