<?php
namespace food;

class buffet
{
    public $id;
    public $dish;
    public $order;
    public $disabled;

    public function __construct($id ,$dish ,$order ,$disabled)
    {
        $this->id = $id;
        $this->dish = $dish;
        $this->order = $order;
        $this->disabled = $disabled;
    }

    public function get_json()
    {
        /**/
    }
}

?>