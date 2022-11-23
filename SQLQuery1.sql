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
