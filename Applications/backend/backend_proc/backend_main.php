<?php
namespace backend_proc;

class backend_main
{
    public $order_handler;
    public $input;
    
    function __construct($input = null)
    {
        require_once (__DIR__ . '/order_handler.php');
        

        
        require_once (__DIR__ . '/../json/json_format.php'); 
        require_once (__DIR__ . '/../json/json_output.php'); 
        require_once (__DIR__ . '/../json/json_adjust.php');



        require_once (__DIR__ . '/../food/food.php');
        require_once (__DIR__ . '/../food/buffet/buffet.php');

        require_once (__DIR__ . '/../food/department/department.php');
        require_once (__DIR__ . '/../food/department/get_department.php');

        require_once (__DIR__ . '/../food/dish/update_dish.php');
        require_once (__DIR__ . '/../food/dish/dish.php');
        require_once (__DIR__ . '/../food/dish/get_dish.php');
        require_once (__DIR__ . '/../food/dish/updatable.php');

        require_once (__DIR__ . '/../food/factory/factory.php');
        require_once (__DIR__ . '/../food/factory/get_factory.php');

        require_once (__DIR__ . '/../food/vege/vege.php');
        


        require_once (__DIR__ . '/../order/announce/announce.php');
        require_once (__DIR__ . '/../order/announce/done_announce.php');
        require_once (__DIR__ . '/../order/announce/get_announce.php');

        require_once (__DIR__ . '/../order/delete_order/delete.php');
        require_once (__DIR__ . '/../order/delete_order/delete_auth.php');

        require_once (__DIR__ . '/../order/logistics/logistics.php');

        require_once (__DIR__ . '/../order/make_order/get_user_id.php');
        require_once (__DIR__ . '/../order/make_order/make_order.php');
        require_once (__DIR__ . '/../order/make_order/get_time.php');

        require_once (__DIR__ . '/../order/money_info/payment/payment.php');
        require_once (__DIR__ . '/../order/money_info/payment/payment_auth.php');
        require_once (__DIR__ . '/../order/money_info/payment/payment.php');
        require_once (__DIR__ . '/../order/money_info/payment/set_payment.php');
        require_once (__DIR__ . '/../order/money_info/get_payments.php');
        require_once (__DIR__ . '/../order/money_info/money_info.php');

        require_once (__DIR__ . '/../order/select_order/create_statement.php');
        require_once (__DIR__ . '/../order/select_order/extend_record.php');
        require_once (__DIR__ . '/../order/select_order/get_orders.php');
        require_once (__DIR__ . '/../order/select_order/select_sql.php');
        require_once (__DIR__ . '/../order/select_order/select_order.php');
        require_once (__DIR__ . '/../order/select_order/select_payment.php');
        require_once (__DIR__ . '/../order/select_order/get_factory_id.php');

        require_once (__DIR__ . '/../order/order.php');


        
        require_once (__DIR__ . '/../other/check_valid.php');
        require_once (__DIR__ . '/../other/date_api.php');
        require_once (__DIR__ . '/../other/get_ip.php');
        require_once (__DIR__ . '/../other/init_vars.php');
        require_once (__DIR__ . '/../other/make_log.php');
        

        
        require_once (__DIR__ . '/../user/class/user_class.php');
        require_once (__DIR__ . '/../user/class/get_class.php');

        require_once (__DIR__ . '/../user/oper_prev/get_able_oper.php');
        require_once (__DIR__ . '/../user/oper_prev/operation.php');
        require_once (__DIR__ . '/../user/oper_prev/previleges.php');

        require_once (__DIR__ . '/../user/register/register.php');
        require_once (__DIR__ . '/../user/register/check_id.php');

        require_once (__DIR__ . '/../user/change_password.php');
        require_once (__DIR__ . '/../user/get_user.php');
        require_once (__DIR__ . '/../user/login.php');
        require_once (__DIR__ . '/../user/logout.php');
        require_once (__DIR__ . '/../user/user.php');

        $this->input = $input;
    }
    
    function init_serv()    #start a new connection.
    {
        if($_SESSION['sql_server'] == null || !$_SESSION['sql_server']->ping()) {
            $server_connection = new \mysqli("localhost", "root", "", "dinnersys");
            \mysqli_set_charset($server_connection ,"utf8");
            $_SESSION['sql_server'] = $server_connection;
        }
        
        if($this->input == null) {
            \header("charset=utf-8;");
            $this->order_handler = new order_handler($_REQUEST);  
        } else {
            $this->order_handler = new order_handler($this->input);  
        }
    }
    
    function run()
    {
        session_start();
        $this->init_serv();
        #sleep(1);
        return $this->order_handler->process_order();
    }
}

?>