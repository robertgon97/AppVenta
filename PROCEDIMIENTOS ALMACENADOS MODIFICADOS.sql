-- Procedimientos Almacenados

	-- // USUARIO (usuarios)
	-- GETTERS
	CREATE Procedure GET_usuarios AS
		BEGIN
			 SELECT TOP 200 * FROM usuarios
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	CREATE Procedure GET_ID_usuarios 
	@idusuario int
	AS
		BEGIN
			 SELECT * FROM usuarios WHERE usuario_id = @idusuario
		END
	GO

	CREATE Procedure GET_SEARCH_usuarios 
	@search text
	AS
		BEGIN
			 SELECT * FROM usuarios WHERE tipo_documento_id LIKE '%@search%' OR 
			 usuario_username LIKE '%@search%' OR 
			 usuario_nombres LIKE '%@search%' OR 
			 usuario_apellidos LIKE '%@search%' OR 
			 usuario_dni LIKE '%@search%' OR 
			 usuario_direccion LIKE '%@search%'
		END
	GO

	-- POST

	CREATE Procedure POSTusuarios
	@idusuario int output,
	@usuario_tipo_id int, 
	@tipo_documento_id int, 
	@usuario_username text,
	@usuario_password text,
	@usuario_nombres text,
	@usuario_apellidos text,
	@usuario_sexo text,
	@usuario_fecha_nacimiento DATE,
	@usuario_dni int,
	@usuario_direccion text,
	@usuario_email text,
	@usuario_telefono int
	AS
		BEGIN
			 INSERT INTO usuarios (usuario_tipo_id, tipo_documento_id, usuario_username, usuario_password, usuario_nombres, usuario_apellidos, usuario_sexo, usuario_fecha_nacimiento, usuario_dni, usuario_direccion, usuario_email, usuario_telefono)
			 VALUES (@usuario_tipo_id, @tipo_documento_id, @usuario_username, @usuario_password, @usuario_nombres, @usuario_apellidos, @usuario_sexo, @usuario_fecha_nacimiento, @usuario_dni, @usuario_direccion, @usuario_email, @usuario_telefono)
		END
	GO

	-- PUT

	CREATE Procedure PUTusuarios
	@idusuario int,
	@usuario_tipo_id int, 
	@tipo_documento_id int, 
	@usuario_username text,
	@usuario_password text,
	@usuario_nombres text,
	@usuario_apellidos text,
	@usuario_sexo text,
	@usuario_fecha_nacimiento DATE,
	@usuario_dni int,
	@usuario_direccion text,
	@usuario_email text,
	@usuario_telefono int
	AS
		BEGIN
			 UPDATE usuarios SET usuario_tipo_id = @usuario_tipo_id, tipo_documento_id = @tipo_documento_id, usuario_username = @usuario_username, usuario_password = @usuario_password, usuario_nombres = @usuario_nombres, usuario_apellidos = @usuario_apellidos, usuario_sexo = @usuario_sexo, usuario_fecha_nacimiento = @usuario_fecha_nacimiento, usuario_dni = @usuario_dni, usuario_direccion = @usuario_direccion, usuario_email = @usuario_email, usuario_telefono = @usuario_telefono
			 WHERE usuarios.usuario_id = @idusuario
		END
	GO

	-- DELETE

	CREATE Procedure DELETEusuarios
	@idusuario int
	AS
		BEGIN
			 DELETE FROM usuarios WHERE usuarios.usuario_id = @idusuario
		END
	GO






	-- // PREGUNTAS DE SEGURIDAD DEL USUARIO (usuarios_pregunta_seguridad)
	-- GETTERS
	CREATE Procedure GET_usuarios_pregunta_seguridad AS
		BEGIN
			 SELECT TOP 200 * FROM usuarios_pregunta_seguridad
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	CREATE Procedure GET_ID_usuarios_pregunta_seguridad 
	@idpregunta int
	AS
		BEGIN
			 SELECT * FROM usuarios_pregunta_seguridad WHERE usuarios_pregunta_seguridad_id = @idpregunta
		END
	GO

	CREATE Procedure GET_SEARCH_usuarios_pregunta_seguridad 
	@search text
	AS
		BEGIN
			 SELECT * FROM usuarios_pregunta_seguridad WHERE usuarios_pregunta_seguridad_pregunta LIKE '%@search%'
		END
	GO

	-- POST

	CREATE Procedure POSTusuarios_pregunta_seguridad
	@idpregunta int output,
	@usuario int, 
	@pregunta text, 
	@respuesta text
	AS
		BEGIN
			 INSERT INTO usuarios_pregunta_seguridad (usuario_id, usuarios_pregunta_seguridad_pregunta, usuarios_pregunta_seguridad_respuesta)
			 VALUES (@usuario, @pregunta, @respuesta)
		END
	GO

	-- PUT

	CREATE Procedure PUTusuarios_pregunta_seguridad
	@idpregunta int,
	@pregunta text, 
	@respuesta text
	AS
		BEGIN
			 UPDATE usuarios_pregunta_seguridad SET usuarios_pregunta_seguridad_pregunta = @pregunta, usuarios_pregunta_seguridad_respuesta = @respuesta
			 WHERE usuarios_pregunta_seguridad.usuarios_pregunta_seguridad_id = @idpregunta
		END
	GO

	-- DELETE

	CREATE Procedure DELETEusuarios_pregunta_seguridad
	@idpregunta int
	AS
		BEGIN
			 DELETE FROM usuarios_pregunta_seguridad WHERE usuarios_pregunta_seguridad.usuarios_pregunta_seguridad_id = @idpregunta
		END
	GO






	-- // VENTAS (venta)
	-- GETTERS
	CREATE Procedure GET_ventas AS
		BEGIN
			 SELECT TOP 200 * FROM ventas
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	CREATE Procedure GET_ID_ventas 
	@idventa int
	AS
		BEGIN
			 SELECT * FROM ventas WHERE venta_id = @idventa
		END
	GO

	CREATE Procedure GET_SEARCH_ventas 
	@search text
	AS
		BEGIN
			 SELECT * FROM ventas WHERE
			 venta_factura LIKE '%@search%' OR 
			 venta_anulado LIKE '%@search%' OR 
			 venta_fecha LIKE '%@search%' OR
			 venta_id LIKE '%@search%'
		END
	GO

	-- POST

	CREATE Procedure POSTventas
	@idventa int output,
	@ventas_tipo_id int, 
	@status_id int, 
	@cliente_id int,
	@usuario_id int,
	@venta_correlativo text,
	@venta_factura text,
	@venta_anulado tinyint,
	@venta_fecha DATE,
	@venta_serie text,
	@venta_iva int, 
	@venta_total_iva decimal,
	@venta_total_sin_iva decimal
	AS
		BEGIN
			 INSERT INTO ventas (ventas_tipo_id, status_id, cliente_id, usuario_id, venta_correlativo, venta_factura, venta_anulado, venta_fecha, venta_serie, venta_iva, venta_total_iva, venta_total_sin_iva)
			 VALUES (@ventas_tipo_id, @status_id, @cliente_id, @usuario_id, @venta_correlativo, @venta_factura, @venta_anulado, @venta_fecha, @venta_serie, @venta_iva, @venta_total_iva, @venta_total_sin_iva)
		END
	GO

	
	-- PUT

	CREATE Procedure PUTventas
	@idventa int,
	@ventas_tipo_id int, 
	@status_id int, 
	@cliente_id int,
	@usuario_id int,
	@venta_correlativo text,
	@venta_factura text,
	@venta_anulado tinyint,
	@venta_fecha DATE,
	@venta_serie text,
	@venta_iva int, 
	@venta_total_iva decimal,
	@venta_total_sin_iva decimal
	AS
		BEGIN
			 UPDATE ventas SET ventas_tipo_id = @ventas_tipo_id, status_id = @status_id, cliente_id = @cliente_id, usuario_id = @usuario_id, venta_correlativo = @venta_correlativo, venta_factura = @venta_factura, venta_anulado = @venta_anulado, venta_fecha = @venta_fecha, venta_serie = @venta_serie, venta_iva = @venta_iva, venta_total_iva = @venta_total_iva, venta_total_sin_iva = @venta_total_sin_iva
			 WHERE ventas.venta_id = @idventa
		END

	GO


	-- DELETE

	CREATE Procedure DELETEventas
	@idventa int
	AS
		BEGIN
			 DELETE FROM ventas WHERE ventas.venta_id = @idventa
		END
	GO






	-- // CLIENTES (clientes)
	-- GETTERS

	CREATE Procedure GET_clientes AS
		BEGIN
			 SELECT TOP 200 * FROM clientes
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	
	CREATE Procedure GET_ID_clientes
	@idcliente int
	AS
		BEGIN
			 SELECT * FROM clientes WHERE cliente_id = @idcliente
		END
	GO

	
	CREATE Procedure GET_SEARCH_clientes
	@search text
	AS
		BEGIN
			 SELECT * FROM clientes WHERE 
			 cliente_nombres LIKE '%@search%' OR 
			  cliente_apellidos LIKE '%@search%' OR 
			 cliente_dni LIKE '%@search%' OR 
			 cliente_direccion LIKE '%@search%' 
			 
		END
	GO


	
	-- POST

	CREATE Procedure POSTclientes
	@idcliente int output,
	@tipo_documento_id int, 
	@cliente_nombres text,
	@cliente_apellidos  text,
	@cliente_dni int,
	@cliente_direccion text,
	@cliente_nacimiento DATETIME,
	@cliente_email text,
	@cliente_telefono int
	AS
		BEGIN
			 INSERT INTO clientes(tipo_documento_id, cliente_nombres, cliente_apellidos, cliente_dni, cliente_direccion, cliente_nacimiento, cliente_email, cliente_telefono)
			 VALUES ( @tipo_documento_id, @cliente_nombres, @cliente_apellidos, @cliente_dni, @cliente_direccion, @cliente_nacimiento, @cliente_email, @cliente_telefono)
		END
	GO

	
	-- PUT

	CREATE Procedure PUTclientes
	@idcliente int,
	@tipo_documento_id int, 
	@cliente_nombres text,
	@cliente_apellidos  text,
	@cliente_dni int,
	@cliente_direccion text,
	@cliente_nacimiento DATETIME,
	@cliente_email text,
	@cliente_telefono int
	AS
		BEGIN
			 UPDATE clientes SET tipo_documento_id = @tipo_documento_id, cliente_nombres = @cliente_nombres, cliente_apellidos = @cliente_apellidos, cliente_dni = @cliente_dni, cliente_direccion = @cliente_direccion, cliente_nacimiento = @cliente_nacimiento, cliente_email = @cliente_email, cliente_telefono = @cliente_telefono
			 WHERE clientes.cliente_id = @idcliente
		END
	GO

		-- DELETE

	CREATE Procedure DELETEclientes
	@idcliente int
	AS
		BEGIN
			 DELETE FROM clientes WHERE clientes.cliente_id = @idcliente
		END
	GO

	

	-- // PROVEEDORES (proveedor)
	-- GETTERS

	CREATE Procedure GET_proveedores AS
		BEGIN
			 SELECT TOP 200 * FROM proveedores
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	
	CREATE Procedure GET_ID_proveedores
	@idproveedor int
	AS
		BEGIN
			 SELECT * FROM proveedores WHERE proveedor_id = @idproveedor
		END
	GO

	CREATE Procedure GET_SEARCH_proveedores
	@search text
	AS
		BEGIN
			 SELECT * FROM proveedores WHERE 
			 proveedor_razon_social LIKE '%@search%' OR 
			  proveedor_dni LIKE '%@search%' OR 
			 proveedor_direccion LIKE '%@search%' OR 
			 proveedor_email LIKE '%@search%' 
			 
		END
	GO

	-- POST

	CREATE Procedure POSTproveedores
	@idproveedor int output,
	@tipo_documento_id int, 
	@proveedor_razon_social text,
	@proveedor_dni  text,
	@proveedor_direccion text,
	@proveedor_email text,
	@proveedor_telefono int,
	@proveedor_url text
	AS
		BEGIN
			 INSERT INTO proveedores(tipo_documento_id, proveedor_razon_social, proveedor_dni, proveedor_direccion, proveedor_email, proveedor_telefono, proveedor_url)
			 VALUES ( @tipo_documento_id, @proveedor_razon_social, @proveedor_dni, @proveedor_direccion, @proveedor_email, @proveedor_telefono, @proveedor_url)
		END
	GO

	
	-- PUT

	CREATE Procedure PUTproveedores
	@idproveedor int,
	@tipo_documento_id int, 
	@proveedor_razon_social text,
	@proveedor_dni  text,
	@proveedor_direccion text,
	@proveedor_email text,
	@proveedor_telefono int,
	@proveedor_url text
	AS

		BEGIN
			 UPDATE proveedores SET tipo_documento_id = @tipo_documento_id, proveedor_razon_social=@proveedor_razon_social, proveedor_dni=@proveedor_dni, proveedor_direccion=@proveedor_direccion,	proveedor_email=@proveedor_email,proveedor_telefono=@proveedor_telefono,proveedor_url=@proveedor_url
			 			 WHERE proveedores.proveedor_id = @idproveedor
		END
	GO
	
	-- DELETE

	CREATE Procedure DELETEproveedores
	@idproveedor int
	AS
		BEGIN
			 DELETE FROM proveedores WHERE proveedores.proveedor_id = @idproveedor
		END
	GO



	
	--// VENTA_CLIENTE_NOTA_CREDITO(venta_cliente_nota_credito)
	-- GETTERS
	CREATE Procedure GET_venta_cliente_nota_credito AS
		BEGIN
			 SELECT TOP 200 * FROM venta_cliente_nota_credito
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	
	CREATE Procedure GET_ID_venta_cliente_nota_credito
	@idventa_cliente_nota_credito int
	AS
		BEGIN
			 SELECT * FROM venta_cliente_nota_credito WHERE venta_cliente_nota_credito_id = @idventa_cliente_nota_credito
		END
	GO

	CREATE Procedure GET_SEARCH_venta_cliente_nota_credito
	@search text
	AS
		BEGIN
			 SELECT * FROM venta_cliente_nota_credito WHERE  
			 venta_cliente_nota_credito_fecha LIKE '%@search%'			 
			 
		END
	GO

	-- POST

	CREATE Procedure POSTventa_cliente_nota_credito
	@idventa_cliente_nota_credito  int output,
	@venta_id int, 
	@venta_cliente_nota_credito_fecha DATE,
	@venta_cliente_nota_credito_gastado  decimal,
	@venta_cliente_nota_credito_valido tinyint
	
	AS
		BEGIN
			 INSERT INTO venta_cliente_nota_credito(venta_id,venta_cliente_nota_credito_fecha,venta_cliente_nota_credito_gastado,venta_cliente_nota_credito_valido)
			 VALUES ( @venta_id , @venta_cliente_nota_credito_fecha, @venta_cliente_nota_credito_gastado, @venta_cliente_nota_credito_valido)
			 END
			 	GO

	
	-- PUT

	CREATE Procedure PUTventa_cliente_nota_credito
	@idventa_cliente_nota_credito  int,
	@venta_id int, 
	@venta_cliente_nota_credito_fecha DATE,
	@venta_cliente_nota_credito_gastado  decimal,
	@venta_cliente_nota_credito_valido tinyint
	
	AS
		BEGIN
			 UPDATE venta_cliente_nota_credito SET venta_id = @venta_id, venta_cliente_nota_credito_fecha = @venta_cliente_nota_credito_fecha, venta_cliente_nota_credito_gastado = @venta_cliente_nota_credito_gastado, venta_cliente_nota_credito_valido = @venta_cliente_nota_credito_valido
			 WHERE venta_cliente_nota_credito.venta_cliente_nota_credito_id = @idventa_cliente_nota_credito
		END
	GO


		-- DELETE

	CREATE Procedure DELETEventa_cliente_nota_credito
	@idventa_cliente_nota_credito int
	AS
		BEGIN
			 DELETE FROM venta_cliente_nota_credito WHERE venta_cliente_nota_credito.venta_cliente_nota_credito_id = @idventa_cliente_nota_credito
		END
	GO

	


	--// VENTAS_DETALLES(ventas_detalles)
	-- GETTERS
	CREATE Procedure GET_ventas_detalles AS
		BEGIN
			 SELECT TOP 200 * FROM ventas_detalles
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	
	CREATE Procedure GET_ID_ventas_detalles
	@iddetalle_venta int
	AS
		BEGIN
			 SELECT * FROM ventas_detalles WHERE detalle_venta_id = @iddetalle_venta
		END
	GO

	CREATE Procedure GET_SEARCH_ventas_detalles
	@search text
	AS
		BEGIN
			 SELECT * FROM ventas_detalles WHERE 
				detalle_venta_cantidad LIKE '%@search%'	OR
				detalle_venta_precio_unidad	LIKE '%@search%'	OR
				detalle_venta_precio_total LIKE '%@search%'
			 
		END
	GO

	-- POST

	CREATE Procedure POSTventas_detalles
	@iddetalle_venta  int output,
	@venta_id int, 
	@stock_id int,
	@detalle_venta_cantidad  int,
	@detalle_venta_precio_unidad decimal,
	@detalle_venta_precio_total decimal
	
	AS
		BEGIN
			 INSERT INTO ventas_detalles(venta_id, stock_id,detalle_venta_cantidad,detalle_venta_precio_unidad,detalle_venta_precio_total)
			 VALUES ( @venta_id ,@stock_id,@detalle_venta_cantidad,@detalle_venta_precio_unidad,@detalle_venta_precio_total)
			 END
			 	GO

	-- PUT

	CREATE Procedure PUTventas_detalles
	@iddetalle_venta  int,
	@venta_id int, 
	@stock_id int,
	@detalle_venta_cantidad  int,
	@detalle_venta_precio_unidad decimal,
	@detalle_venta_precio_total decimal
	
	AS
		BEGIN
			 UPDATE ventas_detalles SET venta_id = @venta_id, stock_id = @stock_id,	detalle_venta_cantidad=@detalle_venta_cantidad,detalle_venta_precio_unidad=@detalle_venta_precio_unidad,	detalle_venta_precio_total=@detalle_venta_precio_total
			 WHERE ventas_detalles.detalle_venta_id = @iddetalle_venta
		END
	GO

	
		-- DELETE

	CREATE Procedure DELETEventas_detalles
	@iddetalle_venta int
	AS
		BEGIN
			 DELETE FROM ventas_detalles WHERE ventas_detalles.detalle_venta_id = @iddetalle_venta
		END
	GO





	-- // STOCK (stock)
	-- GETTERS
	CREATE Procedure GET_stock AS
		BEGIN
			 SELECT TOP 200 * FROM stock
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	CREATE Procedure GET_ID_stock
	@idstock int
	AS
		BEGIN
			 SELECT * FROM stock WHERE stock_id = @idstock
		END
	GO

	CREATE Procedure GET_SEARCH_stock
	@search text
	AS
		BEGIN
			 SELECT * FROM stock WHERE stock_cantidad LIKE '%@search%'  
			  
			 
		END
	GO

	-- POST

	CREATE Procedure POSTstock
	@idstock int output,
	@articulo_id int, 
	@stock_cantidad int
	
	AS
		BEGIN
			 INSERT INTO stock (articulo_id, stock_cantidad)
			 VALUES (@articulo_id, @stock_cantidad)
		END
	GO

	-- PUT

	CREATE Procedure PUTstock
	@idstock int,
	@articulo_id int, 
	@stock_cantidad int
	AS
		BEGIN
			 UPDATE stock SET articulo_id = @articulo_id, stock_cantidad = @stock_cantidad
			 WHERE stock.stock_id = @idstock
		END
	GO

	-- DELETE

	CREATE Procedure DELETEstock
	@idstock int
	AS
		BEGIN
			 DELETE FROM stock WHERE stock.stock_id = @idstock
		END
	GO




	-- // ARTICULOS (articulos)
	-- GETTERS
	CREATE Procedure GET_articulos AS
		BEGIN
			 SELECT TOP 200 * FROM articulos
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	CREATE Procedure GET_ID_articulos
	@idarticulo int
	AS
		BEGIN
			 SELECT * FROM articulos WHERE articulo_id = @idarticulo
		END
	GO

	CREATE Procedure GET_SEARCH_articulos
	@search text
	AS
		BEGIN
			 SELECT * FROM articulos WHERE articulo_nombre LIKE '%@search%' OR 
			 articulo_codigo_barra LIKE '%@search%' OR 
			 articulo_descripcion LIKE '%@search%' OR 
			 articulo_precio LIKE '%@search%' 
			 
		END
	GO

	-- POST

	CREATE Procedure POSTarticulos
	@idarticulo int output,
	@categoria_id int, 
	@presentacion_id int, 
	@articulo_nombre text,
	@articulo_codigo_barra text,
	@articulo_descripcion text,
	@articulo_imagen text,
	@articulo_precio decimal
	
	AS
		BEGIN
			 INSERT INTO articulos (categoria_id,presentacion_id,articulo_nombre,articulo_codigo_barra,articulo_descripcion,articulo_imagen,articulo_precio)
			 VALUES (@categoria_id, @presentacion_id, @articulo_nombre, @articulo_codigo_barra, @articulo_descripcion, @articulo_imagen, @articulo_precio)
		END
	GO

	-- PUT

	CREATE Procedure PUTarticulos
	@idarticulo int,
	@categoria_id int, 
	@presentacion_id int, 
	@articulo_nombre text,
	@articulo_codigo_barra text,
	@articulo_descripcion text,
	@articulo_imagen text,
	@articulo_precio decimal
	AS
		BEGIN
			 UPDATE articulos SET categoria_id=@categoria_id, presentacion_id=@presentacion_id, articulo_nombre=@articulo_nombre,articulo_codigo_barra=@articulo_codigo_barra,articulo_descripcion=@articulo_descripcion,articulo_imagen=@articulo_imagen,articulo_precio= @articulo_precio
			 WHERE articulos.articulo_id = @idarticulo
		END
	GO

	-- DELETE

	CREATE Procedure DELETEarticulos
	@idarticulo int
	AS
		BEGIN
			 DELETE FROM articulos WHERE articulos.articulo_id = @idarticulo
		END
	GO

	


	-- // COMPRAS (compras)
	-- GETTERS
	CREATE Procedure GET_compras AS
		BEGIN
			 SELECT TOP 200 * FROM compras
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	CREATE Procedure GET_ID_compras 
	@idcompra int
	AS
		BEGIN
			 SELECT * FROM compras WHERE compra_id = @idcompra
		END
	GO

	CREATE Procedure GET_SEARCH_compras
	@search text
	AS
		BEGIN
			 SELECT * FROM compras WHERE compra_factura LIKE '%@search%' OR 
			 compra_anulado LIKE '%@search%' OR 
			 compra_fecha LIKE '%@search%' 
			 
		END
	GO

	-- POST

	CREATE Procedure POSTcompras
	@idcompra int output,
	@status_id int, 
	@proveedor_id int, 
	@usuario_id int,
	@compra_correlativo text,
	@compra_factura text,
	@compra_anulado tinyint,
	@compra_fecha Date,
	@compra_serie text,
	@compra_iva int,
	@compra_total_iva decimal,
	@compra_total_sin_iva decimal
	
	AS
		BEGIN
			 INSERT INTO compras (status_id, proveedor_id,usuario_id,compra_correlativo,compra_factura,compra_anulado,compra_fecha,compra_serie,compra_iva,compra_total_iva,compra_total_sin_iva)
			 VALUES (@status_id,@proveedor_id,@usuario_id,@compra_correlativo,@compra_factura,@compra_anulado,@compra_fecha,@compra_serie,@compra_iva,@compra_total_iva,@compra_total_sin_iva)
		END
	GO

	-- PUT

	CREATE Procedure PUTcompras
	@idcompra int,
	@status_id int, 
	@proveedor_id int, 
	@usuario_id int,
	@compra_correlativo text,
	@compra_factura text,
	@compra_anulado tinyint,
	@compra_fecha Date,
	@compra_serie text,
	@compra_iva int,
	@compra_total_iva decimal,
	@compra_total_sin_iva decimal
	AS
		BEGIN
			 UPDATE compras SET status_id = @status_id, proveedor_id = @proveedor_id, usuario_id = @usuario_id, compra_correlativo = @compra_correlativo, compra_factura = @compra_factura, compra_anulado = @compra_anulado, compra_fecha = @compra_fecha, compra_serie = @compra_serie, compra_iva = @compra_iva, compra_total_iva = @compra_total_iva, compra_total_sin_iva = @compra_total_sin_iva
			 WHERE compras.compra_id = @idcompra
		END
	GO

	-- DELETE

	CREATE Procedure DELETEcompras
	@idcompra int
	AS
		BEGIN
			 DELETE FROM compras WHERE compras.compra_id = @idcompra
		END
	GO




	-- // AUDITORIA (auditoria)
	-- GETTERS
	CREATE Procedure GET_auditoria AS
		BEGIN
			 SELECT TOP 200 * FROM auditoria
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	CREATE Procedure GET_ID_auditoria
	@idauditoria int
	AS
		BEGIN
			 SELECT * FROM auditoria WHERE auditoria_id = @idauditoria
		END
	GO

	CREATE Procedure GET_SEARCH_auditoria
	@search text
	AS
		BEGIN
			 SELECT * FROM auditoria WHERE auditoria_fecha LIKE '%@search%' OR 
			 auditoria_descripcion LIKE '%@search%' 
			 
		END
	GO

	-- POST

	CREATE Procedure POSTauditoria
	@idauditoria int output,
	@usuario_id int, 
	@auditoria_fecha date, 
	@auditoria_accion text,
	@auditoria_descripcion text
	
	AS
		BEGIN
			 INSERT INTO auditoria (usuario_id,auditoria_fecha,auditoria_accion,auditoria_descripcion)
			 VALUES (@usuario_id,@auditoria_fecha, @auditoria_accion,@auditoria_descripcion)
		END
	GO

	-- PUT

	CREATE Procedure PUTauditoria
	@idauditoria int,
	@usuario_id int, 
	@auditoria_fecha date, 
	@auditoria_accion text,
	@auditoria_descripcion text
	AS
		BEGIN
			 UPDATE auditoria SET usuario_id = @usuario_id, auditoria_fecha = @auditoria_fecha, auditoria_accion = @auditoria_accion, auditoria_descripcion = @auditoria_descripcion
			 WHERE auditoria.auditoria_id = @idauditoria
		END
	GO

	-- DELETE

	CREATE Procedure DELETEauditoria
	@idauditoria int
	AS
		BEGIN
			 DELETE FROM auditoria WHERE auditoria.auditoria_id = @idauditoria
		END
	GO



	-- // COMPRAS_DETALLES (compras_detalles)
	-- GETTERS
	CREATE Procedure GET_compras_detalles AS
		BEGIN
			 SELECT TOP 200 * FROM compras_detalles
			 -- ORDER BY ----- OPCIONAL
		END
	GO

	CREATE Procedure GET_ID_compras_detalles
	@idcompra_detalle int
	AS
		BEGIN
			 SELECT * FROM compras_detalles WHERE compra_detalle_id = @idcompra_detalle
		END
	GO

	CREATE Procedure GET_SEARCH_compras_detalles
	@search text
	AS
		BEGIN
			 SELECT * FROM compras_detalles WHERE compra_detalle_cantidad LIKE '%@search%' OR 
			 compra_detalle_precio_unidad LIKE '%@search%' OR 
			 compra_detalle_precio_total LIKE '%@search%' 
			 
		END
	GO

	-- POST

	CREATE Procedure POSTcompras_detalles
	@idcompra_detalle int output,
	@compra_id int, 
	@stock_id int, 
	@compra_detalle_cantidad int,
	@compra_detalle_precio_unidad decimal,
	@compra_detalle_precio_total decimal
	
	AS
		BEGIN
			 INSERT INTO compras_detalles (compra_id,stock_id,compra_detalle_cantidad,compra_detalle_precio_unidad,compra_detalle_precio_total)
			 VALUES (@compra_id,@stock_id,@compra_detalle_cantidad,@compra_detalle_precio_unidad,@compra_detalle_precio_total)
		END
	GO

	-- PUT

	CREATE Procedure PUTcompras_detalles
	@idcompra_detalle int,
	@compra_id int, 
	@stock_id int, 
	@compra_detalle_cantidad int,
	@compra_detalle_precio_unidad decimal,
	@compra_detalle_precio_total decimal
	AS
		BEGIN
			 UPDATE compras_detalles SET compra_id=@compra_id, 	stock_id=@stock_id,	compra_detalle_cantidad=@compra_detalle_cantidad,compra_detalle_precio_unidad=@compra_detalle_precio_unidad,compra_detalle_precio_total=@compra_detalle_precio_total
			 WHERE compras_detalles.compra_detalle_id = @idcompra_detalle
		END
	GO

	-- DELETE

	CREATE Procedure DELETEcompras_detalles
	@idcompra_detalle int
	AS
		BEGIN
			 DELETE FROM compras_detalles WHERE compras_detalles.compra_detalle_id = @idcompra_detalle
		END
	GO




	-- // USUARIO_TIPO (usuarios_tipo)
	-- GETTERS
	

	CREATE Procedure GET_ID_usuarios_tipo
	@idusuario_tipo int
	AS
		BEGIN
			 SELECT * FROM usuarios_tipo WHERE usuario_tipo_id = @idusuario_tipo
		END
	GO



	-- // PRESENTACION (presentacion)
	-- GETTERS
	

	CREATE Procedure GET_ID_presentacion
	@idpresentacion int
	AS
		BEGIN
			 SELECT * FROM presentacion WHERE presentacion_id = @idpresentacion
		END
	GO




	-- // CATEGORIAS (categorias)
	-- GETTERS
	

	CREATE Procedure GET_ID_categorias
	@idcategoria int
	AS
		BEGIN
			 SELECT * FROM categorias WHERE categoria_id = @idcategoria
		END
	GO



	-- // VENTAS_TIPO (ventas_tipo)
	-- GETTERS
	

	CREATE Procedure GET_ID_ventas_tipo
	@idventas_tipo int
	AS
		BEGIN
			 SELECT * FROM ventas_tipo WHERE ventas_tipo_id = @idventas_tipo
		END
	GO



	-- // STATUS (status)
	-- GETTERS
	

	CREATE Procedure GET_ID_status
	@idstatus int
	AS
		BEGIN
			 SELECT * FROM status WHERE status_id = @idstatus
		END
	GO




	-- // CONFIGURACION (configuracion)
	-- GETTERS
	

	CREATE Procedure GET_ID_configuracion
	@idconfiguracion int
	AS
		BEGIN
			 SELECT * FROM configuracion WHERE configuracion_id = @idconfiguracion
		END
	GO




	-- // TIPO_DOCUMENTO (tipo_documento)
	-- GETTERS
	

	CREATE Procedure GET_ID_tipo_documento
	@idtipo_documento int
	AS
		BEGIN
			 SELECT * FROM tipo_documento WHERE tipo_documento_id = @idtipo_documento
		END
	GO

