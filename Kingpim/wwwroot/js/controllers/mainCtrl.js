app.controller('mainCtrl', function ($scope, $http) {

    //Check if user is authenticated
    $http({
        method: 'GET',
        url: '/api/Account/isAuthenticated'
    }).then(function successCallback(response) {
        $scope.isAuthenticated = response.data;
    }, function errorCallback(response) {
        $scope.isAuthenticated = response.data;
    });

    //Logout
    $scope.logOut = function () {
        $http({
            method: 'POST',
            url: '/api/Account/Logout'
        }).then(function successCallback(response) {
            $scope.isAuthenticated = false;
            //location.href = "#!/login";
        }, function errorCallback(response) {
            return;
        });
    };



});