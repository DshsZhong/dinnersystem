<?php

class dish implements json_format ,food
{
    public $id;
    public $name;
    public $charge;
    
    public $factory;
    
    public $is_custom;
    public $is_idle;

    public $content;
    
    public function __construct($id ,$name ,$charge ,$is_idle ,$is_custom ,$factory ,$content)
    {
        $this->id = $id;
        $this->name = $name;
        $this->charge = $charge;
        $this->factory = $factory;
        $this->is_idle = $is_idle;
        $this->is_custom = $is_custom;

        if($content === null) $this->content = "{}";
        else $this->content = $content;
    }
    
    public function get_json()
    {
        $json = 
            '{"dish_name":"' . json_output::filter($this->name) .
            '","dish_id":"' . json_output::filter($this->id) . 
            '","dish_cost":"' . json_output::filter($this->charge) .
            '","is_custom":"' . json_output::filter($this->is_custom) . 
            '","is_idle":"' . json_output::filter($this->is_idle) .
            '","content":' . $this->content .  
            ($this->factory != null ? ',"factory":' . $this->factory->get_json() : '') . '}';
        return $json;
    }

    public function updatable()
    {
        if($this->is_custom) return false;

        $uid = unserialize($_SESSION['user'])->id;
        $auth = unserialize($_SESSION['factory_auth']);
        return $auth[$uid][$this->factory->id];
    }
}

?>