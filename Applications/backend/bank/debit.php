<?php
namespace bank;

function debit($row ,$req_id)
{
    $self = unserialize($_SESSION["me"]);
    $bank = $self->bank_id;
    $ip = config()["bank"]["ip"];
    $port = config()["bank"]["port"];
    $password = config()["bank"]["password"];

    $auth = json_encode([
        "password" => $password,
        "timestamp" => strval(time())
    ]);
    $auth = hash("SHA512" ,$auth);
    
    $fp = fsockopen($ip, $port);
    $msg = [
        "operation" => "write" ,
        "uid" => $bank,
        "charge" => $row->money->charge,
        "fid" => reset($row->buffet)->dish->department->factory->pos_id,
        "auth" => $auth
    ];
    $msg = json_encode($msg);
    fwrite($fp, $msg . "\n");

    $data = "";
    while (!feof($fp)) {
        $data .= fgets($fp, 128);
    }
    fclose($fp);
    
    if($data == "success") return true;
    else throw new \Exception("Unable debit from user's account");
}


?>
