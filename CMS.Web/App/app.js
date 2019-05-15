var MainApp = angular.module('MainApp', ['ngRoute']);
                                    
MainApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    var viewbase = '/App/';
    $routeProvider
        .when('/Customer', {
            controller: 'CustCtrl',
            templateUrl: viewbase + 'CustomerApp/List.html'
        })
        /*.when('/Customer/Add', {
            controller: 'CustAddCtrl',
            templateUrl: viewbase + 'CustomerApp/AddCustomer.html'
        })
        .when('/CustCtrl/Edit/:id', {
            controller: 'CustEditCtrl',
            templateUrl: viewbase + 'CustomerApp/EditCustomer.html'
        })*/

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);