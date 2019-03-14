<?php
namespace order\money_info;

use \other\check_valid;

function set_payment($req_id ,$hash ,$ord_id ,$permission ,$target)
{
    $ord_id = check_valid::white_list($ord_id ,check_valid::$only_number);
    $result = \order\select_order\select_order(['oid' => $ord_id]);
    $row = reset($result);
    if($row === null) 
        throw new \Exception("Can't find order.");

    $user_id = unserialize($_SESSION['me'])->id;

    $ip = config()["database"]["ip"];
    $account = config()["database"]["account"];
    $password = config()["database"]["password"];
    $name = config()["database"]["name"];
    $pdo = new \PDO("mysql:host=$ip;dbname=$name;charset=utf8", $account, $password);
    payment_auth($row ,$user_id ,$permission ,$target ,$hash ,$req_id);

    $pdo->beginTransaction();
    try
    {
        $sql_command = "UPDATE `dinnersys`.`payment` AS P
            SET `paid` = ?,
            `paid_datetime` = CURRENT_TIMESTAMP
            WHERE P.money_info = (SELECT O.money_id FROM `dinnersys`.`orders` AS O WHERE O.id = ? FOR UPDATE) 
            AND P.tag = 'payment';";
        $statement = $pdo->prepare($sql_command);
        $statement->execute([$target ,$ord_id]);  
        
        //to ensure we locked the row.
        $money = intval(\bank\get_money());
        if($money < $row->money->charge)
            throw new \Exception("Not enough money.");
        \bank\debit($row ,$hash);
    } catch (\Exception $e) {
        $pdo->rollback();
        throw $e;
    }
    $pdo->commit();

    return $row;
}

?>
