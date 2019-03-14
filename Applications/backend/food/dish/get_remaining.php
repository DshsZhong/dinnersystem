<?php
namespace food;

function get_remaining($did)
{
    $did = \other\check_valid::white_list($did ,\other\check_valid::$only_number); 

    $dish = unserialize($_SESSION["dish"]);
    if($dish[$did]->daily_produce == -1) 
        return $dish[$did];

    $result = get_count($dish[$did]->department->factory->id ,$did);
    $factory_produce = $dish[$did]->department->factory->daily_produce;
    if($factory_produce >= $result["factory"]) {
        $dish[$did]->remaining = 0;
    } else {
        $dish[$did]->sold_out = $result["dish"];
        $dish[$did]->remaining = $dish[$did]->daily_produce - $result["dish"];
    }
    return $dish[$did];
}

function get_count($fid ,$did)
{
    $mysqli = $_SESSION['sql_server'];
    $today = date("Y-m-d");
    $lower_bound = $today . ' 00:00:00';
    $upper_bound = $today . ' 23:59:59';
    $sql = "SELECT COUNT(O.id) ,D.id FROM orders AS O ,buffet AS B ,dish AS D ,department AS DP ,logistics_info AS LO
        WHERE B.dish = D.id AND B.order = O.id AND O.disabled = FALSE AND D.department_id = DP.id AND DP.factory = ?
        AND O.logistics_id = LO.id AND LO.esti_recv_datetime BETWEEN ? AND ?
        GROUP BY D.id
        FOR SHARE;";
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('iss' ,$fid ,$lower_bound ,$upper_bound);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($sum ,$dish_id);

    $factory_sum = 0;
    $dish_sum = 0;
    while($statement->fetch())
    {
        $factory_sum += $sum;
        if($did == $dish_id) $dish_sum = $sum;
    }
    return ["factory" => $factory_sum ,"dish" => $dish_sum];
}

?>