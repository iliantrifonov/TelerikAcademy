app.factory('dataService', [
'$resource', 'baseServiceUrl',
function ($resource, baseServiceUrl) {
    "use strict";
    var headers = {};
    headers.useAuth = true;

    var ServiceResource = $resource(baseServiceUrl + '/api/service/:id', null, {
        'public': { method: 'GET', isArray: true },
        'byId': { method: 'GET', params: { id: '@id' }, isArray: false, headers: headers }
    });

    return {
        public: function () {
            return ServiceResource.public();
        },
        byId: function (id) {
            return ServiceResource.byId({ id: id });
        },
    };
}]);