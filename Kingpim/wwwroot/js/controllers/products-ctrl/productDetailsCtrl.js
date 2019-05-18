app.controller('productDetailsCtrl', function ($scope, $http, $routeParams) {

    $http({
        method: 'GET',
        url: '/api/Products/GetMediumTypes/'
    }).then(function successCallback(response) {

        $scope.mediaTypes = response.data;
        console.log($scope.mediaTypes);


    }, function errorCallback(response) {
        console.log(response.status);
    });

    $scope.changeMediaType = function (selectedMediaType, fileId) {

        $http({
            method: 'POST',
            url: '/api/Products/SetMediaType/' + selectedMediaType + '/' + fileId
        }).then(function successCallback(response) {

            //location.reload();

        }, function errorCallback(response) {



        });

    };

    $http({
        method: 'GET',
        url: '/api/Products/GetProductById/' + $routeParams.id
    }).then(function successCallback(response) {

        var published = "Nej";
        if (response.data.isPublished === true) {
            published = "Ja";
        }

        $scope.productObj = {
            'productId': response.data.productId,
            'productName': response.data.productName,
            'isPublished': published,
            'lastModified': response.data.lastModified,
            'lastModifiedBy': response.data.lastModifiedBy,
            'versioNumber': response.data.versioNumber,
            'Files': response.data.files
        };

        console.log($scope.productObj);

    }, function errorCallback(response) {



    });


    $scope.setMainImage = function (fileId) {
        $http({
            method: 'POST',
            url: '/api/Products/SetMainImage/' + fileId
        }).then(function successCallback(response) {

            location.reload();

        }, function errorCallback(response) {



        });
    };





});