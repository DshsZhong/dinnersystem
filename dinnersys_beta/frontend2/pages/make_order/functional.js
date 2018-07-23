var result;
var data = [];
var adapt = {
    "" :"不對的使用者名稱" ,
    "廠商需要 120 分鐘準備餐點" : "十點之後無法訂餐"
};

function run(counter ,update ,callback) {
    if(counter == data.length) {
        callback();
        return;   
    }

    var value = data[counter]; 

    login(value['uid'] ,value['pswd'] ,function() {} ,function(){

    make_order(value['did'] ,function(data) {
        if($.isNumeric(data)) return;
        var tmp = adapt[data];
        if(tmp != null) data = tmp;

        if(result[data] == undefined) {
            result[data] = 1;
        } else {
            result[data] += 1;
        }
    } ,function() {
    
    logout(function(){
        update(counter + 1)
        run(counter + 1, update ,callback);
    });});});
}


function submit() {
    result = new Object();
    data = [];
    var id = window.localStorage.user_id;
    var password = window.localStorage.password;
    var invalid = false;

    $(".dish_content").each(function(index ,value){
        var base_id = Math.floor(parseInt(id) / 100);
        var uid = parseInt($(this).find('input').val()); 
        if(!(/^([0-9]{1,2})$/.test(uid))) {
            invalid = true;
            return;
        }
        var did = $(this).find('input').attr('name').split('_')[1];
        data.push({'uid' : (base_id * 100 + uid).toString() ,'pswd' : password ,'did' : did});
    });
    if(invalid) {
        show("不合法的使用者名稱，請確認後再試");
        return;
    }

    if(data.length == 0) {
        $("#error_msg").text("請輸入點單資訊");
        $("#error_msg").removeClass("animated bounceIn").parent().css("display" ,"block");
        setTimeout(function(){ 
            $("#error_msg").addClass("animated bounceIn");
        },30);
        return;
    }

    
    logout(function(){
    run(0 ,function(on){
        $("#progress_container").css("display" ,"block");
        $("#progress").css("width" ,(on / data.length * 100) + "%").text(Math.ceil(on / data.length * 100) + "%");
    } ,function(){
        login(id ,password ,function() {} ,show_user);
    });});
}

function show_user() {
    var msg = "成功點餐"; 
    var maxi = -1;
    
    for(var key in result) {
        if(result[key] > maxi) {
            maxi = result[key];
            msg = key;
        } 
    }
    show(msg);
    $("#progress_container").css("display" ,"none");

    if(msg == "成功點餐") {
        setTimeout(function(){
            window.history.back();
        } ,1000);   
    }
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



function update() {
    var charge_sum = 0;
    $(".dish_content").each(function(index ,value){
        var uid = parseInt($(this).find('input').val());
        if(!(/^([0-9]{1,2})$/.test(uid))) {
            return;
        }
        var did = $(this).find('input').attr('name').split('_')[1];
        charge_sum += parseInt(dish_array[did]['dish_cost']);
    });
    $("#chargesum").text("金額總共: " + charge_sum + "$.");

    setTimeout(update ,500);
}