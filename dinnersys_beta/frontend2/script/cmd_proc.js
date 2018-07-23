var adapt = {
    "-5" : "3" ,
    "-6" : "1" ,
    "-7" : "4" ,
    "-8" : "2" ,
};



$(document).ready(function(){
    var now = Math.floor(Date.now() / 1000);
    if(now - window.localStorage.login_date > 3600 || window.localStorage.user_data == null) {
        window.localStorage.clear();
        window.location.replace('login.html');
    }
    
    var json = JSON.parse(window.localStorage.user_data);
    var id = json['id'];
    window.localStorage.fid = adapt[id]; 

    var opers = [];
    $.each(json['valid_oper'], function(index ,value) {
        var tmp = Object.keys(value)[0];
        opers[tmp] = true;
    });
    
    if(opers['select_class']) {
        $("#get_class_order").css("display" ,"block");
        $("#update_password").css("display" ,"block");
        $("#get_menu").css("display" ,"block");
    }

    if(opers['select_facto']) {
        $("#get_facto_order").css("display" ,"block");
        $("#edit_dish").css("display" ,"block");
    }

    if(opers['select_everyone']) {
        $("#get_everyone_order").css("display" ,"block");
        $("#edit_dish").css("display" ,"block");
    }
});

function logout()
{
	$.get( "../backend/backend.php?cmd=logout", function( data ) {
	    window.localStorage.clear();
		window.location = "login.html";
	});
}