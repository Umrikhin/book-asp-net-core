$(document).ready(function () {
    $('.ajax').click(function () {
        $.ajax({
            url: "/api/courses/3",
            success: function (result) {
                console.log(result);
                $("h1").text(result.id);
                $("h3").text(result.title);
                $("p").text(result.hours);
            }
        });
    });
    $(".post").click(function () {
        $.post({
            url: "/api/courses",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify({
                title: "Химия",
                hours: 60
            }),
            success: function(data) {
                console.log(data);
            }
        })
    });
    $(".get").click(function () {
        $.get("/api/courses/4", function (data, status) {
            console.log(status);
            $("h1").text(data.id);
            $("h3").text(data.title);
            $("p").text(data.hours);
        });
    });
    $(".put").click(function () {
        $.ajax({
            url: "/api/courses/4",
            method: 'PUT',
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify({
                title: "История",
                hours: "70"
            }),
            success: function (result) {
                console.log(result);
            }
        });
    });
    $(".delete").click(function () {
        $.ajax({
            url: "/api/courses/4",
            method: 'DELETE',
            success: function (result) {
                console.log(result);
            }
        });
    });
});
