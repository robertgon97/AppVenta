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
    class DB_cliente
    {
        private int _cliente_id;
        private int _tipo_documento_id;
        private int _cliente_nombres;
        private string _cliente_apellidos;
        private string _cliente_dni;
        private string _cliente_direccion;
        private string _cliente_nacimiento;
        private string _cliente_email;
        private string _cliente_telefono;
        private string _search_value;

        public int Cliente_id
        {
            get { return _cliente_id; }
            set { _cliente_id = value; }
        }

        public int Tipo_documento_id
        {
            get { return _tipo_documento_id; }
            set { _tipo_documento_id = value; }
        }

        public int Cliente_nombres
        {
            get { return _cliente_nombres; }
            set { _cliente_nombres = value; }
        }

        public string Cliente_apellidos
        {
            get { return _cliente_apellidos; }
            set { _cliente_apellidos = value; }
        }

        public string Cliente_dni
        {
            get { return _cliente_dni; }
            set { _cliente_dni = value; }
        }

        public string Cliente_direccion
        {
            get { return _cliente_direccion; }
            set { _cliente_direccion = value; }
        }

        public string Cliente_nacimiento
        {
            get { return _cliente_nacimiento; }
            set { _cliente_nacimiento = value; }
        }

        public string Cliente_email
        {
            get { return _cliente_email; }
            set { _cliente_email = value; }
        }

        public string Cliente_telefono
        {
            get { return _cliente_telefono; }
            set { _cliente_telefono = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_cliente()
        {
            // 
        }

        public DB_cliente(int id, int tipodni, int nombres, string apellidos, string dni, string direccion, string nacimiento, string correo, string telefono, string search)
        {
            this._cliente_id = id;
            this._tipo_documento_id = tipodni;
            this._cliente_nombres = nombres;
            this._cliente_apellidos = apellidos;
            this._cliente_dni = dni;
            this._cliente_direccion = direccion;
            this._cliente_nacimiento = nacimiento;
            this._cliente_email = correo;
            this._cliente_telefono = telefono;
            this._search_value = search;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllClientes = new DataTable("clientes");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_clientes";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllClientes);

            } catch (Exception error) {
                respuesta = error.Message;
                AllClientes = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllClientes;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_cliente ClienteSearch)
        {
            string respuesta = "";
            DataTable AllClientes = new DataTable("clientes");
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_clientes";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = ClienteSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllClientes);

            } catch (Exception error) {
                respuesta = error.Message;
                AllClientes = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllClientes;
        }

        // GET ID
        public DataTable GetIdCliente(DB_cliente ClienteID)
        {
            string respuesta = "";
            DataTable AllClientes = new DataTable("clientes");
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_clientes";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDUSER = new SqlParameter();
                IDUSER.ParameterName = "@idcliente";
                IDUSER.SqlDbType = SqlDbType.Int;
                IDUSER.Size = 256;
                IDUSER.Value = ClienteID.Cliente_id;
                SQL_comando.Parameters.Add(IDUSER);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllClientes);

            } catch (Exception error) {
                respuesta = error.Message;
                AllClientes = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllClientes;
        }

        // INSERT
        public string Create(DB_cliente ClienteNew)
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
                SQL_comando.CommandText = "POSTclientes"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter IDCLIENTE = new SqlParameter(); // instanciamos
                IDCLIENTE.ParameterName = "@idcliente"; // nombre de variable
                IDCLIENTE.SqlDbType = SqlDbType.Int; // tipo de variable
                IDCLIENTE.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(IDCLIENTE); // Añadimos al comando
                
                SqlParameter TIPODOCUMENTO = new SqlParameter(); // instanciamos
                TIPODOCUMENTO.ParameterName = "@tipo_documento_id"; // nombre de variable
                TIPODOCUMENTO.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPODOCUMENTO.Size = 256;
                TIPODOCUMENTO.Value = ClienteNew.Tipo_documento_id;
                SQL_comando.Parameters.Add(TIPODOCUMENTO); // Añadimos al comando

                SqlParameter NAME = new SqlParameter(); // instanciamos
                NAME.ParameterName = "@cliente_nombres"; // nombre de variable
                NAME.SqlDbType = SqlDbType.VarChar; // tipo de variable
                NAME.Size = 50; // Tamaño de variable
                NAME.Value = ClienteNew.Cliente_nombres; // valor de la variable
                SQL_comando.Parameters.Add(NAME); // Añadimos al comando

                SqlParameter APELLIDOS = new SqlParameter(); // instanciamos
                APELLIDOS.ParameterName = "@cliente_apellidos"; // nombre de variable
                APELLIDOS.SqlDbType = SqlDbType.VarChar; // tipo de variable
                APELLIDOS.Size = 50; // Tamaño de variable
                APELLIDOS.Value = ClienteNew.Cliente_apellidos; // valor de la variable
                SQL_comando.Parameters.Add(APELLIDOS); // Añadimos al comando

                SqlParameter Cedula = new SqlParameter(); // instanciamos
                Cedula.ParameterName = "@cliente_dni"; // nombre de variable
                Cedula.SqlDbType = SqlDbType.Int; // tipo de variable
                Cedula.Size = 15;
                Cedula.Value = ClienteNew.Cliente_dni;
                SQL_comando.Parameters.Add(Cedula); // Añadimos al comando

                SqlParameter DIRECCION = new SqlParameter(); // instanciamos
                DIRECCION.ParameterName = "@cliente_direccion"; // nombre de variable
                DIRECCION.SqlDbType = SqlDbType.Text; // tipo de variable
                DIRECCION.Size = 300; // Tamaño de variable
                DIRECCION.Value = ClienteNew.Cliente_direccion; // valor de la variable
                SQL_comando.Parameters.Add(DIRECCION); // Añadimos al comando

                SqlParameter NACIMIENTO = new SqlParameter(); // instanciamos
                NACIMIENTO.ParameterName = "@cliente_nacimiento"; // nombre de variable
                NACIMIENTO.SqlDbType = SqlDbType.Date; // tipo de variable
                NACIMIENTO.Value = ClienteNew.Cliente_nacimiento; // valor de la variable
                SQL_comando.Parameters.Add(NACIMIENTO); // Añadimos al comando                

                SqlParameter CORREO = new SqlParameter(); // instanciamos
                CORREO.ParameterName = "@cliente_email"; // nombre de variable
                CORREO.SqlDbType = SqlDbType.Text; // tipo de variable
                CORREO.Size = 300; // Tamaño de variable
                CORREO.Value = ClienteNew.Cliente_email; // valor de la variable
                SQL_comando.Parameters.Add(CORREO); // Añadimos al comando

                SqlParameter TELEFONO = new SqlParameter(); // instanciamos
                TELEFONO.ParameterName = "@cliente_telefono"; // nombre de variable
                TELEFONO.SqlDbType = SqlDbType.Int; // tipo de variable
                TELEFONO.Size = 50;
                TELEFONO.Value = ClienteNew.Cliente_telefono;
                SQL_comando.Parameters.Add(TELEFONO); // Añadimos al comando

                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar el cliente";
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
        public string Edit(DB_cliente ClienteEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTclientes";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDCLIENTE = new SqlParameter();
                IDCLIENTE.ParameterName = "@idcliente";
                IDCLIENTE.SqlDbType = SqlDbType.Int;
                IDCLIENTE.Size = 250;
                IDCLIENTE.Value = ClienteEdit.Cliente_id;
                SQL_comando.Parameters.Add(IDCLIENTE);

                SqlParameter TIPODOCUMENTO = new SqlParameter(); // instanciamos
                TIPODOCUMENTO.ParameterName = "@tipo_documento_id"; // nombre de variable
                TIPODOCUMENTO.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPODOCUMENTO.Size = 256;
                TIPODOCUMENTO.Value = ClienteEdit.Tipo_documento_id;
                SQL_comando.Parameters.Add(TIPODOCUMENTO); // Añadimos al comando

                SqlParameter NAME = new SqlParameter(); // instanciamos
                NAME.ParameterName = "@cliente_nombres"; // nombre de variable
                NAME.SqlDbType = SqlDbType.VarChar; // tipo de variable
                NAME.Size = 50; // Tamaño de variable
                NAME.Value = ClienteEdit.Cliente_nombres; // valor de la variable
                SQL_comando.Parameters.Add(NAME); // Añadimos al comando

                SqlParameter APELLIDOS = new SqlParameter(); // instanciamos
                APELLIDOS.ParameterName = "@cliente_apellidos"; // nombre de variable
                APELLIDOS.SqlDbType = SqlDbType.VarChar; // tipo de variable
                APELLIDOS.Size = 50; // Tamaño de variable
                APELLIDOS.Value = ClienteEdit.Cliente_apellidos; // valor de la variable
                SQL_comando.Parameters.Add(APELLIDOS); // Añadimos al comando

                SqlParameter Cedula = new SqlParameter(); // instanciamos
                Cedula.ParameterName = "@cliente_dni"; // nombre de variable
                Cedula.SqlDbType = SqlDbType.Int; // tipo de variable
                Cedula.Size = 15;
                Cedula.Value = ClienteEdit.Cliente_dni;
                SQL_comando.Parameters.Add(Cedula); // Añadimos al comando

                SqlParameter DIRECCION = new SqlParameter(); // instanciamos
                DIRECCION.ParameterName = "@cliente_direccion"; // nombre de variable
                DIRECCION.SqlDbType = SqlDbType.Text; // tipo de variable
                DIRECCION.Size = 300; // Tamaño de variable
                DIRECCION.Value = ClienteEdit.Cliente_direccion; // valor de la variable
                SQL_comando.Parameters.Add(DIRECCION); // Añadimos al comando

                SqlParameter NACIMIENTO = new SqlParameter(); // instanciamos
                NACIMIENTO.ParameterName = "@cliente_nacimiento"; // nombre de variable
                NACIMIENTO.SqlDbType = SqlDbType.Date; // tipo de variable
                NACIMIENTO.Value = ClienteEdit.Cliente_nacimiento; // valor de la variable
                SQL_comando.Parameters.Add(NACIMIENTO); // Añadimos al comando                

                SqlParameter CORREO = new SqlParameter(); // instanciamos
                CORREO.ParameterName = "@cliente_email"; // nombre de variable
                CORREO.SqlDbType = SqlDbType.Text; // tipo de variable
                CORREO.Size = 300; // Tamaño de variable
                CORREO.Value = ClienteEdit.Cliente_email; // valor de la variable
                SQL_comando.Parameters.Add(CORREO); // Añadimos al comando

                SqlParameter TELEFONO = new SqlParameter(); // instanciamos
                TELEFONO.ParameterName = "@cliente_telefono"; // nombre de variable
                TELEFONO.SqlDbType = SqlDbType.Int; // tipo de variable
                TELEFONO.Size = 50;
                TELEFONO.Value = ClienteEdit.Cliente_telefono;
                SQL_comando.Parameters.Add(TELEFONO); // Añadimos al comando

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar el cliente";
            } catch (Exception error) {
                respuesta = error.Message;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }

        // DELETE
        public string Delete(DB_cliente ClienteDelete)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEclientes";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDCLIENTE = new SqlParameter();
                IDCLIENTE.ParameterName = "@idcliente";
                IDCLIENTE.SqlDbType = SqlDbType.Int;
                IDCLIENTE.Size = 250;
                IDCLIENTE.Value = ClienteDelete.Cliente_id;
                SQL_comando.Parameters.Add(IDCLIENTE);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar el cliente";
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
