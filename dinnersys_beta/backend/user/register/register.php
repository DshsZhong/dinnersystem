<?php

function register($usr_name ,$phone_num ,$is_vege ,$gen ,$email ,$usr_login_id ,$pswd)
{
    $usr_name = htmlspecialchars($usr_name);
    $phone_num = check_valid::regex_check($phone_num ,check_valid::$phone_regex);
    $is_vege = check_valid::vege_check($is_vege);
    $gen = check_valid::gen_check($gen);
    $email = check_valid::regex_check($email ,check_valid::$email_regex);
    $usr_login_id = check_valid::white_list($usr_login_id ,check_valid::$white_list_pattern);
    $pswd = check_valid::white_list($pswd ,check_valid::$white_list_pattern);

    if(!check_id($usr_login_id))
        throw new Exception("Repeated login id.");
    
    $first = "INSERT INTO `dinnersys`.`user_information`
        (`name`, `ad_times`,`phone_number`, `is_vegetarian`,
        `credits`, `gender`, `class_id`, `school_id` ,
        `seat_id` ,`email`)
        VALUES
        (? ,0 ,? ,? ,
        0 ,? ,-1 ,NULL ,
        NULL ,?);";
		
    $second = "INSERT INTO `dinnersys`.`users`
        (`login_id`,`prev_sum`, `password`,
        `class_id`, `year`, `info_id`)
        VALUES
        (? ,3 ,? ,
        -1 ,-1 ,(SELECT MAX(UI.id) FROM `dinnersys`.`user_information` AS UI));"; 
    
    $mysqli = $_SESSION['sql_server'];
    $mysqli->next_result();

    $statement = $mysqli->prepare($first);
    $statement->bind_param('ssiss',$usr_name ,$phone_num ,$is_vege ,$gen ,$email);
    $statement->execute();

    $statement = $mysqli->prepare($second);
    $statement->bind_param('ss' ,$usr_login_id ,$pswd);
    $statement->execute();
}

?>