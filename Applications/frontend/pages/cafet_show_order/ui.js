$(document).ready(function () {
    load();
});

function load() {
    $("#loading").css("display", "block");
    $.get("backstage.php", function (result) {
        $("#data").empty();
        $("#data").append(result);
        $(".delete").click(del_order);
    }).done(function () {
        $("#loading").css("display", "none");
    });
}
