<?php

function make_log($uid ,$func_name ,$query_detail ,$input ,$ip)
{
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $sql = "INSERT INTO `dinnersys`.`log`
        (`user_name`,
        `prev_sum`,
        `oper_name`,
        `query_detail`,
        `input`,
        `datetime`,
        `ip`,
        `device_id`)
        VALUES
        ((SELECT UI.name FROM `dinnersys`.`users` ,`dinnersys`.`user_information` AS UI WHERE users.id = ? AND users.info_id = UI.id),
        (SELECT prev_sum FROM `dinnersys`.`users` WHERE id = ?),
        ?,
        ?,
        ?,
        CURRENT_TIMESTAMP,
        ?,
        (SELECT device_id FROM `dinnersys`.`users` WHERE users.id = ?));";
    
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('iissssi' ,$uid ,$uid ,$func_name ,$query_detail ,$input ,$ip ,$uid);
    $statement->execute();
}

?>