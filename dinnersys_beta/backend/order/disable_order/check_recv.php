<?php

function check_recv($id)
{
    $row = select_order(null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,null ,$order_id);

    $uid = unserialize($_SESSION['user'])->id;
    if(authenticate($id ,$uid ,null ,null) == false)
        throw new Exception("Access denied.");

    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $sql = "UPDATE logistics_info ,orders SET has_recv = TRUE 
        WHERE logistics_info.id = orders.logistics_info
        AND orders.id = ?;";
    
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('i' ,$id);
    $statement->execute();

    return $row;
}

?>