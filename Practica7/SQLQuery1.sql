CREATE DATABASE PWAPractica7
go

use PWAPractica7

CREATE TABLE tbl_producto(
idProducto INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(50),
precio DECIMAL(18,2)
)

CREATE PROCEDURE sp_obtener_productId
@idProducto INT 
AS BEGIN
SELECT * FROM tbl_producto WHERE idProducto=@idProducto
END

CREATE PROCEDURE sp_insert_product
@nombre VARCHAR(50),
@precio DECIMAL(18,2)
AS BEGIN
INSERT INTO tbl_producto VALUES(@nombre,@precio)
END

CREATE PROCEDURE sp_actualizar_product
@idProducto INT,
@nombre VARCHAR(50),
@precio DECIMAL(18,2)
AS BEGIN
UPDATE tbl_producto SET nombre=@nombre, precio=@precio
WHERE idProducto=@idProducto
END

CREATE PROCEDURE sp_eliminar_product
@idProducto INT 
AS BEGIN
DELETE FROM tbl_producto WHERE idProducto=@idProducto
END

CREATE PROCEDURE sp_obtener_product
AS BEGIN
SELECT * FROM tbl_producto
END