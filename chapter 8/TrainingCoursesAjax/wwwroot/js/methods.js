$(document).ready(function () {
    $('.request').click(function () {
        $.ajax({
            url: "/api/courses/3",
            success: function (result) {
                console.log(result);
            }
        });
    });
    $('.broken').click(function () {
        $.ajax({
            url: "/pi/courses/3",
            success: function (result) {
                console.log(result);
            }
        });
    });
    //$(document).ajaxSuccess(function (e, xhr, opt) {
    //    alert("completed");
    //    console.log(e);
    //    console.log(xhr);
    //    console.log(opt);
    //});
    //$(document).ajaxError(function (e, xhr, opt) {
    //    alert("error");
    //    console.log(e, 1);
    //    console.log(xhr, 2);
    //    console.log(opt, 3);
    //});
    $('.start').click(function () {
        $.ajax({
            url: "/api/courses",
            success: function (result) {
                console.log(result);
            }
        });
    });
    $(document).ajaxStart(function () {
        // alert("Старт");
        $(".loading").show(700);
    });
    $(document).ajaxStop(function () {
        // alert("Стоп");
        $(".loading").hide(700);
    });
    $(document).ajaxComplete(function () {
        //alert("Завершено")
    });
});
