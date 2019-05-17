
MainApp.controller("CustAddCtrl", function ($window, $scope, $location, CustService) {
    $scope.IsLoad = true;

    $scope.Add = function () {
        var Customer = {
            CustomerID : $scope.CustomerID,
            CompanyName : $scope.CompanyName,
            ContactName : $scope.ContactName
        }
        CustService.AddData(Customer).then(function () {
            $scope.IsLoad = false;
            alert("新增成功！");
            $window.location.href = '/Customer';
        }, function () {
            alert("新增失敗！");
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        });
    }


});