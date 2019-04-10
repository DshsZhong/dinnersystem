function del_order() {
    var oid = $(this).parent().parent().attr('id');
    delete_order(oid, 'self', function (result) {
        var json = $.parseJSON(result);
        if (json === null) return;

        var id = json['id'];
        $("#" + id).remove();
    }, function () { });
}

function payment() {
    var oid = $(this).parent().parent().attr('id');
    $(this).children("label").text("繳款中...");
    var password = prompt("請輸入你的驗證碼(預設身分證字號後四碼)");
    if(password == null) 
    {
        $(this).children("label").text("確認付款");
        return;
    }

    $(this).removeClass("clickable");
    var button = $("#delete_" + oid).detach();
    make_payment(oid, 'self', password, (result) => {
        if(result == "Punish not over") {
            show("嘗試次數過多");
            $(this).children("label").text("確認付款");
        } else {
            try {
                var json = $.parseJSON(result);
                var id = json['id'];
                $("#" + id).find(".clickable").remove();
                $("#" + id).find(".payment").remove();
                $("#" + id).find("img").attr("src" ,"../../images/paid.png");
                show("繳款成功");
                update_money();
            } catch (err) {
                show("繳款失敗");
                $(this).children("label").text("確認付款");
                $("#" + oid).prepend(button);
                $(this).addClass("clickable");
            }
        }
    });
    update_money();
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