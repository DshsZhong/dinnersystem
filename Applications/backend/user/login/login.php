<?php
namespace user\login;

use \other\check_valid;
use \user\user;

function update_device($uid ,$device)
{
    $sql_command = "UPDATE `dinnersys`.`users` SET `device_id` = ? WHERE `id` = ?;";
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('is',$uid ,$device);
    $statement->execute();
}

function get_data($uid ,$class)
{
    $sql_command = "SELECT U.id ,UI.name ,U.class_id ,UI.is_vegetarian ,UI.seat_id ,UI.bank_id ,U.prev_sum ,U.login_id ,U.password ,U.PIN
        FROM `dinnersys`.`users` AS U ,`dinnersys`.`user_information` AS UI
        WHERE U.info_id = UI.id AND U.id = ?;";
    $mysqli = $_SESSION['sql_server'];
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('i',$uid);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($id ,$name ,$class_id ,$is_vege ,$seat_id, $bank_id, $prev_sum ,$login_id ,$pswd ,$PIN);
    if($statement->fetch())
    {
        $account = new user($id ,$name ,$class[strval($class_id)] ,$seat_id);
        $account->private_init($prev_sum ,new \food\vege($is_vege) ,$login_id ,$bank_id ,$pswd ,$PIN);  
    }
    return $account;
}

function login($login_id, $hash ,$device_id ,$req_id)
{
    $login_id = check_valid::white_list($login_id ,check_valid::$white_list_pattern);
    $device_id = urldecode($device_id);
    $device_id = check_valid::regex_check($device_id ,check_valid::$device_regex);
    
    $result = auth($login_id ,$hash);
    # die(json_encode($result));
    $uid = $result["uid"];
    \punish\check($uid ,"login");
    if(count($result["msg"]) != 0)
    {
        \punish\attempt($uid ,$req_id ,"login"); 
        throw new \Exception(reset($result["msg"]));
    }
    $class = \user\get_class();
    $_SESSION["class"] = serialize($class);
    update_device($uid ,$device_id);
    $account = get_data($uid ,$class);
    $_SESSION['me'] = serialize($account);
    \other\init_vars();
    return $account;
}

?>