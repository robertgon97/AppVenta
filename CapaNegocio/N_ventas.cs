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
           
    }
}
