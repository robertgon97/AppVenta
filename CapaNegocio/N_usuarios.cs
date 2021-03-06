﻿using System;
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

        public static DataTable obtenerTiposDeUsuario(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito informacion acerca de los niveles de usuario", "El Usuario solicito la busqueda de todos los datos de los niveles de usuarios en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable TypeUsers = new DB_users_tipo().GetAll();
            return TypeUsers;
        }

        public static DataTable obtenerUnTipoDeUsuario(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito informacion acerca del nivel de usuario", "El Usuario solicito la busqueda de todos los datos del nivel de usuario en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_users_tipo tipo = new DB_users_tipo(id, "0", "0", "0");
            DataTable TipoEnTabla = tipo.GetDetalleID(tipo);
            return TipoEnTabla;
        }

        public static DataTable obtenerPreguntaSeguridadUsuarioID(int miUsuarioID, int usuarioObjetivo)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito informacion acerca de las preguntas de seguridad del usuario", "El Usuario solicito la busqueda de los datos de seguridad del usuario en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_preguntas preguntas = new DB_preguntas(0, usuarioObjetivo, "0", "0", "0");
            DataTable listaDePreguntas = preguntas.GetAllPreguntaByUser(preguntas);
            return listaDePreguntas;
        }

        public static DataTable ObtenerPreguntaID(int miUsuarioID, int usuarioObjetivo)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito informacion una pregunta de seguridad del usuario", "El Usuario solicito la busqueda de los datos de seguridad de un usuario en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_preguntas preguntas = new DB_preguntas(0, usuarioObjetivo, "0", "0", "0");
            DataTable preguntaEspecifica = preguntas.GetIdPregunta(preguntas);
            return preguntaEspecifica;
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

        public static string agregarTipoUsuario(int miUsuarioID, int _usuario_tipo_id, string _tipo_usuario_nombre, string _tipo_usuario_descripcion, string _search_value)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro un nuevo tipo de usuario", "El Usuario solicito el registro de un nuevo tipo de usuario", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_users_tipo nuevoTipo = new DB_users_tipo(_usuario_tipo_id, _tipo_usuario_nombre, _tipo_usuario_descripcion, _search_value);
            return nuevoTipo.Create(nuevoTipo);
        }

        public static string agregarPregunta(int miUsuarioID, int id, int iduser, string pregunta, string contrasena, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro de una nueva pregunta de usuario", "El Usuario solicito el registro de una pregunta de seguridad de usuario", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_preguntas nuevaPregunta = new DB_preguntas(id, iduser, pregunta, contrasena, search);
            return nuevaPregunta.Create(nuevaPregunta);
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

        public static string modificarPregunta(int miUsuarioID, int id, int iduser, string pregunta, string contrasena, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Modifico preguntas de seguridad de un Usuario", "El Usuario solicito modificar los datos de preguntas de seguridad de un usuario", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_preguntas preguntaUser = new DB_preguntas(id, iduser, pregunta, contrasena, search);
            return preguntaUser.Edit(preguntaUser);
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

        public static string eliminarPregunta(int miUsuarioID, int iduser)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Elimino preguntas de un Usuario", "El Usuario solicito eliminar los datos de pregunta de un usuario", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_preguntas eliminarPreguntas = new DB_preguntas(0, iduser, "0", "0", "0");
            return eliminarPreguntas.Delete(eliminarPreguntas);
        }

    }
}
