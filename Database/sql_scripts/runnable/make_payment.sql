#### MAKE PAYMENT ####

USE dinnersys;
DROP PROCEDURE IF EXISTS make_payment;

DELIMITER $$

CREATE PROCEDURE make_payment(order_id INT ,user_id INT ,money_to VARCHAR(64) ,target BOOL ,ip VARCHAR(1024))
BEGIN
	DECLARE auth_id INT DEFAULT get_auth_id(user_id ,ip);
	DECLARE money_id INT DEFAULT (
		SELECT O.money_id FROM `dinnersys`.`orders` AS O WHERE O.id = order_id
    );
    DECLARE payment_id INT DEFAULT (
		SELECT P.id FROM payment AS P WHERE P.money_info = money_id AND 
        P.tag = CASE money_to
			WHEN 'user' THEN 'user'
            WHEN 'dinnerman' THEN 'dinnerman'
            WHEN 'cafeteria' THEN 'cafeteria'
            WHEN 'factory' THEN 'factory'
            ELSE '-1'
		END
    );

    UPDATE `dinnersys`.`payment`
	SET `paid` = target,
	`paid_datetime` = CURRENT_TIMESTAMP,
	`authority_id` = auth_id
	WHERE `id` = payment_id;
END$$

DELIMITER ;

CALL make_payment(16363 ,1272 ,'user' ,true , '127.0.0.1');