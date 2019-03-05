<?php
namespace order\money_info;

function password_auth($row ,$hash ,$req_id)
{
    \punish\check($row->user->id ,"payment");

	$self = unserialize($_SESSION["me"]);
    $tolerance = config()["payment"]["time"];
    $now = \time();
    $success = false;
    for($i = $now - $tolerance;
        $i <= $now + $tolerance;
        $i += 1)
    {
        $json = [
            "id" => strval($row->id),
            "usr_id" => strval($self->login_id),
            "usr_password" => strval($self->password),
            "pmt_password" => strval($self->PIN),
            "time" => strval($i)
        ];
        $json = json_encode($json);
        $server_hash = hash("SHA512" ,$json);
        $success |= ($server_hash == $hash);
	}
    
    if(!$success)
        \punish\attempt($row->user->id ,$req_id ,"payment");
    
    return $success;
}

?>