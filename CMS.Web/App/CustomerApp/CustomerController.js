MainApp.controller('CustCtrl', function ($scope, $location, $route, CustService) {
    $scope.IsLoad = true;

    var GetData = function () {
        CustService.getList().then(function (response) {
            $scope.Customers = response.data;
            $scope.IsLoad = false;
        }, function ()
        {
            $scope.error = "取得資料錯誤!";
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        })
    }

    GetData();
});