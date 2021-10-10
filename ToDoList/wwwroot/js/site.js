﻿showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

jQuery(document).ready(function ($) {
    $("#ddlAjax").on('change', function () {
        var value = $(this).val();
        if (value) {
            $.ajax({
                type: "POST",
                url: "ListSelect",
                data: { typeSelect: value },
                success: function (data) {
                    $('#table').replaceWith(data);
                }
            });
        }
    });
});

jQuery(document).ready(function ($) {
    $('body').on('change', '.statusEdit', function () {
        var taskStatus = $(this).val();
        var id = $(this).data('id');
        //debugger;
        if (taskStatus) {
            $.ajax({
                type: "POST",
                url: "EditStatus",
                data: { taskStatus: taskStatus, id: id },
                success: function (data) {
                    $('#table').replaceWith(data);
                }
            });
        }
    });
});