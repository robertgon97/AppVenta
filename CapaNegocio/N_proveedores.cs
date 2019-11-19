using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
  public  class N_proveedores
    {

        public static DataTable obtenerTodosLosProveedores(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todos Los Proveedores", "El Usuario solicito todos los Proveedores", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable TodosLosProveedores = new DB_proveedores().GetAll();
            return TodosLosProveedores;
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

        public static string agregarProveedor(int miUsuarioID, int _proveedor_id, int _tipo_documento_id, string _proveedor_razon_social, string _proveedor_dni, string _proveedor_direccion, string _proveedor_email, int _proveedor_telefono, string _proveedor_url, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro un nuevo proveedor", "El Usuario solicito el registro de otro proveedor", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_proveedores nuevoProveedor = new DB_proveedores(_proveedor_id, _tipo_documento_id,  _proveedor_razon_social,  _proveedor_dni, _proveedor_direccion,  _proveedor_email, _proveedor_telefono,  _proveedor_url, buscar);
            return nuevoProveedor.Create(nuevoProveedor);
        }

        public static string modificarProveedor(int miUsuarioID, int _proveedor_id, int _tipo_documento_id, string _proveedor_razon_social, string _proveedor_dni, string _proveedor_direccion, string _proveedor_email, int _proveedor_telefono, string _proveedor_url, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Modifico informacion de un Proveedor", "El Usuario solicito modificar los datos de un proveedor", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_proveedores actualProveedor = new DB_proveedores(_proveedor_id, _tipo_documento_id, _proveedor_razon_social, _proveedor_dni, _proveedor_direccion, _proveedor_email, _proveedor_telefono, _proveedor_url, buscar);
            return actualProveedor.Edit(actualProveedor);
        }

        public static string eliminarProveedor(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Elimino informacion de un proveedor", "El Usuario solicito eliminar los datos de un proveedor", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_proveedores eliminarProveedor = new DB_proveedores(id, 0, "0", "0", "0", "0", 0, "0", "0");
            return eliminarProveedor.Delete(eliminarProveedor);
        }
    }
}
