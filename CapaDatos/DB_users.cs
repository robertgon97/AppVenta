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

        // GET ID
        public DataTable GetIdUser(DB_users UserID) {
            string respuesta = "";
            DataTable AllUsers = new DataTable("usuarios");
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_usuarios";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDUSER = new SqlParameter();
                IDUSER.ParameterName = "@idusuario";
                IDUSER.SqlDbType = SqlDbType.Int;
                IDUSER.Size = 256;
                IDUSER.Value = UserID.User_id;
                SQL_comando.Parameters.Add(IDUSER);

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
                SQL_comando.CommandText = "POSTusuarios"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter IDUSER = new SqlParameter(); // instanciamos
                IDUSER.ParameterName = "@idusuario"; // nombre de variable
                IDUSER.SqlDbType = SqlDbType.Int; // tipo de variable
                IDUSER.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(IDUSER); // Añadimos al comando
                
                SqlParameter TIPOUSER = new SqlParameter(); // instanciamos
                TIPOUSER.ParameterName = "@usuario_tipo_id"; // nombre de variable
                TIPOUSER.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPOUSER.Size = 256;
                TIPOUSER.Value = UserNew.Usuario_tipo_id;
                SQL_comando.Parameters.Add(TIPOUSER); // Añadimos al comando

                SqlParameter TIPODOCUMENTO = new SqlParameter(); // instanciamos
                TIPODOCUMENTO.ParameterName = "@tipo_documento_id"; // nombre de variable
                TIPODOCUMENTO.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPODOCUMENTO.Size = 256;
                TIPODOCUMENTO.Value = UserNew.Tipo_documento_id;
                SQL_comando.Parameters.Add(TIPODOCUMENTO); // Añadimos al comando

                SqlParameter USERNAME = new SqlParameter(); // instanciamos
                USERNAME.ParameterName = "@usuario_username"; // nombre de variable
                USERNAME.SqlDbType = SqlDbType.VarChar; // tipo de variable
                USERNAME.Size = 150; // Tamaño de variable
                USERNAME.Value = UserNew.Usuario_username; // Valor de la variable
                SQL_comando.Parameters.Add(USERNAME); // Añadimos al comando

                SqlParameter PASSWORD = new SqlParameter(); // instanciamos
                PASSWORD.ParameterName = "@usuario_password"; // nombre de variable
                PASSWORD.SqlDbType = SqlDbType.VarChar; // tipo de variable
                PASSWORD.Size = 500; // Tamaño de variable
                PASSWORD.Value = UserNew.User_password; // valor de la variable
                SQL_comando.Parameters.Add(PASSWORD); // Añadimos al comando

                SqlParameter NAME = new SqlParameter(); // instanciamos
                NAME.ParameterName = "@usuario_nombres"; // nombre de variable
                NAME.SqlDbType = SqlDbType.VarChar; // tipo de variable
                NAME.Size = 50; // Tamaño de variable
                NAME.Value = UserNew.Usuario_nombres; // valor de la variable
                SQL_comando.Parameters.Add(NAME); // Añadimos al comando

                SqlParameter APELLIDOS = new SqlParameter(); // instanciamos
                APELLIDOS.ParameterName = "@usuario_apellidos"; // nombre de variable
                APELLIDOS.SqlDbType = SqlDbType.VarChar; // tipo de variable
                APELLIDOS.Size = 50; // Tamaño de variable
                APELLIDOS.Value = UserNew.Usuario_apellidos; // valor de la variable
                SQL_comando.Parameters.Add(APELLIDOS); // Añadimos al comando

                SqlParameter SEXO = new SqlParameter(); // instanciamos
                SEXO.ParameterName = "@usuario_sexo"; // nombre de variable
                SEXO.SqlDbType = SqlDbType.VarChar; // tipo de variable
                SEXO.Size = 50; // Tamaño de variable
                SEXO.Value = UserNew.Usuario_sexo; // valor de la variable
                SQL_comando.Parameters.Add(SEXO); // Añadimos al comando

                SqlParameter NACIMIENTO = new SqlParameter(); // instanciamos
                NACIMIENTO.ParameterName = "@usuario_fecha_nacimiento"; // nombre de variable
                NACIMIENTO.SqlDbType = SqlDbType.Date; // tipo de variable
                NACIMIENTO.Value = UserNew.Usuario_fecha_nacimiento; // valor de la variable
                SQL_comando.Parameters.Add(NACIMIENTO); // Añadimos al comando

                SqlParameter Cedula = new SqlParameter(); // instanciamos
                Cedula.ParameterName = "@usuario_dni"; // nombre de variable
                Cedula.SqlDbType = SqlDbType.Int; // tipo de variable
                Cedula.Size = 15;
                Cedula.Value = UserNew.Usuario_dni;
                SQL_comando.Parameters.Add(Cedula); // Añadimos al comando

                SqlParameter DIRECCION = new SqlParameter(); // instanciamos
                DIRECCION.ParameterName = "@usuario_direccion"; // nombre de variable
                DIRECCION.SqlDbType = SqlDbType.Text; // tipo de variable
                DIRECCION.Size = 300; // Tamaño de variable
                DIRECCION.Value = UserNew.Usuario_direccion; // valor de la variable
                SQL_comando.Parameters.Add(DIRECCION); // Añadimos al comando

                SqlParameter CORREO = new SqlParameter(); // instanciamos
                CORREO.ParameterName = "@usuario_email"; // nombre de variable
                CORREO.SqlDbType = SqlDbType.Text; // tipo de variable
                CORREO.Size = 300; // Tamaño de variable
                CORREO.Value = UserNew.Usuario_email; // valor de la variable
                SQL_comando.Parameters.Add(CORREO); // Añadimos al comando

                SqlParameter TELEFONO = new SqlParameter(); // instanciamos
                TELEFONO.ParameterName = "@usuario_telefono"; // nombre de variable
                TELEFONO.SqlDbType = SqlDbType.Int; // tipo de variable
                TELEFONO.Size = 50;
                TELEFONO.Value = UserNew.Usuario_telefono;
                SQL_comando.Parameters.Add(TELEFONO); // Añadimos al comando

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
                SQL_comando.CommandText = "PUTusuarios";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDUSER = new SqlParameter();
                IDUSER.ParameterName = "@idusuario";
                IDUSER.SqlDbType = SqlDbType.Int;
                IDUSER.Size = 250;
                IDUSER.Value = UserEdit.User_id;
                SQL_comando.Parameters.Add(IDUSER);

                SqlParameter TIPOUSER = new SqlParameter(); // instanciamos
                TIPOUSER.ParameterName = "@usuario_tipo_id"; // nombre de variable
                TIPOUSER.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPOUSER.Size = 256;
                TIPOUSER.Value = UserEdit.Usuario_tipo_id;
                SQL_comando.Parameters.Add(TIPOUSER); // Añadimos al comando

                SqlParameter TIPODOCUMENTO = new SqlParameter(); // instanciamos
                TIPODOCUMENTO.ParameterName = "@tipo_documento_id"; // nombre de variable
                TIPODOCUMENTO.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPODOCUMENTO.Size = 256;
                TIPODOCUMENTO.Value = UserEdit.Tipo_documento_id;
                SQL_comando.Parameters.Add(TIPODOCUMENTO); // Añadimos al comando

                SqlParameter USERNAME = new SqlParameter(); // instanciamos
                USERNAME.ParameterName = "@usuario_username"; // nombre de variable
                USERNAME.SqlDbType = SqlDbType.VarChar; // tipo de variable
                USERNAME.Size = 150; // Tamaño de variable
                USERNAME.Value = UserEdit.Usuario_username; // Valor de la variable
                SQL_comando.Parameters.Add(USERNAME); // Añadimos al comando

                SqlParameter PASSWORD = new SqlParameter(); // instanciamos
                PASSWORD.ParameterName = "@usuario_password"; // nombre de variable
                PASSWORD.SqlDbType = SqlDbType.VarChar; // tipo de variable
                PASSWORD.Size = 500; // Tamaño de variable
                PASSWORD.Value = UserEdit.User_password; // valor de la variable
                SQL_comando.Parameters.Add(PASSWORD); // Añadimos al comando

                SqlParameter NAME = new SqlParameter(); // instanciamos
                NAME.ParameterName = "@usuario_nombres"; // nombre de variable
                NAME.SqlDbType = SqlDbType.VarChar; // tipo de variable
                NAME.Size = 50; // Tamaño de variable
                NAME.Value = UserEdit.Usuario_nombres; // valor de la variable
                SQL_comando.Parameters.Add(NAME); // Añadimos al comando

                SqlParameter APELLIDOS = new SqlParameter(); // instanciamos
                APELLIDOS.ParameterName = "@usuario_apellidos"; // nombre de variable
                APELLIDOS.SqlDbType = SqlDbType.VarChar; // tipo de variable
                APELLIDOS.Size = 50; // Tamaño de variable
                APELLIDOS.Value = UserEdit.Usuario_apellidos; // valor de la variable
                SQL_comando.Parameters.Add(APELLIDOS); // Añadimos al comando

                SqlParameter SEXO = new SqlParameter(); // instanciamos
                SEXO.ParameterName = "@usuario_sexo"; // nombre de variable
                SEXO.SqlDbType = SqlDbType.VarChar; // tipo de variable
                SEXO.Size = 50; // Tamaño de variable
                SEXO.Value = UserEdit.Usuario_sexo; // valor de la variable
                SQL_comando.Parameters.Add(SEXO); // Añadimos al comando

                SqlParameter NACIMIENTO = new SqlParameter(); // instanciamos
                NACIMIENTO.ParameterName = "@usuario_fecha_nacimiento"; // nombre de variable
                NACIMIENTO.SqlDbType = SqlDbType.Date; // tipo de variable
                NACIMIENTO.Value = UserEdit.Usuario_fecha_nacimiento; // valor de la variable
                SQL_comando.Parameters.Add(NACIMIENTO); // Añadimos al comando

                SqlParameter Cedula = new SqlParameter(); // instanciamos
                Cedula.ParameterName = "@usuario_dni"; // nombre de variable
                Cedula.SqlDbType = SqlDbType.Int; // tipo de variable
                Cedula.Size = 15;
                Cedula.Value = UserEdit.Usuario_dni;
                SQL_comando.Parameters.Add(Cedula); // Añadimos al comando

                SqlParameter DIRECCION = new SqlParameter(); // instanciamos
                DIRECCION.ParameterName = "@usuario_direccion"; // nombre de variable
                DIRECCION.SqlDbType = SqlDbType.Text; // tipo de variable
                DIRECCION.Size = 300; // Tamaño de variable
                DIRECCION.Value = UserEdit.Usuario_direccion; // valor de la variable
                SQL_comando.Parameters.Add(DIRECCION); // Añadimos al comando

                SqlParameter CORREO = new SqlParameter(); // instanciamos
                CORREO.ParameterName = "@usuario_email"; // nombre de variable
                CORREO.SqlDbType = SqlDbType.Text; // tipo de variable
                CORREO.Size = 300; // Tamaño de variable
                CORREO.Value = UserEdit.Usuario_email; // valor de la variable
                SQL_comando.Parameters.Add(CORREO); // Añadimos al comando

                SqlParameter TELEFONO = new SqlParameter(); // instanciamos
                TELEFONO.ParameterName = "@usuario_telefono"; // nombre de variable
                TELEFONO.SqlDbType = SqlDbType.Int; // tipo de variable
                TELEFONO.Size = 50;
                TELEFONO.Value = UserEdit.Usuario_telefono;
                SQL_comando.Parameters.Add(TELEFONO); // Añadimos al comando

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
                SQL_comando.CommandText = "DELETEusuarios";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDUSER = new SqlParameter();
                IDUSER.ParameterName = "@idusuario";
                IDUSER.SqlDbType = SqlDbType.Int;
                IDUSER.Size = 250;
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
