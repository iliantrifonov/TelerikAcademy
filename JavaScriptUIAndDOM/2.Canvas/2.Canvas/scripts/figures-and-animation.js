/// <reference path='canvas-vsdoc.js' />
function drawHead() {
	var canvas = Canvas.vsGet(document.getElementById("canvas"));
	var ctx = canvas.getContext('2d');

    // draw head
	ctx.beginPath();
	ctx.arc(90, 90, 50, 0, 2 * Math.PI);
	ctx.fillStyle = 'lightblue';
	ctx.strokeStyle = 'magenta';
	ctx.fill();
	ctx.stroke();
	ctx.save();

	ctx.beginPath();

	ctx.rotate(15 * Math.PI / 180);
	ctx.scale(1, 0.3);
	ctx.arc(100, 310, 20, 0, 2 * Math.PI);
	ctx.stroke();
	ctx.restore();
	ctx.save();

    // draw nose
	ctx.beginPath();
	ctx.moveTo(80, 99);
	ctx.lineTo(70, 99);
	ctx.lineTo(80, 79);
	ctx.stroke();

    // draw eyes
	ctx.beginPath();
	ctx.scale(1, 0.5);
	var x = 95;
	var y = 160;
	var r = 7;
	ctx.arc(x, y, r, 0, 2 * Math.PI);
	ctx.stroke();
	ctx.restore();
	ctx.save();

	ctx.beginPath();
	ctx.scale(0.5, 1);
	ctx.arc(x + 90, y - 80, r - 3, 0, 2 * Math.PI);
	ctx.fillStyle = 'magenta';
	ctx.fill();
	ctx.restore();
	ctx.save();

	ctx.beginPath();
	ctx.scale(1, 0.5);
	x = 60;
	y = 160;
	r = 7;
	ctx.arc(x, y, r, 0, 2 * Math.PI);
	ctx.stroke();
	ctx.restore();
	ctx.save();

	ctx.beginPath();
	ctx.scale(0.5, 1);
	ctx.arc(x + 55, y - 80, r - 3, 0, 2 * Math.PI);
	ctx.fillStyle = 'magenta';
	ctx.fill();
	ctx.restore();
	ctx.save();

    // draw the bottom of the hat
	ctx.restore();
	ctx.lineWidth = 3;
	ctx.strokeStyle = "black";
	ctx.save();
	ctx.fillStyle = "blue";
	ctx.strokeStyle = "black";
	ctx.beginPath();
	ctx.scale(0.6, 0.1);
	ctx.arc(160, 500, 100, 0, 2 * Math.PI);
	ctx.fill();
	ctx.stroke();

    // draw the top of the hat
	ctx.restore();
	ctx.lineWidth = 2;
	ctx.save();
	ctx.fillStyle = "blue";
	ctx.beginPath();
	ctx.scale(0.6, 0.15);
	ctx.arc(160, 50, 50, 0, 2 * Math.PI);
	ctx.fill();
	ctx.stroke();

	ctx.lineTo(210, 50);
	ctx.arc(160, 280, 50, 0, Math.PI);
	ctx.lineTo(110, 40);
	ctx.fill();
	ctx.stroke();
}

function drawBike() {
    var canvas = Canvas.vsGet(document.getElementById("canvas2"));
    var ctx = canvas.getContext('2d');

    // wheel left
    ctx.restore();
    ctx.beginPath();
    ctx.arc(90, 90, 20, 0, 2 * Math.PI);
    ctx.fillStyle = 'lightblue';
    ctx.strokeStyle = 'magenta';
    ctx.fill();
    ctx.stroke();
    ctx.save();

    // wheel right
    ctx.restore();
    ctx.beginPath();
    ctx.arc(190, 90, 20, 0, 2 * Math.PI);
    ctx.fillStyle = 'lightblue';
    ctx.strokeStyle = 'magenta';
    ctx.fill();
    ctx.stroke();
    ctx.save();

    // frame
    ctx.restore();
    ctx.beginPath();
    ctx.moveTo(190, 90);
    ctx.lineTo(180, 60);
    ctx.lineTo(120, 60);
    ctx.lineTo(90, 90);
    ctx.lineTo(135, 90);
    ctx.lineTo(110, 40);
    ctx.lineTo(120, 40);
    ctx.lineTo(100, 40);
    ctx.stroke();
    
    ctx.beginPath();
    ctx.moveTo(135, 90);
    ctx.lineTo(180, 60);
    ctx.lineTo(175, 45);
    ctx.lineTo(190, 30);
    ctx.stroke();

    ctx.beginPath();
    ctx.moveTo(175, 45);
    ctx.lineTo(150, 50);
    ctx.stroke();


    // pedals
    ctx.beginPath();
    ctx.arc(135, 90, 6, 0, 2 * Math.PI);
    ctx.stroke();

    ctx.beginPath();
    ctx.moveTo(135, 96);
    ctx.lineTo(135, 102);
    ctx.stroke();

    ctx.beginPath();
    ctx.moveTo(135, 84);
    ctx.lineTo(135, 78);
    ctx.stroke();
}

function drawHouse() {
    var canvas = Canvas.vsGet(document.getElementById("canvas3"));
    var ctx = canvas.getContext('2d');

    // main house
    ctx.strokeStyle = "black";
    ctx.fillStyle = "pink";
    ctx.fillRect(100, 100, 90, 80);
    ctx.strokeRect(100, 100, 90, 80);

    // windows
    ctx.fillStyle = "black";
    drawWindowAtPos(105, 115);
    drawWindowAtPos(150, 115);
    drawWindowAtPos(150, 150);

    // door
    ctx.strokeRect(110, 150, 20, 30);
    ctx.beginPath();
    ctx.moveTo(120, 180);
    ctx.lineTo(120, 150);
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(115, 170, 2, 0, 2 * Math.PI);
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(125, 170, 2, 0, 2 * Math.PI);
    ctx.stroke();

    // roof
    ctx.beginPath();
    ctx.fillStyle = "pink";
    ctx.moveTo(100, 100);
    ctx.lineTo(145, 40);
    ctx.lineTo(190, 100);
    ctx.fill();
    ctx.stroke();

    // chimney
    ctx.fillRect(165, 55, 10, 30);

    ctx.beginPath();
    ctx.moveTo(165, 55 + 30);
    ctx.lineTo(165, 55);
    ctx.lineTo(165 + 10, 55);
    ctx.lineTo(165 + 10, 55 + 30);
    ctx.stroke();

    function drawWindowAtPos(x, y) {
        ctx.fillRect(x, y, 15, 10);
        ctx.fillRect(x + 17, y, 15, 10);
        ctx.fillRect(x, y + 12, 15, 10);
        ctx.fillRect(x + 17, y + 12, 15, 10);
    }
}

function drawBounce() {
    var canvas = Canvas.vsGet(document.getElementById("canvas4"));
    var ctx = canvas.getContext('2d');
    var x = 30;
    var y = 0;
    var verticalMovement = 1;
    var horisontalMovement = 1;

    ctx.fillStyle = "red";
    startBouncing();

    function startBouncing() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.strokeRect(0, 0, canvas.width, canvas.height);
        ctx.fillRect(x, y, 15, 15);

        if (x > canvas.width - 15 || x < 0) {
            horisontalMovement *= -1;
            ctx.fillStyle = "blue";
        }

        if (y > canvas.height - 15 || y < 0) {
            verticalMovement *= -1;
            ctx.fillStyle = "red";
        }

        x += horisontalMovement;
        y += verticalMovement;
        window.requestAnimationFrame(startBouncing);
    }
}

drawBounce();
drawHouse();
drawHead();
drawBike();