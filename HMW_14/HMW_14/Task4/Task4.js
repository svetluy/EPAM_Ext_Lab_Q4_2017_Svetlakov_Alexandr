var ticks;
var timeout = setTimeout(letsGo, 1000);

function startTimer(minutes) {
    ticks = +minutes * 60;
    timeout();
}

function letsGo() {

    if (ticks < 1) {
        return;
    }

    console.log((ticks/60).toString().substr(0,2) +" " + (ticks%60).toString().substr(0,2));
    //document.getElementById("tick").innerHTML = ticks / 100;
    timeout = setTimeout(letsGo, 1000);
    ticks--;
}

startTimer(20);