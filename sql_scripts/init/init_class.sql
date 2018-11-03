#### INIT CLASS ####
USE DINNERSYS;

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE `dinnersys`.`class`;
SET FOREIGN_KEY_CHECKS = 1;

DROP PROCEDURE IF EXISTS init_class;

DELIMITER $$
CREATE PROCEDURE init_class(grade INT ,yr INT)
BEGIN
	DECLARE counter INT default 1;
	WHILE (counter <= 25) DO
		INSERT INTO `dinnersys`.`class`
		(`year`,`grade`,
		`class_no`,
		`members`, `dinnerman_id`, `leader_id`)
		VALUES
		(yr, grade,
		grade * 100 + counter,
		NULL, NULL ,NULL);
		SET counter = counter + 1;
	END WHILE;
END$$

DELIMITER ;
CALL init_class(1 ,2017);
CALL init_class(2 ,2017);
CALL init_class(3 ,2017);


#### CREATE VIRTUAL CLASS TO SATISFY DEPENDENCY ####
INSERT INTO `dinnersys`.`class` (`id`, `year`, `grade`, `class_no`, `members`, `dinnerman_id`, `leader_id`)
VALUES (-1, -1, -1, -1, NULL, NULL, NULL);

#### CREATE CLASS FOR TEACHER ####
INSERT INTO `dinnersys`.`class` (`id`, `year`, `grade`, `class_no`, `members`, `dinnerman_id`, `leader_id`)
VALUES (-2, -1, -1, 760, NULL, NULL, NULL);