<?php

error_reporting(0);

require_once(__DIR__ . '/../../../backend/backend_proc/backend_main.php');
require_once(__DIR__ . "/../../collapsable/tree.php");

$obj = new \backend_proc\backend_main(['cmd' => 'select_other' ,
    'dm' => 'true' ,
    'esti_start' => date("Y/m/d") . '-00:00:00' ,
    'esti_end' => date("Y/m/d") . '-23:59:59']);
$data = $obj->run();


$categorize = new tree(
    [
        ['child_key' => ['user' ,'class' ,'class_no']                       ,'func' => "class_dom"],
        ['child_key' => ['payment' ,'paid']                                 ,'func' => "paid_dom"],
        ['child_key' => ['dish' ,'department' ,'factory' ,'id']             ,'func' => "factory_dom"],
        ['child_key' => ['dish' ,'id']                                      ,'func' => "dish_dom"],
        ['child_key' => ['id']                                              ,'func' => "user_dom"],
    ] ,0
);

$tmp = [];
foreach($data as $key => $value) {
    $categorize->add($value);
}

$sorter = "sort_time";
switch($_GET['sorter'])
{
    case "time":
        $sorter = "sort_dinnerman"; break;
    case "class":
        $sorter = "sort_class"; break;
    case "paid":
        $sorter = "sort_paid"; break;
}
$categorize->build_info($sorter);

echo $categorize->get_collapsable();



?> 



<?php
function class_dom($parent_id ,$content_id ,$content ,$value){
    $title = $value->info->class . ' x' . $value->info->count . '(' . $value->info->charge_sum .'$.)'; 
    $title_dom = '<div class="father"><div class="title"><h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' .
        $content_id . '">' . $title . '</a></h4></div><div class="checker ' . $value->info->class . '" number="' . $value->info->class . '"><label class="switch"><input type="checkbox" ' .
        ($value->info->paid['cafeteria'] ? " checked " : " " ) . ' ><span class="slider"></span></label></div></div>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . $content .
        '</div></div></div>';
}
function paid_dom($parent_id ,$content_id ,$content ,$value){
    $title = ($value->info->paid['cafeteria'] ? "已經付款" : "尚未付款") . ' x' . $value->info->count . '(' . $value->info->charge_sum .'$.)'; 
    $title_dom = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' .
        $content_id . '">' . $title . '</a></h4>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . $content .
        '</div></div></div>';
}
function factory_dom($parent_id ,$content_id ,$content ,$value){
    $title = $value->info->fname . ' x' . $value->info->count . '(' . $value->info->charge_sum .'$.)'; 
    $title_dom = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' .
        $content_id . '">' . $title . '</a></h4>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . $content .
        '</div></div></div>';
}
function dish_dom($parent_id ,$content_id ,$content ,$value){
    $title = $value->info->dname . ' x' . $value->info->count . '(' . $value->info->charge_sum .'$.)' . '[' . $value->info->dcharge .'$.]'; 
    $title_dom = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' . $content_id . '">' .
        $title . '</a></h4>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . $content .
        '</div></div></div>';
}
function user_dom($parent_id ,$content_id ,$content ,$value){
    $title = $value->info->uname . '(' . $value->info->dcharge . '$.)';
    $title_dom = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' . $content_id . '">' .
        $title . '</a></h4>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . 
        '<div class="order_id ' . $value->info->class . '" oid="' . $value->data[0]->id . '"><button class="delete">刪除</button></div></div></div></div>';
}
?>