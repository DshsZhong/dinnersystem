<?php

function fei_yu_ggyy($content ,$self)
{
    $url = 'https://discordapp.com/api/channels/552494392749981719/messages';
    $ch = curl_init( $url );
    $data = '{
        "embed":{
            "title":"' . $content . '",
            "description":"邪靈飛宇觀陰，禍世災顯板中。",
            "color":16711680,
            "fields":[
                {
                    "name":"陣亡人員座號：",
                    "value":"' . $self->seat_no . '",
                    "inline":true
                },
                {
                    "name":"陣亡者姓名：",
                    "value":"' . $self->name . '",
                    "inline":true
                }
            ], "timestamp":"' . date('c') . '"
        }
    }';
    
    
    curl_setopt_array($ch,
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
            CURLOPT_POST => true,
            CURLOPT_POSTFIELDS => $data,
            CURLOPT_HTTPHEADER => [
                "Authorization: Bot NTUyNDkzMTI0Nzc0MDAyNjkw.D2Aaeg.4NbmaYU3K_6i4yqgr9yXRHvMGlE",
            ]
    ));
    $response = curl_exec( $ch );
}


?>