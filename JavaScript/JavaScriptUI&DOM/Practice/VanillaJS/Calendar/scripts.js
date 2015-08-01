function createCalendar(selector, events) {
    var container = document.querySelector(selector),
        fragment = document.createDocumentFragment(),
        width = window.getComputedStyle(container).width,
        width = (width.slice(0, width.length - 2) / 7) - 8,
        height = width,
        currentDay = -1;

    var weekDays = {
        0: 'Sun',
        1: 'Mon',
        2: 'Tue',
        3: 'Wed',
        4: 'Thu',
        5: 'Fri',
        6: 'Sat'
    };

    function getWeekDay() {
        if (currentDay === 6) {
            currentDay = 0;
        }
        else {
            currentDay++;
        }
        return weekDays[currentDay];
    }

    for (var i = 0; i < 30; i+=1) {
            fragment.appendChild(dayBoxCreate(i + 1, getWeekDay()));
    }

    container.appendChild(fragment);

    var days = document.querySelectorAll('.day-box');
    for (var j = 0, len = days.length; j < len; j+=1) {
        var currentDayBox = days[j],
            currentDateInBox = currentDayBox.querySelector('strong .date-of-june');

        currentDayBox.addEventListener('mouseover', function () {
            this.firstElementChild.style.backgroundColor = 'grey';
        });

        currentDayBox.addEventListener('mouseout', function () {
            this.firstElementChild.style.backgroundColor = 'lightgrey';
        });

        currentDayBox.addEventListener('click', function () {
            this.firstElementChild.style.backgroundColor = 'white';
        });

        for (var i = 0, leni = events.length; i < leni; i++) {
            var currentEvent = events[i];

            if (currentDateInBox.innerHTML === currentEvent.date) {
                var info = document.createElement('div');
                info.innerHTML = currentEvent.hour + ' - ' + currentEvent.title + ' - ' + currentEvent.duration + 'min.';

                currentDayBox.appendChild(info);
            }
        }
    }

    function dayBoxCreate(date, weekDay) {
        var dayBox = document.createElement('div'),
            dayHeader = document.createElement('strong');

        dayHeader.style.backgroundColor = 'lightgrey';
        dayHeader.style.textAlign = 'center';
        dayHeader.style.display = 'inline-block';
        dayHeader.style.borderBottom = '1px solid black';
        dayHeader.style.width = '100%';
        dayHeader.innerHTML = weekDay + ' June ' + '<strong class="date-of-june">' + date + '</strong>' + ' 2014';

        dayBox.style.border = '1px solid black';
        dayBox.style.float = 'left';
        dayBox.style.height = height + 'px';
        dayBox.style.width = width + 'px';
        dayBox.className = 'day-box';

        dayBox.appendChild(dayHeader);

        return dayBox;
    }
}