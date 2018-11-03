$(document).ready(function () {
    update(10);
    $("select[name='line_height']").change(function () {
        update(parseInt($(this).val()));
    });
});

function update(width)
{
    $.get("fetch_infor.php?height=" + (width + 5), function (data) {
        $("#data").empty();
        $("#data").append(data);
        $("th").css("line-height" ,width + "px");
    });
}