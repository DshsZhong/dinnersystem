<?php

error_reporting(0);

require_once(__DIR__ . '/../../../../backend/backend_proc/backend_main.php');
require_once(__DIR__ . "/../../../collapsable/tree.php");

date_default_timezone_set('Asia/Taipei');
$obj = new \backend_proc\backend_main(['cmd' => 'select_facto' ,
    'payment' => 'true' ,
    'esti_start' => date("Y/m/d") . '-00:00:00' ,
    'esti_end' => date("Y/m/d") . '-23:59:59']);
$data = $obj->run();

if($data == null) die();

$categorize = new tree(
    [
        ['child_key' => ['user' ,'class' ,'class_no']         ,'func' => "class_dom"],
        ['child_key' => ['vdish' ,'department' ,'id']         ,'func' => "department_dom"],
        ['child_key' => ['vdish' ,'id']                       ,'func' => "dish_dom"],
        ['child_key' => ['id']                                ,'func' => "user_dom"],
    ] ,0
);

foreach($data as $key => $value) {
    $categorize->add($value);
}
$categorize->build_info("sort_cafeteria");
echo $categorize->get_collapsable();


?> 



<?php

function class_dom($parent_id ,$content_id ,$content ,$value){
    $title = $value->info->class . ' x' . $value->info->count . '(' . $value->info->charge_sum .'$.)'; 
    $title_dom = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' .
        $content_id . '">' . $title . '</a></h4>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . $content .
        '</div></div></div>';
}
function department_dom($parent_id ,$content_id ,$content ,$value){
    $code = $value->info->class . '_' . $value->info->department;
    $title = $value->info->department . ' x' . $value->info->count; 
    $title_dom = '<div><h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' .
        $content_id . '">' . $title . '</a></h4></div>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . $content .
        '</div></div></div>';
}
function dish_dom($parent_id ,$content_id ,$content ,$value){
    $title = $value->info->dname . ' x' . $value->info->count . '(' . $value->info->charge_sum .'$.)'; 
    $title_dom = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' . $content_id . '">' .
        $title . '</a></h4>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . $content .
        '</div></div></div>';
}
function user_dom($parent_id ,$content_id ,$content ,$value){
    $code = $value->info->class . '_' . $value->info->department;
    $title = $value->info->uname . '(' . $value->info->charge_sum . '$.)';
    $title_dom = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' . $content_id . '">' .
        $title . '</a></h4>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . 
        '<div class="order_id ' . $code . '" oid="' . $value->data[0]->id . '"></div></div></div></div>';
}
?>