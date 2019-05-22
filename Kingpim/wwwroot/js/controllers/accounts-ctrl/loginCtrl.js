app.controller('loginCtrl', ['$scope', '$http', 'accountService', function ($scope, $http, accountService) {



    //Login 
    $scope.login = function () {

        let loginData = {
            'Email': $scope.email,
            'Password': $scope.password
        };

        accountService.login(loginData, function (statusMessage) {

            if (statusMessage === "Success") {
                Swal.fire({
                    title: 'Inloggning lyckades!',
                    type: 'success'
                }).then(function () {
                    location.href = "#!/home";
                });
            } else {
                Swal.fire({
                    title: 'Inloggning misslyckades!',
                    type: 'error'
                }).then(function () {
                    return;
                });
            }

        });

       

        //accountService.login(loginData, function (statusMessage) {

        //    if (statusMessage === "Success") {
        //        alert('Logged in success');
        //    } else {
        //        alert('Logged in failed');
        //    }

        //});
    };




}]);