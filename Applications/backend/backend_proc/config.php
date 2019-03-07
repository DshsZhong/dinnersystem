<?php

function config()
{
    return [
        "bank" => [
            "ip" => "192.168.56.1",
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
            "time" => "30",
            "tolerance" => "3",
            "punish" => "60"
        ],
        "payment" => [
            "time" => "30",
            "tolerance" => "3",
            "punish" => "60"
        ]
    ];
}


?>