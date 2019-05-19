app.controller('exportCtrl', ['$scope', 'catalogService', 'categoryService',
    function ($scope, catalogService, categoryService) {

        //Get all catalogs.
        catalogService.getAllCatalogs(function (data) {
            $scope.catalogs = data;
        });

        //Export catalog
        $scope.exportCatalog = function (catalogId) {
            $http({
                method: 'GET',
                url: '/api/Export/ExportFullCatalog/' + catalogId
            }).then(function successCallback(response) {

                //Show download button.
                $scope.showDownloadCatalogBtn = true;

                $scope.catalogJsonFileName = response.data;


            }, function errorCallback(response) {

            });

        };

        //Get all categories
        categoryService.getAllCategories(function (data) {
            $scope.categories = response.data;
        });

        //Export category
        $scope.exportCategory = function (categoryId) {
            $http({
                method: 'GET',
                url: '/api/Export/ExportFullCategory/' + categoryId
            }).then(function successCallback(response) {

                $scope.showDownloadCategoryBtn = true;
                $scope.categoryJsonFileName = response.data;

            }, function errorCallback(response) { });
        };

        //Get all subcategories
        subcategoryService.getAllSubcategories(function (data) {
            $scope.subcategories = data;
        });

        //Export subcategory
        $scope.exportSubcategory = function (subcategoryId) {
            $http({
                method: 'GET',
                url: '/api/Export/ExportFullSubcategory/' + subcategoryId
            }).then(function successCallback(response) {

                $scope.showDownloadSubcategoryBtn = true;
                $scope.subcategoryJsonFileName = response.data;

            }, function errorCallback(response) { });
        };


    }]);