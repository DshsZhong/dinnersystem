<?php
namespace order\make_order;

use \other\check_valid;
use \other\date_api;
use function \food\get_dname;
use function \food\get_sum;
use function \food\insert_buffet;

function make_order($target_id ,$dishes ,$esti_recv ,$type)
{
    $supreme = ($type == "everyone");
    $dishes = check_dish($dishes);
    check_time($dishes ,$esti_recv ,$supreme);  
    $uid = get_user_id($target_id ,$type);
    $self_id = unserialize($_SESSION['me'])->id;
    $dname = get_dname($dishes);
    $dsum = get_sum($dishes);

    $sql_command = "CALL make_order(? ,? ,? ,? ,?);";
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('iisis' , $uid ,$self_id ,$dname, $dsum, $esti_recv);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($result);
    
    $oid = null;
    if($statement->fetch()) 
        $oid = $result;
    else
        throw new \Exception("Unable to fetch data from server.");
    
    while($mysqli->more_results()) $mysqli->next_result();    
    insert_buffet($oid ,$dishes);
    $row = \order\select_order\select_order(['oid' => strval($oid)]); 
    return $row;
}

?>