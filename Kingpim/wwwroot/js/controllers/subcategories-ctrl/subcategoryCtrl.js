app.controller('subcategoryCtrl', ['$scope', 'SwalService', 'subcategoryService', 'categoryService', 'attributeGroupService',
    function ($scope, SwalService, subcategoryService, categoryService, attributeGroupService) {

        //Get all AttributeGroups.
        attributeGroupService.getAllAttributeGroups(function (data) {
            $scope.attributeGroups = data;
        });

        //Get all categories to selectList
        categoryService.getAllCategories(function (data) {
            $scope.categoriesList = data;
        });

        //Get all subcategories
        subcategoryService.getAllSubcategories(function (data) {
            $scope.subcategories = data;
            console.log(data);
        });


        //Delete subcategory
        $scope.deleteSubcategory = function (subcategoryId) {
            console.log(subcategoryId);
            subcategoryService.deleteSubcategory(subcategoryId, function (statusCode) {
                if (statusCode === 200) {
                    $scope.swalMessage = {
                        'title': 'Subkategorin blev bortagen!',
                        'type': 'success'
                    };

                    SwalService.swalShow($scope.swalObj);
                }
                else {
                    $scope.swalMessage = {
                        'title': 'Gick inte ta bort subkategorin!',
                        'type': 'error'
                    };

                    SwalService.swalShow($scope.swalMessage);
                }
            });
        };

        //Get subcategory by Id
        $scope.getSubcategoryById = function (subcategoryId) {
            subcategoryService.getSubcategoryById(subcategoryId, function (data, statusCode) {

                $scope.subcategoryObj = {
                    'SubcategoryId': data.subcategoryId,
                    'SubcategoryName': data.subcategoryName,
                    'CategoryName': data.categoryName,
                    'IsPublished': data.isPublished,
                    'AttributeGroups': data.attributeGroups
                };

                if (statusCode === 404) {
                    $scope.$scope.swalMessage = {
                        'title': 'Gick inte hitta subkategorin!',
                        'type': 'error'
                    };

                    SwalService.swalShow($scope.swalMessage);
                }
            });
        };
       

        $scope.attributeGroupsIdsToDelte = [];

        //Remove attributeGroup
        $scope.removeAttributeGroup = function ($index, attributeGroupId) {

            if (attributeGroupId === undefined) {
                $scope.swalMessage = {
                    'title': 'Gick inte hitta subkategorin!',
                    'type': 'error'
                };

                SwalService.swalShow($scope.swalMessage);
            }

            $scope.subcategoryObj.AttributeGroups.splice($index, 1);
            $scope.attributeGroupsIdsToDelte.push(attributeGroupId);
        };

        //Update subcategorys
        $scope.updateSubcategory = function (subcategoryId) {

            let inputModel = {
                'SubcategoryName': $scope.subcategoryObj.SubcategoryName,
                'IsPublished': $scope.subcategoryObj.IsPublished,
                'CategoryId': $scope.selectedCategory,
                'SelectedAttributeGroupsIdsToCreate': $scope.selectedAttributeGroups,
                'SelectedAttributeGroupsIdsToDelete': $scope.attributeGroupsIdsToDelte
            };

            //Update subcategory
            subcategoryService.updateSubcategory(subcategoryId, inputModel, function (statusCode) {

                if (statusCode === 200) {
                    $scope.swalMessage = {
                        'title': 'Subkategorin är nu updaterad!',
                        'type': 'success'
                    };

                    SwalService.swalShow($scope.swalMessage);
                }
                else {
                    $scope.swalMessage = {
                        'title': 'Gick inte updatera subkategorin!',
                        'type': 'error'
                    };

                    SwalService.swalShow($scope.swalMessage);
                }

            });
        };

    }]);