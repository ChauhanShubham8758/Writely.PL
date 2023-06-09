/* Sign Up Process */

$(document).off('click', '#btn-signup').on('click', '#btn-signup', function () {
    debugger;
    $.ajax({
        type: "POST",
        url: "/User/RegisterUser",
        data: $("#signup-form").serialize(),
        success: function (response) {
            alert('success')
        },
        error: function (response) {
            alert('error')
        }
    });
});