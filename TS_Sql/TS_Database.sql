create Database [TS-Connect]
use [TS-Connect]
  create table TS_User
  (
     us_id int identity(1,1) ,
       us_userId varchar(50) Primary Key,
       us_password varchar (15),
       us_firstName varchar(50),
       us_lastName varchar(50)
);  

create table TS_Role
(
_id int primary key identity(1,1),
role_id int,
--0 =Teacher 1=Student 2=Admin 3=Super USer--
role_usId varchar(50)  foreign key references [TS_User](us_userId),
role_type varchar(15)
);

create table TS_Details
(
details_id int identity (1,1)  Primary Key,
details_usId varchar(50) foreign key references [TS_User](us_userId),
details_age int,
details_gender varchar(10),
details_contact varchar(10),
details_securityId int ,
details__securityAnswer varchar (50),
details_updatedOn datetime,
details_isActive bit
);

create table TS_SecurityQuestion
(
sq_id int identity (1,1)  Primary Key,
sq_question varchar (50)
)

select * from TS_Role
select * from TS_User
select * from TS_Details

insert into TS_Role(role_type) values ('Teacher')
  insert into TS_Role(role_usId) values ('103')

  insert into TS_Role values ('1','103','Teacher')
insert into TS_User values ('103','Sunny123','Sunny','Abhishek' )
       drop table TS_Role
       drop table TS_User
       drop table TS_Details

       delete from  TS_Role
       delete from TS_User
       delete from TS_Details

