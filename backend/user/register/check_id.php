<?php
namespace user;

function check_id($login_id)
{
    $sql = "SELECT COUNT(U.id) FROM `dinnersys`.`users` AS U WHERE U.login_id = ?";

    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql);
    
    $statement->bind_param('s',$login_id);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($result);
    if($statement->fetch())
        if($result == 1)
            throw new \Exception("Repeated login id");
        else
            return true;
    else
        throw new \Exception("Lost server connection.");
}

?>