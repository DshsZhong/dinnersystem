<?php
namespace food;

function fetch_factory() 
{
    $mysqli = $_SESSION['sql_server'];
    $sql = "SELECT F.id ,F.daily_limit ,F.sum ,F.last_update FROM factory AS F;";
    $statement = $mysqli->prepare($sql);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($id ,$limit ,$sum ,$update);

    $ret = [];
    while($statement->fetch()) {
        $ret[$id] = [
            "limit" => $limit ,
            "sum" => $sum ,
            "last_update" => $update
        ];
    }
    return $ret;
}

function fetch_dish()
{
    $mysqli = $_SESSION['sql_server'];
    $sql = "SELECT D.id ,IF(F.daily_limit = -1 ,D.daily_limit ,IF(F.daily_limit > F.sum ,D.sum ,D.daily_limit)) ,D.sum ,D.last_update
        FROM `dinnersys`.`dish` AS D,
             `dinnersys`.`department` AS DP,
             `dinnersys`.`factory` AS F
        WHERE DP.id = D.department_id AND DP.factory = F.id;";
    $statement = $mysqli->prepare($sql);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($id ,$limit ,$sum ,$update);

    $ret = [];
    while($statement->fetch()) {
        $ret[$id] = [
            "limit" => $limit ,
            "sum" => $sum ,
            "last_update" => $update
        ];
    }
    return $ret;
}

?>
