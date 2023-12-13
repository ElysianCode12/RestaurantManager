SET linesize 500
SET pagesize 60
Column name_server Format A30
Column id Format A10
Column password Format A10
INSERT INTO rm_server VALUES ('Alice Garcia', '001AG', '/qJ57-b?');
INSERT INTO rm_server VALUES ('Dave Popov', '002DP', ';5+JrQR.');
INSERT INTO rm_server VALUES ('Frank Biden', '003FB', '@tz,ZG:Z');
INSERT INTO rm_server VALUES ('Alice Jones', '004AJ', '=<!%x5VB');
INSERT INTO rm_server VALUES ('Dave Williams', '005DW', '8-{yaB`W');
INSERT INTO rm_server VALUES ('Carol Miller', '006CM', 'pj@Qm6Td');
INSERT INTO rm_server VALUES ('Bob Smith', '007BS', '6QnrP:P>');
INSERT INTO rm_server VALUES ('Carol Silva', '008CS', '|4jvtU9%');
INSERT INTO rm_server VALUES ('Eve Jones', '009EJ', 'dDkab$|*');
INSERT INTO rm_server VALUES ('Frank Johnson', '010FJ', '*^xz.L;Y');

SET linesize 500
SET pagesize 60
Column table_num Format 99
INSERT INTO rm_table VALUES (1);
INSERT INTO rm_table VALUES (2);
INSERT INTO rm_table VALUES (3);
INSERT INTO rm_table VALUES (4);
INSERT INTO rm_table VALUES (5);
INSERT INTO rm_table VALUES (6);
INSERT INTO rm_table VALUES (7);
INSERT INTO rm_table VALUES (8);
INSERT INTO rm_table VALUES (9);
INSERT INTO rm_table VALUES (10);

SET linesize 500
SET pagesize 60
Column name_customer Format A30
Column time Format A20
Coulmn num_guest Format 99
Column id Format A10
Column name_server Format A30
Column table_num Format 99
Column status A20
INSERT INTO rm_reservation VALUES ('Carol Davis', TO_TIMESTAMP('12/12/2023 08:00', 'MM/DD/YYYY HH24:MI'), 5, '001AG', 'Alice Garcia', 3, 'reserved');
INSERT INTO rm_reservation VALUES ('Bob Williams', TO_TIMESTAMP('12/12/2023 08:12', 'MM/DD/YYYY HH24:MI'), 3, '002DP', 'Dave Popov', 5, 'done');
INSERT INTO rm_reservation VALUES ('Carol Smith', TO_TIMESTAMP('12/12/2023 11:18', 'MM/DD/YYYY HH24:MI'), 5, '003FB', 'Frank Biden', 7, 'reserved');
INSERT INTO rm_reservation VALUES ('Dave Johnson', TO_TIMESTAMP('12/12/2023 13:21', 'MM/DD/YYYY HH24:MI'), 6, '004AJ', 'Alice Jones', 6, 'cancelled');
INSERT INTO rm_reservation VALUES ('Frank Brown', TO_TIMESTAMP('12/12/2023 14:00', 'MM/DD/YYYY HH24:MI'), 6, '005DW', 'Dave Williams', 10, 'reserved');
INSERT INTO rm_reservation VALUES ('Hank Johnson', TO_TIMESTAMP('12/12/2023 18:33', 'MM/DD/YYYY HH24:MI'), 5, '006CM', 'Carol Miller', 8, 'cancelled');
INSERT INTO rm_reservation VALUES ('Frank Jones', TO_TIMESTAMP('12/12/2023 18:55', 'MM/DD/YYYY HH24:MI'), 3, '007BS', 'Bob Smith', 3, 'reserved');
INSERT INTO rm_reservation VALUES ('Dave Davis', TO_TIMESTAMP('12/12/2023 19:16', 'MM/DD/YYYY HH24:MI'), 1, '008CS', 'Carol Silva', 3, 'cancelled');
INSERT INTO rm_reservation VALUES ('Grace Davis', TO_TIMESTAMP('12/12/2023 21:44', 'MM/DD/YYYY HH24:MI'), 7, '009EJ', 'Eve Jones', 7, 'done');
INSERT INTO rm_reservation VALUES ('Alice Williams', TO_TIMESTAMP('12/12/2023 22:04', 'MM/DD/YYYY HH24:MI'), 6, '010FJ', 'Frank Johnson', 5, 'cancelled');