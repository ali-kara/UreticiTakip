$(function () {

    StartThisSessionTimer();


    $("body").on('click keypress', function () {
        ResetThisSession();
    });
});

var timeInSecondsAfterSessionOut = 600; // change this to change session time out (in seconds).
var secondTick = 0;

function ResetThisSession() {
    secondTick = 0;
}

function StartThisSessionTimer() {
    secondTick = secondTick + 5;
    var timeLeft = ((timeInSecondsAfterSessionOut - secondTick) / 60).toFixed(0); // in minutes
    timeLeft = timeInSecondsAfterSessionOut - secondTick; // override, we have 30 secs only

    $("#spanTimeLeft").html(timeLeft);

    if (secondTick > timeInSecondsAfterSessionOut) {
        clearTimeout(tick);
        window.location = "/Nakliye/SignOut";
        return;
    }
    tick = setTimeout("StartThisSessionTimer()", 5000);
}