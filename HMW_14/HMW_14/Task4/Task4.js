var ticks;
var page;
var timeout = setTimeout(letsGo, 10);
var counter = 0;

function startTimer(nextPage) {
    ticks = 3 * 100;
    page = nextPage;
    timeout();
}

function letsGo() {
    if (ticks < 1) {
        if (typeof page == "undefined") {
            if (confirm("Начать сначала?")) {
                page = 'TestPage1.html'
            }
            else {
                return;
            }
        }
        location.assign(page);
        return;
    }

    document.getElementById("tick").innerHTML = ticks / 100;
    timeout = setTimeout(letsGo, 10);
    ticks--;
}

function onPause() {
    counter++;
    if (counter%2 == 1) {
        clearTimeout(timeout); 
    }
    else if (counter % 2 == 0) {
         timeout = setTimeout(letsGo, 10);
    }
}

function nextPage(page) {
    location.assign(page);
}

function previusPage() {
    history.back();
}