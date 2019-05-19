app.service('valueTypeService', function ($http) {

    //Get value types
    this.getValueTypes = function (data, statusMessage) {
        $http({
            method: 'GET',
            url: '/api/Attributes/GetValueTypes'
        }).then(function successCallback(response) {
            data(response.data);
            //statusMessage(response.status);

            }, function errorCallback(response) { statusMessage(response.status); });
    };

});