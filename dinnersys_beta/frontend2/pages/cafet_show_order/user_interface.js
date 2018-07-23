
var assign_id = 0;
function collapsable(data) {
    var id = "collapse" + (assign_id++);

    var element = '<div class="panel-group" id="' + id + '">';
    for (var key in data) {
        var value = data[key];
        var content_id = "collapse" + (assign_id++);
        var title = value['title_func'](id, content_id, value);
        var content = value['content'];
        if (content == null) {
            element += '<div class="panel panel-default"><div class="panel-heading">' + title + '</div></div>';
        } else {
            element += '<div class="panel panel-default"><div class="panel-heading">' + title +
                '</div><div id="' + content_id + '" class="panel-collapse collapse"><div class="panel-body">' + content +
                '</div></div></div>';
        }
    }
    element += '</div>';

    return element;
}

function make_title(parent_id, content_id, value) {
    var title = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' + parent_id + '" href="#' + content_id + '">' + value['title'] + '</a></h4>';
    return title;
}

function make_title_with_payment(parent_id, content_id, value) {
    var class_no = value['title'].match(/[0-9]{3}/);
    var title = '<div class="father"><div class="title"><h4 class="panel-title"><a data-toggle="collapse" data-parent="#' + parent_id + '" href="#' + content_id + '">' + value['title'] + '</a>' +
        '</h4></div>' +
        '<div class="checker" number="' + class_no +  '"><label class="switch"><input type="checkbox" ' + 
        (value['paid'] ? " checked " : " " ) + 
        ' ><span class="slider"></span></label></div></div>';

    return title;
}

function make_element(categorized) {
    var inner_item;
    var content = [];

    var sorter = [];
    for (var k1 in categorized['data']) {
        var value = categorized['data'][k1];
        var time = value['other']['payment_time'];

        sorter[time] = { 'class_no': k1 };
    }

    for (var k1 in sorter) {
        var class_value = categorized['data'][sorter[k1]['class_no']];
        var content_2 = [];
        for (var k2 in class_value['data']) {
            var time_value = class_value['data'][k2];

            for (var k3 in time_value['data']) {
                var factory_value = time_value['data'][k3];
                var content_3 = [];

                for (var k4 in factory_value['data']) {
                    var dish_value = factory_value['data'][k4];
                    var content_4 = "";

                    for (var k5 in dish_value['data']) {
                        var user_value = dish_value['data'][k5];
                        var length = user_value['data'].length;
                        var content_5 = "";

                        for (var k6 in user_value['data']) {
                            inner_item = user_value['data'][k6];
                            content_5 += collapsable([{
                                "title": inner_item['user']['name'],
                                "title_func": make_title,
                                "content": null,
                                "id": -1
                            }]);
                        }

                        content_4 += content_5;
                    }

                    content_3.push({
                        "title": inner_item['dish']['dish_name'] + " x" + dish_value['other']['order_sum'] + "(" + dish_value['other']['charge_sum'] + "$.)",
                        "content": content_4,
                        "title_func": make_title,
                        "id": -1
                    });
                }
                content_2.push({
                    "title": inner_item['dish']['factory']['name'] + " x" + factory_value['other']['order_sum'] + "(" + factory_value['other']['charge_sum'] + "$.)",
                    "content": collapsable(content_3),
                    "title_func": make_title,
                    "id": -1
                });
            }
        }
        content.push({
            "title": inner_item['user']['class_no'] + "(" + class_value['other']['charge_sum'] + "$.)",
            "content": collapsable(content_2),
            "title_func": make_title_with_payment,
            "id": inner_item['user']['class_no'],
            "paid": class_value['other']['paid']
        });
    }
    return collapsable(content);
}

function initialize(item) {
    if (item == null) {
        item = new Object();
        item['data'] = new Object();
        item['other'] = new Object();
        item['other']['charge_sum'] = 0;
        item['other']['paid'] = 0;
        item['other']['order_sum'] = 0;
        item['other']['payment_time'] = 0;
    }
    return item;
}

