<?php
namespace order;
use \other\date_api;

function get_announce($start ,$end)
{
    if($start != null) $start = date('Y/m/d-H:i:s' ,date_api::is_valid_time($start)->getTimestamp());
    if($end != null) $end = date('Y/m/d-H:i:s' ,date_api::is_valid_time($end)->getTimestamp());

    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $sql = "SELECT A.id ,A.msg ,A.anno_type ,A.estimate_datetime ,U.device_id
        FROM users AS U ,orders AS O ,announce AS A
        
        WHERE IFNULL(? ,CURRENT_TIMESTAMP) < A.estimate_datetime
        AND A.estimate_datetime < IFNULL(? ,DATE_ADD(CURRENT_TIMESTAMP ,INTERVAL 30 MINUTE))
        AND O.announce_id = A.id AND O.user_id = U.id
        AND O.disabled = FALSE AND A.announced = FALSE;";
        
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('ss' ,$start ,$end);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($id ,$msg ,$anno_type ,$esti_dt ,$device_id);
    
    $result = [];
    while($statement->fetch())
    {
        $result[$id] = new announce(
            $id ,$msg ,$anno_type ,$esti_dt ,$device_id
        );
    }
    return $result;
}




?>