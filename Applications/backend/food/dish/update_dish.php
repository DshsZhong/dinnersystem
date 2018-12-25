<?php
namespace food;
use \other\check_valid;

function update_dish($id ,$dname ,$csum ,$vege ,$idle)
{
    $id = check_valid::white_list($id ,check_valid::$only_number); 
    $dname = htmlspecialchars($dname);
    $csum = check_valid::white_list($csum ,check_valid::$only_number);
    $vege = check_valid::vege_check($vege);
    if($idle != null) $idle = ($idle == 'true');
    
    $row = get_dish($id)[$id];
    if($row == null || !$row->updatable()) 
        throw new \Exception("Access denied..");
    $same = (
        $row->name == $dname &&
        $row->charge == $csum  &&
        $row->vege->name == $vege &&
        $row->is_idle == $idle
    );
    if($same) return "Nothing to update.";

    $mysqli = $_SESSION['sql_server'];
    $sql = "CALL update_dish(? ,? ,? ,? ,?)";
    
    $statement = $mysqli->prepare($sql);
    $statement->bind_param('isiii' ,$id ,$dname ,$csum ,$vege ,$idle);
    $statement->execute();

    return "Successfully updated food.";
}

?>