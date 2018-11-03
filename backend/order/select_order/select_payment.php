<?php
namespace order\select_order;

/*
this algorithm requires about O(N) to run.
pretty bad ,but there's nothing faster.
*/

function select_payment($rows ,$param)
{
    foreach($rows as $key => $item)
    {
        $delete = false;
        if($param['usr'] !== null && $item->money->payment['user']->paid !== $param['usr'])
            $delete = true;
        if($param['dm'] !== null && $item->money->payment['dinnerman']->paid !== $param['dm'])
            $delete = true;
        if($param['cafet'] !== null && $item->money->payment['cafeteria']->paid !== $param['cafet'])
            $delete = true;
        if($param['facto'] !== null && $item->money->payment['factory']->paid !== $param['facto'])
            $delete = true;
        
        if($delete)
            unset($rows[$key]);
    }
    return $rows;
}

?>