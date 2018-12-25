<?php
namespace bank;

function auth($id ,$hash)
{
    $self = unserialize($_SESSION["me"]);
    $tolerance = config()["payment"]["time"];
    $now = \time();
    $success = false;
    for($i = $now - $tolerance;
        $i <= $now + $tolerance;
        $i += 1)
    {
        $json = [
            "id" => strval($id),
            "usr_id" => strval($self->login_id),
            "usr_password" => strval($self->password),
            "pmt_password" => strval($self->PIN),
            "time" => strval($i)
        ];
        $json = json_encode($json);
        $server_hash = hash("SHA512" ,$json);
        # echo $json . " " . $server_hash . "<br>";
        $success |= ($server_hash == $hash);
    }
    return $success;
}


?>