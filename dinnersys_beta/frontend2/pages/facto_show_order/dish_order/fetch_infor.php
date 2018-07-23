<?php

error_reporting(0);
include(__DIR__ . '/../../../../backend/backend_proc/backend_main.php');
$obj = new backend_main(['cmd' => 'select_facto' ,
    'esti_start' => date('Y/m/d') . '-00:00:00',
    'esti_end' => date('Y/m/d') . '-23:59:59',
    'dm' => 'true' ,'cafet' => 'true' ,'facto' => 'false'
]);
$json = json_decode($obj->run() ,true);

$data = array();
$draw_line = false;
foreach($json as $key => $value) {
    $data[$value['dish']['dish_id']]['count'] += 1;
    $data[$value['dish']['dish_id']]['name'] = $value['dish']['dish_name'];
    $draw_line = ($value['dish']['factory']['name'] == "台灣小吃部");
}

$output = "<tr><th>編號</th><th>名稱</th><th>份數</th></tr>";
ksort($data);
$previous = key($data);
foreach($data as $key => $value) {
    $id = $key; 
    if(intval($previous / 40) != intval($id / 40) && $draw_line) {
        $output .= '<tr><td><hr /></td><td><hr /></td><td><hr /></td></tr>';
    }
    $previous = $id;

    $name = $value['name']; 
    $count = $value['count'];
    $output .= "<tr><td>$id</td><td>$name</td><td>$count</td></tr>";
}

echo $output;

?>
