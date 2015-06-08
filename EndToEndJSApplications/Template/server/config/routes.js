var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/profile', auth.isAuthenticated, controllers.users.getProfile);
    app.get('/profile/update', auth.isAuthenticated, controllers.users.getUpdateUser);
    app.post('/profile/update', auth.isAuthenticated, controllers.users.updateUser);
    //app.post('/profile/update', auth.isAuthenticated, auth.isInRole('random'), controllers.users.updateUser);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.logout);

    app.get('/admin/users', auth.isAuthenticated, auth.isInRole('admin'), controllers.admin.getUsers);

    app.get('/', function(req, res) {
        res.render('index');
    });

    app.get('/error', controllers.error.getErrorPage);

    app.get('*', function(req, res) {
        res.render('index');
    });
};