$(document).ready(function () {
    $("#SaveFeeTerm").click(function () {
        var Status = inputValidation();
        if (Status) {
            $.ajax({
                url: UrlBase + '/Fee/SaveFeeTerm',
                contentType: 'application/json; charset=utf-8',
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify({ 'FeeTerm': $.trim($("#FeeTerm").val()), 'Refundable': $.trim($("#Refundable").val()), 'Active': $.trim($("#Active").val()) }),
                success: function (data) {
                    alert(data);
                    if (data.includes("Successfully"))
                        location.reload();
                },
                error: function () {
                    alert("something went wrong, please try again.");
                }
            })
        }
    })
});
function isKeyValid(evt, validation) {
    var Status = false;
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode
    var validations = validation.split(",");

    for (var i = 0; i < validations.length; i++) {
        if (validations[i].split("-").length == 2) {
            if (!(charCode >= validations[i].split("-")[0] && charCode <= validations[i].split("-")[1]))
                Status = false;
            else
                Status = true;
        }
        else {
            if (charCode != validations[i])
                Status = false;
            else
                Status = true;
        }
        if (Status) break;
    }
    return Status;
}
function inputValidation() {
    var Status = false;
    $('.mandate').each(function () {
        if ($(this).is(":visible")) {
            var val = $.trim($("#" + $(this).attr('id')).val());
            var pat = $(this).attr('pat');
            var minLength = $(this).attr('minlength') != undefined ? parseInt($(this).attr('minlength')) <= val.length ? true : false : true;
            if (val == "" || !val.match(pat) || !minLength) {
                if ($(this).attr('msg') != undefined)
                    alert($(this).attr('msg'));
                else
                    alert("Value required.");
                $(this).focus();
                Status = false;
                return false;
            }
            else {
                Status = true;
            }
        }
    });
    return Status;
}