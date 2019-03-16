<?php
namespace food;

function show_dish()
{
    $flimit = fetch_factory();
    $dlimit = fetch_dish();

    $dish = unserialize($_SESSION["dish"]);
    $department = unserialize($_SESSION["department"]);
    $factory = unserialize($_SESSION["factory"]);
    
    foreach($dlimit as $key => $row) 
        $dish[$key]->init_limit($row["last_update"] ,$row["sum"] ,$row["limit"]);
    foreach($flimit as $key => $row) 
        $factory[$key]->init_limit($row["last_update"] ,$row["sum"] ,$row["limit"]);

    foreach($department as $dp) $dp->factory = $factory[$dp->factory->id];
    foreach($dish as $d) $d->department = $department[$d->department->id];

    session_start();
    $_SESSION["dish"] = serialize($dish);
    $_SESSION["department"] = serialize($department);
    $_SESSION["factory"] = serialize($factory);
    session_write_close();

    return $dish;
}

?>