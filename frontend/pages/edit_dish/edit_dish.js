function update() {
    $.get(window.location.pathname + "back_stage.php?cmd=fetch", function (data) {
        $("#data").empty();
        $("#data").append(data);
    });
}

$(document).ready(function () {
    update();
    $("#update").click(function () {
        $("#update").prop('disabled', 'true');
        $("#reset").prop('disabled', 'true');
        $.get("/../../dinnersys_beta/backend/backend.php?cmd=show_dish" ,update_necessary)
    });
    $("#reset").click(function () {
        $.get("/../../dinnersys_beta/backend/backend.php?cmd=show_dish" ,reset)
    });
});

function update_necessary(data)
{
    var data = JSON.parse(data);
    var dish = {};
    for(var key in data) dish[data[key]["dish_id"]] = data[key];

    $('#table > tbody > tr').each(function (index, value) {
        var id = $(this).attr('id');
        if (id == undefined) return;

        var name = $("#name_" + id).val();
        var cost = $("#cost_" + id).val();
        var idle = $("#idle_" + id).prop("checked");
        var same = (
            dish[id]['dish_name'] == name &&
            dish[id]['dish_cost'] == cost &&
            dish[id]['is_idle'] == idle
        );
        if(same) return;

        var update_url = "/../../dinnersys_beta/backend/backend.php?cmd=update_dish&id=" + id +
            "&dish_name=" + name +
            "&charge_sum=" + cost +
            "&is_vege=MEAT" +
            "&is_idle=" + (idle ? "true" : "false");

        $.get(update_url, function (data) {
            if (!(data == "Successfully updated food." || data == "Nothing to update."))
                alert("無法更新餐點\n" + data);
        });
    });
    $(document).ajaxStop(function () {
        window.history.back();
    });
}

function reset(data)
{
    var data = JSON.parse(data);
    for(var key in data) {
        var item = data[key];
        var same = (
            item['dish_name'] == "閒置中的餐點" &&
            item['dish_cost'] == "55" &&
            item['is_idle'] == true
        );
        if(same) continue;
        var update_url = "/../../dinnersys_beta/backend/backend.php?cmd=update_dish&id=" + item["dish_id"] +
            "&dish_name=閒置中的餐點&charge_sum=55&is_vege=MEAT&is_idle=true";

        $.get(update_url, function (data) {
            if (!(data == "Successfully updated food." || data == "Nothing to update."))
                alert("無法更新餐點\n" + data);
        });
    }
    
    $(document).ajaxStop(function () {
        window.history.back();
    });
}
