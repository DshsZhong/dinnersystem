<?php
namespace backend_proc;


class order_handler
{

public $input;
public $req_id;

function __construct($input)
{
    session_start();
    \other\init_server();
    if($input["cmd"] != "login")
        session_write_close();

    if($_SESSION['me'] == null)
        $_SESSION['me'] = serialize(\user\user::get_guest());
    $this->input = $input;
}

function process_order()
{
    $cmd = $this->input['cmd'];
    $func = unserialize($_SESSION['me'])->services[$cmd];
    $user = unserialize($_SESSION['me']);
    $this->req_id = \other\log\make_log($user->id ,$func ,$_SERVER['REQUEST_URI'] ,serialize($this->input) ,\other\get_ip());
    try
    {
        return $this->$func();   # A very danger way to call a function. #
    } catch(\Exception $e) { 
        $output = $e->getMessage(); 
        \other\log\make_error_log($this->req_id ,$output);
        return $output;
    }
}

function login()
{
    return \user\login\login($this->input['id'] ,$this->input['hash'] ,$this->input['device_id'] ,$this->req_id);
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
        case 'make_everyone_order':
            return \order\make_order\make_order($this->input['target_id'] ,$this->input['dish_id'] ,$this->input['time'] ,'everyone');
            break;
    }
}

function set_payment()
{   
    $target = ($this->input['target'] == 'true');
    switch($this->input['cmd'])
    {
        case 'payment_self':
            return \order\money_info\set_payment($this->req_id ,$this->input['hash'] ,$this->input['order_id'] ,"self" ,$target);
            break;
        case 'payment_everyone':
            return \order\money_info\set_payment($this->req_id ,$this->input['hash'] ,$this->input['order_id'] ,"everyone" ,$target);
            break;
    }
    
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
        case 'delete_everyone':
            return \order\delete_order($this->input['order_id'] ,'none');
            break;
    }
}

function get_money()
{
    return \bank\get_money();
}
}

?>