<?php

function update_dish($id ,$dname ,$csum ,$vege ,$idle)
{
    load_dish();
    
    $id = check_valid::white_list($id ,check_valid::$only_number);
    $dname = htmlspecialchars($dname);
    $csum = check_valid::white_list($csum ,check_valid::$only_number);
    $vege = check_valid::vege_check($vege);
    if($idle != null) $idle = ($idle == 'true');
    
    $dish = unserialize($_SESSION['dish']);
    if($dish[$id] == null || !$dish[$id]->updatable()) throw new Exception("Access denied");
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $sql = "UPDATE `dinnersys`.`dish`
        SET `dish_name` = ?,
        `charge_sum` = ?,
        `is_vegetarian` = ?,
        `is_idle` = ?
        WHERE `dinnersys`.`dish`.`id` = ?;";
    
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('siiii' ,$dname ,$csum ,$vege ,$idle ,$id);
    $statement->execute();
}

?>