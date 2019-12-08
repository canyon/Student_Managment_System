--execute  dbo.pGetMoney 2019, '企业单位', @sumOrdermoney output;
--select '2019年 企业单位 订购金额合计: ', convert(varchar(12),@sumOrdermoney);

--alter procedure check_stu_id @id char(15) as begin
--select
--	count(*)
--from
--	(
--		select
--			stu_id
--		from
--			student as stu
--		union
--		select
--			tea_id
--		from
--			teacher as tea
--	) as total(id)
--where
--	total.id = @id
--end
--go

--alter procedure check_passwd @id char(15),
--	@passwd char(15) as begin
--select
--	count(*)
--from
--	(
--		select
--			stu_id, passwd
--		from
--			student as stu
--		union
--		select
--			tea_id, passwd
--		from
--			teacher as tea
--	) as total(id, passwd)
--where
--	total.id = @id and total.passwd = @passwd
--end
--go

--alter procedure check_admin_id @id char(15) as begin
--select
--	count(*)
--from
--	admin_jwxt
--where
--	admin_jwxt.admin_id = @id
--end
--go

--alter procedure check_admin_passwd @id char(15),
--@passwd char(15) as begin
--select
--	count(*)
--from
--	admin_jwxt
--where
--	admin_jwxt.admin_id = @id and admin_jwxt.passwd = @passwd
--end
--go

--alter procedure get_stu_info
--@id char(15), 
--@year char(15),
--@course char(20)
--as
--begin
--select sco_year as "年份", tea.tea_name as "任课老师", cour.cour_id as "课程号", cour_name as "课程名", score as "分数"
--from student as stu join score as sco on stu.stu_id = sco.stu_id
--join course as cour on cour.cour_id = sco.cour_id 
--join teacher as tea on tea.cour_id = cour.cour_id
--where stu.stu_id = @id and sco.sco_year = @year and cour.cour_name = @course
--end
--go

--alter procedure get_all_cour
--@id char(15)
--as
--begin
--select sco_year as "年份", tea.tea_name as "任课老师", cour.cour_id as "课程号", cour_name as "课程名", score as "分数"
--from student as stu join score as sco on stu.stu_id = sco.stu_id
--join course as cour on cour.cour_id = sco.cour_id 
--join teacher as tea on tea.cour_id = cour.cour_id
--where stu.stu_id = @id
--end

--ALTER DATABASE jwxt SET SINGLE_USER WITH ROLLBACK IMMEDIATE
--ALTER DATABASE jwxt COLLATE Chinese_PRC_CI_AS
--ALTER DATABASE jwxt SET MULTI_USER

--alter procedure get_this_stu
--@id char(15)
--as
--begin
--select stu.stu_id as id, stu.stu_name as stu_name, stu.grade as grade, stu.class as class, pro.pro_name as pro_name
--from profession as pro 
--join student as stu on pro.stu_id = stu.stu_id join score as sco on stu.stu_id = sco.stu_id
--join course as cour on cour.cour_id = sco.cour_id 
--join teacher as tea on tea.cour_id = cour.cour_id
--where stu.stu_id = @id
--end

--alter procedure get_this_tea
--@id char(15)
--as
--begin
--select tea.tea_id as id, tea.tea_name as stu_name
--from teacher as tea
--where tea.tea_id = @id
--end
--go

--alter procedure get_all_cour_tea
--@id char(15)
--as
--begin
--select cour.cour_id as "课程号", cour_name as "课程名"
--from course as cour join teacher as tea on tea.tea_id = cour.tea_id
--where tea.tea_id = @id
--end

create procedure get_stu_detail
as
begin
select stu.stu_id as "学号", stu.stu_name as "姓名", stu.grade as "年级", stu.class as "班级"
from student as stu
end
go

create procedure get_tea_detail
as
begin
select stu.stu_id as "学号", stu.stu_name as "姓名", stu.grade as "年级", stu.class as "班级"
from student as stu
end
go