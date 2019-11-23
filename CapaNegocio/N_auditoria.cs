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
        public static DataTable obtenerTodaLaAuditoria(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Toda la auditoria", "El Usuario solicito todos los datos de la auditoria", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable AllAuditoria = new DB_auditoria().GetAll();
            return AllAuditoria;
        }

        public static DataTable obtenerPorUsuarioID(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion de una auditoria", "El Usuario solicito todos los datos acerca de una auditoria de un usuario en especifico", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_auditoria Auditoria = new DB_auditoria(0, id, "0", "0", "0", "0");
            DataTable TablaAuditoria = Auditoria.GetIdUser(Auditoria);
            return TablaAuditoria;
        }

        public static DataTable buscarAuditoria(int miUsuarioID, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito buscar informacion de una auditoria", "El Usuario solicito la busqueda de todos los datos de las auditorias en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_auditoria Auditorias = new DB_auditoria(0, 0, "0", "0", "0", search);
            DataTable TablaAuditoria = Auditorias.GetSearch(Auditorias);
            return TablaAuditoria;
        }
    }
}
