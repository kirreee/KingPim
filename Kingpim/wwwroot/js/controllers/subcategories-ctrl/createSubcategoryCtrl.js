app.controller('createSubcategoryCtrl', ['$scope', 'subcategoryService', function ($scope, subcategoryService) {

    $scope.createSubcategory = function () {

        let inputModel = {
            'SubcategoryName': $scope.subcategory.name,
            'IsPublished': $scope.subcategory.IsPublished,
            'CategoryId': $scope.selectedCategory,
            'SubcategoiresIds': $scope.selectedAttributeGroups
        };

        subcategoryService.createSubcategory(inputModel, function (statusCode) {
            if (statusCode === 200) {
                Swal.fire({
                    title: 'Subkategorin blev skapad!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            }
            else {
                Swal.fire({
                    title: 'Gick inte skapa subkategorin!',
                    type: 'error'
                }).then(function () {
                    return;
                });
            }
        });
    };
}]);