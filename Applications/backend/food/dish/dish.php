<?php
namespace food;

use json\json_output;
use json\json_format;

class dish implements json_format ,food
{
    public $id;
    public $name;
    public $charge;
    public $vege;
    public $department;
    public $is_idle;
    public $daily_produce;

    public $sold_out;
    public $remaining = -1;
    
    public function __construct($id ,$name ,$charge ,$is_idle ,$department ,$is_vege ,$limit)
    {
        $this->id = $id;
        $this->name = $name;
        $this->charge = $charge;
        $this->is_idle = $is_idle;
        $this->department = $department;
        $this->vege = $is_vege;
        $this->daily_produce = $limit;
    }
    
    public function get_json()
    {
        $json = 
            '{"dish_name":"' . json_output::filter($this->name) .
            '","dish_id":"' . json_output::filter($this->id) . 
            '","vege":' . $this->vege->get_json() . 
            ',"department":' . $this->department->get_json() . 
            ',"dish_cost":"' . json_output::filter($this->charge) .
            '","daily_produce":"' . json_output::filter($this->daily_produce) .
            '","remaining":"' . json_output::filter($this->remaining) .
            '","is_idle":"' . json_output::filter($this->is_idle) . '"}';
        return $json;
    }

    public function updatable()
    {
        return updatable($this->department->factory->id);
    }

    public function __clone() {
        $this->id = $this->id;
        $this->name = $this->name;
        $this->charge = $this->charge;
        $this->is_idle = $this->is_idle;
        $this->department = clone $this->department;
    }
}

?>