/*---------------------------------------------------------------------------------------------------------------*/
/*-----------please ensure this procedure run in serializable transaction mode----------------------*/
DROP PROCEDURE IF EXISTS make_order;
DELIMITER $$

CREATE PROCEDURE make_order(usr_id INT ,maker_id INT ,dishes varchar(1024) ,esti_recv DATETIME)
proce: BEGIN
    DECLARE money_id INT;
    DECLARE logistics_id INT;
	DECLARE dcharge INT;
	DECLARE oid INT;
	DECLARE daily_limit INT;
	DECLARE orders INT;
	DECLARE insert_order VARCHAR(1024);
	
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SELECT "database deadlock";
        ROLLBACK;
    END;

	START TRANSACTION;

    INSERT INTO `dinnersys`.`money_info` (`money_sum`) VALUES (-1);		/* temporary set a number */
    SET money_id = (SELECT MAX(id) FROM money_info);
    
	INSERT INTO `dinnersys`.`payment`
	(`paid`, `money_info` ,`reversable` ,
	 `able_datetime`, `freeze_datetime`, `paid_datetime` ,`tag`)
	VALUES
	(
		FALSE, money_id, FALSE,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), 
		CONCAT(DATE(esti_recv) ,'-10:30:00'), NULL, 'payment'
    );
    
    INSERT INTO `dinnersys`.`logistics_info` (`esti_recv_datetime`)
	VALUES (esti_recv);
    
	SET logistics_id = (SELECT MAX(id) FROM logistics_info);
    
    INSERT INTO `dinnersys`.`cargo`
	(`get`, `reversable`,
	`able_datetime`, `get_datetime`, `freeze_datetime`, 
	`logistics_info`, `tag`)
	VALUES
	(
		FALSE ,TRUE ,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), null ,CONCAT(DATE(esti_recv) ,'-23:59:59'),
		logistics_id ,'user'
	),
	(
		FALSE ,TRUE ,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), null ,CONCAT(DATE(esti_recv) ,'-23:59:59'),
		logistics_id ,'dinnerman'
	),
	(
		FALSE ,TRUE ,
		CONCAT(DATE(esti_recv) ,'-00:00:00'), null ,CONCAT(DATE(esti_recv) ,'-23:59:59'),
		logistics_id ,'factory'
	);
    
    
    INSERT INTO `dinnersys`.`orders`
	(`money_id`,
	`user_id`, `order_maker` ,
	`logistics_id`)
	VALUES
	(
		money_id,
		usr_id, maker_id ,
		logistics_id
    );
	SELECT MAX(O.id) FROM dinnersys.orders AS O INTO @oid;

	SET insert_order = REPLACE(dishes ,')' ,',@oid)');
	SET insert_order = REPLACE(insert_order ,',' ,',@oid),(');
	SET insert_order = REPLACE(insert_order ,',(@oid)' ,'');
	SET @cmd = concat('INSERT INTO `dinnersys`.`buffet` (`dish`,`order`) VALUES ',insert_order ,';');
    PREPARE stmt FROM @cmd;
    EXECUTE stmt;

	UPDATE money_info 
	SET money_sum = 
	(
		SELECT SUM(D.charge)
		FROM dish AS D ,buffet AS B ,orders AS O 
		WHERE O.id = @oid AND B.dish = D.id AND B.order = O.id
	)
	WHERE id = money_id;

	/*-------------------------------------------------------------------------------------------------------*/
	/* To avoid race conditions ,I used some business logic here.
	 * Whenever it fails ,the procedure rollbacks everything it has done.
	 * In php ,we can't ensure everything is serialized ,so we put the codes here.
	 * In this sql transacation ,everything is serialized. */
	SET @cmd = concat("SET @maxi = (SELECT MAX(count) FROM 
        (
            SELECT IF(D.daily_limit < 0 ,0 ,D.daily_limit - COUNT(O.id)) AS count
            FROM orders AS O ,buffet AS B ,logistics_info AS LO ,dish AS D
            WHERE O.logistics_id = LO.id AND B.order = O.id AND D.id = B.dish
			AND LO.esti_recv_datetime BETWEEN CONCAT(DATE(?) ,'-00:00:00') AND CONCAT(DATE(?) ,'-23:59:59')
			AND D.id IN", dishes,
			"GROUP BY D.id FOR UPDATE
        ) AS tmp);");
    PREPARE stmt FROM @cmd;
	SET @esti_recv = esti_recv;
    EXECUTE stmt USING @esti_recv ,@esti_recv;
	
    IF @maxi < 0 THEN 
		SELECT "not enough dish";
		ROLLBACK;
		LEAVE proce;
    END IF;
	
	/* Must ensure this statement won't scan the older part of dinnersys.
	 * It would cause the user can unlimitly order if it scans the older part of database. */
	SELECT COUNT(O.id)
	FROM orders AS O ,logistics_info AS LO ,money_info AS MI ,payment AS P
	WHERE O.logistics_id = LO.id AND O.user_id = usr_id
	AND LO.esti_recv_datetime BETWEEN CONCAT(DATE(esti_recv) ,'-00:00:00') AND CONCAT(DATE(esti_recv) ,'-23:59:59')
	AND O.money_id = MI.id AND P.money_info = MI.id AND P.paid = FALSE AND P.tag = "payment"
	AND O.disabled = FALSE
	INTO orders FOR UPDATE;

	SELECT UI.daily_limit FROM user_information AS UI ,users AS U WHERE U.id = usr_id AND U.info_id = UI.id INTO daily_limit;
	IF orders > daily_limit AND daily_limit > 0 THEN
		SELECT "daily limit exceed";
		ROLLBACK;
		LEAVE proce;
	END IF;
	/*-------------------------------------------------------------------------------------------------------*/

	select @oid;
    commit;
END$$
CALL make_order(1, 2, '(1,2,3,4)' ,CURRENT_TIMESTAMP);
