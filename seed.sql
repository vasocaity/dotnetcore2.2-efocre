
CREATE TABLE mydb.grade (
	grade_id int AUTO_INCREMENT,
	grade_name varchar(100) NULL,
	grade_section varchar(100) NULL,
	PRIMARY KEY (grade_id)
)
ENGINE=InnoDB
DEFAULT CHARSET=utf8
COLLATE=utf8_general_ci;

INSERT INTO mydb.grade (grade_name, grade_section) VALUES ('12', '3');
INSERT INTO mydb.grade (grade_name, grade_section) VALUES ('11', '3');
INSERT INTO mydb.grade (grade_name, grade_section) VALUES ('10', '2');
INSERT INTO mydb.grade (grade_name, grade_section) VALUES ('9', '1');


CREATE TABLE mydb.student (
	student_id int AUTO_INCREMENT,
	student_name varchar(100),
	date_of_birth DATETIME,
	current_grade_id int,
	PRIMARY KEY (student_id),
	FOREIGN KEY (current_grade_id) REFERENCES grade(grade_id)
)
ENGINE=InnoDB
DEFAULT CHARSET=utf8
COLLATE=utf8_general_ci;

INSERT INTO mydb.student (student_name,date_of_birth,current_grade_id) VALUES ('vara','2012-06-18T10:34:09',1);
INSERT INTO mydb.student (student_name,date_of_birth,current_grade_id) VALUES ('vara 2','2012-06-18T10:34:09',2);
INSERT INTO mydb.student (student_name,date_of_birth,current_grade_id) VALUES ('vara 3','2012-06-18T10:34:09',2);
INSERT INTO mydb.student (student_name,date_of_birth,current_grade_id) VALUES ('vara 4','2012-06-18T10:34:09',1);
INSERT INTO mydb.student (student_name,date_of_birth,current_grade_id) VALUES ('vara 5','2012-06-18T10:34:09',1);
