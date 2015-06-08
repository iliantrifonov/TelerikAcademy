var mongoose = require('mongoose');
var port = 27017;

mongoose.connect('mongodb://localhost:' + port + '/chat');

var userSchema = new mongoose.Schema({
    user: String,
    pass: String
});

var User = mongoose.model('User', userSchema);

var messageSchema = new mongoose.Schema({
    from: String,
    to: String,
    text: String
});

var Message = mongoose.model('Message', messageSchema);

function saveUser(user) {
    var toSave = new User(user);
    toSave.save(function (err) {
        if (err) {
            throw err
        } else {
            console.log("User saved: " + user);
        }
    });
};

function sendMessage(message) {
    
    if (!User.findOne({ user: message.to }) || !User.findOne({ user: message.from })) {
        
        console.log('Message not saved, invalid user!');
        return;
    }
    
    var toSave = new Message(message);
    toSave.save(function (err) {
        if (err) {
            console.log('Error saving message' + err);
            throw err;
        } else {
            console.log("Message saved: " + message);
        }
    });
};

function getMessages(searchObject, callback) {
    var userOne = searchObject.with;
    var userTwo = searchObject.and;
    
    if (!User.findOne({ user: userOne }) || !User.findOne({ user: userTwo })) {
        
        console.log('Invalid user!');
        return;
    }
    
    Message.find()
        .or([
        { to: userOne, from: userTwo }, 
        { to: userTwo, from: userOne }])
        .exec(callback);
};

module.exports = {
    registerUser: saveUser,
    sendMessage: sendMessage,
    getMessages: getMessages
};
