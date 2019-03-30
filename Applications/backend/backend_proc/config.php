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
            "time" => "60",
            "tolerance" => "3",
            "punish" => "60"
        ],
        "payment" => [
            "time" => "60",
            "tolerance" => "3",
            "punish" => "60"
        ],
        "announce" => [
            "url" => "www.google.com",
            "auth" => "NTUyNDkzMTI0Nzc0MDAyNjkw.D2Aaeg.4NbmaYU3K_6i4yqgr9yXRHvMGlE" 
            /* "url" => "https://discordapp.com/api/channels/552494392749981719/messages",
            "auth" => "NTUyNDkzMTI0Nzc0MDAyNjkw.D2Aaeg.4NbmaYU3K_6i4yqgr9yXRHvMGlE" */
        ]
    ];
}


?>
