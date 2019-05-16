
MainApp.controller("CustEditCtrl", function ($scope, $location, $routeParams, $route, CustService) {
    var id = $routeParams.id;
    $scope.IsLoad = true;

    CustService.getCustomer(id).then(function (response) {
        $scope.Customer = response.data;
        $scope.IsLoad = false;
    }, function () {
        $scope.error = "取得資料錯誤!";
        $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
    })

    $scope.Update = function () {
        CustService.Update($scope.Customer).then(function (response) {
            alert("更新成功！");
            $scope.IsLoad = false;
        }, function () {
            alert("更新失敗！");
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        });
    }
    

});