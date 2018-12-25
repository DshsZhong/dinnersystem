<?php
namespace order;

function delete_auth($row ,$type) {
    $has_paid = false;
    switch($type) {
        case "self":
            foreach($row->money->payment as $payment)
                $has_paid |= $payment->paid;
            $uid = unserialize($_SESSION['me'])->id;
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
        case 'none':
            break;
    }

    return true;
}

?>