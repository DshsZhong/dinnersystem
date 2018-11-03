<?php
namespace user;

use \other\check_valid;
function login($login_id, $pswd ,$device_id ,$check = true)
{
    if($check) 
    {
        $login_id = check_valid::white_list($login_id ,check_valid::$white_list_pattern);
        $pswd = check_valid::white_list($pswd ,check_valid::$white_list_pattern);

        $device_id = urldecode($device_id);
        $device_id = check_valid::regex_check($device_id ,check_valid::$device_regex);    
    }
    
    $login_command = "CALL login(? ,? ,?);";
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();

    $statement = $mysqli->prepare($login_command);
    
    $statement->bind_param('sss', $login_id, $pswd ,$device_id);

    $statement->execute();
    $statement->store_result();
    $statement->bind_result($id ,$name ,$class_id ,$is_vege ,$seat_id, $prev_sum);
    
    \other\init_vars();
    $class = unserialize($_SESSION['class']);
    $account = null;
    if($statement->fetch())
    {
        $account = new user($id ,$name ,$class[strval($class_id)] ,$seat_id);
        $account->private_init($prev_sum ,new \food\vege($is_vege) ,$login_id ,$pswd);  
    }
    
    if($account == null) throw new \Exception("No account.");

    $account->full_init(
        \user\get_able_oper($account->prev_sum) ,
        \user\previleges::get_prevs($account->prev_sum)
    );
    $_SESSION['me'] = serialize($account);
    return $account;
}

?>