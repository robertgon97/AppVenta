using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;



namespace CapaNegocio
{
   public class N_clientes
    {

        public static DataTable obtenerTodosLosClientes(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todos Los Clientes", "El Usuario solicito todos los Clientes", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable TodosLosClientes = new DB_cliente().GetAll();
            return TodosLosClientes;
        }

        public static DataTable obtenerUnCliente(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion un cliente", "El Usuario solicito todos los datos de un cliente", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_cliente Cliente = new DB_cliente(id, 0, "0", "0", "0", "0", "0", "0", "0","0");
            DataTable ClienteEnTabla = Cliente.GetIdCliente(Cliente);
            return ClienteEnTabla;
        }

        public static DataTable buscarClientes(int miUsuarioID, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito buscar informacion de un cliente", "El Usuario solicito la busqueda de todos los datos de los clientes en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_cliente Cliente = new DB_cliente(0, 0, "0", "0", "0", "0", "0", "0","0", search);
            DataTable ClienteEnTabla = Cliente.GetSearch(Cliente);
            return ClienteEnTabla;
        }

        public static string agregarCliente(int miUsuarioID, int id, int tipodni, string nombres, string apellidos, string dni, string direccion, string nacimiento, string correo, string telefono,  string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro un nuevo cliente", "El Usuario solicito el registro de otro cliente", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_cliente nuevoCliente = new DB_cliente(id, tipodni, nombres, apellidos, dni, direccion, nacimiento, correo, telefono, buscar);
            return nuevoCliente.Create(nuevoCliente);
        }

        public static string modificarCliente(int miUsuarioID, int id, int tipodni, string nombres, string apellidos, string dni, string direccion, string nacimiento, string correo, string telefono, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Modifico informacion de un Cliente", "El Usuario solicito modificar los datos de un cliente", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_cliente actualCliente = new DB_cliente(id, tipodni, nombres, apellidos, dni, direccion, nacimiento, correo, telefono, buscar);
            return actualCliente.Edit(actualCliente);
        }

        public static string eliminarCliente(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Elimino informacion de un cliente", "El Usuario solicito eliminar los datos de un cliente", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_cliente eliminarCliente = new DB_cliente(id, 0, "0", "0", "0", "0", "0", "0", "0", "0");
            return eliminarCliente.Delete(eliminarCliente);
        }
    }
}

