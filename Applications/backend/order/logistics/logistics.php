<?php
namespace order;

use json\json_output;
use json\json_format;

class user implements json_format
{
    public $id;
    public $order_datetime;
    public $recv_datetime;
    public $cargo;
    
    function __construct($id ,$year ,$grade ,$class_no )
    {
        $this->id = $id;
        $this->year = $year;
        $this->grade = $grade;
        $this->class_no = $class_no;
    }
    
    public function get_json()
    {
        $data = 
            '{"id":"' . json_output::filter($this->id) . 
            '","year":"' . json_output::filter($this->name) .
            '","grade":"' . json_output::filter($this->ngradeame) .
            '","class_no":"' . json_output::filter($this->class_no) . '"}';

        return $data;
    }
}

?>