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
    public class DB_proveedores
    {
        private int _proveedor_id;
        private int _tipo_documento_id;
        private string _proveedor_razon_social;
        private string _proveedor_dni;
        private string _proveedor_direccion;
        private string _proveedor_email;
        private int _proveedor_telefono;
        private string _proveedor_url;
        private string _search_value;
        
        public int Proveedor_id
        {
            get { return _proveedor_id; }
            set { _proveedor_id = value; }
        }

        public int Tipo_documento_id
        {
            get { return _tipo_documento_id; }
            set { _tipo_documento_id = value; }
        }

        public string Proveedor_razon_social
        {
            get { return _proveedor_razon_social; }
            set { _proveedor_razon_social = value; }
        }

        public string Proveedor_dni
        {
            get { return _proveedor_dni; }
            set { _proveedor_dni = value; }
        }

        public string Proveedor_direccion
        {
            get { return _proveedor_direccion; }
            set { _proveedor_direccion = value; }
        }

        public string Proveedor_email
        {
            get { return _proveedor_email; }
            set { _proveedor_email = value; }
        }

        public int Proveedor_telefono
        {
            get { return _proveedor_telefono; }
            set { _proveedor_telefono = value; }
        }

        public string Proveedor_url
        {
            get { return _proveedor_url; }
            set { _proveedor_url = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        //Constructor Vacio
        public DB_proveedores()
        {
            //
        }

        public DB_proveedores(int _proveedor_id, int _tipo_documento_id, string _proveedor_razon_social, string _proveedor_dni, string _proveedor_direccion, string _proveedor_email, int _proveedor_telefono, string _proveedor_url, string _search_value)
        {
            this._proveedor_id = _proveedor_id;
            this._tipo_documento_id = _tipo_documento_id;
            this._proveedor_razon_social = _proveedor_razon_social;
            this._proveedor_dni = _proveedor_dni;
            this._proveedor_direccion = _proveedor_direccion;
            this._proveedor_email = _proveedor_email;
            this._proveedor_telefono = _proveedor_telefono;
            this._proveedor_url = _proveedor_url;
            this._search_value = _search_value;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllProveedores = new DataTable("proveedores");
            SqlConnection SQL = new SqlConnection();
            try {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_proveedores";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllProveedores);

            } catch (Exception error) {
                respuesta = error.Message;
                AllProveedores = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllProveedores;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_proveedores ProveedoresSearch)
        {
            string respuesta = "";
            DataTable AllProveedores = new DataTable("proveedores");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_proveedores";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = ProveedoresSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllProveedores);

            } catch (Exception error) {
                respuesta = error.Message;
                AllProveedores = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllProveedores;
        }

        // GET ID
        public DataTable GetIDProveedor(DB_proveedores ProveedorID)
        {
            string respuesta = "";
            DataTable AllProveedores = new DataTable("proveedores");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_proveedores";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDUSER = new SqlParameter();
                IDUSER.ParameterName = "@idproveedor";
                IDUSER.SqlDbType = SqlDbType.Int;
                IDUSER.Size = 256;
                IDUSER.Value = ProveedorID.Proveedor_id;
                SQL_comando.Parameters.Add(IDUSER);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllProveedores);

            } catch (Exception error) {
                respuesta = error.Message;
                AllProveedores = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllProveedores;
        }

        // INSERT
        public string Create(DB_proveedores ProveedorNew)
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
                SQL_comando.CommandText = "POSTproveedores"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter IDPROVEEDOR = new SqlParameter(); // instanciamos
                IDPROVEEDOR.ParameterName = "@idproveedor"; // nombre de variable
                IDPROVEEDOR.SqlDbType = SqlDbType.Int; // tipo de variable
                IDPROVEEDOR.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(IDPROVEEDOR); // Añadimos al comando

                SqlParameter TIPODOCUMENTO = new SqlParameter(); // instanciamos
                TIPODOCUMENTO.ParameterName = "@tipo_documento_id"; // nombre de variable
                TIPODOCUMENTO.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPODOCUMENTO.Size = 256;
                TIPODOCUMENTO.Value = ProveedorNew.Tipo_documento_id;
                SQL_comando.Parameters.Add(TIPODOCUMENTO); // Añadimos al comando

                SqlParameter RAZONSOCIAL = new SqlParameter(); // instanciamos
                RAZONSOCIAL.ParameterName = "@proveedor_razon_social"; // nombre de variable
                RAZONSOCIAL.SqlDbType = SqlDbType.VarChar; // tipo de variable
                RAZONSOCIAL.Size = 500; // Tamaño de variable
                RAZONSOCIAL.Value = ProveedorNew.Proveedor_razon_social; // valor de la variable
                SQL_comando.Parameters.Add(RAZONSOCIAL); // Añadimos al comando
                
                SqlParameter Cedula = new SqlParameter(); // instanciamos
                Cedula.ParameterName = "@proveedor_dni"; // nombre de variable
                Cedula.SqlDbType = SqlDbType.VarChar; // tipo de variable
                Cedula.Size = 20;
                Cedula.Value = ProveedorNew.Proveedor_dni;
                SQL_comando.Parameters.Add(Cedula); // Añadimos al comando

                SqlParameter DIRECCION = new SqlParameter(); // instanciamos
                DIRECCION.ParameterName = "@proveedor_direccion"; // nombre de variable
                DIRECCION.SqlDbType = SqlDbType.Text; // tipo de variable
                DIRECCION.Size = 300; // Tamaño de variable
                DIRECCION.Value = ProveedorNew.Proveedor_direccion; // valor de la variable
                SQL_comando.Parameters.Add(DIRECCION); // Añadimos al comando         

                SqlParameter CORREO = new SqlParameter(); // instanciamos
                CORREO.ParameterName = "@proveedor_email"; // nombre de variable
                CORREO.SqlDbType = SqlDbType.Text; // tipo de variable
                CORREO.Size = 300; // Tamaño de variable
                CORREO.Value = ProveedorNew.Proveedor_email; // valor de la variable
                SQL_comando.Parameters.Add(CORREO); // Añadimos al comando

                SqlParameter TELEFONO = new SqlParameter(); // instanciamos
                TELEFONO.ParameterName = "@proveedor_telefono"; // nombre de variable
                TELEFONO.SqlDbType = SqlDbType.Int; // tipo de variable
                TELEFONO.Size = 50;
                TELEFONO.Value = ProveedorNew.Proveedor_telefono;
                SQL_comando.Parameters.Add(TELEFONO); // Añadimos al comando

                SqlParameter URL = new SqlParameter(); // instanciamos
                URL.ParameterName = "@proveedor_url"; // nombre de variable
                URL.SqlDbType = SqlDbType.Text; // tipo de variable
                URL.Size = 300; // Tamaño de variable
                URL.Value = ProveedorNew.Proveedor_email; // valor de la variable
                SQL_comando.Parameters.Add(URL); // Añadimos al comando

                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar el proveedor";
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
        public string Edit(DB_proveedores ProveedorEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTproveedores";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDPROVEEDOR = new SqlParameter();
                IDPROVEEDOR.ParameterName = "@idproveedor";
                IDPROVEEDOR.SqlDbType = SqlDbType.Int;
                IDPROVEEDOR.Size = 250;
                IDPROVEEDOR.Value = ProveedorEdit.Proveedor_id;
                SQL_comando.Parameters.Add(IDPROVEEDOR);

                SqlParameter TIPODOCUMENTO = new SqlParameter(); // instanciamos
                TIPODOCUMENTO.ParameterName = "@tipo_documento_id"; // nombre de variable
                TIPODOCUMENTO.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPODOCUMENTO.Size = 256;
                TIPODOCUMENTO.Value = ProveedorEdit.Tipo_documento_id;
                SQL_comando.Parameters.Add(TIPODOCUMENTO); // Añadimos al comando

                SqlParameter RAZONSOCIAL = new SqlParameter(); // instanciamos
                RAZONSOCIAL.ParameterName = "@proveedor_razon_social"; // nombre de variable
                RAZONSOCIAL.SqlDbType = SqlDbType.VarChar; // tipo de variable
                RAZONSOCIAL.Size = 500; // Tamaño de variable
                RAZONSOCIAL.Value = ProveedorEdit.Proveedor_razon_social; // valor de la variable
                SQL_comando.Parameters.Add(RAZONSOCIAL); // Añadimos al comando

                SqlParameter Cedula = new SqlParameter(); // instanciamos
                Cedula.ParameterName = "@proveedor_dni"; // nombre de variable
                Cedula.SqlDbType = SqlDbType.VarChar; // tipo de variable
                Cedula.Size = 20;
                Cedula.Value = ProveedorEdit.Proveedor_dni;
                SQL_comando.Parameters.Add(Cedula); // Añadimos al comando

                SqlParameter DIRECCION = new SqlParameter(); // instanciamos
                DIRECCION.ParameterName = "@proveedor_direccion"; // nombre de variable
                DIRECCION.SqlDbType = SqlDbType.Text; // tipo de variable
                DIRECCION.Size = 300; // Tamaño de variable
                DIRECCION.Value = ProveedorEdit.Proveedor_direccion; // valor de la variable
                SQL_comando.Parameters.Add(DIRECCION); // Añadimos al comando         

                SqlParameter CORREO = new SqlParameter(); // instanciamos
                CORREO.ParameterName = "@proveedor_email"; // nombre de variable
                CORREO.SqlDbType = SqlDbType.Text; // tipo de variable
                CORREO.Size = 300; // Tamaño de variable
                CORREO.Value = ProveedorEdit.Proveedor_email; // valor de la variable
                SQL_comando.Parameters.Add(CORREO); // Añadimos al comando

                SqlParameter TELEFONO = new SqlParameter(); // instanciamos
                TELEFONO.ParameterName = "@proveedor_telefono"; // nombre de variable
                TELEFONO.SqlDbType = SqlDbType.Int; // tipo de variable
                TELEFONO.Size = 50;
                TELEFONO.Value = ProveedorEdit.Proveedor_telefono;
                SQL_comando.Parameters.Add(TELEFONO); // Añadimos al comando

                SqlParameter URL = new SqlParameter(); // instanciamos
                URL.ParameterName = "@proveedor_url"; // nombre de variable
                URL.SqlDbType = SqlDbType.Text; // tipo de variable
                URL.Size = 300; // Tamaño de variable
                URL.Value = ProveedorEdit.Proveedor_email; // valor de la variable
                SQL_comando.Parameters.Add(URL); // Añadimos al comando

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar el proveedor";
            } catch (Exception error) {
                respuesta = error.Message;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }

        // DELETE
        public string Delete(DB_proveedores ProveedorDelete)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEproveedores";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDPROVEEDOR = new SqlParameter();
                IDPROVEEDOR.ParameterName = "@idproveedor";
                IDPROVEEDOR.SqlDbType = SqlDbType.Int;
                IDPROVEEDOR.Size = 250;
                IDPROVEEDOR.Value = ProveedorDelete.Proveedor_id;
                SQL_comando.Parameters.Add(IDPROVEEDOR);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar el proveedor";
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }


    }
}
