var result;
var data = [];
var class_no = JSON.parse(window.localStorage.user_data)['class']['class_no'];

function parseSeatNo(value) {
    var integer = parseInt(value);
    if (integer == undefined)
        return false;
    if (class_no == "760") {
        if (integer < 0 || 9999 < integer)
            return false;
        digit = 4;
    } else {
        if (integer <= 0 || 50 <= integer)
            return false;
        digit = 2;
    }
    var str = integer.toString();
    while (str.length < digit) {
        str = "0" + str;
    }
    return str;
}

var invalid = false;
function submit() {
    var no_account = false;
    if (invalid) {
        show("不合法的使用者名稱 請確認後再試");
    } else {
        var over_time = (moment().hour() >= 10);
        $("#submit").text("送出中...");
        $(".dish_content").each(function (index, value) {
            var uid = parseSeatNo($(this).find('input').val());
            var did = $(this).find('input').attr('name').split('_')[1];
            if (uid == false || isNaN(uid) || uid == undefined) {
                return;
            }
            make_order(class_no + uid, did, "class", function (result) {
                if (result == "Invalid seat_id.") no_account = true;
            });
        });
        $(document).ajaxStop(function () {
            $("#submit").text("送出點單");
            
            if (over_time) {
                show("十點之後無法點餐");
            } else if (no_account) {
                show("查無此人");
            } else {
                show("成功點餐");
                setTimeout(function () {
                    window.history.back();
                }, 1000);
            }
        });
    }

}


function show(msg) {
    $("#error_msg").text(msg);
    $("#error_msg").removeClass("animated bounceIn").parent().css("display", "block");
    setTimeout(function () {
        $("#error_msg").addClass("animated bounceIn");
    }, 30);

    setTimeout(function () {
        $("#error_msg").parent().css("display", "none");
    }, 1000);
}

function update() {
    var charge_sum = 0;

    invalid = false;
    $(".dish_content").each(function (index, value) {
        var uid = parseSeatNo($(this).find('input').val());
        if (isNaN(uid) || uid == undefined) {
            return;
        }
        if (uid === false) {
            invalid = true;
            return;
        }
        var charge = parseInt($(this).parent().attr('cost'));
        charge_sum += charge;
    });
    $("#chargesum").text("金額總共: " + charge_sum + "$.");

    setTimeout(update, 500);
}