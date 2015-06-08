define(["HttpRequester"], function (HttpRequester) {
    var url = 'http://localhost:3000/tweets';
    function getTweets(username, count) {
        var countOfTweets;
        if (!isFinite(count)) {
            countOfTweets = 10;
        } else {
            countOfTweets = parseInt(count);
        }
        var data =
            {
                consumerKey: "",
                consumerSecret: "",
                accessToken: "",
                accessTokenSecret: "",
                username: username,
                count: countOfTweets
            };

        return HttpRequester.postJson(url, data);
    }

    return {
        getTweets: getTweets
    }
});