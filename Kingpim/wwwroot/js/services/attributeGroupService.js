app.service('attributeGroupService', function ($http) {

    //Get all attributegGroups
    this.getAllAttributeGroups = function (data, statusCode) {
        $http({
            method: 'GET',
            url: '/api/AttributeGroups/GetAllAttributeGroups'
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) {
            statusCode(response.status);
        });
    };

    //Get attributeGroup by Id
    this.getAllAttributeGroupById = function (attributeGroupId, data, statusCode) {
        $http({
            method: 'GET',
            url: '/api/AttributeGroups/GetAttributeGroupById/' + attributeGroupId
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { statusCode(response.status); });
    };

    //Update attributeGroup
    this.updateAttributeGroup = function (attributeGroupId, inputData, statusCode) {
        $http({
            method: 'POST',
            url: '/api/AttributeGroups/UpdateAttributeGroup/' + attributeGroupId,
            data: inputData
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function erorrCallback(response) { statusCode(response.status); });
    };

    //Create attributeGroup
    this.createAttributeGroup = function (inputData, statusCode) {
        $http({
            method: 'POST',
            url: '/api/AttributeGroups/CreateAttributeGroup',
            data: inputData
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) { statusCode(response.status); });
    };

    //Delete attributeGroup
    this.deleteAttributeGroup = function (attributeGroupId, statusCode) {
        $http({
            method: 'DELETE',
            url: '/api/AttributeGroups/DeleteAttributeGroup/' + attributeGroupId
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) { statusCode(response.status); });
    };



});