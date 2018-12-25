<?php
namespace bank;

function get_money()
{
    $self = unserialize($_SESSION["me"]);
    $bank = $self->bank_id;
    $ip = config()["bank"]["ip"];
    $port = config()["bank"]["port"];

    $fp = fsockopen($ip, $port);
    $operation = [
        "operation" => "read",
        "uid" => $bank
    ];
    fwrite($fp, json_encode($operation) . "\n");

    $data = "";
    while (!feof($fp)) {
        $data .= fgets($fp, 128);
    }
    fclose($fp);
    return $data;
}

?>