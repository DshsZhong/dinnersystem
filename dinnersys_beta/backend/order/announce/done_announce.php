<?php

function done_announce($id ,$device_id)
{
    $id = check_valid::white_list($id ,check_valid::$only_number);
    $device_id = check_valid::white_list($device_id ,check_valid::$only_number);

    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $sql = "UPDATE `dinnersys`.`announce`
	    SET `pushed_datetime` = CURRENT_TIMESTAMP,
	    `announced` = TRUE,
	    `notify_on` = ?
	    WHERE announce.`id` = ?;";
    
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('si' ,$device_id  ,$id);
    $statement->execute();
}

?>