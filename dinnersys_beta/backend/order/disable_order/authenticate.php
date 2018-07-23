<?php

function authenticate($oid ,$uid ,$cid ,$fid) {
    $sql = "SELECT COUNT(DISTINCT O.id) 
                FROM orders AS O ,users AS U ,user_information AS UI ,dish AS D ,logistics_info AS LO
                WHERE O.id = IFNULL(? ,O.id)
                AND U.id = IFNULL(? ,U.id)
                AND UI.class_id = IFNULL(? ,UI.class_id)
                AND D.factory_id = IFNULL(? ,D.factory_id)

                AND O.disabled = FALSE
                AND LO.has_recv = FALSE
                
                AND O.user_id = U.id
                AND U.info_id = UI.id
                AND O.logistics_info = LO.id;";

    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql);

    $statement->bind_param('iiii' ,$oid ,$uid ,$cid ,$fid);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($result);

    if($statement->fetch())
    {
        if($result != 1)
            throw new Exception("Access denied.");
    }

    return true;
}

?>