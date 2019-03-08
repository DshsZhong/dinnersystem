<?php
namespace bank;

function get_money()
{
    $self = unserialize($_SESSION["me"]);
    $bank = $self->bank_id;
    $ip = config()["bank"]["ip"];
    $port = config()["bank"]["port"];

    $fp = fsockopen($ip, $port ,$errno ,$errstr ,3);
    if(!$fp)
    {
        $url = 'https://discordapp.com/api/channels/552494392749981719/messages';
        $ch = curl_init( $url );
        assert(curl_setopt_array($ch,
            array(
                CURLOPT_AUTOREFERER => true,
                CURLOPT_BINARYTRANSFER => true,
                CURLOPT_COOKIESESSION => true,
                CURLOPT_FOLLOWLOCATION => true,
                CURLOPT_FORBID_REUSE => false,
                CURLOPT_RETURNTRANSFER => true,
                CURLOPT_SSL_VERIFYPEER => false,
                CURLOPT_CONNECTTIMEOUT => 10,
                CURLOPT_TIMEOUT => 11,
                CURLOPT_ENCODING => "",
                CURLOPT_USERAGENT =>'XXX',
                CURLOPT_HTTPHEADER =>$headerFields,
                CURLOPT_POST => true,
                CURLOPT_POSTFIELDS =>'{"content":"Fei Yu GGYY"}',
                CURLOPT_HTTPHEADER => [
                    "Authorization: Bot NTUyNDkzMTI0Nzc0MDAyNjkw.D2Aaeg.4NbmaYU3K_6i4yqgr9yXRHvMGlE",
                ]
        )));
        $response = curl_exec( $ch );
        throw new \Exception("POS is dead");
    } 

    $operation = [
        "operation" => "read",
        "uid" => $bank
    ];
    fwrite($fp, json_encode($operation) . "\n");
    stream_set_timeout($fp, 3);
    if(!$fp) 
        throw new \Exception("Fetch money timeout");

    $data = "";
    while (!feof($fp)) {
        $data .= fgets($fp, 128);
    }
    fclose($fp);
    return $data;
}

?>