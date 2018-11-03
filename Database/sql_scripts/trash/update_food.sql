#### update food ####


USE dinnersys;

DROP FUNCTION IF EXISTS update_dish;

DELIMITER $$

CREATE FUNCTION update_dish(id INT ,dname VARCHAR(128),csum INT,vege INT,idle BOOL) RETURNS VARCHAR(128)
BEGIN
	IF (SELECT COUNT(D.id) FROM dish AS D WHERE D.id = id AND D.is_custom = false) = 0 THEN
		RETURN "invalid id";
	END IF;
	
	UPDATE `dinnersys`.`dish`
	SET `dish_name` = dname,
	`charge_sum` = csum,
	`is_vegetarian` = vege,
	`is_idle` = idle
	WHERE `dinnersys`.`dish`.`id` = id;
    
    RETURN "success";
END$$

DELIMITER ;