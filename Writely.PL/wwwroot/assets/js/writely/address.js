$(function () {
    $("#country-list").select2({
        placeholder: "Select your country",
        allowClear: true
    });
});

$(function () {
    $("#state-list").select2({
        placeholder: "Select your state",
        allowClear: true
    });
});

$(function () {
    $("#city-list").select2({
        placeholder: "Select your city",
        allowClear: true
    });
});


$(function () {
    $("#state-list").prop('disabled', true);
    $("#city-list").prop('disabled', true);
});

$(document).off('change', '#country-list').on('change', '#country-list', function () {
    var value = 0;
    if ($(this).val() != "") {
        value = $(this).val();
        $("#state-list").prop('disabled', false); // remove the disabled attribute if a country is selected
    }
    else {
        $("#state-list").empty().prop('disabled', true); // empty and disable the state list if no country is selected
        $("#state-list").select2();
        return;
    }

    $.ajax({
        type: "GET",
        url: "/Address/GetStatesByCountryId",
        data: { countryId: value },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var list = response;
            $("#state-list").empty().append('<option selected="selected" value="0">Select</option>');
            if (list != null && list.length > 0) {
                for (let i = 0; i < list.length; i++) {
                    $("#state-list").append($("<option></option>").val(list[i].id).html(list[i].name));
                }
                $("#state-list").select2();
            } else {
                // Append a new option element with the text "No state available" and a disabled attribute
                $("#state-list").append($("<option></option>").text("No state available").attr("disabled", true));
            }
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
});

$(document).off('change', '#state-list').on('change', '#state-list', function () {
    var value = 0;
    if ($(this).val() != "") {
        value = $(this).val();
        $("#city-list").prop('disabled', false); 
    }
    else {
        $("#city-list").empty().prop('disabled', true);
        $("#city-list").select2();
        return;
    }

    $.ajax({
        type: "GET",
        url: "/Address/GetCities",
        data: { stateId: value },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var list = response;
            $("#city-list").empty().append('<option selected="selected" value="0">Select</option>');
            if (list != null && list.length > 0) {
                for (let i = 0; i < list.length; i++) {
                    $("#city-list").append($("<option></option>").val(list[i].id).html(list[i].name));
                }
                $("#city-list").select2();
            } else {
                // Append a new option element with the text "No state available" and a disabled attribute
                $("#city-list").append($("<option></option>").text("No city available").attr("disabled", true));
            }
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
});

$('#city-list').on('change', function () {
    var cityId = $(this).val();
    $('#city-id').val(cityId);
});

showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}


//jQueryAjaxPost = form => {
//    debugger
//    try {
//        $.ajax({
//            type: 'POST',
//            url: form.action,
//            data: new FormData(form),
//            contentType: false,
//            processData: false,
//            success: function (res) {
//                if (res.isValid) {
//                    $('#view-all').html(res.html)
//                    $('#form-modal .modal-body').html('');
//                    $('#form-modal .modal-title').html('');
//                    $('#form-modal').modal('hide');
//                }
//                else
//                    $('#form-modal .modal-body').html(res.html);
//            },
//            error: function (err) {
//                console.log(err)
//            }
//        })
//        //to prevent default form submit event
//        return false;
//    } catch (ex) {
//        console.log(ex)
//    }
//}

function CountryHome()
{
    var token = localStorage.getItem("jwtToken");
    $.ajax({
        type: "get",
        url: "/Address/CountryHome",
        headers: { "Authorization": "Bearer " + token },
        success: function (res) {
            $('html').html(res);
        }
    });
}

function DeleteCountry(id,countryName) {
    Swal.fire({
        title: 'Are you sure?',
        text: `Do you want to delete the country '${countryName}'?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            // Here, you can trigger the actual deletion logic
            // For example, you can make an AJAX request to delete the record
            // After successful deletion, you can show a success message
            // If there's an error, you can show an error message
            // You can use AJAX or Razor Pages handlers for this.
            // Example:
            // $.ajax({
            //     url: '/Address/DeleteCountry',
            //     type: 'POST',
            //     data: { countryName: countryName },
            //     success: function (response) {
            //         Swal.fire(
            //             'Deleted!',
            //             'The country has been deleted.',
            //             'success'
            //         );
            //     },
            //     error: function (error) {
            //         Swal.fire(
            //             'Error!',
            //             'An error occurred while deleting the country.',
            //             'error'
            //         );
            //     }
            // });
        }
    });
}