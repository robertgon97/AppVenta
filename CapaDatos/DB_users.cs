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
    // Esta clase es para manejar los datos de una tabla en especifico
    class DB_users
    {
        private int _usuario_id;
        private int _usuario_tipo_id;
        private int _tipo_documento_id;
        private string _usuario_username;
        private string _usuario_password;
        private string _usuario_nombres;
        private string _usuario_apellidos;
        private string _usuario_sexo;
        private string _usuario_fecha_nacimiento;
        private int _usuario_dni;
        private string _usuario_direccion;
        private string _usuario_email;
        private string _usuario_telefono;
        private string _search_value;

        private string Encriptar(string valor) {
            valor = "ASDFGHJKLOIUYTREWQASDFGESASDASDASDWQECVSDFSDFSDFSFSZDFSDFSF";
            return valor;
        }

        private string Descriptar(string valor) {
            valor = "DESENCRIPTE";
            return valor;
        }

        public int User_id
        { // Encapsulamiento de _usuario_id
            get { return _usuario_id; }
            set { _usuario_id = value; }
        }

        public int Usuario_tipo_id
        { // Encapsulamiento de _usuario_tipo_id
            get { return _usuario_tipo_id; }
            set { _usuario_tipo_id = value; }
        }

        public int Tipo_documento_id
        { // Encapsulamiento de _tipo_documento_id
            get { return _tipo_documento_id; }
            set { _tipo_documento_id = value; }
        }

        public string Usuario_username
        { // Encapsulamiento de _usuario_username
            get { return _usuario_username; }
            set { _usuario_username = value; }
        }

        public string User_password
        { // Encapsulamiento de _usuario_password
            get { return Descriptar(_usuario_password); }
            set { _usuario_password = Encriptar(_usuario_password); }
        }

        public string Usuario_nombres
        { // Encapsulamiento de _usuario_nombres
            get { return _usuario_nombres; }
            set { _usuario_nombres = value; }
        }

        public string Usuario_apellidos
        { // Encapsulamiento de _usuario_apellidos
            get { return _usuario_apellidos; }
            set { _usuario_apellidos = value; }
        }

        public string Usuario_sexo
        { // Encapsulamiento de _usuario_apellidos
            get { return _usuario_sexo; }
            set { _usuario_sexo = value; }
        }

        public string Usuario_fecha_nacimiento
        { // Encapsulamiento de _usuario_fecha_nacimiento
            get { return _usuario_fecha_nacimiento; }
            set { _usuario_fecha_nacimiento = value; }
        }

        public int Usuario_dni
        { // Encapsulamiento de _usuario_dni
            get { return _usuario_dni; }
            set { _usuario_dni = value; }
        }

        public string Usuario_direccion
        { // Encapsulamiento de _usuario_direccion
            get { return _usuario_direccion; }
            set { _usuario_direccion = value; }
        }

        public string Usuario_email
        { // Encapsulamiento de _usuario_direccion
            get { return _usuario_email; }
            set { _usuario_email = value; }
        }

        public string Usuario_telefono
        { // Encapsulamiento de _usuario_telefono
            get { return _usuario_telefono; }
            set { _usuario_telefono = value; }
        }

        public string Search_value
        { // Encapsulamiento de _search_value
            get { return _search_value; }
            set { _search_value = value; }
        }


        // Constructor Vacio
        public DB_users () {
            //
        }

        // Constructor con parámetros
        public DB_users(int id, int tipoid, int documentoid, string username, string password, string nombres, string apellidos, string sexo, string nacimiento, int cedula, string direccion, string correo, string telefono, string buscar) {
            this._usuario_id = id;
            this._usuario_tipo_id = tipoid;
            this._tipo_documento_id = documentoid;
            this._usuario_username = username;
            this._usuario_password = password;
            this._usuario_nombres = nombres;
            this._usuario_apellidos = apellidos;
            this._usuario_sexo = sexo;
            this._usuario_fecha_nacimiento = nacimiento;
            this._usuario_dni = cedula;
            this._usuario_direccion = direccion;
            this._usuario_email = correo;
            this._usuario_telefono = telefono;
            this._search_value = buscar;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll () {
            string respuesta = "";
            DataTable AllUsers = new DataTable("usuarios");
            SqlConnection SQL = new SqlConnection();
            try {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_usuarios";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllUsers);

            } catch (Exception error) {
                respuesta = error.Message;
                AllUsers = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllUsers;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_users UserSearch) {
            string respuesta = "";
            DataTable AllUsers = new DataTable("usuarios");
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_usuarios";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = UserSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllUsers);

            } catch (Exception error) {
                respuesta = error.Message;
                AllUsers = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllUsers;
        }

        // INSERT
        public string Create(DB_users UserNew) {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try {
                // Conexion
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                // Establecer Procedimiento
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL; // Heredar conexion
                SQL_comando.CommandText = "DB_USERS_REGISTER"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter IDUSER = new SqlParameter(); // instanciamos
                IDUSER.ParameterName = "@varID"; // nombre de variable
                IDUSER.SqlDbType = SqlDbType.Int; // tipo de variable
                IDUSER.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(IDUSER); // Añadimos al comando

                SqlParameter USERNAME = new SqlParameter(); // instanciamos
                USERNAME.ParameterName = "@varUser"; // nombre de variable
                USERNAME.SqlDbType = SqlDbType.VarChar; // tipo de variable
                USERNAME.Size = 50; // Tamaño de variable
                USERNAME.Value = UserNew.User_username; // Valor de la variable
                SQL_comando.Parameters.Add(USERNAME); // Añadimos al comando

                SqlParameter NAME = new SqlParameter(); // instanciamos
                NAME.ParameterName = "@varName"; // nombre de variable
                NAME.SqlDbType = SqlDbType.VarChar; // tipo de variable
                NAME.Size = 50; // Tamaño de variable
                NAME.Value = UserNew.User_name; // valor de la variable
                SQL_comando.Parameters.Add(NAME); // Añadimos al comando

                SqlParameter PASSWORD = new SqlParameter(); // instanciamos
                PASSWORD.ParameterName = "@varPassword"; // nombre de variable
                PASSWORD.SqlDbType = SqlDbType.VarChar; // tipo de variable
                PASSWORD.Size = 256; // Tamaño de variable
                PASSWORD.Value = UserNew.User_password; // valor de la variable
                SQL_comando.Parameters.Add(PASSWORD); // Añadimos al comando

                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar el usuario";
            } catch (Exception error) {
                respuesta = error.Message;
                throw;
            } finally {
                // Cerramos la conexion
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }

        // EDIT
        public string Edit (DB_users UserEdit) {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DB_USERS_UPDATE";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDUSER = new SqlParameter();
                IDUSER.ParameterName = "@varID";
                IDUSER.SqlDbType = SqlDbType.Int;
                IDUSER.Size = 50;
                IDUSER.Value = UserEdit.User_id;
                SQL_comando.Parameters.Add(IDUSER);

                SqlParameter USERNAME = new SqlParameter();
                USERNAME.ParameterName = "@varUser";
                USERNAME.SqlDbType = SqlDbType.VarChar;
                USERNAME.Size = 50;
                USERNAME.Value = UserEdit.User_username;
                SQL_comando.Parameters.Add(USERNAME);

                SqlParameter NAME = new SqlParameter(); 
                NAME.ParameterName = "@varName";
                NAME.SqlDbType = SqlDbType.VarChar;
                NAME.Size = 50;
                NAME.Value = UserEdit.User_name;
                SQL_comando.Parameters.Add(NAME);

                SqlParameter PASSWORD = new SqlParameter(); 
                PASSWORD.ParameterName = "@varPassword";
                PASSWORD.SqlDbType = SqlDbType.VarChar;
                PASSWORD.Size = 256;
                PASSWORD.Value = UserEdit.User_password;
                SQL_comando.Parameters.Add(PASSWORD);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar el usuario";
            } catch (Exception error) {
                respuesta = error.Message;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }

        // DELETE
        public string Delete(DB_users UserDelete) {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DB_USERS_DELETE";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDUSER = new SqlParameter();
                IDUSER.ParameterName = "@varID";
                IDUSER.SqlDbType = SqlDbType.Int;
                IDUSER.Size = 50;
                IDUSER.Value = UserDelete.User_id;
                SQL_comando.Parameters.Add(IDUSER);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar el usuario";
            } catch (Exception error) {
                respuesta = error.Message;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }
    }
}
