
MainApp.controller("CustEditCtrl", function ($window, $scope, $location, $routeParams, $route, CustService) {
    var id = $routeParams.id;
    $scope.IsLoad = true;

    CustService.getCustomer(id).then(function (response) {
        $scope.Customer = response.data;
        $scope.IsLoad = false;
    }, function () {
        $scope.error = "取得資料錯誤!";
        $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
    })

    var changeLocation = function (url, forceReload) {
        $scope = $scope || angular.element(document).scope();
        if (forceReload || $scope.$$phase) {
            window.location = url;
        }
        else {
            //only use this if you want to replace the history stack
            //$location.path(url).replace();

            //this this if you want to change the URL and add it to the history stack
            $location.path(url);
            $scope.$apply();
        }
    };

    $scope.Update = function () {
        CustService.Update($scope.Customer).then(function (response) {

            $scope.IsLoad = false;
            alert("更新成功！");
            $window.location.href = '/Customer';
        }, function () {
            alert("更新失敗！");
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        });
    }
    

});