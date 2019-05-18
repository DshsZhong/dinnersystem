<?php
namespace AI;

function data_collected() {
    $uid = unserialize($_SESSION['me'])->id;
    $sql_command = "UPDATE user_information AS UI SET UI.data_collected = TRUE 
        WHERE UI.id = (SELECT info_id FROM users WHERE users.id = ?);";
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('i' ,$uid);
    $statement->execute();

    return "Collected";
}

?>