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
    public class DB_configuration
    {
        private int _configuracion_id;
        private string _configuracion_nombre_empresa;
        private string _configuracion_nombre_app;
        private int _configuracion_iva;
        private int _configuracion_inventario_minimo;
        private int _configuracion_inventario_maximo;

        public int Configuracion_id
        {
            get { return _configuracion_id; }
            set { _configuracion_id = value; }
        }

        public string Configuracion_nombre_empresa
        {
            get { return _configuracion_nombre_empresa; }
            set { _configuracion_nombre_empresa = value; }
        }

        public string Configuracion_nombre_app
        {
            get { return _configuracion_nombre_app; }
            set { _configuracion_nombre_app = value; }
        }

        public int Configuracion_iva
        {
            get { return _configuracion_iva; }
            set { _configuracion_iva = value; }
        }

        public int Configuracion_inventario_minimo
        {
            get { return _configuracion_inventario_minimo; }
            set { _configuracion_inventario_minimo = value; }
        }

        public int Configuracion_inventario_maximo
        {
            get { return _configuracion_inventario_maximo; }
            set { _configuracion_inventario_maximo = value; }
        }

        // Contructor Vacio

        public DB_configuration()
        {
            //
        }

        public DB_configuration(int _configuracion_id, string _configuracion_nombre_empresa, string _configuracion_nombre_app, int _configuracion_iva, int _configuracion_inventario_minimo, int _configuracion_inventario_maximo)
        {
            this.Configuracion_id = _configuracion_id;
            this.Configuracion_nombre_empresa = _configuracion_nombre_empresa;
            this.Configuracion_nombre_app = _configuracion_nombre_app;
            this.Configuracion_iva = _configuracion_iva;
            this.Configuracion_inventario_minimo = _configuracion_inventario_minimo;
            this.Configuracion_inventario_maximo = _configuracion_inventario_maximo;
        }

        // Metodos DB

        // GET ID
        public DataTable GetDetalleID(DB_configuration ConfigID)
        {
            string respuesta = "";
            DataTable AllConfig = new DataTable("configuracion");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_configuracion";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@idconfiguracion";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 256;
                DetalleID.Value = ConfigID.Configuracion_id;
                SQL_comando.Parameters.Add(DetalleID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllConfig);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllConfig = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllConfig;
        }
    }
}
