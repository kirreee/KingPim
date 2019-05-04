app.controller('subcategoryCtrl', function ($scope, $http) {

    //Get all categories to selectList
    $http({
        method: 'GET',
        url: '/api/Categories/GetAllCategories'
    }).then(function successCallback(response) {
        $scope.categoriesList = response.data;
    }, function errorCallback(response) {

        Swal.fire({
            title: 'Server error!',
            type: 'error'
        }).then(function () {
            location.reload();
        });
    });

    //Get all subcategories
    $http({
        method: 'GET',
        url: '/api/Subcategories/GetAllSubcategories'
    }).then(function successCallback(response) {

        $scope.subcategories = response.data;

    }, function errorCallback(response) {

        Swal.fire({
            title: 'Server error!',
            type: 'error'
        }).then(function () {
            location.reload();
        });

    });

    //Delete subcategory
    $scope.deleteSubcategory = function (subcategoryId) {
        $http({
            method: 'DELETE',
            url: '/api/Subcategories/DeleteSubcategory/' + subcategoryId
        }).then(function successCallback(response) {

            Swal.fire({
                title: 'Subkategorin blev bortagen!',
                type: 'success'
            }).then(function () {
                location.reload();
            });

        }, function errorCallback(response) {

            Swal.fire({
                title: 'Gick inte ta bort subkategorin!',
                type: 'error'
            }).then(function () {
                return;
            });

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
                'IsPublished': response.data.isPublished
            };

        }, function errorCallback(response) {

            Swal.fire({
                title: 'Gick inte hitta subkategorin!',
                type: 'error'
            }).then(function () {
                location.reload();
            });

        });

    };

    //Update subcategory
    $scope.updateSubcategory = function (subcategoryId) {

        let categoryId = $('#selectListCategories :selected').attr('id');
        let inputModel = {
            'SubcategoryName': $scope.subcategoryObj.SubcategoryName,
            'IsPublished': $scope.subcategoryObj.IsPublished,
            'CategoryId': categoryId
        };

        $http({
            method: 'POST',
            url: '/api/Subcategories/UpdateSubcategory/' + subcategoryId,
            data: inputModel
        }).then(function successCallback(response) {

            Swal.fire({
                title: 'Subkategorin är nu updaterad!',
                type: 'success'
            }).then(function () {
                location.reload();
            });


        }, function errorCallback(response) {

            Swal.fire({
                title: 'Gick inte updatera subkategorin!',
                type: 'error'
            }).then(function () {
                location.reload();
            });

        });
    };

   
});