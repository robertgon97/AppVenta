using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_tipodocumento
    {
        public static DataTable obtenerTodos()
        {
            DataTable documentos = new DB_tipo_documento().GetAll();
            return documentos;
        }

    }
}
