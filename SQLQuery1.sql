select * from Users

--BASE DE DATOS
create database MyCompanyTest
go
use MyCompanyTest
go

--TABLAS
create table Users(
id int identity(1,1) primary key,
userName nvarchar (100) unique not null,--No permitir datos duplicados en este campo
password nvarchar (100) not null,
firstName nvarchar(100) not null,
lastName nvarchar(100) not null,
position nvarchar (100) not null,
email nvarchar(100) unique not null,--No permitir datos duplicados en este campo
profilePicture varbinary(max)--Foto de perfil
)

create table Clients(
id int identity(1,1) primary key,
firstName nvarchar(100) not null,
lastName nvarchar(100) not null,
email nvarchar(100) unique not null,--No permitir datos duplicados en este campo

)
go
--PROCEDIMIENTOS ALMACENADOS
create proc AddUser
	@userName nvarchar(100),
	@password nvarchar(100),
	@firstName nvarchar(100),
	@lastName nvarchar(100),
	@position nvarchar(100),
	@email nvarchar(100),
	@photo varbinary(max)--foto de perfil
	as
	insert into Users 
	values (@userName,@password, @firstName, @lastName,@position,@email,@photo)
go

create proc AddClient
	
	@firstName nvarchar(100),
	@lastName nvarchar(100),	
	@email nvarchar(100)
	
	as
	insert into Clients 
	values ( @firstName, @lastName,@email)
go

create proc EditUser
	@userName nvarchar(100),
	@password nvarchar(100),
	@firstName nvarchar(100),
	@lastName nvarchar(100),
	@position nvarchar(100),
	@email nvarchar(100),
	@photo varbinary(max),--foto de perfil
	@id int
	as
	update  Users	
	set userName=@userName,password=@password,firstName=@firstName,lastName= @lastName,position= @position,email=@email, profilePicture=@photo  
	where id=@id 
go

create proc EditClient
	
	@firstName nvarchar(100),
	@lastName nvarchar(100),
	@email nvarchar(100),
	@id int
	as
	update  Users	
	set firstName=@firstName,lastName= @lastName,email=@email
	where id=@id 
go

create proc RemoveUser
	@id int
	as
	delete from Users where id=@id 
go

create proc RemoveClient
	@id int
	as
	delete from Clients where id=@id 
go

create proc LoginUser
	@user nvarchar (100),
	@password nvarchar (100)
	as
	select *from Users 
	where (userName=@user and password=@password ) or (email=@user and password=@password)
go

create proc SelectAllUsers
	as
	select *from Users 
go

create proc SelectAllClients
	as
	select *from Clients
go


create proc SelectUser
	@findValue nvarchar (100)
	as
	select *from Users 
	where userName= @findValue or firstName like @findValue+'%' or email=@findValue
go

create proc SelectClient
	@findValue nvarchar (100)
	as
	select *from Clients 
	where  firstName like @findValue+'%' or email=@findValue
go




 --Agregar usuarios
exec addUser 'admin','admin','Jackson','Collins','System administrator','Support@SystemfAll.biz',null--Sin foto de perfil.
exec addUser 'Benmin','abc123456','Benjamin','Thompson','Accountant','BenThompson@MyCompany.com',null --Sin foto de perfil.
exec addUser 'Kathy','abc123456','Kathrine','Smith','Administrative assistant','KathySmith@MyCompany.com',null--Sin foto de perfil.
--Puedes agregar fotos de perfil desde el formulario mantenimiento de usuario iniciando como administrador, o puedes agregar foto de perfil desde la opción actualizar perfil mi perfil de usuario.

---Mostrar usuarios
exec selectAllUsers
exec loginUser 'admin', 'admin'


