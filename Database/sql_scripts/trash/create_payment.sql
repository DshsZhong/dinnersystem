#### CREATE PAYMENT ####

USE dinnersys;

DROP PROCEDURE IF EXISTS create_payment;
DELIMITER $$



CREATE PROCEDURE create_payment(esti_recv DATETIME ,end_suffix VARCHAR(1024))
BEGIN
	INSERT INTO `dinnersys`.`payment`
	(`paid`, 
	`freeze_datetime`, `able_datetime`, `paid_datetime`,
	`include_credit`, `authority_id`)
	VALUES
	(
		FALSE,
		CONCAT(DATE(esti_recv) ,"-00:00:00"), 
        CONCAT(DATE(esti_recv) ,'-' ,end_suffix), NULL,
		FALSE, -1
    );
END$$

DELIMITER ;
