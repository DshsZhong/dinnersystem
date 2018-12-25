<?php
namespace food;

function get_factory()
{
    $mysqli = $_SESSION['sql_server'];
    $sql = "SELECT F.id ,F.name ,F.disabled ,F.lower_bound ,F.upper_bound ,F.pre_time ,F.boss_id ,F.allow_custom
            FROM dinnersys.factory AS F;";
    
    $statement = $mysqli->prepare($sql);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($fid ,$fname ,$disabled ,
        $lower_bound ,$upper_bound ,$pre_time ,$boss_id ,$allow_custom
    );
    
    $result = [];
    while($statement->fetch())
    {
        $result[$fid] = new factory($fid ,$fname ,
            $lower_bound ,$pre_time ,$upper_bound ,$disabled ,$boss_id ,$allow_custom
        );
    }
    
    return $result;
}

?>