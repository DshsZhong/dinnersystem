<?php

function make_custom_order($user_id ,$json ,$esti_recv)
{
    load_dish();

    $did = make_custom_dish($json);
    return make_order($user_id ,$json ,$esti_recv);
}

?>