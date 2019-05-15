MainApp.factory('CustService', function ($http , $q) {
    return {
        getList: function () {
            var deferred = $q.defer();
            $http.get('/api/Customer')
                .then(deferred.resolve)
                .catch(deferred.reject);
            return deferred.promise
        }
    }
});