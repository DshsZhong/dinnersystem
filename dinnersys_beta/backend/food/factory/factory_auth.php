<?php

function factory_auth()
{
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();

    $sql = "SELECT user_id ,factory_id FROM factory_auth;";
    
    $statement = $mysqli->prepare($sql);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($uid ,$fid);
    
    $result = [];
    while($statement->fetch()) {
        $result[$uid][$fid] = true;
    }
    
    return $result;
}

?>