var data = [];
function run(counter ,update ,callback) {
    if(counter == data.length) {
        callback();
        return;   
    }

    var value = data[counter]; 

    login(value['uid'] ,value['pswd'] ,function() {} ,function(){

    delete_order(value['oid'] ,function() {} ,function() {
    
    logout(function(){
        update(counter + 1)
        run(counter + 1, update ,callback);
    });});});
}


function delete_orders(ids ,callback) {
    var id = window.localStorage.user_id;
    var pswd = window.localStorage.password;
    var base_id = Math.floor(parseInt(id) / 100);

    data = []; 
    for(var key in ids) {
        var value = ids[key];
        var uid = parseInt(value['user']['name']) % 100;
        data.push({
            'oid' : value['id'] ,
            'uid' : (base_id * 100 + uid).toString() ,
            'pswd' : pswd
        });
    }

    logout(function(){
    run(0 ,function(on){
        $("#progress_container").css("display" ,"block");
        $("#progress").css("width" ,(on / data.length * 100) + "%").text(Math.ceil(on / data.length * 100) + "%");
    }, function(){
    login(id ,pswd ,function(){} ,function(){
        $("#error_msg").text("已刪除點單");
        $("#error_msg").removeClass("animated bounceIn").parent().css("display" ,"block");
        setTimeout(function(){ 
            $("#error_msg").addClass("animated bounceIn");
        },30);
        callback();
    })})});
}