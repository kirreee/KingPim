app.controller('createAttributeGroup', ['attributeGroupService', function ($scope, attributeGroupService) {

    //Create attribute group
    $scope.createAttributeGroup = function () {

        let inputData = {
            'AttributeGroupName': $scope.attributeGroup.name
        };

        attributeGroupService.createAttributeGroup(inputData, function (statusCode) {
            if (statusCode === 200) {
                Swal.fire({
                    title: 'Attribute gruppen skapades!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            } else {
                Swal.fire({
                    title: 'Gick inte skapa attribute gruppen!',
                    type: 'error'
                }).then(function () {
                    location.reload();
                });
            }
        });
    };

}]);