var categorized;
var raw;
function load(done) {
    raw = new Object();
    categorized = null;
    var today = moment().format("YYYY/MM/DD");
    var url = "../../../backend/backend.php?cmd=select_everyone&dm=true&facto=false&esti_start=" + today + "-00:00:00&esti_end=" + today + "-23:59:59";

    $.get(url, function (data) {
        var json = $.parseJSON(data);
        for (var key in json) {
            var value = json[key];
            var time = Math.floor(moment(value['payment'][0]['paid_dt'], 'YYYY-MM-DD HH:mm:ss').unix() / 600);        //accurate to 10 minute.
            var factory = value['dish']['factory']['name'];
            var dname = value['dish']['dish_name'];
            var uname = value['user']['name'];
            var charge = parseInt(value['dish']['dish_cost']);
            var id = value['id'];
            var class_no = value['user']['class_no'];
            var paid_time = moment(value['payment'][1]['paid_dt'], 'YYYY-MM-DD HH:mm:ss').unix();
            var cafet_paid = (value['payment'][2]['paid'] == "true");

            categorized = initialize(categorized);
            categorized['data'][class_no] = initialize(categorized['data'][class_no]);
            categorized['data'][class_no]['data'][time] = initialize(categorized['data'][class_no]['data'][time]);
            categorized['data'][class_no]['data'][time]['data'][factory] = initialize(categorized['data'][class_no]['data'][time]['data'][factory]);
            categorized['data'][class_no]['data'][time]['data'][factory]['data'][dname] = initialize(categorized['data'][class_no]['data'][time]['data'][factory]['data'][dname]);
            categorized['data'][class_no]['data'][time]['data'][factory]['data'][dname]['data'][uname] = initialize(categorized['data'][class_no]['data'][time]['data'][factory]['data'][dname]['data'][uname]);

            categorized['other']['charge_sum'] += charge;
            categorized['other']['order_sum'] += 1;
            categorized['data'][class_no]['other']['charge_sum'] += charge;
            categorized['data'][class_no]['other']['order_sum'] += 1;
            categorized['data'][class_no]['other']['paid'] = cafet_paid;
            categorized['data'][class_no]['other']['payment_time'] = Math.max(categorized['data'][class_no]['other']['payment_time'], paid_time);
            categorized['data'][class_no]['data'][time]['other']['charge_sum'] += charge;
            categorized['data'][class_no]['data'][time]['other']['order_sum'] += 1;
            categorized['data'][class_no]['data'][time]['data'][factory]['other']['charge_sum'] += charge;
            categorized['data'][class_no]['data'][time]['data'][factory]['other']['order_sum'] += 1;
            categorized['data'][class_no]['data'][time]['data'][factory]['data'][dname]['other']['charge_sum'] += charge;
            categorized['data'][class_no]['data'][time]['data'][factory]['data'][dname]['other']['order_sum'] += 1;
            categorized['data'][class_no]['data'][time]['data'][factory]['data'][dname]['data'][uname]['data'][id] = value;
            categorized['data'][class_no]['data'][time]['data'][factory]['data'][dname]['data'][uname]['other']['charge_sum'] += charge;
            categorized['data'][class_no]['data'][time]['data'][factory]['data'][dname]['data'][uname]['other']['order_sum'] += 1;

            if (raw[class_no] == null) raw[class_no] = [];
            raw[class_no].push(value);
        }
    }).done(done);
}

$(document).ready(function () {
    load(refresh);
});

function refresh() {
    $("#data").empty();
    $("#chargesum").text("金額總共: 0$.");
    if (categorized != null) {
        $("#data").append(make_element(categorized));
        $("#chargesum").text("金額總共: " + categorized['other']['charge_sum'] + " $.");
        $("img[name='payment']").click(function () {
            var id = $(this).attr('classno');
            var ids = [];
            $.each(raw[id], function (index, value) {
                ids.push(value['id']);
            });
            make_payment(ids, 'cafet', function () {
                $("#error_msg").text("已成功付款");
                load();
            });
        });
    } else {
        $("#data").append("<h3>還沒有人送出</h3>");
    }
    
    var last = null;
    $(".checker").click(function () {
        var target = $(this).find("input[type='checkbox']").is(':checked');
        if(!(last == target || last == null)) {
            $.get("payment.php?class_no=" + $(this).attr('number') + "&target=" + target.toString(), function () {});
        }
        last = target;
    });
}
