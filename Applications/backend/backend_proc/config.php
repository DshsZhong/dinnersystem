<?php

function config()
{
    return [
        "bank" => [
            "ip" => "192.168.0.150",
            "port" => 8787,
            "password" => "Fei Yu GGYY"
        ],
        "database" => [
            "ip" => "localhost",
            "account" => "root",
            "password" => "",
            "name" => "dinnersys"
        ],
        "login" => [
            "time" => "60",
            "tolerance" => "3",
            "punish" => "60"
        ],
        "payment" => [
            "time" => "60",
            "tolerance" => "3",
            "punish" => "60"
        ]
    ];
}


?>
