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
            when("/attributeGroup", {
                templateUrl: "/Templates/AttributeGroup.html",
                controller: "attributeGroupCtrl"
            }).
            when("/attribute", {
                templateUrl: "/Templates/Attribute.html",
                controller: "attributeCtrl"
            }).
            when("/product", {
                templateUrl: "/Templates/Product.html",
                controller: "productCtrl"
            }).
            otherwise({
                redirectTo: "/home"
            });
    }
]);