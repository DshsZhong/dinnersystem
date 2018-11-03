<?php
namespace order\money_info;

use \other\check_valid;

function set_payment($ord_id ,$user_id ,$money_to ,$target ,$check = true)
{
    if($check)
    {
        $ord_id = check_valid::white_list($ord_id ,check_valid::$only_number);
        $result = \order\select_order\select_order(['oid' => $ord_id]);
        $row = reset($result);
        if($row === null) 
            throw new \Exception("Can't find order.");
        if(!payment_auth($row ,$user_id ,$money_to ,$target))
            throw new \Exception("Access denied.");
    }
    $ip = \other\get_ip();
    
    $sql_command = "CALL make_payment(? ,? ,? ,? ,?);";
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql_command);
    
    $statement->bind_param('iisis',$ord_id ,$user_id ,$money_to ,$target ,$ip);
    $statement->execute();
    
    return $row;
}

?>