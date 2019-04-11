$(document).ready(function(){
    $("#loading").css("display" ,"block");
    $.get("backstage.php" ,function(data){
        $("#data").append(data);
        $(".make_order").click(submit);
    }).done(function(){
        $("#loading").css("display" ,"none");  
    });
    
    try {
        get_money((value) => {
            $("#money").text(value + " $.");
        });
    } catch(e) {
        $("#money").text("- $.");
    }
});
