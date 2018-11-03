#### MAKE ANNOUNCE ####
USE dinnersys;

DROP PROCEDURE IF EXISTS make_announce;
DROP FUNCTION IF EXISTS make_order;
DROP PROCEDURE IF EXISTS make_logistics_info;

DELIMITER $$

#### MAKE ORDER ####
CREATE FUNCTION make_order(usr_id INT ,maker_id INT ,dish_id INT ,esti_recv DATETIME) RETURNS INT
BEGIN
	#####################################################################################################################
	DECLARE is_vege INT DEFAULT (
		SELECT D.is_vegetarian FROM dinnersys.dish AS D WHERE D.id = dish_id
    );
     
    DECLARE dish_name VARCHAR(1024) DEFAULT (
		SELECT D.dish_name FROM dish AS D WHERE D.id = dish_id
    );
    
    DECLARE factory_id INT DEFAULT (
		SELECT DP.factory FROM dish AS D ,department AS DP WHERE D.id = dish_id AND DP.id = D.department_id
	);
    
    DECLARE charge INT DEFAULT (
		SELECT D.charge FROM dish AS D WHERE D.id = dish_id
    );
    
    DECLARE money_id INT;
    DECLARE logistics_id INT;
    #####################################################################################################################
    
    #####################################################################################################################
    INSERT INTO `dinnersys`.`money_info` (`money_sum`)
	VALUES (charge);
    
    SET money_id = (SELECT MAX(id) FROM money_info);
    
	INSERT INTO `dinnersys`.`payment`
	(`paid`, `money_info` ,`reversable` ,
	 `able_datetime`, `freeze_datetime`, `paid_datetime`,
	`include_credit`, `authority_id` ,`tag`)
	VALUES
	(
		FALSE, money_id, TRUE,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), 
		CONCAT(DATE(esti_recv) ,'-23:59:59'), NULL,
		FALSE, -1 ,'user'
    ),
	(
		FALSE, money_id, FALSE,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), 
		CONCAT(DATE(esti_recv) ,'-23:59:59'), NULL,
		FALSE, -1 ,'dinnerman'
    ),
	(
		FALSE, money_id, TRUE,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), 
		CONCAT(DATE(esti_recv) ,'-23:59:59'), NULL,
		FALSE, -1 ,'cafeteria'
    ),
	(
		FALSE, money_id, TRUE,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), 
		CONCAT(DATE(esti_recv) ,'-23:59:59'), NULL,
		FALSE, -1 ,'factory'
    );
    #####################################################################################################################
    
    #####################################################################################################################
    INSERT INTO `dinnersys`.`logistics_info` (`esti_recv_datetime`)
	VALUES (esti_recv);
    
	SET logistics_id = (SELECT MAX(id) FROM logistics_info);
    
    INSERT INTO `dinnersys`.`cargo`
	(`get`, `reversable`,`authority_id`,
	`able_datetime`, `get_datetime`, `freeze_datetime`, 
	`logistics_info`, `tag`)
	VALUES
	(
		FALSE ,TRUE ,-1 ,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), null ,CONCAT(DATE(esti_recv) ,'-23:59:59'),
		logistics_id ,'user'
	),
	(
		FALSE ,TRUE ,-1 ,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), null ,CONCAT(DATE(esti_recv) ,'-23:59:59'),
		logistics_id ,'dinnerman'
	),
	(
		FALSE ,TRUE ,-1 ,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), null ,CONCAT(DATE(esti_recv) ,'-23:59:59'),
		logistics_id ,'factory'
	);
    #####################################################################################################################
    
    
    #####################################################################################################################
    INSERT INTO `dinnersys`.`announce`
	(`msg`, `anno_type`, `estimate_datetime`, `pushed_datetime`, `announced`)
	VALUES (CONCAT('午餐系統提醒您今天有訂購「' ,dish_name ,'」 喔') , 'VIBRATE ,ANNOUNCE' , esti_recv, NULL, FALSE);
    #####################################################################################################################
    
    
    INSERT INTO `dinnersys`.`orders`
	(`announce_id`,
	`money_id`,
	`dish`,
	`user_id`, `order_maker` ,
	`logistics_id`)
	VALUES
	(
		(SELECT MAX(A.id) FROM dinnersys.announce AS A LIMIT 1),
		money_id,
		dish_id,
		usr_id, maker_id ,
		logistics_id
    );
    
	RETURN (SELECT MAX(O.id) FROM dinnersys.orders AS O);
END$$

SELECT make_order(1 ,2 ,1 ,CURRENT_TIMESTAMP)