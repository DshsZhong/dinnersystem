<?php


function get_dish($factory_id ,$is_custom)
{
    if($factory_id != null) $factory_id = check_valid::white_list($factory_id ,check_valid::$only_number);
    if($is_custom != null) $is_custom = ($is_custom == 'true');
    

    $user = unserialize($_SESSION['user']);
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();

    $sql = "SELECT DISTINCT D.id ,D.dish_name ,D.charge_sum ,F.id ,F.name ,D.is_idle ,D.is_custom ,D.content
        FROM `dinnersys`.`dish` AS D ,`dinnersys`.`factory` AS F
        WHERE D.factory_id = F.id
        AND IFNULL(? ,F.id) = F.id
        AND IFNULL(? ,D.is_custom) = D.is_custom
        ORDER BY F.id ,ABS(D.is_vegetarian - ?) ,D.id;";
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('iii' ,$factory_id ,$is_custom ,$user->is_vege->number);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result(
        $did ,$dname ,$dcharge ,$fid ,$fname ,$idle ,$custom ,$content
    );
    

    $result = [];
    while($statement->fetch())
    {
        $result[$did] = new dish($did ,$dname ,$dcharge ,
            $idle ,$custom ,new factory($fid ,$fname) ,$content);
    }
    
    return $result;
}



?>