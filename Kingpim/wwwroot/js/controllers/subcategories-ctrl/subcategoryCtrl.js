app.controller('subcategoryCtrl', ['$scope', '$http', 'SwalService', function ($scope, $http, SwalService) {

    //Get all AttributeGroups.
    $http({
        method: 'GET',
        url: '/api/AttributeGroups/GetAllAttributeGroups'
    }).then(function successCallback(response) {

        $scope.attributeGroups = response.data;

    }, function errorCallback(response) {

        $scope.swalObj = {
            'title': 'Server error!',
            'type': 'error'
        };

        SwalService.swalShow();
    });

    //Get all categories to selectList
    $http({
        method: 'GET',
        url: '/api/Categories/GetAllCategories'
    }).then(function successCallback(response) {
        $scope.categoriesList = response.data;
    }, function errorCallback(response) {

        $scope.swalObj = {
            'title': 'Server error!',
            'type': 'error'
        };

        SwalService.swalShow();
    });

    //Get all subcategories
    $http({
        method: 'GET',
        url: '/api/Subcategories/GetAllSubcategories'
    }).then(function successCallback(response) {
        $scope.subcategories = response.data;

    }, function errorCallback(response) {

        $scope.swalObj = {
            'title': 'Server error!',
            'type': 'error'
        };

        SwalService.swalShow();

    });

    //Delete subcategory
    $scope.deleteSubcategory = function (subcategoryId) {
        $http({
            method: 'DELETE',
            url: '/api/Subcategories/DeleteSubcategory/' + subcategoryId
        }).then(function successCallback(response) {

            $scope.swalObj = {
                'title': 'Subkategorin blev bortagen!',
                'type': 'success'
            };

            SwalService.swalShow();

        }, function errorCallback(response) {

            $scope.swalObj = {
                'title': 'Gick inte ta bort subkategorin!',
                'type': 'error'
            };

            SwalService.swalShow($scope.swalObj);
        });
    };


    //Get subcategory by Id
    $scope.getSubcategoryById = function (subcategoryId) {

        $http({
            method: 'GET',
            url: '/api/Subcategories/GetSubcategoryById/' + subcategoryId
        }).then(function successCallback(response) {

            $scope.subcategoryObj = {
                'SubcategoryId': response.data.subcategoryId,
                'SubcategoryName': response.data.subcategoryName,
                'CategoryName': response.data.categoryName,
                'IsPublished': response.data.isPublished,
                'AttributeGroups': response.data.attributeGroups
            };

        }, function errorCallback(response) {

            $scope.swalObj = {
                'title': 'Gick inte hitta subkategorin!',
                'type': 'error'
            };

            SwalService.swalShow($scope.swalObj);
        });
    };


    $scope.attributeGroupsIdsToDelte = [];

    //Remove attributeGroup
    $scope.removeAttributeGroup = function ($index, attributeGroupId) {

        if (attributeGroupId === undefined) {
            $scope.swalObj = {
                'title': 'Gick inte hitta subkategorin!',
                'type': 'error'
            };

            SwalService.swalShow($scope.swalObj);
        }

        $scope.subcategoryObj.AttributeGroups.splice($index, 1);
        $scope.attributeGroupsIdsToDelte.push(attributeGroupId);
    };

    //Update subcategory
    $scope.updateSubcategory = function (subcategoryId) {

        let inputModel = {
            'SubcategoryName': $scope.subcategoryObj.SubcategoryName,
            'IsPublished': $scope.subcategoryObj.IsPublished,
            'CategoryId': $scope.selectedCategory,
            'SelectedAttributeGroupsIdsToCreate': $scope.selectedAttributeGroups,
            'SelectedAttributeGroupsIdsToDelete': $scope.attributeGroupsIdsToDelte
        };

        $http({
            method: 'POST',
            url: '/api/Subcategories/UpdateSubcategory/' + subcategoryId,
            data: inputModel
        }).then(function successCallback(response) {

            $scope.swalObj = {
                'title': 'Subkategorin är nu updaterad!',
                'type': 'success'
            };

            SwalService.swalShow($scope.swalObj);

        }, function errorCallback(response) {

            $scope.swalObj = {
                'title': 'Gick inte updatera subkategorin!',
                'type': 'error'
            };

            SwalService.swalShow($scope.swalObj);
        });
    };

}]);