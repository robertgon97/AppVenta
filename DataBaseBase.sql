
CREATE TABLE categorias (
                categoria_id INT IDENTITY NOT NULL,
                categoria_nombre TEXT NOT NULL,
                categoria_descripcion TEXT,
                CONSTRAINT categorias_primary_key PRIMARY KEY (categoria_id)
)

CREATE TABLE presentacion (
                presentacion_id INT NOT NULL,
                presentacion_nombre TEXT NOT NULL,
                presentacion_descripcion TEXT NOT NULL,
                CONSTRAINT presentacion_primary_key PRIMARY KEY (presentacion_id)
)

CREATE TABLE articulos (
                articulo_id INT IDENTITY NOT NULL,
                categoria_id INT NOT NULL,
                presentacion_id INT NOT NULL,
                articulo_nombre TEXT NOT NULL,
                articulo_codigo_barra TEXT,
                articulo_descripcion TEXT,
                articulo_imagen TEXT,
                articulo_precio DECIMAL(20,3) NOT NULL,
                CONSTRAINT articulos_primary_key PRIMARY KEY (articulo_id)
)

CREATE TABLE stock (
                stock_id INT IDENTITY NOT NULL,
                articulo_id INT NOT NULL,
                stock_cantidad INT NOT NULL,
                CONSTRAINT stock_primary_key PRIMARY KEY (stock_id)
)

CREATE TABLE status (
                status_id INT IDENTITY NOT NULL,
                status_nombre TEXT NOT NULL,
                status_descripcion TEXT,
                CONSTRAINT status_primary_key PRIMARY KEY (status_id)
)

CREATE TABLE ventas_tipo (
                ventas_tipo_id INT IDENTITY NOT NULL,
                ventas_tipo_nombre VARCHAR(150) NOT NULL,
                ventas_tipo_descripcion TEXT,
                CONSTRAINT ventas_tipo_primary_key PRIMARY KEY (ventas_tipo_id)
)

CREATE TABLE configuracion (
                configuracion_id INT IDENTITY NOT NULL,
                configuracion_nombre_empresa IMAGE NOT NULL,
                configuracion_nombre_app TEXT NOT NULL,
                configuracion_iva INT NOT NULL,
                configuracion_inventario_minimo INT DEFAULT 0 NOT NULL,
                configuracion_inventario_maximo INT NOT NULL,
                CONSTRAINT configuracion_primary_key PRIMARY KEY (configuracion_id)
)

CREATE TABLE tipo_documento (
                tipo_documento_id INT IDENTITY NOT NULL,
                tipo_documento_letra VARCHAR(3) NOT NULL,
                tipo_documento_nombre TEXT NOT NULL,
                CONSTRAINT tipo_documento_primary_key PRIMARY KEY (tipo_documento_id)
)
CREATE UNIQUE  NONCLUSTERED INDEX tipo_documento_idxunique
 ON tipo_documento
 ( tipo_documento_letra )


CREATE TABLE proveedores (
                proveedor_id INT IDENTITY NOT NULL,
                tipo_documento_id INT NOT NULL,
                proveedor_razon_social TEXT NOT NULL,
                proveedor_dni VARCHAR(200) NOT NULL,
                proveedor_direccion TEXT,
                proveedor_email TEXT,
                proveedor_telefono INT,
                proveedor_url TEXT,
                CONSTRAINT proveedores_primary_key PRIMARY KEY (proveedor_id)
)
CREATE UNIQUE  NONCLUSTERED INDEX proveedores_idxunique
 ON proveedores
 ( tipo_documento_id, proveedor_dni )


CREATE TABLE clientes (
                cliente_id INT IDENTITY NOT NULL,
                tipo_documento_id INT NOT NULL,
                cliente_nombres TEXT NOT NULL,
                cliente_apellidos TEXT NOT NULL,
                cliente_dni INT NOT NULL,
                cliente_direccion TEXT,
                cliente_nacimiento DATETIME,
                cliente_email TEXT,
                cliente_telefono INT,
                CONSTRAINT clientes_primary_key PRIMARY KEY (cliente_id)
)
CREATE UNIQUE  NONCLUSTERED INDEX clientes_idxunique
 ON clientes
 ( tipo_documento_id, cliente_dni )


