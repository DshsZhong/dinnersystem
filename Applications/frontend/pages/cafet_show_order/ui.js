$(document).ready(function(){
    load();
    $("select[name='sorter']").change(load);
});

function load() {
    $("select[name='sorter'] option:selected").each(function () {
        $("#loading").css("display" ,"block");
        $.get("backstage.php?sorter=" + $(this).attr("value") ,function(result) {
            $("#data").empty();
            $("#data").append(result);
            $(".checker").click(payment);
            $(".delete").click(del_order);
        }).done(function(){
            $("#loading").css("display" ,"none");  
        });
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