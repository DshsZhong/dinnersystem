$(document).ready(function () {
    update(13);
    $("select[name='line_height']").change(function () {
        update(parseInt($(this).val()));
    });
    $("#print").click(function(){
        $("#print").remove();
        $("select[name='line_height']").remove();
        window.print();
    });
});

function update(height)
{
    $.get("fetch_infor.php?height=" + (height + 5), function (data) {
        $("#data").empty();
        $("#data").append(data);
        $("th").css("line-height" ,height + "px");
    });
}