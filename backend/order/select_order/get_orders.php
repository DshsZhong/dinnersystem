<?php
namespace order\select_order;

function get_orders($statement ,$history)
{    
    if($history)
    {
        $statement->bind_result($id ,
            $dish_id ,
            $money_id ,$money_sum ,
            $esti_recv ,
            $old_name ,$old_cost ,$old_fname,
            $user_id ,$maker_id
        );
    }
    else
    {
        $statement->bind_result($id ,
            $dish_id ,
            $money_id ,$money_sum ,
            $esti_recv ,
            $user_id ,$maker_id
        );     
    }
    
    $dish_table = unserialize($_SESSION['dish']);
    $user_table = unserialize($_SESSION['user']);
    $result = [];
    while($statement->fetch()) {
        $dish = clone $dish_table[$dish_id];

        if($history)
        {
            if($old_name == NULL && $old_cost == NULL && $old_fname == NULL)
            {
                $dish->name = "初始設定餐點";
                $dish->charge = 0;
                $dish->department->factory->name = "初始設定廠商";
            }
            else
            {
                $dish->name = $old_name;
                $dish->charge = $old_cost;
                $dish->department->factory->name = $old_fname;
            }
        }
        $result[$id] = new \order\order(
            $id ,$dish ,
            $user_table[$user_id] ,$user_table[$maker_id] ,
            $esti_recv ,
            new \order\money_info\money_info($money_id ,$money_sum)
        );
    }
    return $result;
}

?>