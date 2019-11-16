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
        public static string agregarUsuario(int id, int tipoid, int documentoid, string username, string password, string nombres, string apellidos, string sexo, string nacimiento, int cedula, string direccion, string correo, string telefono, string buscar)
        {
            DB_users nuevoUsuario = new DB_users(id, tipoid, documentoid, username, password, nombres, apellidos, sexo, nacimiento, cedula, direccion, correo, telefono, buscar);
            return nuevoUsuario.Create(nuevoUsuario);
        }
    }
}
