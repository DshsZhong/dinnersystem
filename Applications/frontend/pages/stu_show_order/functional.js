function del_order() {
    var oid = $(this).parent().parent().attr('id');
    delete_order(oid ,'self' ,function(result){
        var json = $.parseJSON(result);
        if(json === null) return;
        
        var id = json['id'];
        $("#" + id).remove();
    }
    , function(){});
}