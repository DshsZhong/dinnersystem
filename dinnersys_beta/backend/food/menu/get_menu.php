<?php

function get_menu($factory_id)
{
    if($factory_id != null) $factory_id = check_valid::white_list($factory_id ,check_valid::$only_number);

    $user = unserialize($_SESSION['user']);
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $sql = "SELECT DISTINCT 
        M.id ,M.name ,M.charge ,M.is_idle
        ,F.id ,F.name 
        FROM `dinnersys`.`menu` AS M ,`dinnersys`.`factory` AS F
        WHERE M.factory_id = F.id
        AND F.id = IFNULL(? ,F.id)
        ORDER BY M.factory_id ,ABS(M.is_vegetarian - ?) ,M.id;";
    
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('ii' ,$factory_id ,unserialize($_SESSION['user'])->is_vege->number);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($mid ,$mname ,$mcharge ,$is_idle ,$fid ,$fname);
    
    $result = [];
    while($statement->fetch())
    {
        $result[$mid] = new menu($mid ,$mname ,$mcharge ,$is_idle ,new factory($fid ,$fname));
    }
    
    return $result;
}

?>