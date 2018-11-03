<?php
namespace order\make_order;

use \other\check_valid;
use \other\date_api;

function make_order($target_id ,$dish_id ,$esti_recv ,$type)
{   
    \other\init_vars();

    $supreme = ($type == "everyone");
    $esti_recv = get_time($dish_id ,$esti_recv ,$supreme);
    
    $uid = get_user_id($target_id ,$type);
    $dish_id = check_valid::white_list($dish_id ,check_valid::$only_number);
    $dish = unserialize($_SESSION['dish'])[$dish_id];
    if($dish == null) throw new \Exception("Invalid dish id.");

    $self_id = unserialize($_SESSION['me'])->id;

    $sql_command = "SELECT make_order(? ,? ,? ,?)";
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('iiis' ,$uid ,$self_id ,$dish_id ,$esti_recv);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($result);
    
    $oid = null;
    if($statement->fetch()) 
        $oid = $result;
    else throw new \Exception("Unable to fetch data from server.");

    if($type == "everyone") {
        \order\money_info\set_payment(strval($oid) ,$uid ,'user' ,true ,false);
        \order\money_info\set_payment(strval($oid) ,$uid ,'dinnerman' ,true ,false);
        \order\money_info\set_payment(strval($oid) ,$uid ,'cafeteria' ,true ,false);
    }

    $row = \order\select_order\select_order(['oid' => strval($oid)]); 
    return $row;
}

?>