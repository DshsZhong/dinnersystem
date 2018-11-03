<?php

error_reporting(0);
include(__DIR__ . '/../../../../backend/backend_proc/backend_main.php');
include(__DIR__ . '/../../../printer_show/sort_department.php');
$obj = new \backend_proc\backend_main(['cmd' => 'select_facto' ,
    'esti_start' => date('Y/m/d') . '-00:00:00',
    'esti_end' => date('Y/m/d') . '-23:59:59',
    'cafet' => 'true'
]);
$data = $obj->run();

$row_height = intval($_GET['height']);
$result = sort_department($data ,"總表" ,$row_height);
echo $result;
?>
