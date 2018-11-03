<?php
namespace order;

use json\json_output;
use json\json_format;

class order implements json_format
{
    public $id;
    public $user;
    public $order_maker;
    public $dish;
    public $money;
    
    public $esti_recv;
    
    public function __construct($id ,$dish, $user, $order_maker, $recv_date ,$money)
    {
        $this->id = $id;
        $this->dish = $dish;
        $this->user = $user;
        $this->order_maker = $order_maker;
        $this->esti_recv = $recv_date;
        $this->money = $money;
    }
    
    public function get_json()
    {
         $data = 
             '{"id" : "' . json_output::filter($this->id) . 
             '","user" : ' . $this->user->get_json() . 
             ',"order_maker" : ' . $this->order_maker->get_json() . 
             ',"dish" : ' . $this->dish->get_json() .  
             ',"money" : ' . $this->money->get_json() . 
             ',"recv_date" : "' . json_output::filter($this->esti_recv) . '"}';
         return $data;
    }

}
?>