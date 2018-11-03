function make_order(value) {
    var has_paid = (value['money']["payment"][0]['paid'] == "true");
    var highlight = (value['user']['id'] !== value['order_maker']['id']);
    return '<div id="' + value['id'] + '"><div class="info"><div class="index index_adjust"><label>付款狀態:</label>' + 
        '<img src="../../images/' + (has_paid ? 'paid' : 'unpaid') + '.png"></img></div>' + 
        (has_paid ? '' : '<div class="value value_adjust clickable"><img src="../../images/cross_symbol.png"></img></div>') + 
        '</div><div class="info"><div class="index dish_name ' + (highlight ? " red-highlight " : "") + '"><label>' +
        value['dish']['dish_name'] + '(' + value['dish']['dish_cost'] + '$.)' + '</label></div></div><hr /></div>';
}

function load() {
    var today = moment().format("YYYY/MM/DD");
    var url = "../../../backend/backend.php?cmd=select_self&esti_start=" + today + "-00:00:00&esti_end=" + today + "-23:59:59";
    
    $("#loading").css("display" ,"block");
    $.get(url ,function(data){
        var json = $.parseJSON(data);
        for(var key in json) {
            var value = json[key];
            $("#data").append(make_order(value));
        }
        $(".value_adjust.clickable").off('click').click(del_order);
    }).done(function(){
        $("#loading").css("display" ,"none");  
    });
}

$(document).ready(function(){
    load();
});
