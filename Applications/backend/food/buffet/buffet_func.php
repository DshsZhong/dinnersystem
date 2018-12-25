<?php
namespace food;

function insert_buffet($oid ,$dishes)
{
    $sql = "INSERT INTO `dinnersys`.`buffet` (`dish`,`order`) VALUES";
    $values = [];
    $params = "";
    foreach($dishes as $dish)
    {
        $sql .= "(?,?),";
        $params .= "ii";
        $values[] = $dish->id;
        $values[] = $oid;
    }
    $sql = substr($sql ,0 ,-1);
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($sql);
    $statement->bind_param($params ,...$values);
    $statement->execute();
}

function get_dname($dish)
{
    if(count($dish) == 1) $name = reset($dish)->name;
    else $name = "自訂套餐";
    return $name;
}

function get_sum($dish)
{
    $sum = 0;
    foreach($dish as $d) $sum += $d->charge;
    return $sum;
}

function allow_buffet($dish)
{
    $dish_table = unserialize($_SESSION["dish"]);
    foreach($dish as $id)
    {
        $allow = $dish_table[$id]->department->factory->allow_buffet;
        if(!$allow && count($dish) != 1) 
            throw new Exception("Not allow multiple order.");
    }
}

?>