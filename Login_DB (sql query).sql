Create DATABASE EmployeeDB;

USE EmployeeDB;

create database employeeDB;
use employeeDB;


CREATE TABLE dbo.[EmpLogin]
(
    EmpID INT IDENTITY(1,1) NOT NULL,
    EmpEmailId NVARCHAR(40) NOT NULL,
    EmpPassword NVARCHAR(256) NOT NULL,
   CONSTRAINT [PK_User_EmpID] PRIMARY KEY CLUSTERED (EmpID ASC)
)

Insert into dbo.[EmpLogin]
values('mansha.madaan@g.com','d5ae959e8241af6154453f662bcfa224');  //Mansha@123

Insert into dbo.[EmpLogin]
values('aditya.sharma@g.com','687dc37171ea06cea452324f25f5ab4d'); //Aditya@123

Select * from EmpLogin

