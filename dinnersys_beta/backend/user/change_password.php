<?php

function change_password($old_password ,$new_password)
{
    $user_id = unserialize($_SESSION['user'])->id;

    $old_password = check_valid::white_list($old_password ,check_valid::$white_list_pattern);
    $new_password = check_valid::pswd_check($new_password);

    if($old_password != unserialize($_SESSION['user'])->password)
        throw new Exception("Wrong password.");

    $sql = "UPDATE `dinnersys`.`users`
        SET `password` = ?
        WHERE `class_id` = 
            (SELECT tmp.cid FROM
                (SELECT class_id AS cid FROM users AS U WHERE id = ?) AS tmp
            )
        LIMIT 1000;";
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql);
    
    $statement->bind_param('is', $user_id , $new_password);
    $statement->execute();

    $user = unserialize($_SESSION['user']);
    $user->password = $new_password;
    $_SESSION['user'] = serialize($user);
}

?>