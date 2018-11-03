<?php
namespace order;
use \other\check_valid;

function delete_order($order_id ,$type)
{
    $order_id = check_valid::white_list($order_id ,check_valid::$only_number);
    $data = \order\select_order\select_order(['oid' => $order_id]);
    $row = reset($data);
    
    if($row == false)
        throw new \Exception("Unable to find the row");

    if(!delete_auth($row ,$type))
        throw new \Exception("Access denied");

    $sql_command = "UPDATE `dinnersys`.`orders` ,`dinnersys`.`announce`
        SET `dinnersys`.`orders`.`disabled` = TRUE
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