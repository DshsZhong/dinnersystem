#### SHOW MENU ####
USE dinnersys;

DROP PROCEDURE IF EXISTS show_menu;
DROP PROCEDURE IF EXISTS show_dish;
DROP FUNCTION IF EXISTS is_vege;

DELIMITER $$

CREATE FUNCTION is_vege(usr_id INT) RETURNS INT
BEGIN
	RETURN (
		SELECT I.is_vegetarian FROM `dinnersys`.`users` AS U ,`dinnersys`.`user_information` AS I
		WHERE (U.info_id = I.id  AND U.id = usr_id)
	);
END$$

CREATE PROCEDURE show_menu(usr_id INT ,factory_id INT)
BEGIN
	DECLARE vegetarian INT DEFAULT is_vege(usr_id);

	SELECT DISTINCT 
    M.id ,M.name ,M.charge ,M.is_idle
    ,F.id ,F.name 
	FROM `dinnersys`.`menu` AS M ,`dinnersys`.`factory` AS F
	WHERE M.factory_id = F.id
	AND F.id = IFNULL(factory_id ,F.id)
	ORDER BY M.factory_id ,ABS(M.is_vegetarian - vegetarian) ,M.id;
END$$

CREATE PROCEDURE show_dish(usr_id INT ,factory_id INT ,is_custom BOOL)
BEGIN
	DECLARE vegetarian INT DEFAULT is_vege(usr_id);

	SELECT DISTINCT 
    D.id ,D.dish_name ,D.charge_sum ,F.id ,F.name ,D.is_idle ,D.is_custom ,D.content
    
	FROM `dinnersys`.`dish` AS D ,`dinnersys`.`factory` AS F
	WHERE D.factory_id = F.id
	AND F.id = IFNULL(factory_id ,F.id)
    AND IF(is_custom IS NULL ,TRUE ,is_custom = D.is_custom)
	ORDER BY F.id ,ABS(D.is_vegetarian - vegetarian) ,D.id;
END$$

DELIMITER ;

CALL show_dish(-1 ,NULL ,NULL);