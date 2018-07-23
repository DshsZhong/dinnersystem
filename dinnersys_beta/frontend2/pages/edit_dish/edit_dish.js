function update() {
    $.get(window.location.pathname + "back_stage.php?cmd=fetch", function (data) {
        $("#data").empty();
        $("#data").append('<table id="table" width="100%;text-align:center;">' + data + '</table>');
    });
}
$(document).ready(function () {
    update();
});

$(document).ready(function () {
    $("#update").click(function () {
        $('#table > tbody > tr').each(function (index, value) {
            var id = $(this).attr('id');
            if (id == undefined) return;

            var name = $("#name_" + id).val();
            var cost = $("#cost_" + id).val();
            var idle = $("#idle_" + id).prop("checked");

            var update_url = "../../../backend/backend.php?cmd=update_dish&id=" + id +
                "&dish_name=" + name +
                "&charge_sum=" + cost +
                "&is_vege=MEAT" +
                "&is_idle=" + (idle ? "true" : "false");

            $.get(update_url, function (data) {
                if (data != "Successfully updated food.")
                    alert(" 無法更新餐點\n" + data);
            });
        });
        update();
    });

    $("#reset").click(function () {
        $("#update").prop('disabled' ,'true');
        $.get("back_stage.php?cmd=reset", function (data) {
            update();
            $("#update").removeAttr("disabled");
        });
    });
});
