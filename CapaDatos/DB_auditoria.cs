using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Agregados manualmente
using System.Data; // Manejo de Datos SQL
using System.Data.SqlClient; // Enviar comandos a la BD

namespace CapaDatos
{
    class DB_auditoria
    {
        private int _auditoria_id;
        private int _usuario_id;
        private string _auditoria_fecha;
        private string _auditoria_accion;
        private string _auditoria_descripcion;
        private string _search_value;
    }
}
