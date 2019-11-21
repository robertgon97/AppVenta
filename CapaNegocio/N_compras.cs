using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;


namespace CapaNegocio
{
  public  class N_compras
    {

        public static DataTable obtenerTodasLasCompras(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todas las Compras", "El Usuario solicito Todas las Compras", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable TodasLasCompras = new DB_compras().GetAll();
            return TodasLasCompras;
        }

        public static DataTable obtenerUnaCompra(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion de una compra", "El Usuario solicito todos los datos de una compra", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_compras Compra = new DB_compras(id, 0, 0, 0, "0", "0", 0, "0", "0", 0, 0, 0,"0");
            DataTable CompraEnTabla = Compra.GetIDVenta(Compra);
            return CompraEnTabla;
        }

        public static DataTable buscarCompras(int miUsuarioID, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito buscar informacion de una Compra", "El Usuario solicito la busqueda de todos los datos de las compras en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_compras Compra = new DB_compras(0, 0, 0,,0, "0", "0", 0, "0", "0", 0, 0, 0, "0", search);
            DataTable CompraEnTabla = Compra.GetSearch(Compra);
            return CompraEnTabla;
        }

        public static string agregarCompra(int miUsuarioID, int id, int _compra_id, int _status_id, int _proveedor_id, int _usuario_id, string _compra_correlativo, string _compra_factura, int _compra_anulado, string _compra_fecha, string _compra_serie, int _compra_iva, decimal _compra_total_iva, decimal _compra_total_sin_iva, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro una nueva compra", "El Usuario solicito el registro de otra compra", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_compras nuevaCompra = new DB_compras(_compra_id, _status_id, _proveedor_id,_usuario_id,_compra_correlativo, _compra_factura,_compra_anulado, _compra_fecha, _compra_serie, _compra_iva,  _compra_total_iva, _compra_total_sin_iva, buscar);
            return nuevaCompra.Create(nuevaCompra);
        }

        public static string modificarCompra(int miUsuarioID, int id, int _compra_id, int _status_id, int _proveedor_id, int _usuario_id, string _compra_correlativo, string _compra_factura, int _compra_anulado, string _compra_fecha, string _compra_serie, int _compra_iva, decimal _compra_total_iva, decimal _compra_total_sin_iva, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Modifico informacion de una Compra", "El Usuario solicito modificar los datos de una Compra", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_compras actualCompra = new DB_compras(_compra_id, _status_id, _proveedor_id, _usuario_id, _compra_correlativo, _compra_factura, _compra_anulado, _compra_fecha, _compra_serie, _compra_iva, _compra_total_iva, _compra_total_sin_iva, buscar);
            return actualCompra.Edit(actualCompra);
        }

        public static string eliminarCompra(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Elimino informacion de una Compra", "El Usuario solicito eliminar los datos de una Compra", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_compras eliminarCompra = new DB_compras(id, 0, 0, 0, "0", "0", 0, "0", "0", 0, 0, 0, "0");
            return eliminarCompra.Delete(eliminarCompra);
        }

    }
}
