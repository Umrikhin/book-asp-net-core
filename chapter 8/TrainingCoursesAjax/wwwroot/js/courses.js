$(document).ready(function () {
    loadData();
});
//Функция загрузки данных
function loadData() {
    $.ajax({
        url: "/api/courses",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            let html = ''; var i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + (i++).toString() + '</td>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.title + '</td>';
                html += '<td>' + item.hours + '</td>';
                html += '<td><a href="#" onclick="return getbyID(\'' + item.id + '\')">Изменить</a> | <a href="#" onclick="Delete(\'' + item.id + '\')">Удалить</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
            $('.total').html((--i).toString());
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Функция очистки полей ввода данных в модальном окне и установка значений по умолчанию
function clearTextBox() {
    $('#Id').val("");
    $('#Title').val("Химия");
    $('#Hours').val("60");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Title').css('border-color', 'lightgrey');
    $('#Hours').css('border-color', 'lightgrey');
    $('.msg-error').html('');
    $('.msg-error').hide();
}
//Функция добавления данных
function Add() {
    let res = validate();
    if (res == false) {
        return false;
    }
    let aObj = {
        title: $('#Title').val(),
        hours: $('#Hours').val()
    };
    $.ajax({
        url: "/api/courses",
        data: JSON.stringify(aObj),
        method: 'POST',
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#modalWindow').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Валидация данных
function validate() {
    let isValid = true;
    if ($('#Title').val().trim() == "") {
        $('#Title').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Title').css('border-color', 'lightgrey');
    }
    if ($('#Hours').val().trim() == "") {
        $('#Hours').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Hours').css('border-color', 'lightgrey');
    }
    return isValid;
}
//Функция удаления записи
function Delete(id) {
    let ans = confirm("Вы действительно хотите удалить запись?");
    if (ans) {
        $.ajax({
            url: "/api/courses/" + id,
            method: 'DELETE',
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
//Функция получения записи по идентификатору курса
function getbyID(id) {
    $('#Title').css('border-color', 'lightgrey');
    $('#Hours').css('border-color', 'lightgrey');
    $.ajax({
        url: "/api/courses/" + id,
        method: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.id);
            $('#Title').val(result.title);
            $('#Hours').val(result.hours);
            $('#Level').val(result.level);
            $('.msg-error').html('');
            $('.msg-error').hide();
            $('#modalWindow').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
//Функция, обновляющая запись по учебному курсу
function Update() {
    let res = validate();
    if (res == false) {
        return false;
    }
    let id = $('#Id').val();
    let aObj = {
        title: $('#Title').val(),
        hours: $('#Hours').val()
    };
    $.ajax({
        url: "/api/courses/" + id,
        method: 'PUT',
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: JSON.stringify(aObj),
        success: function (result) {
            loadData();
            $('#modalWindow').modal('hide');
            $('#Id').val("");
            $('#Title').val("");
            $('#Hours').val("");
            $('.msg-error').html('');
            $('.msg-error').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

