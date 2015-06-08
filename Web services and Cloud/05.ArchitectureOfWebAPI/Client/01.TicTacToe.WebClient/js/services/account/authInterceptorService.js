app.factory('authInterceptorService', [
'$q', '$location', 'authorization', 'notifier',
function ($q, $location, authorization, notifier) {
    "use strict";

    return {
        request: function (config) {
            config.headers = config.headers || {};

            if (!config.headers.useAuth) {
                return config;
            }

            var authData = authorization.getAuthorizationHeader();
            if (authData) {
                config.headers.Authorization = authData.Authorization;
            }

            return config;
        },
        responseError: function (rejection) {
            if (rejection.status === 401) {
                $location.path('/');
                notifier.error('Redirecting to main page');
            } else if (rejection.status === 400) {
                notifier.error('Invalid !');
            }

            return $q.reject(rejection);
        }
    };
}]);