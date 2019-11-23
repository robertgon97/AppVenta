using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;


namespace CapaNegocio
{
 public  class N_ventas
    {
        public static DataTable obtenerTodasLasVentas(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todas Las Ventas", "El Usuario solicito todas las Ventas", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable TodasLasVentas = new DB_ventas().GetAll();
            return TodasLasVentas;
        }

        public static DataTable obtenerUnaVenta(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion una venta", "El Usuario solicito todos los datos de una venta", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_ventas Venta = new DB_ventas(id, 0, 0, 0, 0, "0", "0", 0, "0", "0", 0, 0, 0,"0");
            DataTable VentaEnTabla = Venta.GetIDVenta(Venta);
            return VentaEnTabla;
        }

        public static DataTable buscarVentas(int miUsuarioID, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito buscar informacion de una venta", "El Usuario solicito la busqueda de todos los datos de las ventas en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_ventas Venta = new DB_ventas(0,0, 0, 0, 0, "0", "0", 0, "0", "0", 0, 0, 0, search);
            DataTable VentaEnTabla = Venta.GetSearch(Venta);
            return VentaEnTabla;
        }

        public static string agregarVenta(int miUsuarioID, int id, int tipoventa, int status, int cliente, int usuario, string correlativo, string factura, int anulado, string fecha, string serie, int iva, decimal totalIva, decimal total, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro una nueva venta", "El Usuario solicito el registro de otra venta", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_ventas nuevaVenta = new DB_ventas(id, tipoventa, status, cliente, usuario, correlativo, factura, anulado, fecha, serie, iva,totalIva, total, buscar);
            return nuevaVenta.Create(nuevaVenta);
        }

        public static string modificarVenta(int miUsuarioID, int id, int tipoventa, int status, int cliente, int usuario, string correlativo, string factura, int anulado, string fecha, string serie, int iva, decimal totalIva, decimal total, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Modifico informacion de una Venta", "El Usuario solicito modificar los datos de una Venta", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_ventas actualVenta = new DB_ventas(id, tipoventa, status, cliente, usuario, correlativo, factura, anulado, fecha, serie, iva, totalIva, total, buscar);
            return actualVenta.Edit(actualVenta);
        }

        public static string eliminarVenta(int miUsuarioID, int id)

        { // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Elimino informacion de una Venta", "El Usuario solicito eliminar los datos de una Venta", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_ventas eliminarVenta = new DB_ventas(id, 0, 0, 0, 0, "0", "0", 0, "0", "0", 0, 0, 0, "0");
            return eliminarVenta.Delete(eliminarVenta);
        }

        //VENTAS_DETALLES EN VENTAS
        public static DataTable obtenerVenta_Detalle(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion del Detalle de la Venta  ", "El Usuario solicito todos los datos del Detalle de la Venta ", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_ventas_detalles DetalleVenta = new DB_ventas_detalles (id, 0, 0, 0, 0, 0, "0");
            DataTable DetalleVentaEnTabla = DetalleVenta.GetDetalleID(DetalleVenta);
            return DetalleVentaEnTabla;
        }
        
        public static DataTable obtenerTodasLasVentasDetalles(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todos Los Detalles de Ventas", "El Usuario solicito todos los Detalles de las Ventas", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable TodasLasVentasDetalles = new DB_ventas_detalles().GetAll();
            return TodasLasVentasDetalles;
        }
        
        public static string agregarVentasDetalles(int miUsuarioID, int _detalle_venta_id, int _venta_id, int _stock_id, int _detalle_venta_cantidad, decimal _detalle_venta_precio_unidad, decimal _detalle_venta_precio_total, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro un nuevo Detalle de Venta", "El Usuario solicito el registro del Detalle de Venta", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_ventas_detalles nuevoDetalleVenta = new DB_ventas_detalles(_detalle_venta_id, _venta_id, _stock_id, _detalle_venta_cantidad, _detalle_venta_precio_unidad, _detalle_venta_precio_total, buscar);
            return nuevoDetalleVenta.Create(nuevoDetalleVenta);
        }

        // Notas de credito

        public static DataTable obtenerTodasLasNotasCredito(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todas Las Notas de Credito", "El Usuario solicito todas las notas de credito de la aplicacion", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable NotasCreditos = new DB_venta_nota_credito().GetAll();
            return NotasCreditos;
        }

        public static DataTable obtenerUnaNotaCredito(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion de una nota de credito", "El Usuario solicito los datos de una nota de credito", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_venta_nota_credito NotaCredito = new DB_venta_nota_credito(id, 0, "0", 0, 0, "0");
            DataTable TablaNotas = NotaCredito.GetNOTAID(NotaCredito);
            return TablaNotas;
        }

        public static DataTable buscarNotasCreditos(int miUsuarioID, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito buscar informacion de una nota de credito", "El Usuario solicito la busqueda de todos los datos de las notas de credito en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_venta_nota_credito NotaSearch = new DB_venta_nota_credito(0, 0, "0", 0, 0, search);
            DataTable TablaNotas = NotaSearch.GetSearch(NotaSearch);
            return TablaNotas;
        }

        public static string agregarNotaCredito(int miUsuarioID, int id, int ventaid, string fechanotacredito, decimal gastado, int valido, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro una nueva nota de credito", "El Usuario solicito el registro de otra nota de credito", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_venta_nota_credito nuevaNotaCredito = new DB_venta_nota_credito(id, ventaid, fechanotacredito, gastado, valido, buscar);
            return nuevaNotaCredito.Create(nuevaNotaCredito);
        }

        public static string modificarNotaCredito(int miUsuarioID, int id, int ventaid, string fechanotacredito, decimal gastado, int valido, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Modifico informacion de una nota de credito", "El Usuario solicito modificar los datos de una nota de credito", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_venta_nota_credito NotaCreditoEdit = new DB_venta_nota_credito(id, ventaid, fechanotacredito, gastado, valido, buscar);
            return NotaCreditoEdit.Edit(NotaCreditoEdit);
        }

        public static string eliminarNotaCredito(int miUsuarioID, int id)

        { // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Elimino informacion de una nota de credito", "El Usuario solicito eliminar los datos de una nota de credito", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_venta_nota_credito eliminarNota = new DB_venta_nota_credito(id, 0, "0", 0, 0, "0");
            return eliminarNota.Delete(eliminarNota);
        }

        // Tipo de Ventas

        public static DataTable obtenerTiposVentas(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todos los tipos de ventas", "El Usuario solicito todas las notas de credito de la aplicacion", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable ventasTipos = new DB_ventas_tipoventa().GetAll();
            return ventasTipos;
        }

    }
}
