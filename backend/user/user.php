<?php
namespace user;

use json\json_output;
use json\json_format;

class user implements json_format
{
    public $id;
    public $name;
    public $class;
    public $seat_no;

    public $login_id = "";
    public $password  = "";
    public $is_vege;
    public $prev_sum = 0;

    public $servives = [];
    public $prev = [];
    public $services_output = [];
    
    function __construct($usr_id ,$name ,$class ,$seat_no)
    {
        $this->id = $usr_id;
        $this->name = $name;
        $this->class= $class;
        $this->seat_no = $seat_no;

        $this->is_vege = new \food\vege(null ,null);
    }
    
    public function full_init($services ,$prev)
    {
        $this->services = $services;
        $this->prev = $prev;
        foreach($services as $key => $value) $this->services_output[$key] = true;
    }

    public function private_init($prev_sum ,$vege ,$login_id ,$password)
    {
        $this->prev_sum = $prev_sum;
        $this->is_vege = $vege;
        $this->login_id = $login_id;
        $this->password = $password;
    }
    
    public function get_json()
    {
        $data = 
            '{"id":"' . json_output::filter($this->id) . 
            '","name":"' . json_output::filter($this->name) .
            '","vege":' . $this->is_vege->get_json() .
            ',"class":' . $this->class->get_json() .
            ',"seat_no":"' . json_output::filter($this->seat_no) .
            '","prev_sum":"' . json_output::filter($this->prev_sum) .
            '","valid_oper":' . json_output::array_to_json($this->services_output) . '}';

        return $data;
    }
}

?>