<?php
function fetch() {
    $line = "<tr><td><hr /></td><td><hr /></td><td><hr /></td><td><hr /></td><td><hr /></td><td><hr /></td></tr>";

    $obj = new backend_main(['cmd' => 'show_dish']);
    $json = json_decode($obj->run() ,true);

    $data = "<tr><th>編號</th><th>名稱</th><th>要價</th><th>廠商</th><th>是否供應</th></tr>";
    $dish = unserialize($_SESSION['dish']);
    foreach($json as $row) {
        $id = $row['dish_id'];
        if(!$dish[$id]->updatable()) continue;

        if($id % 40 == 1 && $row['factory']['name'] == "台灣小吃部") {
            $data .= $line;
        }

        $name = $row['dish_name'];
        $cost = $row['dish_cost'];
        $factory = $row['factory']['name'];

        $name = '<input type="text" id="name_' . $id . '" value="' . $name . '" />';
        $cost = '<input type="text" id="cost_' . $id . '" value="' . $cost . '" />';
        $idle = '<input type="checkbox" id="idle_' . $id . '" ' . ($row['is_idle'] ? 'checked="checked"' : '') . '/><label>暫不供應</label>';

        $str = "<tr id=\"$id\"><td>$id</td><td>$name</td><td>$cost</td><td>$factory</td><td>$idle</td><td>$update</td></tr>";
        $data .= $str;
    }

    echo $data;
}

function reset_dish() {
    $obj = new backend_main(['cmd' => 'show_dish']);
    $json = json_decode($obj->run() ,true);

    $dish = unserialize($_SESSION['dish']);
    foreach($json as $row) {
        $id = $row['dish_id'];
        if(!$dish[$id]->updatable()) continue;

        $tmp = new backend_main(['cmd' => 'update_dish' ,
            'id' => $id ,
            'dish_name' => "閒置的餐點" ,
            'charge_sum' => "0" ,
            'is_vege' => "MEAT" ,
            "is_idle" => "true"]);
        $tmp->run();
    }
}
?>


<?php

error_reporting(0);
require_once(__DIR__ . '/../../../backend/backend_proc/backend_main.php');

switch($_GET['cmd']) {
    case 'fetch' :
        fetch();
        break;
    case 'reset':
        reset_dish();
        break;
}

?>
