using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_usuarios
    {        
        public static DataTable obtenerTodosLosUsuarios(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todos Los Usuarios", "El Usuario solicito todos los usuarios", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable TodosLosUsuarios = new DB_users().GetAll();
            return TodosLosUsuarios;
        }

        public static DataTable obtenerUnUsuario(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion un Usuario", "El Usuario solicito todos los datos de un usuario", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_users Usuario = new DB_users(id, 0, 0, "0", "0", "0", "0", "0", "0", 0, "0", "0", "0", "0");
            DataTable UsuarioEnTabla = Usuario.GetIdUser(Usuario);
            return UsuarioEnTabla;
        }

        public static DataTable buscarUsuarios(int miUsuarioID, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito buscar informacion de un usuario", "El Usuario solicito la busqueda de todos los datos de los usuarios en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_users Usuarios = new DB_users(0, 0, 0, "0", "0", "0", "0", "0", "0", 0, "0", "0", "0", search);
            DataTable UsuarioEnTabla = Usuarios.GetSearch(Usuarios);
            return UsuarioEnTabla;
        }

        public static string agregarUsuario(int miUsuarioID, int id, int tipoid, int documentoid, string username, string password, string nombres, string apellidos, string sexo, string nacimiento, int cedula, string direccion, string correo, string telefono, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro un nuevo usuario", "El Usuario solicito el registro de otro usuario", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_users nuevoUsuario = new DB_users(id, tipoid, documentoid, username, password, nombres, apellidos, sexo, nacimiento, cedula, direccion, correo, telefono, buscar);
            return nuevoUsuario.Create(nuevoUsuario);
        }

        public static string modificarUsuario(int miUsuarioID, int id, int tipoid, int documentoid, string username, string password, string nombres, string apellidos, string sexo, string nacimiento, int cedula, string direccion, string correo, string telefono, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Modifico informacion un Usuario", "El Usuario solicito modificar los datos de un usuario", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_users actualUsuario = new DB_users(id, tipoid, documentoid, username, password, nombres, apellidos, sexo, nacimiento, cedula, direccion, correo, telefono, buscar);
            return actualUsuario.Edit(actualUsuario);
        }

        public static string eliminarUsuario(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Elimino informacion un Usuario", "El Usuario solicito eliminar los datos de un usuario", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_users eliminarUsuario = new DB_users(id, 0, 0, "0", "0", "0", "0", "0", "0", 0, "0", "0", "0", "0");
            return eliminarUsuario.Delete(eliminarUsuario);
        }
    }
}
