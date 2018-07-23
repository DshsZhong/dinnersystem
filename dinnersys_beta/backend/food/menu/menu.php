<?php

class menu implements json_format ,food
{
    public $id;
    public $name;
    public $charge;

    public $is_idle;

    public $factory;
    
    public function __construct($id ,$name ,$charge ,$is_idle ,$factory)
    {
        $this->id = $id;
        $this->name = $name;
        $this->charge = $charge;

        $this->is_idle = $is_idle;
        
        $this->factory = $factory;
    }
    
    public function get_json()
    {
        $json = 
            '{"dish_name":"' . json_output::filter($this->name) .
            '","dish_id":"' . json_output::filter($this->id) . 
            '","dish_cost":"' . json_output::filter($this->charge) .
            '","is_idle":"' . ($this->is_idle ? 'true' : 'false') . '"' .
            ($this->factory != null ? ',"factory":' . $this->factory->get_json() : '') . '}';
        return $json;
    }

    public function updatable() 
    {
        $uid = unserialize($_SESSION['user'])->id;
        $auth = unserialize($_SESSION['factory_auth']);
    
        return $auth[$uid][$this->factory->id];
    }
}

?>