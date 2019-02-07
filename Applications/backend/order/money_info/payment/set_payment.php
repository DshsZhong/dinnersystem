<?php
namespace order\money_info;

use \other\check_valid;

function set_payment($req_id ,$hash ,$ord_id ,$permission ,$target ,$check = true)
{
    $ord_id = check_valid::white_list($ord_id ,check_valid::$only_number);
    $result = \order\select_order\select_order(['oid' => $ord_id]);
    $user_id = unserialize($_SESSION['me'])->id;
    $row = reset($result);
    if($row === null) 
        throw new \Exception("Can't find order.");
    if($check)
        payment_auth($row ,$user_id ,$permission ,$target ,$hash ,$req_id);
    
    $money = intval(\bank\get_money());
    if($money < $row->money->charge)
        throw new \Exception("Not enough money.");
    \bank\debit($row ,$hash);
    $after = intval(\bank\get_money());
    if($money != $after + $row->money->charge)
        throw new \Exception("Failed to debit.");
    

    $sql_command = "UPDATE `dinnersys`.`payment` AS P
        SET `paid` = ?,
        `paid_datetime` = CURRENT_TIMESTAMP
        WHERE P.money_info = (SELECT O.money_id FROM `dinnersys`.`orders` AS O WHERE O.id = ?) 
        AND P.tag = 'payment';";
    
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($sql_command);
    
    $statement->bind_param('ii',$target ,$ord_id);
    $statement->execute();
    
    return $row;
}

?>