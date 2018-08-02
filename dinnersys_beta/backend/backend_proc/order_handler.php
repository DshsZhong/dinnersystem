<?php
class order_handler
{

public $input;

function __construct($input)
{
    if($_SESSION['user'] == null)
    {
        $user = login('guest' ,'!!!!!' ,"NULL" ,false);
        $_SESSION['user'] = serialize($user);
    }
    $this->input = $input;
    
}

function process_order()
{
    $cmd = $this->input['cmd'];
    $func = unserialize($_SESSION['able_serv'])[$cmd];
    $user = unserialize($_SESSION['user']);

    make_log($user->id ,$func ,$_SERVER['REQUEST_URI'] ,serialize($this->input) ,$user->get_ip());

    return $this->$func();                     # A very danger way to call a function. #
}

function login()
{
    try
    {
        $user = login($this->input['id']
            ,$this->input['password'] 
            ,$this->input['device_id']);
    }
    catch(Exception $e) { return $e->getMessage(); }
    
    return json_output::output(unserialize($_SESSION['user']));
}

function logout() 
{
    logout();
    die("Successfully logout.");
}

function show_food()
{
    if($this->input['cmd'] == 'show_dish') {
        $result = get_dish($this->input['is_custom'] ,
            $this->input['is_custom']);
    }
    if($this->input['cmd'] == 'show_menu') $result = get_menu($this->input['is_custom']);
    return json_output::output($result);
}

function update_food()
{
    try
    {
        if($this->input['cmd'] == "update_menu")
        {
            update_menu($this->input['id'] ,
                $this->input['charge'] ,
                $this->input['name'] ,
                $this->input['vege'] ,
                $this->input['idle']);
        }
        if($this->input['cmd'] == "update_dish")
        {
            update_dish($this->input['id'] ,
                $this->input['dish_name'] ,
                $this->input['charge_sum'] ,
                $this->input['is_vege'] ,
                $this->input['is_idle']);
        } 
    }catch(Exception $e) {return $e->getMessage(); }
    return "Successfully updated food.";
}

function show_order()
{
    $user_id = strval(unserialize($_SESSION['user'])->id);
    $person = $class = $grade = $yr = $class_no = null;
    $factory_id = $this->input['factory_id'];
    try
    {
        switch($this->input['cmd'])
        {
            case 'select_self':
                $person = true;
                break;
            case 'select_class':
                $class = true; 
                break;
            case 'select_facto':
                $factory_id = strval(key(unserialize($_SESSION['factory_auth'])[$user_id]));
                break;
            case 'select_other':
                $user_id = $this->input['uid'];
                $person = $this->input['person'];
                $class = $this->input['class'];
                $class_no = $this->input['class_no'];
                $grade = $this->input['grade'];
                $yr = $this->input['year'];
                break;
            case 'select_everyone':
                break;
        }

        $result = select_order($user_id ,
            $person ,$class ,
            $class_no ,$grade ,$yr ,
            $this->input['vege'] ,
            $this->input['usr'] ,$this->input['dm'] ,$this->input['cafet'] ,$this->input['facto'],
            $this->input['esti_start'] ,$this->input['esti_end'] ,
            $factory_id ,
            $this->input['oid']);
    }catch(Exception $e) {return $e->getMessage();}
    
    return json_output::output($result);
}

function make_order()
{  
    try
    {
        return make_order($this->input['dish_id'] 
            ,$this->input['time']);
    }
    catch(Exception $e) { return $e->getMessage(); }
}

function make_custom_order()        # not activated.
{
    try
    {
        return make_custom_order(unserialize($_SESSION['user'])->id ,
            $this->input['dish_data'] ,
            $this->input['time']);
    }catch(Exception $e) {return $e->getMessage();}    
}

function set_payment()
{   
    try
    {
        $target = ($this->input['target'] == 'true');
        $ip = unserialize($_SESSION['user'])->get_ip();
        $user_id = unserialize($_SESSION['user'])->id;
        switch($this->input['cmd'])
        {
            case 'payment_dm':
                $money_to = 'dm';
                break;
            case 'payment_cafet':
                $money_to = 'cafet';
                break;
            case 'payment_facto':
                $money_to = 'fact';
                break;
        }
        set_payment($this->input['order_id'] ,$user_id ,$money_to ,$target ,$ip);
    }catch(Exception $e){ return $e->getMessage(); }
    return "Successfully set payment.";
}

function change_password()
{
    try
    {
        change_password($this->input['old_pswd'] ,$this->input['new_pswd']);
    }catch(Exception $e){return $e->getMessage();}
    return "Successfully changed password.";
}
    
function delete_order()
{
    $data = null;
    try
    {
        switch($this->input['cmd'])
        {
            case 'delete_self':
                $data = delete_order($this->input['order_id'] ,'self');
                break;
            case 'delete_dm':
                $data = delete_order($this->input['order_id'] ,'class');
                break;
            case 'delete_facto':
                $data = delete_order($this->input['order_id'] ,'facto');
                break;
            case 'delete_everyone':
                $data = delete_order($this->input['order_id'] ,'none');
                break;
        }
    } catch(Exception $e) { return $e->getMessage();}
    return json_output::output($data);
}

function get_date()
{
    if($this->input['cmd'] == 'get_date')
        return json_output::date_to_json(date_api::get_date_array());
    if($this->input['cmd'] == 'get_datetime')
        return json_output::date_to_json(date_api::get_datetime_array());
}

function register()
{
    try
    {
        register($this->input['user_name'] ,
            $this->input['phone_number'] ,
            $this->input['is_vege'] ,
            $this->input['gen'] ,
            $this->input['email'] ,
            $this->input['login_id'] ,
            $this->input['password']);
    }catch(Exception $e) {return $e->getMessage();}
    return "Succesfully registered user.";
}

function check_recv()
{
    $data = null;
    try
    {
        $id = $this->input['order_id'];
        $data = check_recv($id);
    }catch(Exception $e) {return $e->getMessage();}
    return json_output::output($data);
}

function announce_handle()
{
    if($this->input['cmd'] == 'get_announce')
    {
        $result = get_announce($this->input['start'] ,$this->input['end']);
        return json_output::output($result);
    }
    if($this->input['cmd'] == 'done_announce')
    {
        done_announce($this->input['id'] ,$this->input['device_id']);
        return 'Succesfully recorded to server.';
    }
}

function show_factory()
{
    $result = get_factory_info($this->input['id']);
    return json_output::output($result);
}

}

?>