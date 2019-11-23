using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_auditoria
    {
        public static DataTable obtenerTodosLosProveedores(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Toda la auditoria", "El Usuario solicito todos los datos de la auditoria", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable AllAuditoria = new DB_auditoria().GetAll();
            return AllAuditoria;
        }

        public static DataTable obtenerUnProveedor(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion un proveedor", "El Usuario solicito todos los datos de un proveedor", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_proveedores Proveedor = new DB_proveedores(id, 0, "0", "0", "0", "0", 0, "0", "0");
            DataTable ProveedorEnTabla = Proveedor.GetIDProveedor(Proveedor);
            return ProveedorEnTabla;
        }

        public static DataTable buscarProveedores(int miUsuarioID, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito buscar informacion de un proveedor", "El Usuario solicito la busqueda de todos los datos de los proveedores en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_proveedores Proveedor = new DB_proveedores(0, 0, "0", "0", "0", "0", 0, "0", search);
            DataTable ProveedorEnTabla = Proveedor.GetSearch(Proveedor);
            return ProveedorEnTabla;
        }
    }
}
