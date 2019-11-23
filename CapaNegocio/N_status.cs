using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_status
    {
        public static DataTable obtenerTodosLosStatus(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todas Los Status de Ventas", "El Usuario solicito todos los status de las Ventas", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable StatusVentas = new DB_status_global().GetAll();
            return StatusVentas;
        }

        public static DataTable ObtenerUnStatus(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion de un status de venta", "El Usuario solicito todos los datos de un status de venta", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_status_global Status = new DB_status_global(id, "0", "0");
            DataTable TablaStatus = Status.GetDetalleID(Status);
            return TablaStatus;
        }
    }
}
