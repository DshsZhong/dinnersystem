#### INIT MENU AND DISH ####

USE DINNERSYS;

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE menu;
TRUNCATE TABLE dish;
SET FOREIGN_KEY_CHECKS = 1;

DROP PROCEDURE IF EXISTS init_food;

DELIMITER $$
CREATE PROCEDURE init_food()
BEGIN
	DECLARE facto INT DEFAULT 1;
	DECLARE counter INT DEFAULT 1;
    
    SET facto = 1;
    i: WHILE (facto <= 5) DO
		SET counter = 1;
	   j: WHILE (counter <= 100) DO
            INSERT INTO `dinnersys`.`dish`
			(`dish_name`,
			`charge_sum`,
			`is_vegetarian`,
			`is_custom`,
			`is_idle`,
			`factory_id`,
            `department_id`,
			`content`)
			VALUES
			("閒置中的餐點",
			0,
			false,
			false,
			true,
			facto,
            (facto - 1) * 4 + CEIL(counter / 25),
			'{}');
            
			SET counter = counter + 1;
		END WHILE j;
        SET facto = facto + 1;
	END WHILE i;
END$$

DELIMITER ;

CALL init_food();
DROP PROCEDURE IF EXISTS init_food;
