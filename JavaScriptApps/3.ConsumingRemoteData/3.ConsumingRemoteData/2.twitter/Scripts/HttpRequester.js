define(["QLib", "Jquery"], function (Q) {
    var HttpRequester;
    HttpRequester = (function () {
        function HttpRequester() {
        }

        var AjaxRequest = function (url, type, data) {
            var deferred = Q.defer();

            if (data) {
                data = JSON.stringify(data);
            }

            $.ajax({
                url: url,
                type: type,
                data: data,
                contentType: "application/json",
                success: function (responseData) {
                    deferred.resolve(responseData);
                },
                error: function (errorData) {
                    deferred.reject(errorData);
                }
            });

            return deferred.promise;
        }

        HttpRequester.prototype = {
            postJson: function (url , data) {
                return AjaxRequest(url, "POST", data);
            },
            getJson: function (url) {
                return AjaxRequest(url, "GET");
            }
        }

        return HttpRequester;
    }());
    return new HttpRequester();
});