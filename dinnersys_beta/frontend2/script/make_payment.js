function make_payment(ids ,type ,callback) {
    for(var key in ids) {
        var value = ids[key];
        var url = "/dinnersys_beta/backend/backend.php?cmd=payment_" + type + "&target=true&order_id=" + value;
        $.get(url ,function(data){
            if(data != "Successfully set payment.") alert(data);
        });
    }

    setTimeout(function(){
        callback();
    } ,1000);
}