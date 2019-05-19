app.controller('attributeCtrl', ['$scope', 'attributeService', 'valueTypeService', 'attributeGroupService',
    function ($scope, attributeService, valueTypeService, attributeGroupService) {

        //Get value List.
        valueTypeService.getValueTypes(function (data, statusCode) {
            $scope.values = data;

            if (statusCode !== 200) {
                Swal.fire({
                    title: 'Server fel',
                    type: 'error'
                }).then(function () {
                    location.reload();
                });
            }
        });

        //Get all AttributeGroups.
        attributeGroupService.getAllAttributeGroups(function (data, statusCode) {
            $scope.attributeGroups = data;

            if (statusCode !== 200) {
                Swal.fire({
                    title: 'Server fel',
                    type: 'error'
                }).then(function () {
                    location.reload();
                });
            }

        });

        //Get all attributes.
        attributeService.getAllAttributes(function (data, statusCode) {
            $scope.attributes = data;

            if (statusCode !== 200) {
                Swal.fire({
                    title: 'Server fel',
                    type: 'error'
                }).then(function () {
                    location.reload();
                });
            }
        });


        //Get attribute by id.
        $scope.getAttributeById = function (attributeId) {

            attributeService.getAttributeById(attributeId, data, function (statusCode) {
                $scope.attributeObj = {
                    'attributeId': data.attributeId,
                    'attributeName': data.attributeName,
                    'value': data.value,
                    'attributeGroupName': data.attributeGroupName,
                    'creationDate': data.creationDate,
                    'lastModifiedDate': data.lastModifiedDate
                };

                if (statusCode === 400) {
                    Swal.fire({
                        title: 'Gick inte hitta attribute!',
                        type: 'error'
                    }).then(function () {
                        return;
                    });
                }

            });
        };

        //Update attribute.
        $scope.updateAttribute = function (attributeId) {

            let selectedAttributeGroupId = $('#selectListAttributeGroup :selected').attr('id');
            let selectedValue = $('#selectListValues :selected').attr('id');

            let inputModel = {
                'AttributeName': $scope.attributeObj.attributeName,
                'ValueTypeId': selectedValue,
                'attributeGroupId': selectedAttributeGroupId
            };


            attributeService.updateAttribute(attributeId, inputModel, function (statusCode) {
                if (statusCode === 200) {
                    Swal.fire({
                        title: 'Attribute har updaterats!',
                        type: 'success'
                    }).then(function () {
                        location.reload();
                    });
                }
                else {
                    Swal.fire({
                        title: 'Gick inte updatera attribute',
                        type: 'error'
                    }).then(function () {
                        return;
                    });
                }
            });
        };

        //Delete attribute.
        $scope.deleteAttribute = function (attributeId) {

            attributeService.deleteAttribute(attributeId, function (statusCode) {
                if (statusCode === 200) {
                    Swal.fire({
                        title: 'Attribute är nu bortagen!',
                        type: 'success'
                    }).then(function () {
                        location.reload();
                    });
                } else {
                    Swal.fire({
                        title: 'Gick inte ta bort attributen!',
                        type: 'error'
                    }).then(function () {
                        return;
                    });
                }
            });
        };

    }]);