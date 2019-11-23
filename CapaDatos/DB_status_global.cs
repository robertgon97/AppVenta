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
    public class DB_status_global
    {
        private int _status_id;
        private string _status_nombre;
        private string _status_descripcion;

        public int Status_id
        {
            get { return _status_id; }
            set { _status_id = value; }
        }

        public string Status_nombre
        {
            get { return _status_nombre; }
            set { _status_nombre = value; }
        }

        public string Status_descripcion
        {
            get { return _status_descripcion; }
            set { _status_descripcion = value; }
        }

        // Constructor Vacio
        public DB_status_global()
        {
            //
        }

        public DB_status_global(int _status_id, string _status_nombre, string _status_descripcion)
        {
            this.Status_id = _status_id;
            this.Status_nombre = _status_nombre;
            this.Status_descripcion = _status_descripcion;
        }


        //Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllStatus = new DataTable("status");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ALL_status";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllStatus);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllStatus = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllStatus;
        }

        // GET ID
        public DataTable GetDetalleID(DB_status_global StatusID)
        {
            string respuesta = "";
            DataTable AllStatus = new DataTable("status");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_status";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@idstatus";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 256;
                DetalleID.Value = StatusID.Status_id;
                SQL_comando.Parameters.Add(DetalleID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllStatus);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllStatus = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllStatus;
        }
    }
}
