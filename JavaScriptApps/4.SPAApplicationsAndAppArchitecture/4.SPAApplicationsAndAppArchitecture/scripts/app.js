/// <reference path="jquery-2.1.1.js" />
/// <reference path="require.js" />
/// <reference path="bower_components/sammy/lib/sammy.js" />
/// <reference path="mustache.js-master/mustache.js" />
/// <reference path="bower_components/sammy/lib/plugins/sammy.mustache.js" />
(function () {
    requirejs.config({
        paths: {
            jquery: 'jquery-2.1.1',
            sammy: 'bower_components/sammy/lib/sammy',
            mustache: 'mustache.js-master/mustache',
            m:'bower_components/sammy/lib/plugins/sammy.mustache',
        }
    });
    
    require(['jquery', 'sammy', 'mustache', 'm'], function ($, S, M) {
        var app = S('.chat-posts', function () {
            // include a plugin
            this.use('Mustache');
            var that = this;
            // define a 'route'
            this.get('#/', function () {
                var that = this;
                console.log(that);
                $.getJSON('http://crowd-chat.herokuapp.com/posts', function (data) {
                    var template = $('#m').html();
                    for (var i = 0; i < data.length; i++) {
                        var rendered = that.mustache(template, data[i]);
                        $('#container .chat-posts').append(rendered);
                    }
                });
            });

            $('#container .post').on('click', function () {
                $.post('http://crowd-chat.herokuapp.com/posts', {
                    user: $('#container .name').val(),
                    text: $('#container .input').val().trim()
                });
                $('#container .input').val('');

                that.refresh();
            });

        });

        // start the application
        app.run('#/');
    });
})();