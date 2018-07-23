<?php

class backend_main
{
    public $order_handler;
    public $input;
    
    function __construct($input = null)
    {
        require_once (__DIR__ . '/order_handler.php');
        require_once (__DIR__ . '/date_api.php');
        require_once (__DIR__ . '/check_valid.php');
 
        require_once (__DIR__ . '/../json/json_format.php'); 
        require_once (__DIR__ . '/../json/json_output.php'); 
        require_once (__DIR__ . '/../json/json_adjust.php');
        
        require_once (__DIR__ . '/../other/get_able_oper.php');
        require_once (__DIR__ . '/../other/make_log.php');
        require_once (__DIR__ . '/../other/lock_tables.php');
        
        require_once (__DIR__ . '/../user/login.php');
        require_once (__DIR__ . '/../user/change_password.php');
        require_once (__DIR__ . '/../user/logout.php');
        require_once (__DIR__ . '/../user/user.php');

        require_once (__DIR__ . '/../user/register/register.php');
        require_once (__DIR__ . '/../user/register/check_register_id.php');
        
        require_once (__DIR__ . '/../food/load_food.php');
        require_once (__DIR__ . '/../food/food.php');
        require_once (__DIR__ . '/../food/menu/update_menu.php');
        require_once (__DIR__ . '/../food/menu/menu.php');
        require_once (__DIR__ . '/../food/menu/get_menu.php');
        require_once (__DIR__ . '/../food/factory/factory.php');
        require_once (__DIR__ . '/../food/factory/get_factory_info.php');
        require_once (__DIR__ . '/../food/factory/factory_auth.php');
        require_once (__DIR__ . '/../food/dish/update_dish.php');
        require_once (__DIR__ . '/../food/dish/make_custom_dish.php');
        require_once (__DIR__ . '/../food/dish/dish.php');
        require_once (__DIR__ . '/../food/dish/get_dish.php');

        require_once (__DIR__ . '/../food/vege/vege.php');
        
        require_once (__DIR__ . '/../order/select_order/select_order.php');
        require_once (__DIR__ . '/../order/make_custom_order.php');
        require_once (__DIR__ . '/../order/payment/payment.php');
        require_once (__DIR__ . '/../order/payment/set_payment.php');
        require_once (__DIR__ . '/../order/order.php');

        require_once (__DIR__ . '/../order/make_order/make_order.php');
        require_once (__DIR__ . '/../order/make_order/check_make_order.php');

        require_once (__DIR__ . '/../order/disable_order/check_recv.php');
        require_once (__DIR__ . '/../order/disable_order/delete.php');
        require_once (__DIR__ . '/../order/disable_order/authenticate.php');
        
        require_once (__DIR__ . '/../order/announce/announce.php');
        require_once (__DIR__ . '/../order/announce/get_announce.php');
        require_once (__DIR__ . '/../order/announce/done_announce.php');

        $this->input = $input;
    }
    
    function init_serv()    #start a new connection.
    {
        if($_SESSION['sql_server'] == null || !$_SESSION['sql_server']->ping()) {
            $server_connection = new mysqli("localhost", "root", "2rjurrru", "dinnersys");
            mysqli_set_charset($server_connection ,"utf8");
            $_SESSION['sql_server'] = $server_connection;
        }
        
        if($this->input == null) {
            header("Content-Type:text/html; charset=utf-8");
            $this->order_handler = new order_handler($_REQUEST);  
        } else {
            $this->order_handler = new order_handler($this->input);  
        }
        
    }
    
    function run()
    {
        session_start();
        $this->init_serv();
        return $this->order_handler->process_order();
    }
}

?>