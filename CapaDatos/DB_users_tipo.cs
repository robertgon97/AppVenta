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
    class DB_users_tipo
    {
        private int _usuario_tipo_id;
        private string _tipo_usuario_nombre;
        private string _tipo_usuario_descripcion;
        private string _search_value;
        
        public int Usuario_tipo_id
        {
            get { return _usuario_tipo_id; }
            set { _usuario_tipo_id = value; }
        }

        public string Tipo_usuario_nombre
        {
            get { return _tipo_usuario_nombre; }
            set { _tipo_usuario_nombre = value; }
        }

        public string Tipo_usuario_descripcion
        {
            get { return _tipo_usuario_descripcion; }
            set { _tipo_usuario_descripcion = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_users_tipo()
        {
            // 
        }

        public DB_users_tipo(int _usuario_tipo_id, string _tipo_usuario_nombre, string _tipo_usuario_descripcion, string _search_value)
        {
            this._usuario_tipo_id = _usuario_tipo_id;
            this._tipo_usuario_nombre = _tipo_usuario_nombre;
            this._tipo_usuario_descripcion = _tipo_usuario_descripcion;
            this._search_value = _search_value;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllUsersType = new DataTable("usuarios_tipo");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ALL_usuarios_tipo";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllUsersType);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllUsersType = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllUsersType;
        }

        // GET ID
        public DataTable GetDetalleID(DB_users_tipo UserType)
        {
            string respuesta = "";
            DataTable AllUsersType = new DataTable("compras_detalles");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_usuarios_tipo";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@idusuario_tipo";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 256;
                DetalleID.Value = UserType.Usuario_tipo_id;
                SQL_comando.Parameters.Add(DetalleID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllUsersType);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllUsersType = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllUsersType;
        }

        // INSERT
        public string Create(DB_users_tipo UserTypeNew)
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
                SQL_comando.CommandText = "POST_usuarios_tipo"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter TIPO = new SqlParameter(); // instanciamos
                TIPO.ParameterName = "@usuario_tipo_id"; // nombre de variable
                TIPO.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPO.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(TIPO); // Añadimos al comando

                SqlParameter NOMBRE = new SqlParameter(); // instanciamos
                NOMBRE.ParameterName = "@tipo_usuario_nombre"; // nombre de variable
                NOMBRE.SqlDbType = SqlDbType.VarChar; // tipo de variable
                NOMBRE.Size = 150;
                NOMBRE.Value = UserTypeNew.Tipo_usuario_nombre;
                SQL_comando.Parameters.Add(NOMBRE); // Añadimos al comando

                SqlParameter DESCRIPCION = new SqlParameter(); // instanciamos
                DESCRIPCION.ParameterName = "@tipo_usuario_descripcion"; // nombre de variable
                DESCRIPCION.SqlDbType = SqlDbType.Text; // tipo de variable
                DESCRIPCION.Size = 500;
                DESCRIPCION.Value = UserTypeNew.Tipo_usuario_descripcion; // valor de la variable
                SQL_comando.Parameters.Add(DESCRIPCION); // Añadimos al comando         
                
                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar el item al carrito";
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
