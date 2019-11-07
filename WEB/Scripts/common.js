$(document).ready(function () {
    $("#RegisterUser").click(function () {
        var Status = inputValidation();
        return Status;
        //if (Status) {
        //    var userDeails = { Mobile: $.trim($("#Mobile").val()), Password: $.trim($("#Password").val()), Name: $.trim($("#Name").val()), EmailId: $.trim($("#EmailId").val()), UserType: $.trim($("#UserType").val()) }
        //    $.ajax({
        //        url: 'http://localhost:51267/Account/RegisterUser',
        //        contentType: 'application/json; charset=utf-8',
        //        type: 'POST',
        //        dataType: 'json',
        //        data: JSON.stringify({ 'registerUser': userDeails }),
        //        success: function (data) {
        //            if (data.Status == "2" && data.Code == "OTP") {
        //                $(".InfoDiv").hide();
        //                $(".OTPDiv").show();
        //            }
        //            else if (data.Status == "0") {
        //                alert(data.Description);
        //            }

        //        },
        //        error: function () {
        //            alert("something went wrong, please try again.");
        //        }
        //    })
        //}
    })

    $("#GenerateOTP").click(function () {
        var Status = inputValidation();
        if (Status) {
            $.ajax({
                url: 'http://localhost:51267/Account/ForgetPassword',
                contentType: 'application/json; charset=utf-8',
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify({ 'UserName': $.trim($("#Mobile").val()) }),
                success: function (data) {
                    if (data.Status == "1" && data.Code == "OTP") {
                        $(".InfoDiv").hide();
                        $(".OTPDiv").show();
                    }
                    else {
                        alert(data.Description);
                    }
                },
                error: function () {
                    alert("something went wrong, please try again.");
                }
            })
        }
    })
    $("#OTPVerifyNGenerate").click(function () {
        var Status = inputValidation();
        if (Status) {
            var userDeails = { Mobile: $.trim($("#Mobile").val()), OTP: $.trim($("#OTP").val()), NewPassword: $.trim($("#NewPassword").val()) }
            $.ajax({
                url: 'http://localhost:51267/Account/OTPVerifyNGenerate',
                contentType: 'application/json; charset=utf-8',
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify({ 'forgetPassword': userDeails }),
                success: function (data) {
                    debugger;
                    if (data.Status == "1") {
                        alert(data.Description);
                        window.location.href = location.protocol + '//' + location.host + "/" + "Account/UserLogin";
                    }
                    else if (data.Status == "0") {
                        alert(data.Description);
                    }
                },
                error: function () {
                    alert("Something went wrong, please try again.");
                }
            })
        }
    })
    $("#link").click(function () {
        var x = document.getElementById($("#" + this.id).attr("class"));
        if (x.type === "password") {
            x.type = "text";
        } else {
            x.type = "password";
        }
    })
    $(".OTPVerify").click(function () {
        var a = $("#OTP").val();
        if (a == "") return alert("Please enter OTP."), !1;
        var c = CryptoJS.enc.Utf8.parse("8080808080808080"),
            d = CryptoJS.enc.Utf8.parse("8080808080808080"),
            e = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(a), c, {
                keySize: 16,
                iv: d,
                mode: CryptoJS.mode.CBC,
                padding: CryptoJS.pad.Pkcs7
            });
        $("#OTP").val(e)
    })
});
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
function getLoginStatus() {
    return false;
}