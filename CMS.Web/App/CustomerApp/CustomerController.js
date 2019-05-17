
MainApp.controller('CustCtrl', function ($scope, $location, $routeParams, $route, CustService) {
    $scope.IsLoad = true;

    // 分頁參數
    $scope.totalRecords = 0;
    $scope.pageSize = 10; // 每頁筆數
    $scope.currentPage = 1; // 初始值，第一頁

    $scope.pageChanged = function () {
        //$scope.IsLoad = true;
        GetData();
    }
    var GetList = function () {
        CustService.getList().then(function (response) {
            $scope.Customers = response.data.Data;
            $scope.IsLoad = false;
        }, function ()
        {
            $scope.error = "取得資料錯誤!";
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        })
    }

    var GetData = function () {
        CustService.getData($scope.currentPage,$scope.pageSize).then(function (response) {
            $scope.totalRecords = response.data.Total;
            $scope.Customers = response.data.Data;
            $scope.IsLoad = false;
        }, function () {
                $scope.error = "取得資料錯誤!";
                $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
            })
    }

    var GetCustomer = function () {
        CustService.getCustomer($routeParams.id).then(function (response) {
            $scope.Customers = response.data;
            $scope.IsLoad = false;
        }, function () {
            $scope.error = "取得資料錯誤!";
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        })
    }

    $scope.Update = function (id) {
        $location.path('/Customer/Edit/' + id);
    }

    $scope.Delete = function (Cust) {
        CustService.DeleteCustomer(Cust.CustomerID).then(function () {
            alert("刪除成功！");
            $scope.currentPage = 1;
            GetData();
            $scope.IsLoad = false;
        }, function () {
            alert("刪除失敗！");
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        });
    }

    GetData();
});