<?php
namespace food;

function get_dish($id = null)
{
    $user = unserialize($_SESSION['user']);
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();

    $sql = "SELECT D.id ,D.dish_name ,D.charge ,D.is_idle ,DP.id ,D.is_vegetarian
        FROM `dinnersys`.`dish` AS D ,`dinnersys`.`department` AS DP
        WHERE D.department_id = DP.id AND D.id = IFNULL(? ,D.id);";
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('i' ,$id);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result(
        $did ,$dname ,$dcharge ,$idle ,$dp_id ,$vege
    );
    
    $department = unserialize($_SESSION['department']);
    $result = [];
    while($statement->fetch())
    {
        $result[$did] = new dish($did ,$dname ,$dcharge ,$idle ,$department[$dp_id] ,new vege($vege));
    }
    
    return $result;
}



?>