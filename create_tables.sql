create table student
(
	stu_id char(15) primary key,
	stu_name varchar(20),
	grade char(15),
	class char(15),
	passwd char(15)
) 
create table teacher
(
	tea_id char(15) primary key,
	tea_name varchar(20),
	cour_id char(15),
	passwd char(15)
)
create table profession
(
	pro_id char(15),
	pro_name varchar(20),
	stu_id char(15) primary key
)
create table course
(
	cour_id char(15) primary key,
	cour_name varchar(20),
	tea_id char(15)
)
--create table score
--(
--	cour_id char(15) not null,
--	stu_id char(15) not null,
--	sco_year char(15),
--	score char(15)
--)

--alter table score add primary key (cour_id, stu_id)

--create table admin_jwxt
--(
--	admin_id char(15) primary key,
--	passwd char(15)
--)

--insert into admin_jwxt values('000', '000');