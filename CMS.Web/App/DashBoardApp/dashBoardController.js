MainApp.controller("DashBoardCtrl", function ($window,$scope, $location, $route, DashBoardService) {
    $scope.IsLoad = true;

    DashBoardService.getData().then(function (response) {
        $scope.Datas = response.data;
        $scope.IsLoad = false;
    }, function () {
        $scope.error = "取得資料錯誤！";
        $scope.IsLoad = false;
    });

    //訊息
    $scope.Messages = [];

    //建立連線
    var hub = $window.jQuery.hubConnection();
    //SignalR Hub 名稱
    var proxy = hub.createHubProxy('ChatHub');
    //SignalR 回傳function
    proxy.on('addMessageToPage', function (Name, Message, Time) {
        $scope.Messages.push({ Name: Name, Message: Message, Time: Time });
        // 重要，如果不加這段AngularJS的Model無法更新
        $scope.$apply();
    })

    // 發送訊息至Server Hub
    hub.start().done(function () {
        proxy.invoke('cust');
    });

    $scope.SendMessage = function () {
        proxy.invoke('send','Erric',$scope.Msg);
    };
});