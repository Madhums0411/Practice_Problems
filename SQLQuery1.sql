create database Addressbooksql

create Table AddressBook
(
Id int primary key Identity(1,1),
FirstName varchar(100),
LastName varchar(100),
Email varchar(100),
Mobile varchar(100),
Address varchar(100),
City varchar(100),
State varchar(100),
Pincode varchar(100)
)

Create procedure SpAddressBook
(
@FirstName varchar(255),
@LastName varchar(255),
@Email varchar(255),
@Mobile varchar(255),
@Address varchar(255),
@City varchar(255),
@State varchar(255),
@Pincode varchar(255)
)
as
begin
insert into AddressBook values(@FirstName,@LastName,@Email,@Mobile,@Address,@City,@State,@Pincode)
end
Select * from AddressBook

create procedure getAddressBook
as
begin
select * from AddressBook
end

create procedure UpdateAddressBook(
@Id int,
@FirstName varchar(100),
@LastName varchar(100),
@Email varchar(100),
@Mobile varchar(100),
@Address varchar(100),
@City varchar(100),
@State varchar(100),
@Pincode varchar(100)
)
as
begin
update AddressBook set FirstName=@FirstName, LastName=@LastName, Email=@Email, Mobile=@Mobile, Address=@Address, City=@City, State=@State, Pincode=@Pincode where Id=@Id;
end


create procedure DeleteAddressBook(
@Id int
)
as
begin
delete from AddressBook where Id=@Id;
end


select * from AddressBook


create table UserTable(
Id int primary key Identity(1,1),
FirstName varchar(100),
LastName varchar(100),
Email varchar(100),
Password varchar(100)
)

select * from UserTable

create procedure UserRegister(
@FirstName varchar(100),
@LastName varchar(100),
@Email varchar(100),
@Password varchar(100)
)
as
begin
insert into UserTable values(@FirstName,@LastName,@Email,@Password)
end

alter procedure (
@Email varchar(100)Userlogin
)
as
begin
select * from UserTable where Email=@Email;
end


create procedure ForgotPassword(
@Email varchar(100)
)
as
begin
select * from UserTable where Email=@Email;
end

create procedure SpResetPassword(
@Email varchar(255),
@Password varchar(255)
)
as
begin
update UserTable set Password=@Password where Email=@Email
end