CREATE TABLE usuarios_tipo (
                usuario_tipo_id INT IDENTITY NOT NULL,
                tipo_usuario_nombre VARCHAR(100) NOT NULL,
                tipo_usuario_descripcion TEXT,
                CONSTRAINT usuarios_tipo_primary_key PRIMARY KEY (usuario_tipo_id)
)
CREATE UNIQUE  NONCLUSTERED INDEX usuarios_tipo_unique
 ON usuarios_tipo
 ( tipo_usuario_nombre )


CREATE TABLE usuarios (
                usuario_id INT IDENTITY NOT NULL,
                usuario_tipo_id INT NOT NULL,
                tipo_documento_id INT NOT NULL,
                usuario_username VARCHAR(200) NOT NULL,
                usuario_password TEXT NOT NULL,
                usuario_nombres TEXT NOT NULL,
                usuario_apellidos TEXT NOT NULL,
                usuario_sexo VARCHAR(150) NOT NULL,
                usuario_fecha_nacimiento DATETIME,
                usuario_dni INT NOT NULL,
                usuario_direccion TEXT,
                usuario_email TEXT,
                usuario_telefono INT,
                CONSTRAINT usuarios_primary_key PRIMARY KEY (usuario_id)
)
CREATE UNIQUE  NONCLUSTERED INDEX usuarios_idx_unique
 ON usuarios
 ( tipo_documento_id, usuario_username, usuario_dni )


CREATE TABLE auditoria (
                auditoria_id INT IDENTITY NOT NULL,
                usuario_id INT NOT NULL,
                auditoria_fecha DATETIME NOT NULL,
                auditoria_accion TEXT NOT NULL,
                auditoria_descripcion TEXT NOT NULL,
                CONSTRAINT auditoria_primary_key PRIMARY KEY (auditoria_id)
)

CREATE TABLE compras (
                compra_id INT IDENTITY NOT NULL,
                status_id INT NOT NULL,
                proveedor_id INT NOT NULL,
                usuario_id INT NOT NULL,
                compra_correlativo VARCHAR(100) NOT NULL,
                compra_factura TEXT,
                compra_anulado TINYINT DEFAULT 0,
                compra_fecha DATETIME NOT NULL,
                compra_serie TEXT,
                compra_iva INT NOT NULL,
                compra_total_iva DECIMAL(20,3) NOT NULL,
                compra_total_sin_iva DECIMAL(20,3) NOT NULL,
                CONSTRAINT compras_primary_key PRIMARY KEY (compra_id)
)

CREATE TABLE compras_detalles (
                compra_detalle_id INT IDENTITY NOT NULL,
                compra_id INT NOT NULL,
                stock_id INT NOT NULL,
                compra_detalle_cantidad INT NOT NULL,
                compra_detalle_precio_unidad DECIMAL(20,3) NOT NULL,
                compra_detalle_precio_total DECIMAL(20,3) NOT NULL,
                CONSTRAINT compras_detalles_primary_key PRIMARY KEY (compra_detalle_id)
)
CREATE UNIQUE  NONCLUSTERED INDEX compras_detalles_idxunique
 ON compras_detalles
 ( compra_id, stock_id )


CREATE TABLE ventas (
                venta_id INT IDENTITY NOT NULL,
                ventas_tipo_id INT NOT NULL,
                status_id INT NOT NULL,
                cliente_id INT NOT NULL,
                usuario_id INT NOT NULL,
                venta_correlativo VARCHAR(100) NOT NULL,
                venta_factura TEXT,
                venta_anulado TINYINT DEFAULT 0,
                venta_fecha DATETIME NOT NULL,
                venta_serie TEXT,
                venta_iva INT NOT NULL,
                venta_total_iva DECIMAL(20,3) NOT NULL,
                venta_total_sin_iva DECIMAL(20,3) NOT NULL,
                CONSTRAINT ventas_primary_key PRIMARY KEY (venta_id)
)

CREATE TABLE ventas_detalles (
                detalle_venta_id INT IDENTITY NOT NULL,
                venta_id INT NOT NULL,
                stock_id INT NOT NULL,
                detalle_venta_cantidad INT NOT NULL,
                detalle_venta_precio_unidad DECIMAL(20,3) NOT NULL,
                detalle_venta_precio_total DECIMAL(20,3) NOT NULL,
                CONSTRAINT ventas_detalles_primary_key PRIMARY KEY (detalle_venta_id)
)
CREATE UNIQUE  NONCLUSTERED INDEX ventas_detalles_idxunique
 ON ventas_detalles
 ( venta_id, stock_id )


