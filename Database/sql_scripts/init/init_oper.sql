#### INITIALIZE OPERATION TABLE ####

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE `dinnersys`.`operations`;
SET FOREIGN_KEY_CHECKS = 1;

DELIMITER $$

CREATE PROCEDURE make_oper(oper_name VARCHAR(128) ,oper_func VARCHAR(128) ,oper_prev VARCHAR(128))
BEGIN
	INSERT INTO `dinnersys`.`operations`
	(`oper_name`, `oper_func_name`, `oper_chinese`, `require_prev`)
	VALUES (oper_name ,oper_func ,'' ,
	(
		SELECT id FROM `dinnersys`.`previleges`
		WHERE prev_name = oper_prev
	));
END$$

DELIMITER ;

#####################################################
CALL make_oper('login' ,'login' ,'guest');
CALL make_oper('logout' ,'logout' ,'guest');
CALL make_oper('register' ,'register' ,'guest');

CALL make_oper('change_password' ,'change_password' ,'normal');
CALL make_oper('change_password' ,'change_password' ,'cafeteria');
CALL make_oper('change_password' ,'change_password' ,'factory');
#####################################################

#####################################################
CALL make_oper('show_factory' ,'show_factory' ,'normal');
CALL make_oper('show_dish' ,'show_dish' ,'normal');

CALL make_oper('show_factory' ,'show_factory' ,'dinnerman');
CALL make_oper('show_dish' ,'show_dish' ,'dinnerman');

CALL make_oper('show_factory' ,'show_factory' ,'cafeteria');
CALL make_oper('show_dish' ,'show_dish' ,'cafeteria');

CALL make_oper('show_factory' ,'show_factory' ,'factory');
CALL make_oper('show_dish' ,'show_dish' ,'factory');
#####################################################

#####################################################
CALL make_oper('update_dish' ,'update_dish' ,'factory');
CALL make_oper('update_dish' ,'update_dish' ,'cafeteria');
CALL make_oper('update_dish' ,'update_dish' ,'admin');
#####################################################

#####################################################
CALL make_oper('select_self' ,'show_order' ,'normal');
CALL make_oper('select_class' ,'show_order' ,'dinnerman');
CALL make_oper('select_facto' ,'show_order' ,'factory');
CALL make_oper('select_other' ,'show_order' ,'cafeteria');
CALL make_oper('select_other' ,'show_order' ,'admin');
#####################################################

#####################################################
CALL make_oper('make_self_order' ,'make_order' ,'normal');
CALL make_oper('make_class_order' ,'make_order' ,'dinnerman');
CALL make_oper('make_everyone_order' ,'make_order' ,'cafeteria');
CALL make_oper('make_facto_order' ,'make_order' ,'factory');

CALL make_oper('make_self_order' ,'make_order' ,'admin');
CALL make_oper('make_class_order' ,'make_order' ,'admin');
CALL make_oper('make_everyone_order' ,'make_order' ,'admin');
CALL make_oper('make_facto_order' ,'make_order' ,'admin');
#####################################################

#####################################################
CALL make_oper('delete_self' ,'delete_order' ,'normal');
CALL make_oper('delete_dm' ,'delete_order' ,'dinnerman');
CALL make_oper('delete_facto' ,'delete_order' ,'factory');
CALL make_oper('delete_everyone' ,'delete_order' ,'admin');
CALL make_oper('delete_everyone' ,'delete_order' ,'cafeteria');
#####################################################


#####################################################
CALL make_oper('payment_usr' ,'set_payment' ,'dinnerman');
CALL make_oper('payment_dm' ,'set_payment' ,'dinnerman');
CALL make_oper('payment_cafet' ,'set_payment' ,'cafeteria');
CALL make_oper('payment_facto' ,'set_payment' ,'factory');
#####################################################

#####################################################
CALL make_oper('get_date' ,'get_date' ,'normal');
CALL make_oper('get_datetime' ,'get_date' ,'normal');
#####################################################

#####################################################
CALL make_oper('get_announce' ,'announce_handle' ,'admin');
CALL make_oper('done_announce' ,'announce_handle' ,'admin');
#####################################################

DROP PROCEDURE IF EXISTS make_oper;