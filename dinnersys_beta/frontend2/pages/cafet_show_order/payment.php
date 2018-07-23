<?php
error_reporting(0);

$cno = $_GET['class_no'];
$target = $_GET['target'];

$today = date("Y/m/d");

include(__DIR__ . '/../../../backend/backend_proc/backend_main.php');
$obj = new backend_main(['cmd' => 'select_everyone' 
    ,'dm' => 'true' ,'facto' => 'false' 
    ,'esti_start' => $today . '-00:00:00' ,'esti_end' => $today . '-23:59:59']);
$json = json_decode($obj->run() ,true);

echo json_encode($json);
foreach($json as $key => $value) {
    if($cno == $value['user']['class_no']) {
        $tmp = new backend_main(['cmd' => 'payment_cafet' ,'target' => $target ,'order_id' => $value['id']]);
        $tmp->run();
    }
}
?>