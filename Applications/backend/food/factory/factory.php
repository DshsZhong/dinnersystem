<?php
namespace food;

use json\json_output;
use json\json_format;

class factory implements json_format
{
    public $id;
    public $name;
    public $lower_bound;
    public $prepare_time;
    public $upper_bound;
    public $disabled;
    public $boss_id;
    public $allow_custom;
    public $pos_id;
    public $daily_produce;

    public function __construct($id ,$name ,
        $lower_bound ,$prepare_time ,$upper_bound ,
        $disabled ,$boss_id ,$allow_custom ,$minimum ,
        $pos_id ,$daily_produce)
    {
        $this->id = $id;
        $this->name = $name;
        $this->lower_bound = $lower_bound;
        $this->prepare_time = $prepare_time;
        $this->upper_bound = $upper_bound;
        $this->disabled = $disabled;
        $this->boss_id = $boss_id;
        $this->allow_custom = $allow_custom;
        $this->minimum = $minimum;
        $this->pos_id = $pos_id;
        $this->daily_produce = $daily_produce;
    }
    
    public function get_json()
    {
        $json = 
            '{"id":"' . json_output::filter($this->id) .
            '","name":"' . json_output::filter($this->name) .
            '","lower_bound":"' . json_output::filter($this->lower_bound) .
            '","prepare_time":"' . json_output::filter($this->prepare_time) .
            '","upper_bound":"' . json_output::filter($this->upper_bound) .
            '","minimum":"' . json_output::filter($this->minimum) .
            '","daily_produce":"' . json_output::filter($this->daily_produce) .
            '","allow_custom":"' . ($this->allow_custom ? "true" : "false") .
            '","disabled":"' . json_output::filter($this->disabled) . '"}';
        return $json;
    }

    public function __clone() {
        $this->id = $this->id;
        $this->name = $this->name;
        $this->lower_bound = $this->lower_bound;
        $this->prepare_time = $this->prepare_time;
        $this->upper_bound = $this->upper_bound;
        $this->disabled = $this->disabled;
        $this->boss_id = $this->boss_id;
        $this->allow_custom = $this->allow_custom;
        $this->minimum = $this->minimum;
        $this->pos_id = $this->pos_id;
        $this->pos_id = $this->daily_produce;
    }
}
?>