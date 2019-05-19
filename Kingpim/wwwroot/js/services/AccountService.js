app.service('accountService', function ($http) {


    //Login
    this.login = function (inputData, statusMessage) {

        $http({
            method: 'POST',
            url: '/api/Users/account/login',
            async: true,
            data: inputData,
            headers: {
                "Content-Type": "application/json; charset = utf-8;"
            }
        }).then(function successCallback(response) {
            //statusMessage(response.status);
        }, function errorCallback(response) {
            //statusMessage(response.status);
        });
    };



});