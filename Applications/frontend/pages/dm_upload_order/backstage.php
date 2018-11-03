<?php

error_reporting(0);

require_once(__DIR__ . '/../../../backend/backend_proc/backend_main.php');
require_once(__DIR__ . "/../../collapsable/tree.php");


switch($_GET['data']) {
    case 'unupload':
        $param = ['cmd' => 'select_class' ,
            'usr' => 'true' ,'dm' => 'false' ,
            'esti_start' => date("Y/m/d") . '-00:00:00' ,
            'esti_end' => date("Y/m/d") . '-23:59:59'];
        break;
    case 'upload':
        $param = ['cmd' => 'select_class' ,
            'usr' => 'true' ,'dm' => 'true' ,
            'esti_start' => date("Y/m/d") . '-00:00:00' ,
            'esti_end' => date("Y/m/d") . '-23:59:59'];
        break;
}
$obj = new \backend_proc\backend_main($param);
$data = $obj->run();

switch($_GET['cmd']) {
    case 'collapse' :
        $categorize = new tree(
            [
                ['child_key' => ['dish' , 'department' ,'factory' ,'id']   ,'func' => "factory_dom"],
                ['child_key' => ['dish' ,'id']                             ,'func' => "dish_dom"],
                ['child_key' => ['id']                                     ,'func' => "user_dom"],
            ] ,0
        );
        if($data == null) die();
        foreach($data as $key => $value) {
            $categorize->add($value);
        }
        $categorize->build_info();
        echo $categorize->get_collapsable();
        break;
    case 'charge_sum':
        $sum = 0;
        foreach($data as $key => $value) {
            $sum += $value->money->charge;
        }
        echo $sum;
        break;
}

?> 



<?php

function factory_dom($parent_id ,$content_id ,$content ,$value){
    $title = $value->info->fname . ' x' . $value->info->count . '(' . $value->info->charge_sum .'$.)'; 
    $title_dom = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' .
        $content_id . '">' . $title . '</a></h4>';
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
    $title = $value->info->uname . '(' . $value->info->dcharge . '$.)';
    $title_dom = '<h4 class=" panel-title"><a style="width:80%" data-toggle="collapse" data-parent="#' . $parent_id . '" href="#' . $content_id . '">' .
        $title . '</a></h4>';
    return '<div class="panel panel-default"><div class="panel-heading">' . $title_dom . 
        '</div><div id="' . $content_id . '" class="panel-collapse collapse"><div class="panel-body">' . 
        '<div class="order_id ' . ($value->info->paid['dinnerman'] ? "upload" : "unupload") . '" oid="' . $value->data[0]->id . '"></div></div></div></div>';
}
?>