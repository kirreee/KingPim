app.service('valueTypeService', function ($http) {

    //Get value types
    this.getValueTypes = function (data, statusCode) {
        $http({
            method: 'GET',
            url: '/api/Attributes/GetValueTypes'
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { statusCode(response.status) });
    };

});