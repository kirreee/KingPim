app.controller('attributeGroupCtrl', function ($scope, $http) {

    //Get all AttributeGroups.
    $http({
        method: 'GET',
        url: '/api/AttributeGroups/GetAllAttributeGroups'
    }).then(function successCallback(response) {
        console.log(response.data);
        $scope.attributeGroups = response.data;

    }, function errorCallback(response) {

        Swal.fire({
            title: 'Server fel',
            type: 'error'
        }).then(function () {
            location.reload();
        });

    });


    //Get attributeGroup by id.
    $scope.getAttributeGroupById = function (attributeGroupId) {
        $http({
            method: 'GET',
            url: '/api/AttributeGroups/GetAttributeGroupById/' + attributeGroupId
        }).then(function successCallback(response) {

            $scope.attributeGroupObj = {
                'AttributeGroupId': response.data.attributeGroupId,
                'AttributeGroupName': response.data.attributeGroupName
            };

        }, function errorCallback(response) {

            Swal.fire({
                title: 'Server fel!',
                type: 'error'
            }).then(function () {
                location.reload();
            });

        });
    };


    //Update attributeGroup
    $scope.updateAttributeGroup = function (attributeGroupId) {

        let inputModel = {
            'AttributeGroupName': $scope.attributeGroupObj.AttributeGroupName
        };

        $http({
            method: 'POST',
            url: '/api/AttributeGroups/UpdateAttributeGroup/' + attributeGroupId,
            data: inputModel
        }).then(function successCallback(response) {

            Swal.fire({
                title: 'Attribute gruppen har updaterats!',
                type: 'success'
            }).then(function () {
                location.reload();
            });


        }, function erorrCallback(response) {

            Swal.fire({
                title: 'Gick inte updatera attribute gruppen!',
                type: 'error'
            }).then(function () {
                location.reload();
            });

        });
    };

    $scope.deleteAttributeGroup = function (attributeGroupId) {

        console.log(attributeGroupId);

        $http({
            method: 'DELETE',
            url: '/api/AttributeGroups/DeleteAttributeGroup/' + attributeGroupId
        }).then(function successCallback(response) {

            Swal.fire({
                title: 'Attribute gruppen är nu bortagen!',
                type: 'success'
            }).then(function () {
                location.reload();
            });

        }, function errorCallback(response) {

            Swal.fire({
                title: 'Kunde inte ta bort attribute gruppen!',
                type: 'error'
            }).then(function () {
                location.reload();
            });

        });
    };


});