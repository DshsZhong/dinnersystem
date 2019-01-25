<?php
namespace bank;

function debit($row ,$req_id ,$hash)
{
    \punish\check($row->user->id ,"payment");
    if(!auth($row->id ,$hash))
    {
        \punish\attempt($row->user->id ,$req_id ,"payment");
        throw new \Exception("Wrong password");
    }
    
    $self = unserialize($_SESSION["me"]);
    $bank = $self->bank_id;
    $ip = config()["bank"]["ip"];
    $port = config()["bank"]["port"];

    $fp = fsockopen($ip, $port);
    $msg = [
        "operation" => "write" ,
        "uid" => $bank,
        "charge" => $row->money->charge
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
