<?php

function update_menu($id ,$charge ,$name ,$vege ,$idle)
{
    load_menu();

    $id = check_valid::white_list($id ,check_valid::$only_number);
    $name = check_valid::white_list($name ,check_valid::$white_list_pattern);
    $charge = check_valid::white_list($charge ,check_valid::$only_number);
    $vege = check_valid::vege_check($vege);
    if($idle != null) $idle = ($idle == 'true');

    $menu = unserialize($_SESSION['menu']);
    if($menu[$id] == null || !$menu[$id]->updatable()) throw new Exception("Access denied");

    $sql_command = "UPDATE `dinnersys`.`menu`
        SET `charge` = ?,
        `name` = ?,
        `is_vegetarian` = ?,
        `is_idle` = ?
        WHERE `id` = ?;";
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql_command);    
    
    $statement->bind_param('isiii' ,$charge ,$name ,$vege ,$idle ,$id);
    $statement->execute();
}

?>