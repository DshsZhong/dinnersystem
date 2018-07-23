
function normal_login()
{
    var uid = $("#id").val();
    var pswd = $("#password").val();

    login(uid ,pswd ,function(result){
        if(result == null) {
            $("#error_msg").text("錯誤的帳號密碼");
            $("#error_msg").removeClass("animated bounceIn")
            setTimeout(function(){ 
                $("#eror_msg").addClass("animated bounceIn")
            },30);
        } else {
            window.localStorage.user_data = JSON.stringify(result);
            window.localStorage.user_id = uid;
            window.localStorage.password = pswd;
            window.localStorage.login_date = Math.floor(Date.now() / 1000);
            window.location = 'index.html';
        }
    } ,function(){});
}