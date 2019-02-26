<?php
namespace order\select_order;

function get_orders($statement ,$dirty)
{    
    $statement->bind_result($id ,
        $esti_recv ,
        $user_id ,$maker_id,
        $money_id ,$money_sum ,$locked
    );
    
    $user_table = unserialize($_SESSION['user']);
    $result = [];
    while($statement->fetch()) {
        if(!$dirty && $locked)
            throw new \Exception("Invalid denied (The row is locked).");
        $result[$id] = new \order\order(
            $id , $user_table[$user_id] ,$user_table[$maker_id] ,
            $esti_recv ,
            new \order\money_info\money_info($money_id ,$money_sum)
        );
    }
    return $result;
}

?>