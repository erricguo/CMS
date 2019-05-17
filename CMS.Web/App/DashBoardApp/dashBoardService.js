MainApp.factory("DashBoardService", function ($http, $q) {
    return {
        getData: function () {
            var deferred = $q.defer()
            $http.get('api/DashBoard')
                .then(deferred.resolve)
                .catch(deferred.reject);
            return deferred.promise;
        }
    }
});