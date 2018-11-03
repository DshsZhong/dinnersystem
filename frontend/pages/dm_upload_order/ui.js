function load() {
    $("#unupload_loading").css("display" ,"block");
    $.get("backstage.php?cmd=collapse&data=unupload" ,function(dom_object) {
        $("#unupload_data").empty();
        if (dom_object != "") {
            $("#unupload_data").append(dom_object);
        } else {
            $("#unupload_data").append("<h3>沒有未上傳的資料</h3>");
        }
    }).done(function(){
        $("#unupload_loading").css("display" ,"none");
    });

    
    $("#upload_loading").css("display" ,"block");
    $.get("backstage.php?cmd=collapse&data=upload" ,function(dom_object) {
        $("#data").empty();
        if (dom_object != "") {
            $("#upload_data").append(dom_object);
        } else {
            $("#upload_data").append("<h3>沒有已上傳的資料</h3>");
        }
    }).done(function(){
        $("#upload_loading").css("display" ,"none");
    });


    $.get("backstage.php?cmd=charge_sum&data=unupload" ,function(sum) {
        $("#unupload_chargesum").text("金額總共: " + parseInt(sum) + "$.");
    });
    $.get("backstage.php?cmd=charge_sum&data=upload" ,function(sum) {
        $("#upload_chargesum").text("已上傳金額: " + parseInt(sum) + "$.");
    });
}

$(document).ready(function () {
    load();
});
