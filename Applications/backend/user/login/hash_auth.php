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

function hash_auth($login_id ,$time ,$hashed)
{
    $data = fetch($login_id);
    $pswd = $data["password"];

    $valid = false;
    $tolerance = config()["login"]["time"];
    $now = time();

    if($time == null)
    {
        for($shift = 0;$shift <= $tolerance;$shift += 1)
        {
            if(get_hash($login_id ,$pswd ,$now + $shift) === $hashed)
                $valid = true;
            if(get_hash($login_id ,$pswd ,$now - $shift) === $hashed)
                $valid = true;
        }
    } else {
        $diff = $now - $time;
        if(($diff > 0 ? $diff : -$diff) >= intval($tolerance)) 
            throw new \Exception("Invalid time");
        $valid = (get_hash($login_id ,$pswd ,$time) === $hashed);
    }

    $msg = [];
    if($pswd === NULL)
        throw new \Exception("No Account.");
    
    return $valid;
}

?>