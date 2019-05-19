app.service('attributeService', function ($http) {

    //Get all attributes
    this.getAllAttributes = function (data, statusCode) {
        $http({
            method: 'GET',
            url: '/api/Attributes/GetAllAttributes'
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { statusCode(response.status) });
    };

    //Get attribute by Id
    this.getAttributeById = function (attributeId, data, statusCode) {

        $http({
            method: 'GET',
            url: '/api/Attributes/GetAttributeById/' + attributeId
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { statusCode(response.status) });
    };

    //Update attribute
    this.updateAttribute = function (attributeId, inputData, statusCode) {
        $http({
            method: 'POST',
            url: '/api/Attributes/UpdateAttribute/' + attributeId,
            data: inputModel
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) { statusCode(response.status); });
    };

    //Delete attribute
    this.deleteAttribute = function (attributeId, statusCode) {
        $http({
            method: 'DELETE',
            url: '/api/Attributes/DeleteAttribute/' + attributeId
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) {
            statusCode(response.status);
        });
    };

    //Create attribute
    this.createAttribute = function (data, statusCode) {
        $http({
            method: 'POST',
            url: '/api/Attributes/CreateAttribute',
            data: inputModel
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { statusCode(response.status); });
    };

});














