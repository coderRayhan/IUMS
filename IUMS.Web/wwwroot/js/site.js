$(document).ready(function () {
    $('.form-image').click(function () { $('#customFile').trigger('click'); });
    $(function () {
        $('.selectpicker').selectpicker();
    });
    setTimeout(function () {
        $('body').addClass('loaded');
    }, 200);

    jQueryModalGet = (url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal .modal-body').html(res.html);
                    $('#form-modal .modal-title').html(title);
                    $('#form-modal').modal('show');
                    console.log(res);
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

    jQueryModalPost = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        $('#viewAll').html(res.html)
                        $('#form-modal').modal('hide');
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }

    jQueryModalDelete = form => {

        Swal.fire({
            title: 'Do you want to delete this?',
            showCancelButton: true,
            confirmButtonText: `Delete`,
            icon: 'warning',

        }).then((result) => {

            if (result.isConfirmed) {
                try {
                    $.ajax({
                        type: 'POST',
                        url: form.action,
                        data: new FormData(form),
                        contentType: false,
                        processData: false,
                        success: function (res) {
                            if (res.isValid) {
                                Swal.fire('Deleted!', '', 'success')
                                $('#viewAll').html(res.html)
                            }
                        },
                        error: function (err) {
                            console.log(err)
                        }
                    })
                } catch (ex) {
                    console.log(ex)
                }
            }
        })
        return false;
    }

    jQueryModalStatus = form => {

        Swal.fire({
            title: 'Do you want to change this?',
            showCancelButton: true,
            confirmButtonText: `Update`,
            icon: 'warning',

        }).then((result) => {

            if (result.isConfirmed) {
                try {
                    $.ajax({
                        type: 'POST',
                        url: form.action,
                        data: new FormData(form),
                        contentType: false,
                        processData: false,
                        success: function (res) {
                            if (res.isValid) {
                                Swal.fire('Updated!', '', 'success')
                                $('#viewAll').html(res.html)
                            }
                        },
                        error: function (err) {
                            console.log(err)
                        }
                    })
                } catch (ex) {
                    console.log(ex)
                }
            }
        })
        return false;
    }
});