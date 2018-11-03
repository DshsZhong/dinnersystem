<?php
namespace order;

function delete_auth($row ,$type) {
    $has_paid = false;
    switch($type) {
        case "self":
            $has_paid = ($row->money->payment['user']->paid || $row->money->payment['dinnerman']->paid || $row->money->payment['cafeteria']->paid || $row->money->payment['factory']->paid);
            $uid = unserialize($_SESSION['me'])->id;
            break;
        case 'class':
            $has_paid = ($row->money->payment['dinnerman']->paid || $row->money->payment['cafeteria']->paid || $row->money->payment['factory']->paid);
            $cid = unserialize($_SESSION['me'])->class->class_no;
            break;
        case 'none':
            break;
    }
    
    if($has_paid) {
        throw new \Exception("This order already has payment.");
    }

    $self = unserialize($_SESSION['me']);
    switch($type) {
        case "self":
            if($row->user->id != $self->id) 
                throw new \Exception("No permission to delete this order.");
            break;
        case 'class':
            if($row->user->class->id != $self->class->id) 
                throw new \Exception("No permission to delete this order.");
            break;
        case 'none':
            break;
    }

    return true;
}

?>