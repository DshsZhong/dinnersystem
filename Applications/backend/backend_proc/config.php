<?php

function config()
{
    return [
        "bank" => [
            "ip" => "192.168.0.2",
            "port" => 8787,
            "password" => "Fei Yu GGYY"
        ],
        "database" => [
            "ip" => "localhost",
            "account" => "dinnersystem",
            "password" => "2rjurrru",
            "name" => "dinnersys"
        ],
        "login" => [
            "time" => "600",
            "tolerance" => "3",
            "punish" => "60"
        ],
        "payment" => [
            "time" => "600",
            "tolerance" => "3",
            "punish" => "60"
        ]
    ];
}


?>