<?php
namespace order\make_order;

function check_time($dishes ,$esti_recv ,$supreme)
{
    $recv = \other\date_api::is_valid_time($esti_recv);

    if(!$supreme)
    {
        $date = $recv->format("Y-m-d");

        foreach($dishes as $dish)
        {
            $lower_bound = $date . ' ' . $dish->department->factory->lower_bound;
            $upper_bound = $date . ' ' . $dish->department->factory->upper_bound;
            $prepare = $dish->department->factory->prepare_time;
            
            # esti_recv >= now + prepare
            # echo ($recv->getTimestamp() + 8 * 60 * 60) . " " . (strtotime("1970-01-01 $prepare UTC") + strtotime("Now") + 8 * 60 * 60) . "<br>";
            if(!($recv->getTimestamp() + 8 * 60 * 60 >= 
                (strtotime("1970-01-01 $prepare UTC") + strtotime("Now") + 8 * 60 * 60)))
                throw new \Exception('Impossible to make the order.');
    
            # $lower_bound < $esti_recv < $upper_bound
            # echo $lower_bound . " " . $esti_recv . " " . $upper_bound;
            $recv_parsed = date('Y-m-d H:i:s' ,intval(\other\date_api::is_valid_time($esti_recv)->getTimestamp()));
            if(!\other\date_api::is_between($lower_bound ,$recv_parsed ,$upper_bound))
                throw new \Exception("Off hours.");
        }
    }
    return true;
}

?>