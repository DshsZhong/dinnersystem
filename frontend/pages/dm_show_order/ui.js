function normal_order(value) {
    var seat_no = parseInt(value['user']['seat_no']) % 100;
    var highlight = (value['user']['id'] !== value['order_maker']['id']);
    var ret = '<div id="' + value['id'] + '" class="order"><div class="info"><div class="index index_adjust' + (highlight ? " red-highlight " : "") +
        '"><label>' + value['user']['name'] + '(' + seat_no + ')' + '</label></div>';
    return ret + '</div><div class="info"><div class="index dish_name' +
        (highlight ? " red-highlight " : "") + '"><label>' +
        value['dish']['dish_name'] + '(' + value['dish']['dish_cost'] + '$.)' +
        '</label></div></div><hr /></div>';
}
function editable_order(value) {
    var seat_no = parseInt(value['user']['seat_no']) % 100;
    var highlight = (value['user']['id'] !== value['order_maker']['id']);
    var ret = '<div id="' + value['id'] + '" class="order editable"><div class="info"><div class="index index_adjust' + (highlight ? " red-highlight " : "") +
        '"><label>' + value['user']['name'] + '(' + seat_no + ')' + '</label></div>';

    ret += '<div class="extend extend_adjust">';
    ret += '<div class="checker payment"><label class="switch">' +
        '<input type="checkbox" ' + (value['money']['payment'][0]['paid'] == 'true' ? "checked" : "") +
        '><span class="slider"></span></label></div>';
    ret += '</div><div class="value value_adjust clickable">' +
            '<img src="../../images/cross_symbol.png"></img></div>';

    return ret + '</div><div class="info"><div class="index dish_name' +
        (highlight ? " red-highlight " : "") + '"><label>' +
        value['dish']['dish_name'] + '(' + value['dish']['dish_cost'] + '$.)' +
        '</label></div></div><hr /></div>';
}

var payment_data = [];

var unupload_real_paid = 0;
var unupload_should_paid = 0;
var upload_paid = 0;


function load() {
    var today = moment().format("YYYY/MM/DD");
    var url = "../../../backend/backend.php?cmd=select_class&esti_start=" + today + "-00:00:00&esti_end=" + today + "-23:59:59";

    $("#loading").css("display" ,"block");
    $.get(url, function (data) {
        var json = $.parseJSON(data);
        for (var key in json) {
            var value = json[key];
            payment_data[value['id']] = (value['money']['payment'][0]['paid'] == 'true');

            if(value['money']['payment'][1]['paid'] === 'true') {
                upload_paid += parseInt(value['dish']['dish_cost']);
                $("#data_show").append(normal_order(value));
            } else {
                $("#data_editable").append(editable_order(value));
                unupload_should_paid += parseInt(value['dish']['dish_cost']);
                unupload_real_paid += (value['money']['payment'][0]['paid'] === 'true' ? parseInt(value['dish']['dish_cost']) : 0);    
            }
        }
        $(".value_adjust.clickable").off('click').click(del_order);
        $(".checker.payment").off('click').click(do_payment);
        update_paids();
    }).done(function(){
        $("#loading").css("display" ,"none");
    });
}

function update_paids() {
    $("#unupload_real_paid").empty().append("實付: " + unupload_real_paid + " $.");
    $("#unupload_should_paid").empty().append("應付: " + unupload_should_paid + " $.");
    $("#upload_paid").empty().append("已上傳金額: " + upload_paid + " $.");
}


$(document).ready(function () {
    load();
    $(".payment_all").click(payment_all);
});

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