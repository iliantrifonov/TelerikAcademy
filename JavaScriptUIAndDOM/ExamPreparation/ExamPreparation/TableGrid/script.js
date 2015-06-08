function createTableGrid(selector, items) {
    var ROWS_OF_ITEMS = items.length - 1;
    var HEADER_ARR = items[0];

    var ARR_OF_PROPERTIES = ['title', 'date', 'hour', 'duration'];

    var prevElement;

    var container = document.querySelectorAll(selector)[0];

    container.addEventListener('click', function (ev) {
        var element;

        if (ev.target.tagName === 'TD' || ev.target.tagName === 'TH') {

            if (prevElement) {
                prevElement.classList.remove('selected');
                prevElement.style.backgroundColor = '';
            }

            element = ev.target;
            element.style.backgroundColor = 'lightblue';
            element.classList.add('selected');
            prevElement = element;
        }
    });

    container.addEventListener('mouseout', function (ev) {
        var element;

        if (ev.target.tagName === 'TD' || ev.target.tagName === 'TH') {
            element = ev.target;
            if (!element.classList.contains('selected')) {
                element.style.backgroundColor = '';
            }
        }
    });

    container.addEventListener('mouseover', function (ev) {
        var element;

        if (ev.target.tagName === 'TD' || ev.target.tagName === 'TH') {
            element = ev.target;
            if (!element.classList.contains('selected')) {
                element.style.backgroundColor = 'yellowgreen';
            }
        }
    });

    var table = document.createElement('table');
    var tableHeader = document.createElement('thead');
    var tableBody = document.createElement('tbody');
    var tr = document.createElement('tr');
    var td = document.createElement('td');
    var th = document.createElement('th');

    applyAttributesToTable();
    applyAttributesToTD();
    applyAttributesToTH();
    applyAttributesToTR();
    applyAttributesToTHEAD();
    applyAttributesToTBODY();

    //thead
    var headRows = 1;
    for (var i = 0; i < headRows; i++) {
        var tRow = tr.cloneNode(true);
       
        for (var k = 0; k < ARR_OF_PROPERTIES.length; k++) {
    
            var tHeadData = th.cloneNode(true);
            tHeadData.innerHTML = HEADER_ARR[ARR_OF_PROPERTIES[k]];
            tRow.appendChild(tHeadData.cloneNode(true));
        }

        tableHeader.appendChild(tRow.cloneNode(true));
    }

    //tbody
    for (var i = 0; i < ROWS_OF_ITEMS; i++) {
        var tRow = tr.cloneNode(true);

        for (var k = 0; k < ARR_OF_PROPERTIES.length; k++) {
            var tData = td.cloneNode(true);
            tData.innerHTML = items[i + 1][ARR_OF_PROPERTIES[k]];
            tRow.appendChild(tData.cloneNode(true));
        }
        
        tableBody.appendChild(tRow.cloneNode(true));
    }

    table.appendChild(tableHeader.cloneNode(true));
    table.appendChild(tableBody.cloneNode(true));

    container.appendChild(table.cloneNode(true));

    function applyAttributesToTable() {
        table.style.borderCollapse = 'collapse';
        table.style.border = '1px solid black';
        table.style.padding = '0';
    }

    function applyAttributesToTD() {
        td.style.border = '1px solid black';
        td.style.margin = '0';
    }

    function applyAttributesToTH() {
        th.style.border = '1px solid black';
        th.style.margin = '0';
    }

    function applyAttributesToTR() {
        tr.style.margin = '0';
        tr.style.padding = '0';
    }

    function applyAttributesToTHEAD() {
        tableHeader.style.padding = '0';
        tableHeader.style.margin = '0';
    }

    function applyAttributesToTBODY() {
        tableHeader.style.padding = '0';
        tableBody.style.margin = '0';
    }
}