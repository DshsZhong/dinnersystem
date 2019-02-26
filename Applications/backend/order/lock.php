<?php
namespace order;

function enlock($oid)
{
    $sql_command = "UPDATE orders SET locked = true WHERE id = ?";
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('i' ,$oid);
    $statement->execute();
}

function delock($oid)
{
    $sql_command = "UPDATE orders SET locked = false WHERE id = ?";
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('i' ,$oid);
    $statement->execute();
}

?>