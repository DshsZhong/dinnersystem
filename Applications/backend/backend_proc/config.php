<?php

function config()
{
    return [
        "bank" => [
            "ip" => "localhost",
            "port" => 8787
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
            "punish" => "600"
        ],
        "payment" => [
            "time" => "600",
            "tolerance" => "3",
            "punish" => "600"
        ]
    ];
}


?>