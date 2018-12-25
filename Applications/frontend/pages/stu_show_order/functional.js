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
    make_payment(oid, 'self', '123', (result) => {
        var json = $.parseJSON(result);
        var id = json['id'];
        $("#" + id).find(".clickable").remove();
        $("#" + id).find("img").attr("src" ,"../../images/paid.png");
    });
    update_money();
}