(function(){
  'use strict';

  angular.module('users')
         .service('userService', ['$http', '$q', UserService]);

  /**
   * Users DataService
   * Uses embedded, hard-coded data model; acts asynchronously to simulate
   * remote data service call(s).
   *
   * @returns {{loadAll: Function}}
   * @constructor
   */
  function UserService($http, $q){
   
    return {
        loadAllUsers: function () {
            var deferred = $q.defer();

            $http.get('api/User')
                .success(function(data) {
                    deferred.resolve(data);
                });

            return deferred.promise;
      }
    };
  }

})();
