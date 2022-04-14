$(document).ready(function () {
    $.ajaxSetup({
        url: "/api/courses/3",
        context: $(".content"),
        // async:false,
        statusCode: {
            404: function () {
                alert("Не найдено");
            }
        },
        success: function (data) {
            $(this).text(`Выполнено: ${data.id}`);
        },
        error: function (xhr) {
            alert(`Ошибка ${xhr.status} Описание ${xhr.statusText}`);
        }
    });
    $("button").click(function () {
        $.ajax();
    });
});
