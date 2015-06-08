var http = require('http'),
    formidable = require('formidable'),
    fs = require('fs'),
    storedFile,
    originalFileName,
    port = 1234;

var server = http.createServer(function (req, res) {
    
    switch (req.url) { 
        case '/favicon.ico':
            res.writeHead(200, { 'Content-Type': 'image/x-icon' });
            res.end();
            break;      
        case '/upload':
            uploadFile(req, res);
            break;
        case '/download':
            downloadFile(req, res);
            break;
        case '/':
            displayForm(req, res);
            break;
        default:
            notFound(req, res);
            break;
    }
});

server.listen(port);
console.log('Server running on ' + port);

function notFound(req, res) {
    res.writeHead(404, { 'message': 'Not found' });
}

function displayForm(req, res) {
    res.write(getUploadForm());
    res.end;
}

function uploadFile(req, res) {
    var form = new formidable.IncomingForm();
    form.uploadDir = './uploads/';
    form.encoding = 'utf-8';
    form.keepExtensions = true;
    res.writeHead(200, { 'content-type': 'text/html' });
    
    form.parse(req, function (err, fields, files) {
    });
    
    form.on('progress', function (bytesReceived, bytesExpected) {
        var progress = (bytesReceived / bytesExpected) * 100;
        res.write(parseInt(progress) + ' % <br />');
        if (progress === 100) {
            res.write('<h2>Successfull upload.</h2>');
            res.write('<a href="/download">Download</a>');
            storedFile = this.openedFiles[0].path;
            originalFileName = this.openedFiles[0].name;
            res.end();
        }
    });
}

function downloadFile(req, res) {
    var stat = fs.statSync(storedFile);
    res.writeHead(200, {
        'Content-Length': stat.size,
    });
    
    var readStream = fs.createReadStream(storedFile);
    readStream.pipe(res);
}

function getUploadForm() {
    return '<div><form action="/upload" method="post" enctype="multipart/form-data"><input type="file" size=80 name="pic" ><input type="submit" value="Upload"></form></div>';
}