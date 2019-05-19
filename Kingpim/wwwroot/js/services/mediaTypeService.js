app.service('mediaTypeService', function ($http) {

    //Get all mediatypes
    this.getAllMediaTypes = function (data) {
        $http({
            method: 'GET',
            url: '/api/Products/GetMediumTypes/'
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { });
    };

    //Set media type
    this.setMediaTypeOnProduct = function (mediaType, fileId, statusCode) {
        $http({
            method: 'POST',
            url: '/api/Products/SetMediaType/' + mediaType + '/' + fileId
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) { statusCode(response.status); });
    };

});