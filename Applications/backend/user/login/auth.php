<?php
namespace user\login;

function get_hash($login_id ,$pswd ,$time)
{
    $data = json_encode([
        "id" => $login_id,
        "password" => $pswd,
        "time" => strval($time)
    ]);
    # echo $time . " " . (json_encode($data)) . "<br>";
    $hashed = hash("sha512", $data);
    return $hashed;
}


function fetch($login_id)
{
    $sql_command = "SELECT id ,password FROM users WHERE login_id = ?;";
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('s',$login_id);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($id ,$password);
    $statement->fetch();
    return ["id" => $id ,"password" => $password];
}

function auth($login_id ,$hashed)
{
    $data = fetch($login_id);
    $pswd = $data["password"];

    $valid = false;
    $tolerance = config()["login"]["time"];
    $now = time();
    for($shift = 0;$shift <= $tolerance;$shift += 1)
    {
        if(get_hash($login_id ,$pswd ,$now + $shift) === $hashed)
            $valid = true;
        if(get_hash($login_id ,$pswd ,$now - $shift) === $hashed)
            $valid = true;
    }

    $msg = [];
    if(!$valid)
        $msg[] = "Wrong password.";
    if($pswd === NULL)
        $msg[] = "No account.";
    
    return ["uid" => $data["id"], "msg" => $msg];
}

?>