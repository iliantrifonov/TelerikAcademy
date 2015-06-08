var chatDb = require('./data/chat-db');

chatDb.registerUser({ user: 'DonchoMinkov', pass: '123456q' });
chatDb.registerUser({ user: 'NikolayKostov', pass: '123456q' });

chatDb.sendMessage({
    'from': 'DonchoMinkov',
    'to': 'NikolayKostov',
    'text': 'Hey, Niki!'
});

chatDb.sendMessage({
    'from': 'NikolayKostov',
    'to': 'DonchoMinkov',
    'text': 'Hey, Donchooo!'
});

chatDb.sendMessage({
    'from': 'DonchoMinkov',
    'to': 'NikolayKostov',
    'text': 'Te sa zeleni !'
});

chatDb.getMessages({
    with: 'DonchoMinkov',
    and: 'NikolayKostov',
}, function (err, data) { 
    if (err) {
        console.log(err);
    }
    for (i = 0; i < data.length; i++) {
        console.log('From: ' + data[i].from + ', To: ' + data[i].to);
        console.log(data[i].text);
    }
});