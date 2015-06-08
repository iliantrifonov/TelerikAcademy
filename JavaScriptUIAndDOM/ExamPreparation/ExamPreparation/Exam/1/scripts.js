function createImagesPreviewer(selector, items) {

    var LENGHT = items.length,
        container = document.querySelector(selector),
        divLeft = document.createElement('div'),
        divRight = document.createElement('div'),
        imageContainer = document.createElement('div'),
        pFilter = document.createElement('p'),
        textFilter = document.createElement('input'),
        innerContainer = document.createElement('div'),
        imageContentLeft = document.createElement('div'),
        imageTitleText = document.createElement('p'),
        img = document.createElement('img');

    img.style.borderRadius = '15px';
    
    innerContainer.style.padding = '20px';

    textFilter.style.width = '80%';
    textFilter.setAttribute('type', 'text');
    textFilter.addEventListener('input', function (ev) {
        var value = this.value;

        var items = container.querySelectorAll('.image-container');

        for (var i = 0, len = items.length; i < len; i++) {
            var text = items[i].querySelectorAll('p')[0].innerHTML;
            if (text.indexOf(value) > -1) {
                items[i].style.display = '';
            }
            else {
                items[i].style.display = 'none';
            }
        }
    });

    imageTitleText.style.textAlign = 'center';
    imageTitleText.style.width = 'bold';

    pFilter.style.textAlign = 'center';
    pFilter.style.width = 'bold';

    divLeft.style.display = 'inline-block';
    divLeft.style.width = '700px';
    divLeft.style.height = '600px';
    divLeft.classList.add('left');
    divLeft.style.alignContent = 'center';
    divLeft.style.verticalAlign = 'center';
    divLeft.style.float = 'left';
    divLeft.style.paddingLeft = '50px';


    divRight.style.display = 'inline-block';
    divRight.style.width = '350px';
    divRight.style.height = '600px';
    divRight.style.overflowY = 'auto';

    img.style.width = '280px';
    img.style.height = 'auto';

    pFilter.innerHTML = 'Filter';
    
    var frag = document.createDocumentFragment();
    for (var i = 0; i < LENGHT; i++) {
        var div = innerContainer.cloneNode(true);
        var image = img.cloneNode(true);
        var title = imageTitleText.cloneNode(true);

        image.setAttribute('src', items[i].url);
        image.setAttribute('index', i);
        title.innerHTML = items[i].title;

        div.addEventListener('click', clickPicture);
        div.addEventListener('mouseover', mouseover);
        div.addEventListener('mouseout', mouseout);

        div.appendChild(title);
        div.appendChild(image);
        div.classList.add('image-container');
        div.classList.add(items[i].title);

        frag.appendChild(div);
    }

    imageContainer.appendChild(pFilter);
    imageContainer.appendChild(textFilter);
    imageContainer.appendChild(frag);

    divRight.appendChild(imageContainer);
    
    //DIV LEFT LOGIC

    //END DIV LEFT LOGIC

    container.appendChild(divLeft);
    container.appendChild(divRight);

    function clickPicture(ev) {
        console.log('help');
        var children = this.children;
        var containerInner = imageContentLeft.cloneNode(true);
        var frag = document.createDocumentFragment();

        for (var i = 0; i < children.length; i++) {

            var currentChild = children[i].cloneNode(true);
            currentChild.style.width = '600px';
            currentChild.style.fontSize = '1.9rem';
            frag.appendChild(currentChild);
        }

        containerInner.appendChild(frag.cloneNode(true));

        var divLeft = document.querySelector('.left');
        while (divLeft.firstChild) {
            divLeft.removeChild(divLeft.firstChild);
        }

        divLeft.appendChild(containerInner.cloneNode(true));
    }

    function mouseover(ev) {
        this.style.background = 'yellowgreen';
    }

    function mouseout(ev) {
        this.style.background = '';
    }
}