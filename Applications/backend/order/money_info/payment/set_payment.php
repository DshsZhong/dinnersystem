<?php
namespace order\money_info;

use \other\check_valid;

function set_payment($req_id ,$hash ,$ord_id ,$permission ,$target)
{
    $ord_id = check_valid::white_list($ord_id ,check_valid::$only_number);

    $ip = config()["database"]["ip"];
    $account = config()["database"]["account"];
    $password = config()["database"]["password"];
    $name = config()["database"]["name"];
    $pdo = new \PDO("mysql:host=$ip;dbname=$name;charset=utf8", $account, $password);
    $pdo->beginTransaction();
    
    $result = \order\select_order\select_order(['oid' => $ord_id]);
    $row = reset($result);

    if($row === null) 
        throw new \Exception("Can't find order.");
    payment_auth($row ,unserialize($_SESSION['me'])->id ,$permission ,$target ,$hash ,$req_id);
    try
    {
        $sql_command = "CALL payment(? ,?)";
        $statement = $pdo->prepare($sql_command);
        $statement->execute([$ord_id ,$target]); //to ensure we locked the row.
        $result = $statement->fetch(\PDO::FETCH_NUM);
        if($result[0] != "success")
            throw new \Exception($result[0]);

        /* The part is extremely slow. Ventem ,fuck you */
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
