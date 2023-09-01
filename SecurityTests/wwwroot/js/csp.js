var $timeSpan = document.getElementById("timeSpan");
var $tmpl = _.template("Current time: <%= time %>");

function updateTime(timeString) {
    $timeSpan.innerHTML = $tmpl({ time: timeString });
}

window.setInterval(
    function () {
        updateTime(new Date().toLocaleTimeString());
    },
    1000);