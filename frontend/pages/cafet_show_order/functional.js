function payment() {
    var current = $(this).find("input[type='checkbox']").is(':checked');
    var item = $(this).find("label").detach();
    var cid = $(this).attr('number');

    current = !current;
    if(current) {
        $(".checker." + cid).append("<label>繳款中...</label>");
    } else {
        $(".checker." + cid).append("<label>取消繳款中...</label>");
    }

    $("." + cid + ".order_id").each(function (index, value) {
        var id = $(this).attr('oid');
        make_payment(id, 'cafet', function () {} ,current);
    });

    $(document).ajaxStop(function () {
        $(".checker." + cid).find("label").remove();
        $(".checker." + cid).append(item);
    });
}


function del_order() {
    var oid = $(this).parent().attr('oid');
    delete_order(oid ,'everyone' ,function() {} ,function(){
        load();
    });
}