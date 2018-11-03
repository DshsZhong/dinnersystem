<?php
namespace user;
use \other\check_valid;

function change_password($old_password ,$new_password)
{
    $self = unserialize($_SESSION['me']);

    $old_password = check_valid::white_list($old_password ,check_valid::$white_list_pattern);
    $new_password = check_valid::pswd_check($new_password);

    if($old_password != $self->password)
        throw new \Exception("Wrong password.");

    $sql = "UPDATE `dinnersys`.`users`
        SET `password` = ?
        WHERE `users`.`id` = ?;";
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql);
    
    $statement->bind_param('si', $new_password , $self->id);
    $statement->execute();
    
    return login($self->login_id ,$new_password ,'relogin');
}

?>