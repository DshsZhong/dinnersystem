<?php

function login($login_id, $pswd ,$device_id ,$check = true)
{
    if($check) 
    {
        $login_id = check_valid::white_list($login_id ,check_valid::$white_list_pattern);
        $pswd = check_valid::white_list($pswd ,check_valid::$white_list_pattern);
        $device_id = check_valid::white_list($device_id ,check_valid::$white_list_pattern);    
    }
    
    $login_command = "CALL login(? ,? ,?);";
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();

    $statement = $mysqli->prepare($login_command);
    
    $statement->bind_param('sss', $login_id, $pswd ,$device_id);

    $statement->execute();
    $statement->store_result();
    $statement->bind_result($id ,$name ,$class_id ,$is_vege);
    
    if($statement->fetch())
        $account = new user($id ,$name ,$class_id ,new vege($is_vege)
            ,$login_id ,$pswd);   
        
    if($account == null) throw new Exception("No account.");
    
    load_food();
    $_SESSION['factory_auth'] = serialize(factory_auth());
    $account->init_serv();
    $_SESSION['user'] = serialize($account);
    return $account;
}
?>