CREATE TABLE venta_cliente_nota_credito (
                venta_cliente_nota_credito_id INT IDENTITY NOT NULL,
                venta_id INT NOT NULL,
                venta_cliente_nota_credito_fecha DATETIME NOT NULL,
                venta_cliente_nota_credito_gastado DECIMAL(20,3) NOT NULL,
                venta_cliente_nota_credito_valido TINYINT DEFAULT 1,
                CONSTRAINT venta_cliente_nota_credito_primary_key PRIMARY KEY (venta_cliente_nota_credito_id)
)

CREATE TABLE usuarios_pregunta_seguridad (
                usuarios_pregunta_seguridad_id INT IDENTITY NOT NULL,
                usuario_id INT NOT NULL,
                usuarios_pregunta_seguridad_pregunta TEXT NOT NULL,
                usuarios_pregunta_seguridad_respuesta TEXT NOT NULL,
                CONSTRAINT usuarios_pregunta_seguridad_primary_key PRIMARY KEY (usuarios_pregunta_seguridad_id)
)

ALTER TABLE articulos ADD CONSTRAINT categorias_articulos_fk
FOREIGN KEY (categoria_id)
REFERENCES categorias (categoria_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE articulos ADD CONSTRAINT presentacion_articulos_fk
FOREIGN KEY (presentacion_id)
REFERENCES presentacion (presentacion_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE stock ADD CONSTRAINT articulos_stock_fk
FOREIGN KEY (articulo_id)
REFERENCES articulos (articulo_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE ventas_detalles ADD CONSTRAINT stock_ventas_detalles_fk
FOREIGN KEY (stock_id)
REFERENCES stock (stock_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE compras_detalles ADD CONSTRAINT stock_compras_detalles_fk
FOREIGN KEY (stock_id)
REFERENCES stock (stock_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE ventas ADD CONSTRAINT status_ventas_fk
FOREIGN KEY (status_id)
REFERENCES status (status_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE compras ADD CONSTRAINT status_compras_fk
FOREIGN KEY (status_id)
REFERENCES status (status_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE ventas ADD CONSTRAINT ventas_tipo_ventas_fk
FOREIGN KEY (ventas_tipo_id)
REFERENCES ventas_tipo (ventas_tipo_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE usuarios ADD CONSTRAINT tipo_documento_usuarios_fk
FOREIGN KEY (tipo_documento_id)
REFERENCES tipo_documento (tipo_documento_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE clientes ADD CONSTRAINT tipo_documento_clientes_fk
FOREIGN KEY (tipo_documento_id)
REFERENCES tipo_documento (tipo_documento_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE proveedores ADD CONSTRAINT tipo_documento_proveedores_fk
FOREIGN KEY (tipo_documento_id)
REFERENCES tipo_documento (tipo_documento_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE compras ADD CONSTRAINT proveedores_compras_fk
FOREIGN KEY (proveedor_id)
REFERENCES proveedores (proveedor_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE ventas ADD CONSTRAINT clientes_ventas_fk
FOREIGN KEY (cliente_id)
REFERENCES clientes (cliente_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE usuarios ADD CONSTRAINT usuarios_tipo_usuarios_fk
FOREIGN KEY (usuario_tipo_id)
REFERENCES usuarios_tipo (usuario_tipo_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE usuarios_pregunta_seguridad ADD CONSTRAINT usuarios_usuarios_pregunta_seguridad_fk
FOREIGN KEY (usuario_id)
REFERENCES usuarios (usuario_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE ventas ADD CONSTRAINT usuarios_ventas_fk
FOREIGN KEY (usuario_id)
REFERENCES usuarios (usuario_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE compras ADD CONSTRAINT usuarios_compras_fk
FOREIGN KEY (usuario_id)
REFERENCES usuarios (usuario_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE auditoria ADD CONSTRAINT usuarios_auditoria_fk
FOREIGN KEY (usuario_id)
REFERENCES usuarios (usuario_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE compras_detalles ADD CONSTRAINT compras_compras_detalles_fk
FOREIGN KEY (compra_id)
REFERENCES compras (compra_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE venta_cliente_nota_credito ADD CONSTRAINT ventas_venta_cliente_nota_credito_fk
FOREIGN KEY (venta_id)
REFERENCES ventas (venta_id)
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE ventas_detalles ADD CONSTRAINT ventas_ventas_detalles_fk
FOREIGN KEY (venta_id)
REFERENCES ventas (venta_id)
ON DELETE CASCADE
ON UPDATE CASCADE
