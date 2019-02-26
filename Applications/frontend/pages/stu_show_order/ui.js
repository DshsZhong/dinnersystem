function make_order(value) {
    var dname = (value["dish"].length == 1 ? value['dish'][0]['dish_name'] : "自訂套餐");
    var has_paid = (value['money']["payment"][0]['paid'] == "true");
    var highlight = (value['user']['id'] !== value['order_maker']['id']);
    var expired = (moment().isAfter(moment().format("YYYY-MM-DD") + " 10:30:00"));
    return '<div id="' + value['id'] + '"><div class="info"><div class="index index_adjust"><label>付款狀態:</label>' +
        '<img src="../../images/' + (has_paid ? 'paid' : 'unpaid') + '.png"></img></div>' +
        (has_paid || expired ? '' : '<div class="value payment clickable"><label> 確認繳款 </label></div>') +
        (has_paid ? '' : '<div id="delete_' + value["id"] + '" class="value value_adjust clickable"><img src="../../images/cross_symbol.png"></img></div>') +
        '</div><div class="info"><div class="index dish_name ' + (highlight ? " red-highlight " : "") + '"><label>' +
        dname + '(' + value['money']['charge'] + '$.)' + '</label></div></div><hr /></div>';
}

function load() {
    var today = moment().format("YYYY/MM/DD");
    var url = "../../../backend/backend.php?cmd=select_self&history=true&dirty=true&esti_start=" + today + "-00:00:00&esti_end=" + today + "-23:59:59";

    $("#loading").css("display", "block");
    $.get(url, function (data) {
        $("#data").empty();
        var json = $.parseJSON(data);
        for (var key in json) {
            var value = json[key];
            $("#data").append(make_order(value));
        }
        $(".value.clickable").off('click').click(payment);
        $(".value_adjust.clickable").off('click').click(del_order);
    }).done(function () {
        $("#loading").css("display", "none");
    });
    update_money();
}

function update_money() {
    var money = "../../../backend/backend.php?cmd=get_money";
    $.get(money, (data) => {
        if(data === parseInt(data, 10))
            $("#money").text(data + "$.");
        else
            $("#money").text("- $.");
    });
}

$(document).ready(function () {
    load();
});
