app.controller('createAttributeCtrl', function ($scope, $http) {

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

    //Create attribute
    $scope.createAttribute = function () {

        let selectedValue = $('#selectListValue :selected').attr('id');
        let selectedAttributeGroupId = $('#selectListAttributeGroup :selected').attr('id');

        let inputModel = {
            'AttributeName': $scope.attribute.name,
            'ValueTypeId': selectedValue,
            'AttributeGroupId': selectedAttributeGroupId
        };

        $http({
            method: 'POST',
            url: '/api/Attributes/CreateAttribute',
            data: inputModel
        }).then(function successCallback(response) {
            Swal.fire({
                title: 'Attribute är nu skapad!',
                type: 'success'
            }).then(function () {
                location.reload();
            });
        }, function errorCallback(response) {
            Swal.fire({
                title: 'Gick inte skapa attribute',
                type: 'error'
            }).then(function () {
                return;
            });
        });
    };

});