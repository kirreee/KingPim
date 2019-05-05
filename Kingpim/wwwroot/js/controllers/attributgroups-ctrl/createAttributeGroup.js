app.controller('createAttributeGroup', function ($scope, $http) {


    //Create attribute group
    $scope.createAttributeGroup = function () {

        let inputData = {
            'AttributeGroupName': $scope.attributeGroup.name
        };

        $http({
            method: 'POST',
            url: '/api/AttributeGroups/CreateAttributeGroup',
            data: inputData
        }).then(function successCallback(response) {

            Swal.fire({
                title: 'Attribute gruppen skapades!',
                type: 'success'
            }).then(function () {
                location.reload();
            });

        }, function errorCallback(response) {

            Swal.fire({
                title: 'Gick inte skapa attribute gruppen!',
                type: 'error'
            }).then(function () {
                location.reload();
            });

        });
    };

});