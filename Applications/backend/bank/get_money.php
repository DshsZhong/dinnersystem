<?php
namespace bank;

function get_money()
{;
    $self = unserialize($_SESSION["me"]);
    $bank = $self->bank_id;
    $ip = config()["bank"]["ip"];
    $port = config()["bank"]["port"];
    $fp = fsockopen($ip, $port ,$errno ,$errstr ,3);
    if(!$fp)
    {
        $rnd = rand(0 ,1);
        if($rnd == 0) {
            fei_yu_ggyy("先準備一缸酒，再把系統泡進去，這種東西，輕者當日，重者七日就會好，急不得的。" ,$self);
        } else if($rnd == 1) {
            fei_yu_ggyy("有人課金課到系統掛了，看起來是非洲運。" ,$self);
        }
        
        throw new \Exception("POS is dead");
    }

    $operation = [
        "operation" => "read",
        "uid" => $bank
    ];
    fwrite($fp, json_encode($operation) . "\n");
    stream_set_timeout($fp, 3);
    if(!$fp) throw new \Exception("Fetch money timeout");

    $data = "";
    while (!feof($fp)) {
        $data .= fgets($fp, 128);
    }
    fclose($fp);
    return $data;
}

?>
