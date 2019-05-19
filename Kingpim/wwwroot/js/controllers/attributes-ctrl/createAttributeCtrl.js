app.controller('createAttributeCtrl', ['$scope', 'attributeService', 'attributeGroupService',
    function ($scope, attributeService, attributeGroupService) {

        //Get all AttributeGroups.
        attributeGroupService.getAllAttributeGroups(function (data, responseMessage) {

           
            $scope.attributeGroups = data;


            //if (statusCode !== 200) {
            //    Swal.fire({
            //        title: 'Server fel',
            //        type: 'error'
            //    }).then(function () {
            //        location.reload();
            //    });
            //}
        });



        //Create attribute
        $scope.createAttribute = function () {

            let selectedValue = $('#selectListValue :selected').attr('id');
            let selectedAttributeGroupId = $('#selectListAttributeGroup :selected').attr('id');

            let inputModel = {
                'AttributeName': $scope.attribute.name,
                'ValueTypeId': selectedValue,
                'AttributeGroupId': selectedAttributeGroupId
            };


            attributeService.createAttribute(inputModel, function (statusCode) {
                if (statusCode === 200) {
                    Swal.fire({
                        title: 'Attribute är nu skapad!',
                        type: 'success'
                    }).then(function () {
                        location.reload();
                    });
                } else {
                    Swal.fire({
                        title: 'Gick inte skapa attribute',
                        type: 'error'
                    }).then(function () {
                        return;
                    });
                }

            });
        };

    }]);