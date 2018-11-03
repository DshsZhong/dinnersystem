function load() {
    $("#loading").css("display" ,"block");  
    $.get("backstage.php?cmd=collapse" ,function(dom_object) {
        $("#data").empty();
        if (dom_object != "") {
            $("#data").empty();
            $("#data").append(dom_object);
            $(".checker").click(payment);
        } else {
            $("#data").append("<h3>沒有上傳過來的資料</h3>");
        }
    }).done(function(){
        $("#loading").css("display" ,"none");  
    });
}

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

$(document).ready(function () {
    load();
});
