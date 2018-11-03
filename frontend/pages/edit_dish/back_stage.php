<?php
function fetch() {
    $obj = new \backend_proc\backend_main(['cmd' => 'show_dish']);
    $dish = $obj->run();

    $department = []; $dp_name = []; $f_name = [];
    foreach($dish as $value) {
        if(!$value->updatable()) continue;
        $department[$value->department->id][] = $value;
        $dp_name[$value->department->id] = $value->department->name;
        $f_name[$value->department->id] = $value->department->factory->name;
    }

    $data = "";
    foreach($department as $key => $array) {
        $title = $f_name[$key] . "-" . $dp_name[$key];
        $data .= "<h4 style=\"text-align:center\">$title</h4>";
        $data .= 
        '<div class="department">
            <table id="table" style="width:100%;text-align:center;">
                <tr><th>編號</th><th>名稱</th><th>要價</th><th>廠商</th><th>是否供應</th></tr>';
        foreach($array as $row) {
            $id = $row->id;
    
            $name = $row->name;
            $cost = $row->charge;
            $factory = $row->department->factory->name;
    
            $name = '<input type="text" id="name_' . $id . '" value="' . $name . '" />';
            $cost = '<input type="text" id="cost_' . $id . '" value="' . $cost . '" />';
            $idle = '<input type="checkbox" id="idle_' . $id . '" ' . ($row->is_idle ? 'checked="checked"' : '') . '/><label>暫不供應</label>';
    
            $str = "<tr id=\"$id\"><td>$id</td><td>$name</td><td>$cost</td><td>$factory</td><td>$idle</td></tr>";
            $data .= $str;
        }
        $data .= '
            </table>
        </div>';
    }
    echo $data;
}


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