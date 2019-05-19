app.controller('loginCtrl', ['$scope', 'accountService', function ($scope, accountService) {

    

    //Login 
    $scope.login = function () {

        console.log('ost');

        let loginData = {
            'Password': $scope.password,
            'Email': $scope.password
        };

        accountService.login(loginData, function (statusMessage) {

            if (statusMessage === "Success") {
                alert('Logged in success');
            } else {
                alert('Logged in failed');
            }

        });
    };




}]);