(function () {
    requirejs.config({
        paths: {
            QLib: './Libs/q',
            Jquery: './Libs/jquery-2.1.1.min',
            HttpRequester: './HttpRequester',
            GetTweets: './GetTweets',
            mustache: './Libs/mustache'
        }
    });

    require(["GetTweets", "mustache"], function (GetTweets, Mustache) {
        $('#getTweets').on("click", function () {
            var name = $("#username").val();
            var count = $("#count-of-tweets").val();
            GetTweets.getTweets(name, count)
            .then(function (data) {
                var data = JSON.parse(data);
                var template = '<div class="tweet"><div>Created At: {{created_at}}</div><div>Content: {{text}}</div></div>';
                var divWithTweets = $("<div>");
                for (var i = 0; i < data.length; i++) {
                    divWithTweets.append(Mustache.render(template, data[i]));
                }
                $('#tweets').text("").append(divWithTweets);
            })
        });
    });
}());