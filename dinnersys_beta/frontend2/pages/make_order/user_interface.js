
var assign_id = 0;
function collapsable(data) {
    var id = "collapse" + (assign_id++);

    var element = '<div class="panel-group" id="' + id + '">';
    for(var key in data) {
        var value = data[key];
        var content_id = "collapse" + (assign_id++);
        var title = value['title_func'](id ,content_id ,value);
        var content = value['content'];
        
        element += '<div class="panel panel-default"><div class="panel-heading">' + title + 
            '</div><div id="' + content_id + '" class="panel-collapse collapse"><div class="panel-body">' + content +
            '</div></div></div>';
    }
    element += '</div>';

    return element;
}

function make_title(parent_id ,content_id ,value){
    var title = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' + parent_id + '" href="#' + content_id + '">' + value['title'] + '</a></h4>';
    return title;
}

function make_title_with_another(parent_id ,content_id ,value){
    var title = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' + parent_id + '" href="#' + content_id + '">' + value['title'] + '</a>' +  
        '<img src="../../images/another.png" class="side_btn" name="another" dish="' + value['dish_id'] + '"></img></h4>';
    return title;
}


function make_column() {
    var id = $(this).attr('dish'); 
    var element = '<div class="dish_content"><input name="user_' + id + 
        '" type="text" placeholder="座號 ex.[07]"><button name="delete_btn">刪除</button></div>';
    $("#dish_" + id).append(element);

    $("#dish_" + id).parent().parent().collapse('show');

    $("button[name='delete_btn']").off('click').click(function(){
        var id = $(this).parent().parent().attr('id').split('_')[1];
        $(this).parent().remove();
    });
}


var factory_array = new Object();
var dish_array = new Object();
$(document).ready(function(){
    $.get("../../../backend/backend.php?cmd=show_dish", function( data ) {
        update();
        var json = JSON.parse(data);
        
        for(var key in json) {
            var value = json[key];
            var fname = value['factory']['name'];
            var fid = value['factory']['id'];
            var did = value['dish_id'];

            if(value['is_idle'] === "1")  continue;
            if(fid === "2" || fid === "4")  continue;
            

            if(factory_array[fid] == null) {
                factory_array[fid] = new Object();        
                factory_array[fid]['data'] = new Object();
            }
            factory_array[fid]['fname'] = fname;
            factory_array[fid]['data'][did] = value;

            dish_array[did] = value;
        }

    }).done(function(){
        var data = [];
        
        for(var key in factory_array) {
            var factory = factory_array[key];
            var content = [];
            for(var key2 in factory['data']) {
                var dish = factory['data'][key2];
                content.push({
                    "content" : '<div id="dish_' + dish['dish_id'] + '"></div>' ,
                    "title_func" : make_title_with_another ,
                    "title" : (dish['dish_name'] + "(" + dish['dish_cost'] + "$.)") ,
                    'dish_id' : dish['dish_id']
                });
            }
            
            data.push(
                {"content" : collapsable(content) ,"title_func" : make_title ,"title" : factory['fname']}
            );
        }
        $("#data").append(collapsable(data));
        $("img[name='another']").click(make_column);
    });
});