/* Sign Up Process */
$(document).off('click', '#btn-signup').on('click', '#btn-signup', function () {
    var FirstName = $('#firstName').val();
    var LastName = $('#lastName').val();
    var EmailAddress = $('#email').val();
    var Password = $('#password').val();
    var PhoneNumber = $('#phoneNumber').val();

    if (FirstName == "" || FirstName == null) {
        showLoginAlert("<strong>Error! </strong> Please enter first name.", "alert-danger");
        return false;
    }
    else if (LastName == "" || LastName == null) {
        showLoginAlert("<strong>Error! </strong> Please enter last name.", "alert-danger");
        return false;
    }
    else if (EmailAddress == "" || EmailAddress == null) {
        showLoginAlert("<strong>Error! </strong> Please enter email address.", "alert-danger");
        return false;
    }
    else if (!ValidateEmail(EmailAddress)) {
        showLoginAlert("<strong>Error! </strong> Invalid Email. Please enter valid email address.", "alert-danger");
        return false;
    }
    else if (Password == "" || Password == null) {
        showLoginAlert("<strong>Error! </strong> Please enter your password.", "alert-danger");
        return false;
    }
    else if (!ValidatePassword(Password)) {
        showLoginAlert("<strong>Error! </strong> Invalid Password.Must have minimum 8 charcters, one capital letter, one small letter, one special character", "alert-danger");
        return false;
    }
    else if (PhoneNumber == "" || PhoneNumber == null) {
        showLoginAlert("<strong>Error! </strong> Please enter phone number.", "alert-danger");
        return false;
    }
    else {
        var over = '<div id="overlay">' +
            '<div id="loading"></div>' +
            '</div>';
        $(over).appendTo('body');

        $.ajax({
            type: "POST",
            url: "/User/RegisterUser",
            data: $("#signup-form").serialize(),
            success: function (response) {
                window.location.href = "/User/LoginUser";
            },
            error: function (response) {
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

/* Sign-In Process */

$(document).off('click', '#btn-signin').on('click', '#btn-signin', function () {
    var EmailAddress = $('#login-email').val();
    var Password = $('#login-password').val();

    if (EmailAddress == "" || EmailAddress == null) {
        showLoginAlert("<strong>Error! </strong> Please enter email address.", "alert-danger");
        return false;
    }
    else if (!ValidateEmail(EmailAddress)) {
        showLoginAlert("<strong>Error! </strong> Invalid Email. Please enter valid email address.", "alert-danger");
        return false;
    }
    else if (Password == "" || Password == null) {
        showLoginAlert("<strong>Error! </strong> Please enter your password.", "alert-danger");
        return false;
    }
    else if (!ValidatePassword(Password)) {
        showLoginAlert("<strong>Error! </strong> Invalid Password.Must have minimum 8 charcters, one capital letter, one small letter, one special character", "alert-danger");
        return false;
    }
    else {
        var over = '<div id="overlay">' +
            '<div id="loading"></div>' +
            '</div>';
        $(over).appendTo('body');

        $.ajax({
            type: "POST",
            url: "/User/LoginUser",
            data: $("#signin-form").serialize(),
            success: function (response) {
                var token = response.asT0;
                localStorage.setItem('jwtToken', token);
                $.ajax({
                    type: "get",
                    url: "/Home/Index",
                    headers: { "Authorization": "Bearer " + token },
                    success: function (res) {
                        $('html').html(res);
                    }
                });

            },
            error: function (response) {
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

/* Display Error message */
function showLoginAlert(message, alertClass) {
    $("#_LoginMessage").html(message);

    if (alertClass != '') {
        $("#LoginMessage").find("#login-inner-message").removeClass();
        $("#LoginMessage").find("#login-inner-message").addClass('alert ' + alertClass);
    }
    $("#LoginMessage").css('display', 'block');
}

function ValidateEmail(email) {
    var expr = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return expr.test(email);
}

function ValidatePassword(passwd) {
    var expr = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,50}$/;
    return expr.test(passwd);
}

// Add event listener to the close button
$("#LoginMessage").on("click", ".btnclose", function () {
    $("#LoginMessage").css('display', 'none');
});