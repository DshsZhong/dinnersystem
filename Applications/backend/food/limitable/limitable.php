<?php
namespace food;

class limitable {
    public $sum;
    public $limit;
    public $last_update;
    const max = 2147483647;

    function init_limit($last_update ,$sum ,$limit) {
        $this->sum = $sum;
        $this->limit = $limit;
        $this->last_update = $last_update;
    }

    function get_remaining() {
        if(date("Y-m-d" ,strtotime($this->last_update)) === date("Y-m-d")) {
            if($this->limit == -1) {
                return self::max;
            } else {
                return $this->limit - $this-sum;
            }
        } else {
            if($this->limit == -1) {
                return self::max;
            } else {
                return $this->limit;
            }
        }
    }
}


?>