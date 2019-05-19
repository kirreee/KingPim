app.controller('attributeGroupCtrl', ['$scope', 'attributeGroupService', function ($scope, attributeGroupService) {

    //Get all AttributeGroups.
    attributeGroupService.getAllAttributeGroups(function (data, responseMessage) {
        $scope.attributeGroups = data;
    }); 

    //Get attributeGroup by id.
    $scope.getAttributeGroupById = function (attributeGroupId) {

        attributeGroupService.getAttributeGroupById(attributeGroupId, function (data, statusCode) {

            $scope.attributeGroupObj = {
                'AttributeGroupId': data.attributeGroupId,
                'AttributeGroupName': data.attributeGroupName
            };

            if (statusCode === 200) {
                Swal.fire({
                    title: 'Server fel!',
                    type: 'error'
                }).then(function () {
                    location.reload();
                });
            }
        });
    };

    //Update attributeGroup
    $scope.updateAttributeGroup = function (attributeGroupId) {

        let inputModel = {
            'AttributeGroupName': $scope.attributeGroupObj.AttributeGroupName
        };

        attributeGroupService.updateAttributeGroup(attributeGroupId, inputModel, function (status) {

            if (statusCode === 200) {
                Swal.fire({
                    title: 'Attribute gruppen har updaterats!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            } else {
                Swal.fire({
                    title: 'Gick inte updatera attribute gruppen!',
                    type: 'error'
                }).then(function () {
                    location.reload();
                });
            }

        });
    };

    //Delete attrbuteGroup
    $scope.deleteAttributeGroup = function (attributeGroupId) {
        attributeGroupService.deleteAttributeGroup(attributeGroupId, function (statusCode) {
            if (statusCode === 200) {
                Swal.fire({
                    title: 'Attribute gruppen är nu bortagen!',
                    type: 'success'
                }).then(function () {
                    location.reload();
                });
            } else {
                Swal.fire({
                    title: 'Kunde inte ta bort attribute gruppen!',
                    type: 'error'
                }).then(function () {
                    location.reload();
                });
            }
        });
    };




}]);