<?php
namespace pos;

function announce($content ,$self)
{
    $url = \config()["announce"]["url"];
    $auth = \config()["announce"]["auth"];
    $ch = curl_init( $url );
    $data = '{
        "embed":{
            "title":"' . $content . '",
            "description":"邪靈飛宇觀落陰，禍世災難害板中。",
            "color":16711680,
            "fields":[
                {
                    "name":"陣亡者資料：",
                    "value":"' . $self->name . ', ' . $self->seat_no . '",
                    "inline": false
                },
                {
                    "name":"死亡日期：",
                    "value":"' . date("Y/m/d H:i:s") . '",
                    "inline": false
                }
            ]
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
                "Authorization: Bot $auth",
            ]
    ));
    $response = curl_exec( $ch );
}


?>