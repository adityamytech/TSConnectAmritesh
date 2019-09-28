create procedure TS_signUp (@userId varchar(50), @password varchar(15), @firstName varchar(50), @lastName varchar(50),@roleId int, @type varchar(15), @age int, @gender varchar(10), @contact varchar(10), @securityId int, @securityAnswer varchar(50),@updatedOn datetime,@isActive bit)
as
begin
declare @id varchar(50)
select @id =  us_userId from [TS_User] where us_userId = @userId 
if @id is null
begin
insert into TS_User values (@userId, @password, @firstName, @lastName)
insert into TS_Role values (@roleId, @userId, @type)
insert into TS_Details values (@userId, @age , @gender,@contact, @securityId, @securityAnswer,@updatedOn,@isActive)
end
else
select 0 as 'Return'
end


execute TS_signUp 'vedantSuperUser','123456','Vedant','Kulkarni',3,'Super User','25','Male','7909089863','0','Dog','2019-09-18 10:17:57.183','1'
execute TS_signUp'102','Babbar Sher','Lion','Sher',1,'USer',55,'Male',9660179867,28,'Silk Bubbly'


create procedure TS_SignIn (@userId varchar(50), @password varchar(15))
as
begin
declare @active bit
select @active = details_isActive from TS_Details where details_usId=@userId
if @active=1
begin
select  us_userId, us_password, us_firstName, us_lastName from TS_User where us_userId=@userId and us_password=@password 
select  role_id, role_type from TS_Role where role_usId=@userId
end
else
select 0 as 'Return'
end

create procedure Approval_DisplayData
as
begin
declare @id varchar(50)
select details_usId,details_contact from TS_Details where details_isActive=0
select us_userId, us_firstName, us_lastName from TS_User where us_userId in (select details_usId from TS_Details where details_isActive=0)
end 



execute Approval_DisplayData

execute TS_SignIn 'nooraFathei','123456'
select * from TS_User
select * from TS_Role
select * from TS_Details
