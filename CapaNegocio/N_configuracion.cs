using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_configuracion
    {
        public static DataTable obtenerConfiguracion()
        {
            DataTable Config = new DB_articulos().GetAll();
            return Config;
        }

    }
}
