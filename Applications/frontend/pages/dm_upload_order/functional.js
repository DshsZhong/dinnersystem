function submit() {
    $("#submit").text("上傳中...");
    $(".order_id.unupload").each(function(index ,value) {
        var id = $(this).attr("oid");
        make_payment(id, 'dm', function (result) {
            if($.parseJSON(result) == null)
                alert(result);
        });
    });

    $(document).ajaxStop(function () {
        show("成功上傳");
        setTimeout(function(){
            window.history.back();
        }, 1000);
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