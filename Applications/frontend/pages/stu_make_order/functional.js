var result;
var data = [];

function submit() {
    var over_time = (moment().hour() >= 10);
    var did = $(this).parent().attr('id').split('_')[1];
    
    make_order(null ,did ,"self" ,function(result) {});

    $(document).ajaxStop(function() {
        if(over_time) {
            show("十點之後無法點餐");
        } else {
            show("成功點餐");
            setTimeout(function(){
                window.history.back();
            } ,1000);
        }
    });
}


function show(msg) {
    $("#error_msg").text(msg);
    $("#error_msg").removeClass("animated bounceIn").parent().css("display" ,"block");
    setTimeout(function(){ 
        $("#error_msg").addClass("animated bounceIn");
    },30);

    setTimeout(function(){ 
        $("#error_msg").parent().css("display" ,"none");
    },1000);
}
