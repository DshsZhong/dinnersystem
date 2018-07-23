//every function here is synchornized.

function login(uid ,pswd ,callback ,done) {
    var json;

    $.get("/dinnersys_beta/backend/backend.php?cmd=login&id=" + uid + "&password=" + pswd + "&device_id=website", function( data ) {
        try {
            json = $.parseJSON(data);
        }
        catch(err) {
            json = null;
        }
    }).done(function(){
        callback(json);
        done();
    });
}

function delete_order(oid ,callback ,done) {
    var json;

    $.get("/dinnersys_beta/backend/backend.php?cmd=delete_self&order_id=" + oid, function(data){
        if(data == 'Succesfully deleted order.') {
            json = data;
        } else {
            json = null;
        }
    }).done(function(){
        callback(json);
        done();
    });
}

function make_order(did ,callback ,done) {
    var result = "";
    var esti_recv = moment().format("YYYY/MM/DD") + "-23:59:59";

    $.get("/dinnersys_beta/backend/backend.php?cmd=make_order&dish_id=" + did + "&time=" + esti_recv , function( data ) {
        result = data;
    }).done(function(){
        var num = parseInt(result);
        if(isNaN(num))
            callback(result);
        else
            callback(num);
        
        done();
    });
}

function logout(done)
{
    $.get( "/dinnersys_beta/backend/backend.php?cmd=logout", function(data) {

    }).done(function(){
        done();
    });
}