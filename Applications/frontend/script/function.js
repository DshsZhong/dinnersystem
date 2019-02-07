//every function here is synchornized.

var time = "-12:00:00";

function login(uid, pswd, callback, done) {
    var json;
    var hashed = JSON.stringify({
        "id": uid,
        "password": pswd,
        "time": Math.floor(Date.now() / 1000).toString()
    });
    hashed = sha512(hashed);

    $.get("/dinnersys_beta/backend/backend.php?cmd=login&id=" + uid + "&hash=" + hashed + "&device_id=website", function (data) {
        json = data;
    }).done(function () {
        callback(json);
        done();
    });
}

function logout(done) {
    $.get("/dinnersys_beta/backend/backend.php?cmd=logout", function (data) {

    }).done(function () {
        done();
    });
}


function make_payment(id, type, pin, callback, target = true) {
    var uid = window.localStorage.user_id;
    var pswd = window.localStorage.password;
    var hashed = JSON.stringify({
        "id": id,
        "usr_id": uid,
        "usr_password": pswd,
        "pmt_password": pin,
        "time": Math.floor(Date.now() / 1000).toString()
    });
    hashed = sha512(hashed)

    var url = "/dinnersys_beta/backend/backend.php?cmd=payment_" + type + "&target=" + target + "&order_id=" + id + "&hash=" + hashed;
    $.get(url, function (data) {
        callback(data);
    });
}




function delete_order(oid, type, callback, done) {
    var json;
    var url = "/dinnersys_beta/backend/backend.php?";
    switch (type) {
        case "self":
            url += "cmd=delete_self";
            break;
        case "class":
            url += "cmd=delete_dm";
            break;
        case "everyone":
            url += "cmd=delete_everyone";
            break;
    }

    $.get(url + "&order_id=" + oid, function (data) {
        json = data;
    }).done(function () {
        callback(json);
        done();
    });
}


function make_order(login_id, did, type, callback) {
    var result;
    var esti_recv = moment().format("YYYY/MM/DD") + time;
    var url = "/dinnersys_beta/backend/backend.php?";
    switch (type) {
        case "self":
            url += "cmd=make_self_order";
            break;
        case "class":
            url += "cmd=make_class_order&target_id=" + login_id;
            break;
        case "everyone":
            url += "cmd=make_everyone_order&target_id=" + login_id;
            break;
    }

    $.get(url + "&dish_id[]=" + did + "&time=" + esti_recv, function (data) {
        result = data;
    }).done(function () {
        callback(result);
    });
}
