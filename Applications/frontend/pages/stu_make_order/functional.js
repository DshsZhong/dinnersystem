var result;
var data = [];

function submit() {
    var over_time = (moment().hour() >= 10);
    var did = $(this).parent().attr('id').split('_')[1];
    var server_respond;
    var remaining;
    
    show_remaining(did ,(data) => {
        remaining = JSON.parse(data)["remaining"];
        if(remaining != 0) 
            make_order(null, did, "self", function (result) { server_respond = result });
    });
    
    $(document).ajaxStop(function () {
        if(remaining == 0) {
            show("賣完了");
        } else if (over_time) {
            show("十點之後無法點餐");
        } else if(server_respond == "daily limit exceed") {
            show("達單日訂購上限");
        } else {
            show("成功點餐");
            setTimeout(function () {
                window.history.back();
            }, 1000);
        }
    });
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
