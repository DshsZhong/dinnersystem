
function normal_login()
{
    var uid = $("#id").val();
    var pswd = $("#password").val();

    login(uid ,pswd ,function(result){
        if(result == null) {
            show("帳號或密碼不對");
        } else {
            window.localStorage.user_data = JSON.stringify(result);
            window.localStorage.user_id = uid;
            window.localStorage.password = pswd;
            window.localStorage.login_date = Math.floor(Date.now() / 1000);
            window.location = 'index.html';
        }
    } ,function(){});
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
