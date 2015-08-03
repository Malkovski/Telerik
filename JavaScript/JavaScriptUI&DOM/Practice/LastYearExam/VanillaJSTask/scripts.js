function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector),
        leftSector = document.createElement('div'),
        rightSector = document.createElement('div'),
        itemList = document.createElement('div'),
        filterZone = document.createElement('input');

    divCreate(leftSector, 'left-sector', '70%', '600px', items[0].title, items[0].url, 'left', '28px', '20px', '20px');
    divCreate(rightSector, 'right-sector', '30%', '650px', null, null, 'left', null, null);
    filterSectorCreate(rightSector, filterZone);

    for (var i = 0, len = items.length; i < len; i += 1) {
        var currentItem = document.createElement('div');
        divCreate(currentItem, 'item-container', '100%', null, items[i].title, items[i].url, '', '16px', '10px');

        currentItem.addEventListener('mouseover', function () {
            this.style.backgroundColor = 'lightgreen';
        });

        currentItem.addEventListener('mouseout', function () {
            this.style.backgroundColor = '';
        });

        currentItem.addEventListener('click', function () {
            leftSector.innerHTML = '';
            divCreate(leftSector, 'left-sector', '70%', '650px', this.querySelector('.image-title').innerHTML,
                    this.querySelector('.image-view').src, 'left', '28px', '20px')

        });

        itemList.appendChild(currentItem);
    }

    rightSector.appendChild(itemList);

    container.appendChild(leftSector);

    rightSector.style.overflow = 'hidden';
    rightSector.style.overflowY = 'scroll';
    container.appendChild(rightSector);

    function divCreate(container, classToAdd, width, height, title, url, float, fontSize, borderRadius, paddingTop) {

        container.style.width = width;
        container.className = classToAdd;
        container.style.height = height;
        container.style.float = float;
        container.style.fontSize = fontSize;
        container.style.marginTop = paddingTop;
        container.style.paddingBottom = '10px';

        if (title !== null && url !== null) {
            titleCreate(container, title);
            imageCreate(container, url, borderRadius);
        }
    }

    function titleCreate(container, item) {
        var title = document.createElement('strong');

        title.className = 'image-title';
        title.style.display = 'inline-block';
        title.style.paddingTop = '10px';
        title.style.paddingBottom = '10px';
        title.style.textAlign = 'center';
        title.style.width = '100%';
        title.innerHTML = item;

        container.appendChild(title);
    }

    function imageCreate(container, item, borderRadius) {
        var image = document.createElement('img');

        image.className = 'image-view';
        image.style.display = 'block';
        image.style.width = '95%';
        image.style.height = '95%';
        image.style.marginBottom = '10px';
        image.style.marginLeft = '10px';
        image.style.borderRadius = borderRadius;
        image.src = item;

        container.appendChild(image);
    }

    function filterSectorCreate(container, filterZone) {
        var filter = document.createElement('div');
        titleCreate(filter, 'Filter');
        filterZone.type = 'text';
        filterZone.style.width = '100%';
        filter.appendChild(filterZone);

        container.appendChild(filter);
    }

    var allContainers = document.querySelectorAll('.item-container');
    filterZone.addEventListener('change', function () {
        var template = this.value.toLowerCase();

        itemList.innerHTML = '';

        for (var i = 0, leni = allContainers.length; i < leni; i += 1) {
            var currentContainerTitle = allContainers[i].firstElementChild.innerHTML.toLowerCase();

            if (currentContainerTitle.indexOf(template) > -1) {
                itemList.appendChild(allContainers[i]);
            }
        }
    });
}