
var assign_id = 0;
function collapsable(data) {
    var id = "collapse" + (assign_id++);

    var element = '<div class="panel-group" id="' + id + '">';
    for(var key in data) {
        var value = data[key];
        var content_id = "collapse" + (assign_id++);
        var title = value['title_func'](id ,content_id ,value);
        var content = value['content'];
        if(content == null) {
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

function make_title(parent_id ,content_id ,value){
    var title = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' + parent_id + '" href="#' + content_id + '">' + value['title'] + '</a>' +  
        '<img src="../../images/cross_symbol.png" class="side_btn" name="delete" dish="' + value['id'] + '"></img></h4>';
    return title;
}

function initialize(item) {
    if(item == null) {
        item = new Object();
        item['data'] = new Object();
        item['other'] = new Object();
        item['other']['charge_sum'] = 0;
        item['other']['order_sum'] = 0;
    }
    return item;
}

function make_element(categorized) {
    var inner_item;
    var content = [];

    for(var k1 in categorized['data']) {
        var time_value = categorized['data'][k1];

        for(var k2 in time_value['data']) {
            var factory_value = time_value['data'][k2];
            var content_2 = [];

            for(var k3 in factory_value['data']) {
                var dish_value = factory_value['data'][k3];
                var content_3 = "";

                for(var k4 in dish_value['data']) {
                    var user_value = dish_value['data'][k4];
                    var length = user_value['data'].length;
                    var content_4 = "";
                    
                    for(var k5 in user_value['data']) {
                        inner_item = user_value['data'][k5];
                        content_4 += collapsable([{
                            "title" : inner_item['user']['name'] ,
                            "title_func" : make_title ,
                            "content" : null ,
                            "id" : inner_item['id']
                        }]);
                    }

                    content_3 += content_4;
                }

                content_2.push({
                    "title" : inner_item['dish']['dish_name'] + " x" + dish_value['other']['order_sum'] + "(" + dish_value['other']['charge_sum'] + "$.)" ,
                    "content" : content_3 ,
                    "title_func" : make_title ,
                    "id" : -1
                });
            }
            content.push({
                "title" : inner_item['dish']['factory']['name'] + " x" + factory_value['other']['order_sum'] + "(" + factory_value['other']['charge_sum'] + "$.)" ,
                "content" : collapsable(content_2) ,
                "title_func" : make_title ,
                "id" : -1
            });
        } 
    }

    return collapsable(content);
}

var categorized;
var raw;
function load() {
    raw = new Object();
    categorized = null;
    var today = moment().format("YYYY/MM/DD");
    var url = "../../../backend/backend.php?cmd=select_class&dm=false&esti_start=" + today + "-00:00:00&esti_end=" + today + "-23:59:59";

    $.get(url,function(data){
        var json = $.parseJSON(data);
        for(var key in json) {
            var value = json[key];
            var time = Math.floor(moment(value['payment'][0]['paid_dt'] ,'YYYY-MM-DD HH:mm:ss').unix() / 600);        //accurate to 10 minute.
            var factory = value['dish']['factory']['name'];
            var dname = value['dish']['dish_name'];
            var uname = value['user']['name'];
            var charge = parseInt(value['dish']['dish_cost']);
            var id = value['id']

            categorized                                                              = initialize(categorized);
            categorized['data'][time]                                                = initialize(categorized['data'][time]);
            categorized['data'][time]['data'][factory]                               = initialize(categorized['data'][time]['data'][factory]);
            categorized['data'][time]['data'][factory]['data'][dname]                = initialize(categorized['data'][time]['data'][factory]['data'][dname]);
            categorized['data'][time]['data'][factory]['data'][dname]['data'][uname] = initialize(categorized['data'][time]['data'][factory]['data'][dname]['data'][uname]);

            categorized['other']['charge_sum'] += charge;
            categorized['other']['order_sum'] += 1;
            categorized['data'][time]['other']['charge_sum'] += charge;
            categorized['data'][time]['other']['order_sum'] += 1;
            categorized['data'][time]['data'][factory]['other']['charge_sum'] += charge;
            categorized['data'][time]['data'][factory]['other']['order_sum'] += 1;
            categorized['data'][time]['data'][factory]['data'][dname]['other']['charge_sum'] += charge;
            categorized['data'][time]['data'][factory]['data'][dname]['other']['order_sum'] += 1;
            categorized['data'][time]['data'][factory]['data'][dname]['data'][uname]['data'][id] = value;
            categorized['data'][time]['data'][factory]['data'][dname]['data'][uname]['other']['charge_sum'] += charge;
            categorized['data'][time]['data'][factory]['data'][dname]['data'][uname]['other']['order_sum'] += 1;

            raw[id] = value;
        }
    }).done(function(){
        $("#data").empty();
        $("#chargesum").text("金額總共: 0$.");
        if(categorized != null) {
            $("#data").append(make_element(categorized));
            $("#chargesum").text("金額總共: " + categorized['other']['charge_sum'] + " $.");
            $("img[name='delete']").click(function(){
                var delete_ids = [];
                var items = $(this).parent().parent().parent().find("img[name='delete']")
                .each(function (index, element) {
                    var id = $(this).attr('dish');
                    if(id == -1) return;
                    delete_ids.push(raw[id]);
                });
                delete_orders(delete_ids ,function(){
                    load();
                });
            });
        } else {
            $("#data").append("<h3>沒有未上傳的資料</h3>");
        }
    });
}



function submit() {
    var ids = [];
    for(var key in raw) {
        ids.push(raw[key]['id']);
    }
    make_payment(ids ,'dm' ,function(){
        window.history.back();
    });
}

$(document).ready(function(){
    $("#submit").click(submit);
    load();
});
