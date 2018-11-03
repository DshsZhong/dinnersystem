function payment() {
    var current = $(this).find("input[type='checkbox']").is(':checked');
    var item = $(this).find("label").detach();
    var code = $(this).attr('code');

    current = !current;
    if(current) {
        $(".checker." + code).append("<label>繳款中...</label>");
    } else {
        $(".checker." + code).append("<label>取消繳款中...</label>");
    }

    $("." + code + ".order_id").each(function (index, value) {
        var oid = $(this).attr('oid');
        make_payment(oid, 'facto', function () {} ,current);
    });

    $(document).ajaxStop(function () {
        $(".checker." + code).find("label").remove();
        $(".checker." + code).append(item);
    });
}