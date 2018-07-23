<?php

function delete_order($order_id ,$type)       //only allows to delete the order that made by the user itself.
{   
    $uid = $cid = $fid = null;
    switch($type) {
        case "self":
            $uid = unserialize($_SESSION['user'])->id;
            break;
        case 'class':
            $cid = unserialize($_SESSION['user'])->class_no;
            break;
        case 'facto':
            $fid = key(unserialize($_SESSION['factory_auth'])[$uid]);
            break;
        case 'none':
            break;
    }

    $row = select_order(null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,$order_id);
    
    if(authenticate($order_id ,$uid ,$cid ,$fid) == false)
        throw new Exception("Access denied.");

    $order_id = check_valid::white_list($order_id ,check_valid::$only_number); 

    $sql_command = "UPDATE `dinnersys`.`orders` ,`dinnersys`.`announce`
        SET `dinnersys`.`orders`.`disabled` = TRUE ,
        `dinnersys`.`announce`.`disabled` = TRUE 
        WHERE `dinnersys`.`orders`.`id` = ? 
        AND `dinnersys`.`orders`.`announce_id` = `dinnersys`.`announce`.`id`";
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql_command);
    
    $statement->bind_param('i' ,$order_id);
    $statement->execute();

    return $row;
}

?>