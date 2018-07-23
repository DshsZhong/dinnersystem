<?php

function lock_table()
{
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare("LOCK TABLES payment WRITE;");
    $statement->execute();
}

function unlock_table()
{
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare("UNLOCK TABLES;");
    $statement->execute();
}

?>