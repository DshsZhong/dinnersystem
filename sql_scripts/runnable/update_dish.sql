#### update dish ####
USE dinnersys;

DROP PROCEDURE IF EXISTS update_dish;

DELIMITER $$
CREATE PROCEDURE update_dish(id INT ,dname VARCHAR(1024) ,charge INT ,vege INT ,idle BOOL)
BEGIN
	UPDATE `dinnersys`.`dish_history`
	SET `die_at` = CURRENT_TIMESTAMP
	WHERE CURRENT_TIMESTAMP BETWEEN `born_at` AND `die_at`;
    
	INSERT INTO `dinnersys`.`dish_history`
	(`dish_id`,
	`factory_name`,
	`dish_name`,
	`charge`,
	`die_at`)
	VALUES
	(id,
	(
		SELECT CONCAT(F.name ,"-" ,DP.name) 
        FROM factory AS F ,dish AS D ,department AS DP
        WHERE D.id = id AND D.department_id = DP.id AND DP.factory = F.id
	),
	dname,
	charge,
	'9999-12-31 23:59:59');

	UPDATE `dinnersys`.`dish`
	SET `dish_name` = dname,
	`charge` = charge,
	`is_vegetarian` = vege,
	`is_idle` = idle
	WHERE `dinnersys`.`dish`.`id` = id;
END$$

DELIMITER ;
# CALL update_dish(1 ,'qwreqwereqw' ,87 ,0 ,TRUE)