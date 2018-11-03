#### INIT USERS ####

USE DINNERSYS;

DROP PROCEDURE IF EXISTS make_user;
DROP PROCEDURE IF EXISTS init_user;


SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE `dinnersys`.`users`;
TRUNCATE TABLE `dinnersys`.`user_information`;
SET FOREIGN_KEY_CHECKS = 1;


SET @yr = 2017;

DELIMITER $$



CREATE PROCEDURE make_user(
	id INT ,uname VARCHAR(128) ,phone VARCHAR(128) ,
    is_vege BOOL ,gender VARCHAR(64) ,class_id INT ,class_no INT ,
    school_id INT ,seat_id INT ,email VARCHAR(256) ,birthday DATETIME ,
    
    login_id VARCHAR(128) ,pswd VARCHAR(1024) ,
    prev_sum INT ,yr INT)
BEGIN
	IF id IS NULL THEN
		SET id = (SELECT MAX(U.id) FROM users AS U) + 1;
        SET id = IFNULL(id ,1);							# if users is empty id would be null.
    END IF;
    
	INSERT INTO `dinnersys`.`user_information`
	(`id` ,`name`,
	`ad_times`,
	`phone_number`,
	`is_vegetarian`,
	`credits`,
	`gender`,			
	`class_id`,
	`school_id` ,
	`seat_id` ,
	`email` ,
    `birthday`)			
	VALUES
	(id ,uname,
	0,
	phone,
	is_vege,
	0,
	gender,
	class_no,
	school_id ,
	seat_id ,
	email ,
    birthday);

	## CREATE user ##

	INSERT INTO `dinnersys`.`users`
	(`id`, 
	`login_id`,
	`prev_sum`,
	`password`,
	`class_id`,
	`year`,
	`info_id`)
	VALUES
	(
    id ,
	login_id,
	prev_sum,
	pswd,
	class_id,
	yr,
	(SELECT MAX(id) FROM `dinnersys`.`user_information`));
END$$










CREATE PROCEDURE init_user()
BEGIN
	DECLARE gr INT default 1;
    DECLARE class INT default 1;
    DECLARE seat INT default 1;
   /*i: WHILE (gr <= 3) DO
		SET class = 1;
		j: WHILE (class <= 25) DO
            SET seat = 1;
			k: WHILE (seat <= 50) DO
				CALL make_user(
					null ,gr * 10000 + class * 100 + seat ,'0900-000-000' ,
					FALSE ,'UNKNOWN' ,(
						SELECT C.id FROM `dinnersys`.`class` as C 
						WHERE C.class_no = gr * 100 + class
						AND C.year =  @yr
					) ,gr * 100 + class ,
					null ,gr * 10000 + class * 100 + seat ,'UNKNOWN',
					
					CONCAT(gr * 10000 + class * 100 + seat) ,
                    CONCAT(gr * 100 + class) ,
					IF(seat = 50 ,5 ,3) , @yr
				);
			SET seat = seat + 1;
			END WHILE k;
		SET class = class + 1;
		END WHILE j;
	SELECT gr;
	SET gr = gr + 1;
	END WHILE i;*/
    i: WHILE (gr <= 3) DO
		SET class = 1;
		j: WHILE (class <= 25) DO
            SET seat = 50;		
			CALL make_user(
				null ,gr * 10000 + class * 100 + seat ,'0900-000-000' ,
				FALSE ,'UNKNOWN' ,(
					SELECT C.id FROM `dinnersys`.`class` as C 
					WHERE C.class_no = gr * 100 + class
					AND C.year =  @yr
				) ,gr * 100 + class ,
				 gr * 10000 + class * 100 + seat,gr * 10000 + class * 100 + seat ,'UNKNOWN','2002-04-26' ,
				
				CONCAT(gr * 10000 + class * 100 + seat) ,
				CONCAT(gr * 100 + class) ,
				5 , @yr
			);
		SET class = class + 1;
		END WHILE j;
	SELECT gr;
	SET gr = gr + 1;
	END WHILE i;
    
    CALL make_user(
			null ,7600000 ,'0900-000-000' ,
			FALSE ,'UNKNOWN' ,(
				SELECT C.id FROM `dinnersys`.`class` as C 
				WHERE C.class_no = '760'
			) ,'760' ,
			null ,7600000 ,'UNKNOWN','2002-04-26' ,
			CONCAT(7600000) ,
			CONCAT(760) ,
			5 , @yr
	);
    SET seat = 1;
    k: WHILE (seat <= 9999) DO
		CALL make_user(
			null ,7600000 + seat ,'0900-000-000' ,
			FALSE ,'UNKNOWN' ,(
				SELECT C.id FROM `dinnersys`.`class` as C 
				WHERE C.class_no = '760'
			) ,'760' ,
			null ,7600000 + seat ,'UNKNOWN','2002-04-26' ,
			CONCAT(7600000 + seat) ,
			CONCAT(760) ,
			3 , @yr
		);
        
        # avoid lose connection to mysql.
        IF seat % 1000 = 0 THEN
			SELECT seat;
        END IF;
	SET seat = seat + 1;
	END WHILE k;
END$$

DELIMITER ;

CALL init_user();
#### ADD ADMIN USER ####

CALL make_user(
	-1 ,'ADMINSTRATOR' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'dinnersys' ,'2rjurrru' ,
	63 ,-1
);

CALL make_user(
	-2 ,'ADMINSTRATOR' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'lawrence910426' ,'2rjurrru' ,
	63 ,-1
);

#### ADD GUEST USER ####

CALL make_user(
	-3 ,'guest' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'guest' ,'!!!!!' ,
	1 ,-1
);


#### ADD authority satisfy user ####

CALL make_user(
	-4 ,'auth_satisfy' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'!!!!!' ,'!!!!!' ,					# special characters would be blocked by regex in php
	1 ,-1
);

INSERT IGNORE INTO `dinnersys`.`authority`
(`id` ,`user`, `ip`)
VALUES
(-4, -2, '0.0.0.0');



#### ADD factory users ####

CALL make_user(
	-5 ,'愛佳便當' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'101' ,'101' ,
	9 ,-1
);

CALL make_user(
	-6 ,'台灣小吃部' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'033' ,'033' ,
	9 ,-1
);

CALL make_user(
	-7 ,'關東煮' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'123' ,'123' ,
	9 ,-1
);

CALL make_user(
	-8 ,'早餐部' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'107' ,'107' ,
	9 ,-1
);


CALL make_user(
	-9 ,'合作社' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'099' ,'099' ,
	9 ,-1
);

#### ADD cafeteria ####

CALL make_user(
	-10 ,'阿文' ,'0900-000-000' ,
	FALSE ,'UNKNOWN' ,-1 ,-1 ,
	null ,-1 ,'UNKNOWN','2002-04-26' ,
	'q020705349' ,'qazwsx7' ,
	17 ,-1
);


# DROP PROCEDURE IF EXISTS make_user;
DROP PROCEDURE IF EXISTS init_user;
SELECT * FROM dinnersys.users;
