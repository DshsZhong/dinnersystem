function do_payment() {
    var current = $(this).find("input[type='checkbox']").is(':checked');
    var oid = $(this).parent().parent().parent().attr('id');
    if(current == payment_data[oid]) return;

    payment_data[oid] = current;
    make_payment(oid ,'usr' ,function(result){
        var json = $.parseJSON(result);
        if(current) {
            unupload_real_paid += parseInt(json['money']['charge']);
        } else {
            unupload_real_paid -= parseInt(json['money']['charge']);
        }
        update_paids();
    } ,current);
}

function del_order() {
    var oid = $(this).parent().parent().attr('id');
    if(confirm('你確定要刪除本點單嗎?')) {
        delete_order(oid ,'class' ,function(result){
            var json = $.parseJSON(result);
            var seat_no = parseInt(json['user']['seat_no']) % 100;

            unupload_should_paid -= parseInt(json['money']['charge']);
            if(json['money']['payment'][0]['paid'] == 'true') {
                unupload_real_paid -= parseInt(json['money']['charge']);
                alert("你應該退還給" + json['user']['name'] + 
                    '(' + seat_no + ') ' + json['money']['charge'] + '$.');
            }
        }, function(){
            $("#" + oid).remove();
            update_paids();
        });
    }
}

function payment_all() {
    var target = ($(this).attr("target") === "true");
    $(".order.editable").each(function(index, value){
        var oid = $(this).attr('id');
        make_payment(oid ,'usr' ,function(result){} ,target);   
    });
    $(document).ajaxStop(function() {
        show((target ? "已經全部繳款" : "已經全部取消繳款"));
        setTimeout(function(){
            window.history.back();
        } ,1000);
    });
}