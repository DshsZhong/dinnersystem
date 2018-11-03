#### SELECT ORDER ####

USE dinnersys;

DROP PROCEDURE IF EXISTS select_order;

DELIMITER $$
CREATE PROCEDURE select_order
	(vege INT ,
	usr BOOL ,dm BOOL ,cafet BOOL ,facto BOOL ,
    esti_start DATETIME ,esti_end DATETIME ,
    factory_id INT ,
    user_id INT ,person BOOL ,class BOOL ,
    class_no INT ,
    grade INT ,yr INT ,
    oid INT)
BEGIN
    SELECT
    /*-----------------import data columns---------------------*/
    O.id ,
	D.id ,D.dish_name ,D.charge_sum ,
	MT.id ,MT.charge ,
	LO.esti_recv_datetime ,
	F.id ,F.name ,
	(SELECT U.id			    FROM users AS U 															WHERE O.user_id = U.id LIMIT 1),
	(SELECT UI.name 		    FROM users AS U INNER JOIN user_information AS UI ON U.info_id = UI.id 		WHERE O.user_id = U.id LIMIT 1),
	(SELECT UI.class_id 	    FROM users AS U INNER JOIN user_information AS UI ON U.info_id = UI.id 		WHERE O.user_id = U.id LIMIT 1),
	(SELECT UI.is_vegetarian 	FROM users AS U INNER JOIN user_information AS UI ON U.info_id = UI.id 		WHERE O.user_id = U.id LIMIT 1),

	(SELECT U.id 			    FROM users AS U 															WHERE O.order_maker = U.id LIMIT 1),
	(SELECT UI.name 		    FROM users AS U INNER JOIN user_information AS UI ON U.info_id = UI.id		WHERE O.order_maker = U.id LIMIT 1),
	(SELECT UI.class_id 	    FROM users AS U INNER JOIN user_information AS UI ON U.info_id = UI.id		WHERE O.order_maker = U.id LIMIT 1),
	(SELECT UI.is_vegetarian 	FROM users AS U INNER JOIN user_information AS UI ON U.info_id = UI.id 		WHERE O.order_maker = U.id LIMIT 1),

	(SELECT P.id                FROM payment AS P                                                           WHERE P.id = MT.user LIMIT 1),
	(SELECT P.paid              FROM payment AS P                                                           WHERE P.id = MT.user LIMIT 1),
	(SELECT P.able_datetime     FROM payment AS P                                                           WHERE P.id = MT.user LIMIT 1),
	(SELECT P.paid_datetime     FROM payment AS P                                                           WHERE P.id = MT.user LIMIT 1),
	(SELECT P.freeze_datetime   FROM payment AS P                                                           WHERE P.id = MT.user LIMIT 1),

	(SELECT P.id                FROM payment AS P                                                           WHERE P.id = MT.dinnerman LIMIT 1),
	(SELECT P.paid              FROM payment AS P                                                           WHERE P.id = MT.dinnerman LIMIT 1),
	(SELECT P.able_datetime     FROM payment AS P                                                           WHERE P.id = MT.dinnerman LIMIT 1),
	(SELECT P.paid_datetime     FROM payment AS P                                                           WHERE P.id = MT.dinnerman LIMIT 1),
	(SELECT P.freeze_datetime   FROM payment AS P                                                           WHERE P.id = MT.dinnerman LIMIT 1),

	(SELECT P.id                FROM payment AS P                                                           WHERE P.id = MT.cafeteria LIMIT 1),
	(SELECT P.paid              FROM payment AS P                                                           WHERE P.id = MT.cafeteria LIMIT 1),
	(SELECT P.able_datetime     FROM payment AS P                                                           WHERE P.id = MT.cafeteria LIMIT 1),
	(SELECT P.paid_datetime     FROM payment AS P                                                           WHERE P.id = MT.cafeteria LIMIT 1),
	(SELECT P.freeze_datetime   FROM payment AS P                                                           WHERE P.id = MT.cafeteria LIMIT 1),

	(SELECT P.id                FROM payment AS P                                                           WHERE P.id = MT.factory LIMIT 1),
	(SELECT P.paid              FROM payment AS P                                                           WHERE P.id = MT.factory LIMIT 1),
	(SELECT P.able_datetime     FROM payment AS P                                                           WHERE P.id = MT.factory LIMIT 1),
	(SELECT P.paid_datetime     FROM payment AS P                                                           WHERE P.id = MT.factory LIMIT 1),
	(SELECT P.freeze_datetime   FROM payment AS P                                                           WHERE P.id = MT.factory LIMIT 1)
	#-----------------import data tables---------------------#
	FROM orders AS O,
	users AS U,
	user_information AS UI,
	class AS C,
	dish AS D,
	factory AS F,
	money_trace AS MT,
	logistics_info AS LO
	#-----------------connect data tables---------------------#
	WHERE O.user_id = U.id
	AND U.info_id = UI.id
	AND U.class_id = C.id
	AND O.dish = D.id
	AND D.factory_id = F.id
	AND O.money_trace_id = MT.id
	AND O.logistics_info = LO.id
	#-----------------remove useless rows--------------------------#
	AND O.disabled = FALSE
	AND LO.has_recv = FALSE

    /*-----------------remove useless rows--------------------------*/
    AND O.disabled = FALSE
    AND LO.has_recv = FALSE
    
    /*------------------create selection criteria-----------------*/
    AND IF(vege IS NULL ,TRUE ,vege = LO.is_vegetarian)
    AND (
		(IF(usr IS NULL ,TRUE ,(SELECT P.paid FROM payment AS P WHERE P.id = MT.user) = usr)) AND
		(IF(dm IS NULL ,TRUE ,(SELECT P.paid FROM payment AS P WHERE P.id = MT.dinnerman) = dm)) AND 
        (IF(cafet IS NULL ,TRUE ,(SELECT P.paid FROM payment AS P WHERE P.id = MT.cafeteria) = cafet)) AND 
        (IF(facto IS NULL ,TRUE ,(SELECT P.paid FROM payment AS P WHERE P.id = MT.factory) = facto))
	)
	AND IF((esti_start IS NULL) OR (esti_end IS NULL)
		, TRUE
		,LO.esti_recv_datetime BETWEEN esti_start AND esti_end)
	AND IF(factory_id IS NULL ,TRUE ,factory_id = D.factory_id)
    AND IF((person IS NULL) OR (person = FALSE) ,TRUE ,user_id = O.user_id)
    AND IF((class IS NULL) OR (class = FALSE) ,TRUE ,class_id = U.class_id)
    
    AND IF(class_no IS NULL ,TRUE ,UI.class_id = class_no)
	AND IF(grade IS NULL ,TRUE ,grade = C.grade)
    AND IF(U.`year` = -1 ,TRUE ,U.`year` = yr)
    AND O.id = IFNULL(oid ,O.id);
END$$

DELIMITER ;

CALL select_order(null ,
	true ,null ,null ,null ,
    '2018-07-22 00:00:00' ,'2018-07-23 00:00:00' ,
	null ,
	null ,null ,null ,
	null, 
    null ,null ,
    null);