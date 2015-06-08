define(['jquery'], function ($) {
    'use strict';
    // Create a module that exposes methods for performing HTTP requests by given URL and headers
    return {
        getJSON: function (url, success, headers) {
            // jQuery.ajax() returns a promise
            return $.ajax({
                url: url,
                headers: headers,
                dataType: "json",
                data: undefined,
                success: success
            });
        },
        postJSON: function (url, data, success, headers) {
            // jQuery.ajax() returns a promise
            return $.ajax({
                url: url,
                type: "post",
                headers: headers,
                dataType: "json",
                data: data,
                success: success
            });
        }
    }
});