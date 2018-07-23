<?php

function make_order($dish_id ,$esti_recv)
{   
    load_dish();

    $dish_id = check_valid::white_list($dish_id ,check_valid::$only_number);
    $dish = unserialize($_SESSION['dish'])[$dish_id];
    $esti_recv = date_api::check_recv_time($esti_recv);
    if($dish == null) throw new Exception("Invalid dish id.");

    $self_id = unserialize($_SESSION['user'])->id;

    $sql_command = "SELECT make_order(? ,? ,? ,?)";
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();
    $statement = $mysqli->prepare($sql_command);
    $statement->bind_param('iiis' ,$self_id ,$self_id ,$dish_id ,$esti_recv);
    $statement->execute();
    $statement->store_result();
    $statement->bind_result($result);
    
    if($statement->fetch())
        return $result;
    else throw new Exception("Unable to fetch data from server.");
}

?>