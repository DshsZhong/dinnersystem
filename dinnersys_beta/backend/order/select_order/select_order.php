<?php

function select_order($user_id ,$person ,$class ,$class_no ,$grade ,$yr ,
    $vege ,$usr ,$dm ,$cafet ,$facto ,$esti_start ,$esti_end ,$factory_id ,$oid)
{    
    $user_id = check_valid::white_list_null($user_id ,check_valid::$integers);
    $vege = check_valid::bool_null_check($vege);
    $usr = check_valid::bool_null_check($usr);
    $dm = check_valid::bool_null_check($dm);
    $cafet = check_valid::bool_null_check($cafet);
    $facto = check_valid::bool_null_check($facto);
    if($esti_start != null) $esti_start = date_api::is_valid_time($esti_start)->format('Y/m/d-H:i:s');
    if($esti_end != null) $esti_end = date_api::is_valid_time($esti_end)->format('Y/m/d-H:i:s');
    $factory_id = check_valid::white_list_null($factory_id ,check_valid::$only_number);
    $person = check_valid::bool_null_check($person);
    $class = check_valid::bool_null_check($class_no);
    $class_no = check_valid::white_list_null($class_no ,check_valid::$only_number);
    $grade = check_valid::white_list_null($grade ,check_valid::$only_number);
    $yr = check_valid::white_list_null($yr ,check_valid::$only_number);
    $oid = check_valid::white_list_null($oid ,check_valid::$only_number);

    $command = 
    "CALL select_order
        (? ,
        ? ,? ,? ,? ,
        ? ,? ,
        ? ,? ,? ,
        ? ,
        ? ,? ,? ,
        ?);";
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($command);
    
    $statement->bind_param('iiiiissiiiiiiii', 
        $vege ,
        $usr ,$dm ,$cafet ,$facto ,
        $esti_start ,$esti_end ,
        $factory_id ,
        $user_id, $person , $class ,
        $class_no ,
        $grade ,$yr ,
        $oid);
    $statement->execute();
    $statement->bind_result($id ,
                    $uid ,$seat_no ,$uname ,$class_no ,
                    $did ,$dname ,$dcharge ,
                    $mt_id ,$mt_charge ,
                    $esti_recv ,
                    $fid ,$fname ,
        $pid['u'] ,$paid['u'] ,$able_dt['u'] ,$paid_dt['u'] ,$freeze_dt['u'] ,     #u: user
        $pid['d'] ,$paid['d'] ,$able_dt['d'] ,$paid_dt['d'] ,$freeze_dt['d'] ,     #d: dinnerman
        $pid['c'] ,$paid['c'] ,$able_dt['c'] ,$paid_dt['c'] ,$freeze_dt['c'] ,     #c: cafeteria
        $pid['f'] ,$paid['f'] ,$able_dt['f'] ,$paid_dt['f'] ,$freeze_dt['f']);     #f: factory
    
    $result = []; 
    $cols = ['u' => 'user' ,'d' => 'dinnerman' ,'c' => 'cafeteria' ,'f' => 'factory'];
    while($statement->fetch())
    {
        $result[$id] = new order(
            $id ,
            new dish($did ,$dname ,$dcharge ,null ,null ,new factory($fid ,$fname) ,null) ,
            new user($uid ,$uname ,$class_no ,new vege(null)) ,
            new user($uid ,$uname ,$class_no ,new vege(null)) ,
            $esti_recv
        );
        foreach($cols as $key => $value)
        {
            $result[$id]->payment[$value] = 
                new payment($pid[$key] ,
                $paid[$key] ,$able_dt[$key] ,$paid_dt[$key] ,$freeze_dt[$key] ,
                $value ,$mt_charge);
        }
    }
    return $result;
}

?>