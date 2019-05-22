app.service('accountService', function ($http) {

    //Login 
    this.login = function (inputModel, statusCode) {

        $http({
            method: 'POST',
            url: '/api/Account/Login',
            data: inputModel
        }).then(function successCallback(response) {
            statusCode(response.data);
        }, function errorCallback(response) { statusCode(response.data); });
    };


});