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