<?php

function get_factory_info($factory_id)
{
    if($factory_id != null) $factory_id = check_valid::white_list($factory_id ,check_valid::$only_number);

    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $sql = "SELECT F.id ,F.name ,F.disabled ,F.lower_bound ,F.upper_bound ,F.pre_time
            FROM dinnersys.factory AS F
            WHERE IFNULL(? ,F.id) = F.id;";
    
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('i' ,$factory_id);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($fid ,$fname ,$disabled ,
        $lower_bound ,$upper_bound ,$pre_time
    );
    
    $result = [];
    while($statement->fetch())
    {
        $result[$fid] = new factory($fid ,$fname ,
            $lower_bound ,$pre_time ,$upper_bound ,$disabled);
    }
    
    return $result;
}

?>