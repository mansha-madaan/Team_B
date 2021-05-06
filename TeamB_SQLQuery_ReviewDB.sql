drop database employeeDB;

create database employeeDB;
use employeeDB;
CREATE TABLE dbo.[EmpLogin]
(
    EmpID INT IDENTITY(1,1) NOT NULL primary key,
    EmpEmailId NVARCHAR(40) NOT NULL,
    PasswordHash BINARY(64) NOT NULL,
   
)

create table review(
EmpID int,
RID int primary key IDENTITY(1,1),
R_Name varchar(255),
QA_Name varchar(255),
Target_Date DATE,
Status varchar(30),
Review_Cycle varchar(255),
Promotion_Cycle varchar(255),
Self_Effect varchar(3000),
Self_Effect_Status varchar(255),
Self_Lead varchar(3000),
Self_Lead_Status varchar(255),
Self_Feed varchar(3000),
Self_Feed_Status varchar(255),
Self_Growth varchar(3000),
Self_Growth_Status varchar(255),
RQ_Effect varchar(3000),
RQ_Effect_Status varchar(255),
RQ_Lead varchar(3000),
RQ_Lead_Status varchar(255),
RQ_Feed varchar(3000),
RQ_Feed_Status varchar(255),
RQ_Growth varchar(3000),
RQ_Growth_Status varchar(255),
FOREIGN KEY (EmpID) REFERENCES EmpLogin(EmpID));

select * from review;

DELETE FROM review;

insert into review(EmpID,reviewName,R_Name,QA_Name,Target_Date,RStatus)
VALUES(1,'review2021','Avneet','Himanshu','2021-05-21','Initiate')

insert into review(EmpID,reviewName,R_Name,QA_Name,Target_Date,RStatus,Review_Cycle,Promotion_Cycle)
VALUES(3,'review2021','Avneet','Himanshu','2021-08-07','Initiate','2020-2021','2020')