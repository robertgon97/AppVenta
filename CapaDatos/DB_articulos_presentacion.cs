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
    class DB_articulos_presentacion
    {
        private int _presentacion_id;
        private string _presentacion_nombre;
        private string _presentacion_descripcion;
        
        public int Presentacion_id
        {
            get { return _presentacion_id; }
            set { _presentacion_id = value; }
        }

        public string Presentacion_nombre
        {
            get { return _presentacion_nombre; }
            set { _presentacion_nombre = value; }
        }

        public string Presentacion_descripcion
        {
            get { return _presentacion_descripcion; }
            set { _presentacion_descripcion = value; }
        }

        // Constructor Vacio
        public DB_articulos_presentacion()
        {
            //
        }

        public DB_articulos_presentacion(int _presentacion_id, string __presentacion_nombre, string _presentacion_descripcion)
        {
            this._presentacion_id = _presentacion_id;
            this._presentacion_nombre = __presentacion_nombre;
            this._presentacion_descripcion = _presentacion_descripcion;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllPresentacion = new DataTable("presentacion");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ALL_presentacion";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllPresentacion);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllPresentacion = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllPresentacion;
        }

        // GET ID
        public DataTable GetDetalleID(DB_articulos_presentacion PresentacionID)
        {
            string respuesta = "";
            DataTable AllPresentacion = new DataTable("presentacion");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_presentacion";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter PRESENTACION = new SqlParameter();
                PRESENTACION.ParameterName = "@idpresentacion";
                PRESENTACION.SqlDbType = SqlDbType.Int;
                PRESENTACION.Size = 256;
                PRESENTACION.Value = PresentacionID.Presentacion_id;
                SQL_comando.Parameters.Add(PRESENTACION);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllPresentacion);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllPresentacion = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllPresentacion;
        }

        // INSERT
        public string Create(DB_articulos_presentacion PresentacionNew)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                // Conexion
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                // Establecer Procedimiento
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL; // Heredar conexion
                SQL_comando.CommandText = "POST_presentacion"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter PRESENTACION = new SqlParameter(); // instanciamos
                PRESENTACION.ParameterName = "@presentacion_id"; // nombre de variable
                PRESENTACION.SqlDbType = SqlDbType.Int; // tipo de variable
                PRESENTACION.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(PRESENTACION); // Añadimos al comando

                SqlParameter NOMBRE = new SqlParameter(); // instanciamos
                NOMBRE.ParameterName = "@presentacion_nombre"; // nombre de variable
                NOMBRE.SqlDbType = SqlDbType.VarChar; // tipo de variable
                NOMBRE.Size = 150;
                NOMBRE.Value = PresentacionNew.Presentacion_nombre;
                SQL_comando.Parameters.Add(NOMBRE); // Añadimos al comando

                SqlParameter DESCRIPCION = new SqlParameter(); // instanciamos
                DESCRIPCION.ParameterName = "@presentacion_descripcion"; // nombre de variable
                DESCRIPCION.SqlDbType = SqlDbType.Text; // tipo de variable
                DESCRIPCION.Size = 500;
                DESCRIPCION.Value = PresentacionNew.Presentacion_descripcion; // valor de la variable
                SQL_comando.Parameters.Add(DESCRIPCION); // Añadimos al comando         

                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar la presentacion de plato";
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                throw;
            }
            finally
            {
                // Cerramos la conexion
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }

    }
}
