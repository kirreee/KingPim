app.controller('createCatalogCtrl', function ($scope, $http) {
    console.log('create catalog ctrl körs!');

    //Create a new catalog
    $scope.createCatalog = function () {
        var inputModel = {
            'Name': $scope.category.name
        };

        $http({
            method: 'POST',
            url: '/api/Catalogs/CreateCatalog',
            data: inputModel
        }).then(function successCallback(response) {

            }, function errorCallback(response) {

        });
    };
});