<?php
namespace other;

function init_server()
{
    if($_SESSION['sql_server'] == null || !$_SESSION['sql_server']->ping()) {
        $server_connection = new \mysqli("localhost", "root", "", "dinnersys");
        \mysqli_set_charset($server_connection ,"utf8");
        $_SESSION['sql_server'] = $server_connection;
    }
} 

?>