<?php
class sort_function {
    static function sort_cafeteria($a ,$b) {
        $time_a = ($a->info->time['cafeteria']);
        $time_b = ($b->info->time['cafeteria']);
        return ($time_a == $time_b ? 0 : 
            ($time_a < $time_b) ? -1 : 1);
    }
    static function sort_dinnerman($a ,$b) {
        $time_a = ($a->info->time['dinnerman']);
        $time_b = ($b->info->time['dinnerman']);
        return ($time_a == $time_b ? 0 : 
            ($time_a < $time_b) ? -1 : 1);
    }
    static function sort_paid($a ,$b) {
        $paid_a = ($a->info->paid['cafeteria']);
        $paid_b = ($b->info->paid['cafeteria']);
        return ($paid_a == $paid_b ? 0 : 
            ($paid_a == true && $paid_b == false) ? -1 : 1);
    }
    static function sort_class($a ,$b) {
        $class_a = ($a->info->class);
        $class_b = ($b->info->class);
        return ($class_a == $class_b ? 0 : 
            ($class_a < $class_b) ? -1 : 1);
    }
}
?>