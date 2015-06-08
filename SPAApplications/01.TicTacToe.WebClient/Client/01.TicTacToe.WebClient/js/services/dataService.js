app.factory('dataService', [
'$resource', 'baseServiceUrl', '$http', '$q',
function ($resource, baseServiceUrl, $http, $q) {
    "use strict";
    var headers = { useAuth: true };

    //var ServiceResource = $resource(baseServiceUrl + '/api/service/:id', null, {
    //    'public': { method: 'GET', isArray: true },
    //    'byId': { method: 'GET', params: { id: '@id' }, isArray: false, headers: headers }
    //});
    //var GamesResourse = $resource(baseServiceUrl + '/api/games/create', null, {
    //    'createGame': { method: 'POST', isArray: true, headers: headers }
    //});
    var ScoresResource = $resource(baseServiceUrl + '/api/score/GetTopScores', null, {
        'getScores': { method: 'GET', isArray: true }
    });

    var createGame = function () {
        var deferred = $q.defer();

        $http({ url: baseServiceUrl + '/api/games/create', headers: headers, method: 'POST' })
            .success(function (data) {
                deferred.resolve(data);
            }, function (response) {
                deferred.reject(response);
            });

        return deferred.promise;
    };

    var joinGame = function () {
        var deferred = $q.defer();

        $http({ url: baseServiceUrl + '/api/games/join', headers: headers, method: 'POST', })
            .success(function (data) {
                deferred.resolve(data);
            }, function (response) {
                deferred.reject(response);
            });

        return deferred.promise;
    };

    var getStatus = function (id) {
        var deferred = $q.defer();

        $http({ url: baseServiceUrl + '/api/games/Status?gameId=' + id, headers: headers, method: 'GET', })
            .success(function (data) {
                deferred.resolve(data);
            }, function (response) {
                deferred.reject(response);
            });

        return deferred.promise;
    };

    var play = function (toSend) {
        var deferred = $q.defer();

        $http({ url: baseServiceUrl + '/api/games/play', headers: headers, method: 'POST', data: toSend })
            .success(function (data) {
                deferred.resolve(data);
            }, function (response) {
                deferred.reject(response);
            });

        return deferred.promise;
    };

    return {
        //public: function () {
        //    return ServiceResource.public();
        //},
        //byId: function (id) {
        //    return ServiceResource.byId({ id: id });
        //},
        getScores: function () {
            return ScoresResource.getScores();
        },
        getGameState: getStatus,
        createGame: createGame,
        joinGame: joinGame,
        play: play,
    };
}]);