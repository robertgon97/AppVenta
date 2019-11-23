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
    class DB_ventas_tipoventa
    {
        private int _ventas_tipo_id;
        private string _ventas_tipo_nombre;
        private string _ventas_tipo_descripcion;

        public int Ventas_tipo_id
        {
            get { return _ventas_tipo_id; }
            set { _ventas_tipo_id = value; }
        }

        public string Ventas_tipo_nombre
        {
            get { return _ventas_tipo_nombre; }
            set { _ventas_tipo_nombre = value; }
        }

        public string Ventas_tipo_descripcion
        {
            get { return _ventas_tipo_descripcion; }
            set { _ventas_tipo_descripcion = value; }
        }

        // Constructor Vacio

        public DB_ventas_tipoventa()
        {
            //
        }

        public DB_ventas_tipoventa(int _ventas_tipo_id, string _ventas_tipo_nombre, string _ventas_tipo_descripcion)
        {
            this.Ventas_tipo_id = _ventas_tipo_id;
            this.Ventas_tipo_nombre = _ventas_tipo_nombre;
            this.Ventas_tipo_descripcion = _ventas_tipo_descripcion;
        }


        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllTipo_ventas = new DataTable("ventas_tipo");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ALL_ventas_tipo";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllTipo_ventas);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllTipo_ventas = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllTipo_ventas;
        }

        // GET ID
        public DataTable GetDetalleID(DB_ventas_tipoventa TipoVenta)
        {
            string respuesta = "";
            DataTable AllTipo_ventas = new DataTable("ventas_tipo");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_ventas_tipo";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@idventas_tipo";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 256;
                DetalleID.Value = TipoVenta.Ventas_tipo_id;
                SQL_comando.Parameters.Add(DetalleID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllTipo_ventas);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllTipo_ventas = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllTipo_ventas;
        }

    }
}
