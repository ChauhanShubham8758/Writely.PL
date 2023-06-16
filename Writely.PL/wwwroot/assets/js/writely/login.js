/* Sign Up Process */

$(document).off('click', '#btn-signup').on('click', '#btn-signup', function () {

    var EmailAddress = $('#txtLoginEmail').val();
    var Password = $('#txtLoginPassword').val();

    if (EmailAddress == "") {
        showLoginAlert("<strong>Error! </strong>Please enter email address.", "alert-danger");
        return false;
    }
    else {
        $.ajax({
            type: "POST",
            url: "/User/RegisterUser",
            data: $("#signup-form").serialize(),
            success: function (response) {
                alert('success')
                window.location.href = "/User/LoginUser";
            },
            error: function (response) {
                //alert(response.responseText)
                $("#errorToast").toast({
                    autohide: true,
                    delay: 3000 // hide the toast after 3 seconds
                });

                // Show the error toast
                $("#errorToast").toast("show");
            }
        });
    }

});

function showLoginAlert(message, alertClass) {
    $("#_LoginMessage").html(message);

    if (alertClass != '') {
        $("#LoginMessage").find("#login-inner-message").removeClass();
        $("#LoginMessage").find("#login-inner-message").addClass('alert ' + alertClass);
    }
    $("#LoginMessage").css('display', 'block');
}

/* Sign-In Process */

$(document).off('click', '#btn-signin').on('click', '#btn-signin', function () {

    var EmailAddress = $('#login-email').val();
    var Password = $('#login-password').val();

    if (EmailAddress == "") {
        showLoginAlert("<strong>Error! </strong>Please enter email address.", "alert-danger");
        return false;
    }
    else {
        $.ajax({
            type: "POST",
            url: "/User/LoginUser",
            data: $("#signin-form").serialize(),
            success: function (response) {
                alert('success')
                window.location.href = "/User/LoginUser";
            },
            error: function (response) {
                //alert(response.responseText)
                $("#errorToast").toast({
                    autohide: true,
                    delay: 3000 // hide the toast after 3 seconds
                });

                // Show the error toast
                $("#errorToast").toast("show");
            }
        });
    }

});