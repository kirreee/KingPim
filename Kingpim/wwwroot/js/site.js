var app = angular.module('app', ['ngRoute']).run(function () {
    console.log('Angular is running!');
});


// App Config
app.config(["$routeProvider",
    function ($routeProvider) {

        // Routing
        $routeProvider.
            when("/catalog", {
                templateUrl: "/Templates/Catalog.html",
                controller:"catalogCtrl"
            }).
            when("/category", {
                templateUrl: "/Templates/Category.html",
                controller: "categoryCtrl"
            }).
            when("/subcategory", {
                templateUrl: "/Templates/Subcategory.html",
                controller: "subcategoryCtrl"
            }).
            otherwise({
                redirectTo: "/home"
            });
    }
]);