var app = angular.module('app', ['ngRoute']).run(function () {
    console.log('Angular is running!');
});


// App Config
app.config(["$routeProvider",
    function ($routeProvider) {

        // Routing
        $routeProvider.
            when("/catalog", {
                templateUrl: "/Templates/Catalog.html"
            }).
            otherwise({
                redirectTo: "/home"
            });
    }
]);