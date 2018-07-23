<?php

function check_make_order($login_id ,$type)
{   
    $cno = null;
    $self = unserialize($_SESSION['user']);
    switch($type) {
        case "self":
            return $self->id;
            break;
        case "dm":
            $cno = $self->class_no;
            break;
        case "facto":
            break;
        case "cafet":
            break;
    }

    
    $sql_command = "SELECT U.id FROM users AS U ,user_information AS UI
        WHERE U.login_id = ?
        AND UI.class_id = IFNULL(? ,UI.class_id)
        AND UI.id = U.info_id;";
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('ss' ,$login_id ,$cno);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($result);
    
    if($statement->fetch()) return $result;
    else throw new Exception("Invalid login_id.");
}


?>