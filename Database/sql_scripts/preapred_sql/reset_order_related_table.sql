#### RESET ORDER RELATED TABLES ####

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE `dinnersys`.`log`;
TRUNCATE TABLE `dinnersys`.`orders`;
TRUNCATE TABLE `dinnersys`.`announce`;
TRUNCATE TABLE `dinnersys`.`payment`;
TRUNCATE TABLE `dinnersys`.`cargo`;
TRUNCATE TABLE `dinnersys`.`money_info`;
TRUNCATE TABLE `dinnersys`.`logistics_info`;

TRUNCATE TABLE `dinnersys`.`user_information`;
TRUNCATE TABLE `dinnersys`.`users`;
#TRUNCATE TABLE `dinnersys`.`authority`;					### reset it in init_user ###
SET FOREIGN_KEY_CHECKS = 1;

