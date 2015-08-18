function solve() {

  return function (selector, isCaseSensitive) {
    /*if (isCaseSensitive !== 'true') {
      selector = selector.toLowerCase();
    }*/

    var container = document.querySelector(selector);

      container.className = 'items-control';

    if (typeof selector === 'undefined') {
      throw new Error('Missing parameter!');
    }

    if (selector === null) {
      throw new Error('Null parameter!');
    }

    if (typeof selector !== 'string') {
      throw new Error('Selector must be string!');
    }

//add part

    var mainElement = document.createElement('div');

    mainElement.className = 'add-controls';

      var labelAddEL = document.createElement('label');
      labelAddEL.innerHTML = 'Enter text';
      labelAddEL.setAttribute('for', 'main-element');

      var inputElement = document.createElement('input');
      inputElement.id = 'main-element';
      inputElement.type = 'text';

      var buttonElement = document.createElement('button');
      buttonElement.className = 'button';
      buttonElement.innerHTML = 'Add';

      buttonElement.addEventListener('click', function () {
          var listItem = document.createElement('div');
          var text = document.createElement('span');
          var closingButton = document.createElement('button');
          closingButton.className = 'closing';
          closingButton.innerHTML = 'X';

          listItem.className = 'list-item';
          text.innerHTML = inputElement.value;

          listItem.appendChild(text);
          listItem.appendChild(closingButton);
          itemsList.appendChild(listItem);
      });

      mainElement.appendChild(labelAddEL);
      mainElement.appendChild(inputElement);
      mainElement.appendChild(buttonElement);

// search
    var searchElement = document.createElement('div');
    searchElement.className = 'search-controls';

      var labelSearch = document.createElement('label');
      labelSearch.innerHTML = 'Search';
      labelSearch.setAttribute('id', 'search-element');

   var searchInput = document.createElement('input');
    searchInput.type = 'text';
      searchInput.id = 'search-element';

     searchElement.appendChild(labelSearch);
    searchElement.appendChild(searchInput);


      searchInput.addEventListener('change', function () {
          var inputContent = this.value,
              allListItems = itemsList.childNodes;

          for (var i = 0, leni = allListItems.length; i < leni; i += 1) {
              var currentItem = allListItems[i],
                  currentText = currentItem.firstElementChild.innerHTML;

              if (isCaseSensitive === 'true') {
                  inputContent = inputContent.toLowerCase();
                  currentText = currentText.toLowerCase();
              }

              if (currentText.indexOf(inputContent) < 0) {
                  currentItem.style.display = 'none';
              }
          }
      });

// result prt
    var resultElement = document.createElement('div'),
        itemsList = document.createElement('div');

    resultElement.className = 'result-controls';
    itemsList.className = 'items-list';
    resultElement.appendChild(itemsList);

    itemsList.addEventListener('click', function (ev) {
        var clickedEl = ev.target;

        if (clickedEl.className = 'button') {
            clickedEl.parentNode.innerHTML = '';
        }
    });

    container.appendChild(mainElement);
    container.appendChild(searchElement);
    container.appendChild(resultElement);
  };
}

module.exports = solve;