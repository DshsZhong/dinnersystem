$(document).ready(function(){
    $("#loading").css("display" ,"block");
    $.get("backstage.php" ,function(data){
        $("#data").append(data);
        $(".make_order").click(submit);
    }).done(function(){
        $("#loading").css("display" ,"none");  
    });
    update_money()
});

function update_money() {
    var money = "../../../backend/backend.php?cmd=get_money";
    $.get(money, (data) => {
        $("#money").text(data + "$.");
    });
}