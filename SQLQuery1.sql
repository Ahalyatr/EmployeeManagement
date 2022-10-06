create database EvaluationProject;

use EvaluationProject

create Table Employee
(
Id int primary key identity(1,1),
Name varchar(20) not null,
Department varchar(30) not null,
Age int not null,
Address varchar(50) not null
)

insert into Employee(Name,Department,Age,Address)
values
('Akshay','Finance',25,'Trivandrum Kerala'),
('Rahul','HR',29,'Palakkad Kerala'),
('Akshara','Developer',26,'Coimbatore TamilNadu'),
('Jasmine','Finance',24,'Alappuzha Kerala')

select * from Employee

drop table Employee




