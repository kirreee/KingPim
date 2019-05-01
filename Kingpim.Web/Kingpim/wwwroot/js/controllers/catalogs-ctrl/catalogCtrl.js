app.controller('catalogCtrl', function ($scope, $http) {
    
    //Get all categories
    $http({
        method: 'GET',
        url: '/api/Catalogs/GetAllCategories'
    }).then(function successCallback(response) {
        $scope.catalogs = response.data;
    }, function errorCallback(response) {

    });

});