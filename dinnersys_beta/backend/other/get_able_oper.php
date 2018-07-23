<?php

function get_able_oper($id)
{
    $result = array();   
    
    $cmd = "CALL show_avaialble_operations(?);";
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();

    $statement = $mysqli->prepare($cmd);
    $statement->store_result();
    $statement->bind_param('i', $id);

    $statement->execute();
    $statement->store_result();
    $statement->bind_result($internal_name ,$external_name);
    
    while($statement->fetch())
        $result[$external_name] = $internal_name;
    
    return $result;
}

?>