<?php
namespace user;

function get_user()
{
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $sql = "SELECT U.id ,UI.name ,U.class_id ,UI.seat_id
        FROM users AS U ,user_information AS UI 
        WHERE U.info_id = UI.id";
    
    $statement = $mysqli->prepare($sql);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($uid ,$name ,$cid ,$sno);
    
    $class = unserialize($_SESSION['class']);
    $result = [];
    while($statement->fetch())
    {
        $result[$uid] = new user($uid ,$name ,$class[$cid] ,$sno);
    }
    
    return $result;
}

?>