<?php
namespace order\select_order;

/*
this algorithm requires O(N) to run.
pretty bad ,but considering to expandability this is the best choice.
*/

function select_payment($rows ,$param)
{
    foreach($rows as $key => $item)
    {
        $delete = false;
        if($param['payment'] !== null && $item->money->payment['payment']->paid !== $param['payment'])
            $delete = true;
        
        if($delete)
            unset($rows[$key]);
    }
    return $rows;
}

?>