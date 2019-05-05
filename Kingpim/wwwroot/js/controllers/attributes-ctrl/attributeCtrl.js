app.controller('attributeCtrl', function ($scope, $http) {

    //Get value List.
    $http({
        method: 'GET',
        url: '/api/Attributes/GetValueTypes'
    }).then(function successCallback(response) {
        $scope.values = response.data;
        console.log(response);
    }, function errorCallback(response) {
        Swal.fire({
            title: 'Server fel',
            type: 'error'
        }).then(function () {
            location.reload();
        });
    });

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

    //Get all attributes.
    $http({
        method: 'GET',
        url: '/api/Attributes/GetAllAttributes'
    }).then(function successCallback(response) {
        $scope.attributes = response.data;
    }, function errorCallback(response) {

        Swal.fire({
            title: 'Server error!',
            type: 'error'
        }).then(function () {
            return;
        });

    });

    //Get attribute by id.
    $scope.getAttributeById = function (attributeId) {

        $http({
            method: 'GET',
            url: '/api/Attributes/GetAttributeById/' + attributeId
        }).then(function successCallback(response) {

            $scope.attributeObj = {
                'attributeId': response.data.attributeId,
                'attributeName': response.data.attributeName,
                'value': response.data.value,
                'attributeGroupName': response.data.attributeGroupName,
                'creationDate': response.data.creationDate,
                'lastModifiedDate': response.data.lastModifiedDate
            };

        }, function errorCallback(response) {

            Swal.fire({
                title: 'Gick inte hitta attribute!',
                type: 'error'
            }).then(function () {
                return;
            });

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

        $http({
            method: 'POST',
            url: '/api/Attributes/UpdateAttribute/' + attributeId,
            data: inputModel
        }).then(function successCallback(response) {
            Swal.fire({
                title: 'Attribute har updaterats!',
                type: 'success'
            }).then(function () {
                location.reload();
            });
        }, function errorCallback(response) {
            Swal.fire({
                title: 'Gick inte updatera attribute',
                type: 'error'
            }).then(function () {
                return;
            });
        });
    };


    //Delete attribute.
    $scope.deleteAttribute = function (attributeId) {
        $http({
            method: 'DELETE',
            url: '/api/Attributes/DeleteAttribute/' + attributeId
        }).then(function successCallback(response) {
            Swal.fire({
                title: 'Attribute är nu bortagen!',
                type: 'success'
            }).then(function () {
                location.reload();
            });
        }, function errorCallback(response) {
            Swal.fire({
                title: 'Gick inte ta bort attributen!',
                type: 'error'
            }).then(function () {
                return;
            });
        });
    };

});