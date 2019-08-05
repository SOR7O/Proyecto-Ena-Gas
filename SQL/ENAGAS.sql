USE tempdb
GO

--Crear las base de datos
IF NOT EXISTS(SELECT * FROM sys.databases WHERE [name] = 'ENAGAS')
	BEGIN
		CREATE DATABASE ENAGAS
	END
GO

--Usar la base de datos
USE ENAGAS
GO

--Creacion de Esquema 
CREATE SCHEMA EnaGas
GO

--Tabla donde registran los clientes
CREATE TABLE EnaGas.ClientesEna(
idCliente INT IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
identidad VARCHAR(13)NOT NULL,
nombre NVARCHAR(50)NOT NULL,
apellido NVARCHAR(50)NOT NULL,
direccion NVARCHAR(100)NOT NULL,
telefono VARCHAR(100),
pesoC NVARCHAR(100),
cantidad INT
)
GO


--Tabla que registra el total de chimbos sin importar el peso, en general
CREATE TABLE EnaGas.Inventario(
idCantidad INT IDENTITY(1,1)NOT NULL,
cantidad INT NOT NULL PRIMARY KEY CLUSTERED
)
GO

--Tabla donde se registran los chimbos por peso
CREATE TABLE EnaGas.Chimbo(
idChimbo INT IDENTITY(1,1)NOT NULL,
cantidad int NOT NULL,
peso VARCHAR(20)NOT NULL,
precio MONEY NOT NULL
)
GO

--Tabla donde se registran los usuarios
CREATE TABLE EnaGas.Usuario(
idUsuario INT IDENTITY(1,100)NOT NULL PRIMARY KEY CLUSTERED,
nombreUsuario NVARCHAR(100)NOT NULL,
contraseña NVARCHAR(100)NOT NULL,
idCargo INT,
cargo NVARCHAR(50)NOT NULL
)
GO

--Tabla donde estan registrados los tipos de cargos del usuario
CREATE TABLE EnaGas.Cargo(
idCargo INT IDENTITY NOT NULL PRIMARY KEY CLUSTERED,
cargoUsuario NVARCHAR(50) NOT NULL
)
GO


--Tabla de registro del total por venta
CREATE TABLE EnaGas.TotalVenta(
idTotal INT IDENTITY NOT NULL PRIMARY KEY CLUSTERED,
totalVenta MONEY,
fecha DATETIME DEFAULT GETDATE())
GO

--Llave foranea de el usuario
ALTER TABLE EnaGas.Usuario
ADD CONSTRAINT FK_EnaGas_Usuario_idCargo$TieneUn$EnaGas_Cargo_idCargo
FOREIGN KEY(idCargo) REFERENCES EnaGas.Cargo(idCargo)
ON UPDATE CASCADE
ON DELETE NO ACTION
GO

--Procedimiento almacenado para agregar n cantidad de chimbos y actualizar el inventario
CREATE PROCEDURE EnaGas.AGREGAR_CHIMBO @cantidad INT,@precio MONEY,@peso NVARCHAR(20)
AS
  BEGIN TRANSACTION
    BEGIN TRY
	if NOT EXISTS(SELECT * FROM EnaGas.Inventario WHERE idCantidad=1)
	BEGIN
	INSERT INTO EnaGas.Inventario(cantidad)
	values(@cantidad-@cantidad)
	END
	IF EXISTS(SELECT * FROM EnaGas.Chimbo WHERE peso=@peso)
	BEGIN
	       UPDATE EnaGas.Chimbo SET cantidad=@cantidad+cantidad,precio=@precio,peso=@peso where peso=@peso;
		   UPDATE EnaGas.Inventario SET cantidad=@cantidad+cantidad
		         WHERE idCantidad=1;
		 END
   ELSE
   BEGIN
   	       INSERT INTO EnaGas.Chimbo(cantidad,precio,peso)
		   VALUES(@cantidad,@precio,@peso);
		   		   UPDATE EnaGas.Inventario SET cantidad=@cantidad+cantidad
		         WHERE idCantidad=1;
   END
		 COMMIT
		   END TRY
		   BEGIN CATCH
		     ROLLBACK TRANSACTION
		   END CATCH
GO

--Procedimiento almacenado para agregar una vente junto con los datos del cliente
--Actualiza el inventario 
--Actualiza la cantidad de chimbos que salen por peso
CREATE PROCEDURE EnaGas.AGREGAR_VENTA 
@identidad VARCHAR(13),
@nombre NVARCHAR(50),
@apellido NVARCHAR(50),
@direccion NVARCHAR(100),
@telefono VARCHAR(100),
@peso NVARCHAR(100),
@cantidad INT
AS
  BEGIN TRANSACTION
    BEGIN TRY
	IF NOT EXISTS(SELECT * FROM EnaGas.ClientesEna WHERE identidad=@identidad)
	BEGIN
	IF EXISTS(SELECT * FROM EnaGas.Chimbo WHERE peso=@peso)
	BEGIN
	INSERT INTO EnaGas.ClientesEna(identidad,nombre,apellido,direccion,telefono,pesoC,cantidad)
	values(@identidad,@nombre,@apellido,@direccion,@telefono,@peso,@cantidad);
	UPDATE EnaGas.Inventario SET cantidad=cantidad-@cantidad WHERE idCantidad=1;
	UPDATE EnaGas.Chimbo SET cantidad=cantidad-@cantidad where peso=@peso;
	 END
	 END
	 ELSE
	 BEGIN
	 IF EXISTS(SELECT * FROM EnaGas.Chimbo,EnaGas.ClientesEna WHERE peso=@peso and pesoC=@peso)
	 BEGIN
    UPDATE EnaGas.ClientesEna SET cantidad=@cantidad+cantidad WHERE identidad=@identidad and pesoC=@peso; 
	UPDATE EnaGas.Inventario SET cantidad=cantidad-@cantidad WHERE idCantidad=1;
	UPDATE EnaGas.Chimbo SET cantidad=cantidad-@cantidad where peso=@peso;
	 END
	 ELSE
	 BEGIN
	 INSERT INTO EnaGas.ClientesEna(identidad,nombre,apellido,direccion,telefono,pesoC,cantidad)
	values(@identidad,@nombre,@apellido,@direccion,@telefono,@peso,@cantidad);
	UPDATE EnaGas.Inventario SET cantidad=cantidad-@cantidad WHERE idCantidad=1;
	UPDATE EnaGas.Chimbo SET cantidad=cantidad-@cantidad where peso=@peso;
	 END
	 END
	 COMMIT
	END TRY
	BEGIN CATCH
	  ROLLBACK TRANSACTION
	END CATCH
GO


--Procedimiento almacenado para sacar el total de la venta
CREATE PROCEDURE EnaGas.TOTAL_VENTA @cantidad INT ,@peso NVARCHAR(100)
AS
INSERT INTO EnaGas.TotalVenta(totalVenta)
SELECT precio * @cantidad FROM EnaGas.Chimbo 
WHERE peso=@peso
GO
