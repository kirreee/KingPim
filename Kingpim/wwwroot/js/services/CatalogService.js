app.service('catalogService', function ($http) {

    //Get all catalogs
    this.getAllCatalogs = function (data) {

        $http({
            method: 'GET',
            url: '/api/Catalogs/GetAllCatalogs'
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { });

    };

    //Get catalog by Id
    this.getCatalogById = function (catalogId, data) {

        $http({
            method: 'GET',
            url: '/api/Catalogs/GetCatalogById/' + catalogId
        }).then(function successCallback(response) {
            data(response.data);
        }, function errorCallback(response) { });

    };

    //Create catalog
    this.createCatalog = function (inputData, statusCode) {

        $http({
            method: 'POST',
            url: '/api/Catalogs/CreateCatalog',
            data: inputData
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) {
            statusCode(response.status);
        });

    };

    //Update catalog
    this.updateCatalog = function (catalogId, inputData, statusCode) {

        $http({
            method: 'POST',
            url: '/api/Catalogs/UpdateCatalog/' + catalogId,
            data: inputData
        }).then(function successCallback(response) {
            statusCode(response.status);
        }, function errorCallback(response) {
            statusCode(response.status);
        });

    };

    //Remove catalog
    this.removeCatalog = function (catalogId, responseStatus) {

        $http({
            method: 'DELETE',
            url: '/api/Catalogs/DeleteCatalog/' + catalogId
        }).then(function successCallback(response) {

           
            responseStatus(response.status);

        }, function errorCallback(response) {
            statusCode(response.statusCode);
        });

    };

});