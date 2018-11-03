#### pressure test ####
DELIMITER $$
DROP PROCEDURE P$$
CREATE PROCEDURE P()
BEGIN
	DECLARE i INT default 0;
    DECLARE r VARCHAR(1024);
    WHILE (i <= 10000000) do
		SET r = make_order(807 ,807 ,41 ,DATE_SUB(CURRENT_TIMESTAMP ,INTERVAL 30 HOUR));
		SET i = i + 1;
        
        IF (i % 1000) = 0 THEN select i;
        end if;
	END WHILE;
END$$

CALL P()$$
DROP PROCEDURE P