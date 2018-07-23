<?php
function set_payment($ord_id ,$user_id ,$money_to ,$target ,$ip)
{
    $ord_id = check_valid::white_list($ord_id ,check_valid::$only_number);
    $sql_command = "SELECT make_payment(? ,? ,? ,? ,?);";
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql_command);
    
    $statement->bind_param('iisis',$ord_id ,$user_id ,$money_to ,$target ,$ip);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($result);
    if($statement->fetch())
        if($result != 'success done')
            throw new Exception($result);
}

?>