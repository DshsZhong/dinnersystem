<?php
namespace order\select_order;

function normal_sql() {
    return "SELECT 
        
        O.id ,
        D.id ,
        MI.id ,MI.money_sum ,
        LO.esti_recv_datetime ,
        O.user_id ,O.order_maker
        
        FROM orders AS O
        INNER JOIN users AS U 				ON O.user_id = U.id
        INNER JOIN user_information AS UI 	ON U.info_id = UI.id
        INNER JOIN class AS C				ON U.class_id = C.id
        INNER JOIN dish AS D				ON O.dish = D.id
        INNER JOIN department AS DP			ON D.department_id = DP.id
        INNER JOIN factory AS F				ON DP.factory = F.id
        INNER JOIN money_info AS MI			ON O.money_id = MI.id
        INNER JOIN logistics_info AS LO		ON O.logistics_id = LO.id
    
        WHERE O.disabled = FALSE
    ";
}

function history_sql() {
    return "SELECT 
        
        O.id ,
        D.id ,
        MI.id ,MI.money_sum ,
        LO.esti_recv_datetime ,
        (SELECT DH.dish_name        FROM dish_history AS DH  WHERE DH.dish_id = D.id AND LO.esti_recv_datetime BETWEEN DH.born_at AND DH.die_at),
        (SELECT DH.charge           FROM dish_history AS DH  WHERE DH.dish_id = D.id AND LO.esti_recv_datetime BETWEEN DH.born_at AND DH.die_at),
        (SELECT DH.factory_name     FROM dish_history AS DH  WHERE DH.dish_id = D.id AND LO.esti_recv_datetime BETWEEN DH.born_at AND DH.die_at),
        O.user_id ,O.order_maker

        FROM orders AS O
        INNER JOIN users AS U 				ON O.user_id = U.id
        INNER JOIN user_information AS UI 	ON U.info_id = UI.id
        INNER JOIN class AS C				ON U.class_id = C.id
        INNER JOIN dish AS D				ON O.dish = D.id
        INNER JOIN department AS DP			ON D.department_id = DP.id
        INNER JOIN factory AS F				ON DP.factory = F.id
        INNER JOIN money_info AS MI			ON O.money_id = MI.id
        INNER JOIN logistics_info AS LO		ON O.logistics_id = LO.id
    
        WHERE O.disabled = FALSE
        ";
}

?>