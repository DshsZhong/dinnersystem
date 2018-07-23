<?php

function make_custom_dish($json)
{


    $sql = "
        INSERT INTO `dinnersys`.`dish`
        (`dish_name`, `charge_sum`, `is_vegetarian`,
        `is_custom`, `is_idle`, `factory_id`, `content`)
        VALUES
        (?, ?, ?,
        true, false, ?, ?);

        SELECT MAX(id) FROM dinnersys.dish;
    ";
    

    $dish_id = 0;
    return $dish_id;
}

?>