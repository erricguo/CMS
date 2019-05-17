

MainApp.factory('CustService', function ($http, $q) {
    return {
        getList: function () {
            var deferred = $q.defer();
            $http.get('/api/Customer')
                .then(deferred.resolve)
                .catch(deferred.reject);
            return deferred.promise
        },
        getData: function (currentPage,pageSize) {
            var deferred = $q.defer();
            $http.get('/api/Customer', { params: { CurrPage: currentPage, PageSize: pageSize }})
                .then(deferred.resolve)
                .catch(deferred.reject);
            return deferred.promise
        },
        getCustomer: function (customerID) {
            var deferred = $q.defer();
            $http.get('/api/Customer', { params: { CustomerID: customerID } })
                .then(deferred.resolve)
                .catch(deferred.reject);
            return deferred.promise
        },
        AddData: function (Customer) {
            var deferred = $q.defer();
            $http.post('/api/Customer', Customer)
                .then(deferred.resolve)
                .catch(deferred.reject);
            return deferred.promise
        },
        Update: function (Customer) {
            var deferred = $q.defer();
            $http.put('/api/Customer', Customer)
                .then(deferred.resolve)
                .catch(deferred.reject);
            return deferred.promise
        },
        DeleteCustomer: function (customerID) {
            var deferred = $q.defer();
            $http.delete('/api/Customer', { params: { CustomerID: customerID } })
                .then(deferred.resolve)
                .catch(deferred.reject);
            return deferred.promise
        }

    }
});