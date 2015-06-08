(function () {

    var container = document.getElementById('container');

    var btn = document.getElementById('create-task');
    btn.addEventListener('click', function () {
        var task = getTask(document.getElementById('text').value);
        container.appendChild(task);
    });

    var showHide = document.getElementById('change-state');
    showHide.addEventListener('click', function () {
        if (showHide.innerHTML === 'Hide') {
            showHide.innerHTML = 'Show';
            container.style.opacity = 0;
        } else {
            showHide.innerHTML = 'Hide';
            container.style.opacity = 1;
        }
    });

    function getTask(text) {
        var div = document.createElement('div');
        div.innerHTML = text;

        var btn = document.createElement('button');
        btn.innerHTML = 'Remove task';
        btn.addEventListener('click', function () {
            div.parentNode.removeChild(div);
        });

        div.appendChild(btn);

        return div;
    }
})();