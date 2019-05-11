app.controller('createSubcategoryCtrl', function ($scope, $http) {

    $scope.createSubcategory = function () {

        let inputModel = {
            'SubcategoryName': $scope.subcategory.name,
            'IsPublished': $scope.subcategory.IsPublished,
            'CategoryId': $scope.selectedCategory,
            'SubcategoiresIds': $scope.selectedAttributeGroups
        };

        $http({
            method: 'POST',
            url: '/api/Subcategories/CreateSubcategory',
            data: inputModel
        }).then(function successCallback(response) {
            Swal.fire({
                title: 'Subkategorin blev skapad!',
                type: 'success'
            }).then(function () {
                location.reload();
            });
        }, function errorCallback(response) {
            Swal.fire({
                title: 'Gick inte skapa subkategorin!',
                type: 'error'
            }).then(function () {
                return;
            });

        });
    };

});