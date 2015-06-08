/*global document*/
/*global window*/
/*global Event*/
/*global navigator*/

(function () {
    "use strict";
    var applicationName = navigator.appName,
        addScroll = false,
        theLayer,
        positionX = 0,
        positionY = 0;
    if ((navigator.userAgent.indexOf('MSIE 5') > 0)
            || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    document.onmousemove = mouseMove;

    if (applicationName === 'Netscape') {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function popTip() {
        if (applicationName === 'Netscape') {
            theLayer = 'document.layers[\'ToolTip\']';

            if ((positionX + 120) > window.innerWidth) {
                positionX = window.innerWidth - 150;
            }

            theLayer.left = positionX + 10;
            theLayer.top = positionY + 15;
            theLayer.visibility = 'show';
        } else {
            theLayer = 'document.all[\'ToolTip\']';

            if (theLayer) {
                positionX = event.x - 5;
                positionY = event.y;
                if (addScroll) {
                    positionX = positionX + document.body.scrollLeft;
                    positionY = positionY + document.body.scrollTop;
                }
                if ((positionX + 120) > document.body.clientWidth) {
                    positionX = positionX - 150;
                }
                theLayer.style.pixelLeft = positionX + 10;
                theLayer.style.pixelTop = positionY + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function mouseMove(applicationEvent) {
        if (applicationName === 'Netscape') {
            positionX = applicationEvent.pageX - 5;
            positionY = applicationEvent.pageY;
        } else {
            positionX = event.x - 5;
            positionY = event.y;
        }

        if (applicationName === 'Netscape') {
            if (document.layer.ToolTip.visibility === 'show') {
                popTip();
            }
        } else {
            if (document.all.ToolTip.style.visibility === 'visible') {
                popTip();
            }
        }
    }

    function hideTip() {
        if (applicationName === 'Netscape') {
            document.layers.ToolTip.visibility = 'hide';
        } else {
            document.all.ToolTip.style.visibility = 'hidden';
        }
    }

    function hideMenuOne() {
        if (applicationName === 'Netscape') {
            document.layers.menu1.visibility = 'hide';
        } else {
            document.all.menu1.style.visibility = 'hidden';
        }
    }

    function showMenuOne() {
        if (applicationName === 'Netscape') {
            theLayer = 'document.layers[\'menu1\']';
            theLayer.visibility = 'show';
        } else {
            theLayer = 'document.all[\'menu1\']';
            theLayer.style.visibility = 'visible';
        }
    }

    function hideMenuTwo() {
        if (applicationName === 'Netscape') {
            document.layers.menu2.visibility = 'hide';
        } else {
            document.all.menu2.style.visibility = 'hidden';
        }
    }

    function showMenuTwo() {
        if (applicationName === 'Netscape') {
            theLayer = 'document.layers[\'menu2\']';
            theLayer.visibility = 'show';
        } else {
            theLayer = 'document.all[\'menu2\']';
            theLayer.style.visibility = 'visible';
        }
    }
})();