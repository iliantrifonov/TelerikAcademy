function createCalendar(selector, events) {
    var DAYS_ARR = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
        NUMBER_OF_DAYS_IN_MONTH = 30,
        MONTH_YEAR_STRING = 'June 2014';

    var calendarContainer = document.querySelectorAll(selector);
    var dayContainer = document.createElement('div');
    var dayTitleContainer = document.createElement('h4');
    var dayEventContainer = document.createElement('div');
    var oldTitle;

    calendarContainer[0].addEventListener('click', function (ev) {
        var title;
        if (ev.target.classList.contains('title')) {
            title = ev.target;
        } else if (ev.target.classList.contains('day')) {
            title = ev.target.querySelector('.title');
        } else if (ev.target.parentElement.classList.contains('day')) {
            title = ev.target.parentElement.querySelector('.title');
        }

        if (title) {
            if (oldTitle) {
                oldTitle.style.backgroundColor = 'grey';
                oldTitle.classList.remove('current');
            }
            title.style.backgroundColor = 'white';
            title.classList.add('current');
            oldTitle = title;
        }
    });

    calendarContainer[0].addEventListener('mouseover', function (ev) {
        var title;
        if (ev.target.classList.contains('title')) {
            title = ev.target;
        } else if (ev.target.classList.contains('day')) {
            title = ev.target.querySelector('.title');
        } else if (ev.target.parentElement.classList.contains('day')) {
            title = ev.target.parentElement.querySelector('.title');
        }

        if (title) {
            if (!title.classList.contains('current')) {
                title.style.backgroundColor = 'red';
            }
        }
    });

    calendarContainer[0].addEventListener('mouseout', function (ev) {
        var title;
        if (ev.target.classList.contains('title')) {
            title = ev.target;
        } else if (ev.target.classList.contains('day')) {
            title = ev.target.querySelector('.title');
        } else if (ev.target.parentElement.classList.contains('day')) {
            title = ev.target.parentElement.querySelector('.title');
        }

        if (title) {
            if (!title.classList.contains('current')) {
                title.style.backgroundColor = 'grey';
            }
        }
    });


    calendarContainer[0].style.width = '950px';

    dayTitleContainer.style.margin = '0';
    dayTitleContainer.style.padding = '0';
    dayTitleContainer.classList.add('title');
    dayTitleContainer.style.borderBottom = '1px solid black';
    dayTitleContainer.style.backgroundColor = 'grey';

    dayContainer.style.width = '130px';
    dayContainer.style.height = '120px';
    dayContainer.style.border = '1px solid black';
    dayContainer.style.display = 'inline-block';
    dayContainer.classList.add('day');

    dayEventContainer.style.float = 'left';

    var eventsArr = [];
    for (var i = 0; i < events.length; i++) {
        eventsArr[events[i].date] = {
            title: events[i].title,
            date: events[i].date,
            hour: events[i].hour,
            duration: events[i].duration
        };
    }

    var fragment = document.createDocumentFragment();

    for (var i = 0; i < NUMBER_OF_DAYS_IN_MONTH; i++) {
        var day = dayContainer.cloneNode(true);
        var title = dayTitleContainer.cloneNode(true);
        var ev = dayEventContainer.cloneNode(true);
        if (eventsArr[i + 1]) {
            ev.innerHTML = eventsArr[i + 1].hour + ' ' + eventsArr[i + 1].title;
        }

        title.innerHTML = DAYS_ARR[i % 7] + ' ' + (i + 1) + ' ' + MONTH_YEAR_STRING;

        day.appendChild(title);
        day.appendChild(ev);
        fragment.appendChild(day);
    }

    calendarContainer[0].appendChild(fragment);
}