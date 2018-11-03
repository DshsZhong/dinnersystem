<?php
namespace backend_proc;


class order_handler
{

public $input;

function __construct($input)
{
    if($_SESSION['me'] == null)
        $user = \user\login('guest' ,'!!!!!' ,"NULL" ,false);
    $this->input = $input;
}

function process_order()
{
    $cmd = $this->input['cmd'];
    $func = unserialize($_SESSION['me'])->services[$cmd];
    $user = unserialize($_SESSION['me']);

    \other\make_log($user->id ,$func ,$_SERVER['REQUEST_URI'] ,serialize($this->input) ,\other\get_ip());

    try
    {
        return $this->$func();   # A very danger way to call a function. #
    }
    catch(\Exception $e) { return $e->getMessage(); }
}

function login()
{
    return \user\login($this->input['id']
        ,$this->input['password'] 
        ,$this->input['device_id']);
}

function logout() 
{
    \user\logout();
    return "Successfully logout.";
}

function show_dish()
{
    return \food\get_dish();
}

function update_dish()
{
    return \food\update_dish($this->input['id'] ,
        $this->input['dish_name'] ,
        $this->input['charge_sum'] ,
        $this->input['is_vege'] ,
        $this->input['is_idle']);
}

function show_order()
{
    $param = $this->input;
    $param['user_id'] = strval(unserialize($_SESSION['me'])->id);
    switch($this->input['cmd'])
    {
        case 'select_self':
            $param['person'] = true;
            break;
        case 'select_class':
            $param['class'] = true;
            break;
        case 'select_facto':
            $param['factory_id'] = \order\select_order\get_factory_id($param["user_id"]);
            break;
        case 'select_other':
            $param['user_id'] = $this->input['uid'];
            $param['person'] = $this->input['person'];
            $param['class'] = $this->input['class'];
            break;
    }
    return \order\select_order\select_order($param);
}

function make_order()
{  
    switch($this->input['cmd']) {
        case 'make_self_order':
            return \order\make_order\make_order(null ,$this->input['dish_id'] ,$this->input['time'] ,'self');
            break;
        case 'make_class_order':
            return \order\make_order\make_order($this->input['target_id'] ,$this->input['dish_id'] ,$this->input['time'] ,'class');
            break;
        case 'make_everyone_order':
            return \order\make_order\make_order($this->input['target_id'] ,$this->input['dish_id'] ,$this->input['time'] ,'everyone');
            break;
    }
}

function set_payment()
{   
    $target = ($this->input['target'] == 'true');
    $user_id = unserialize($_SESSION['me'])->id;
    switch($this->input['cmd'])
    {
        case 'payment_usr':
            $money_to = 'user';
            break;
        case 'payment_dm':
            $money_to = 'dinnerman';
            break;
        case 'payment_cafet':
            $money_to = 'cafeteria';
            break;
        case 'payment_facto':
            $money_to = 'factory';
            break;
    }
    return \order\money_info\set_payment($this->input['order_id'] ,$user_id ,$money_to ,$target);
}

function change_password()
{
    return \user\change_password($this->input['old_pswd'] ,$this->input['new_pswd']);
}
    
function delete_order()
{
    switch($this->input['cmd'])
    {
        case 'delete_self':
            return \order\delete_order($this->input['order_id'] ,'self');
            break;
        case 'delete_dm':
            return \order\delete_order($this->input['order_id'] ,'class');
            break;
        case 'delete_everyone':
            return \order\delete_order($this->input['order_id'] ,'none');
            break;
    }
}


# This funciton has been disabled. #
/*
function register()
{
    \user\register($this->input['user_name'] ,
        $this->input['phone_number'] ,
        $this->input['is_vege'] ,
        $this->input['gen'] ,
        $this->input['email'] ,
        $this->input['login_id'] ,
        $this->input['password']);
    return "Succesfully registered user.";
}
*/

function announce_handle()
{
    if($this->input['cmd'] == 'get_announce')
    {
        $result = \order\get_announce($this->input['start'] ,$this->input['end']);
        return $result;
    }
    if($this->input['cmd'] == 'done_announce')
    {
        \order\done_announce($this->input['id'] ,$this->input['device_id']);
        return 'Succesfully recorded to server.';
    }
}

}

?>