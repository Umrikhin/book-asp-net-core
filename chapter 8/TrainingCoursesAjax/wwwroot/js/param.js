$(document).ready(function () {
    let form = {
        Land: "Russia",
        Currency: "Ruble",
        Capital: "Moscow"
    }
    $(".result").text($.param(form));
});
