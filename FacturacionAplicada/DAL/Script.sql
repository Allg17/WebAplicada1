
create database ProyectoFinalAplicada1
go
use ProyectoFinalAplicada1
go
Create Table Usuarios
(
	IdUsuario int primary key identity(1,1),
	Nombre varchar(30),
	Clave varchar(8),
	NombreUsuario varchar(max),
	Fecha date,
	Comentario varchar(max)


);
set dateformat dmy;
insert into Usuarios values('Albert Lopez','123456','root','30/03/2018','Developer')
go
Create Table Productoes
(
	Idproducto int primary key identity(1,1),
	Descripcion varchar(max),
	Precio money,
	DepartamentoId int,
	Cantidad int,
	Costo money,
	Ganancia money,
	Fecha date

);
go
create table Departamentoes
(
	DepartamentoId int primary key identity(1,1),
	Nombre varchar(max)

);
go
create table Clientes 
(
	IdCliente int primary key identity(1,1),
	Nombre varchar(30),
	Direccion varchar(max),
	Cedula varchar(15),
	Telefono varchar(15),
	Fecha date

);
go
create table Facturas
(
	FacturaId int primary key identity(1,1),
	Monto money,
	UsuarioId int,
	ClienteId int,
	Fecha date,
	Descripcion varchar(max),
	FormaDePago varchar(max),
	Devuelta money,
	EfectivoRecibido money
);
go
create table FacturaDetalles
(
	Id int primary key identity(1,1),
	FacturaId int,
	ProductoId int,
	Cantidad int,
	Precio decimal,
	Descripcion varchar(max)

);
go
CREATE TABLE EntradaArticuloes
(
EntradaArticuloID int primary key identity(1,1),
Fecha date,
Cantidad int,
ArticuloID int
);
