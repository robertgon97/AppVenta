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
    public class DB_auditoria
    {
        private int _auditoria_id;
        private int _usuario_id;
        private string _auditoria_fecha;
        private string _auditoria_accion;
        private string _auditoria_descripcion;
        private string _search_value;
        
        public int Auditoria_id
        {
            get { return _auditoria_id; }
            set { _auditoria_id = value; }
        }

        public int Usuario_id
        {
            get { return _usuario_id; }
            set { _usuario_id = value; }
        }

        public string Auditoria_fecha
        {
            get { return _auditoria_fecha; }
            set { _auditoria_fecha = value; }
        }

        public string Auditoria_accion
        {
            get { return _auditoria_accion; }
            set { _auditoria_accion = value; }
        }

        public string Auditoria_descripcion
        {
            get { return _auditoria_descripcion; }
            set { _auditoria_descripcion = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_auditoria()
        {
            //
        }

        public DB_auditoria(int _auditoria_id, int _usuario_id, string _auditoria_fecha, string _auditoria_accion, string _auditoria_descripcion, string _search_value)
        {
            this._auditoria_id = _auditoria_id;
            this._usuario_id = _usuario_id;
            this._auditoria_fecha = _auditoria_fecha;
            this._auditoria_accion = _auditoria_accion;
            this._auditoria_descripcion = _auditoria_descripcion;
            this._search_value = _search_value;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllAuditorias = new DataTable("auditoria");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_auditoria";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllAuditorias);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllAuditorias = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllAuditorias;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_auditoria AuditoriaSearch)
        {
            string respuesta = "";
            DataTable AllAuditorias = new DataTable("auditoria");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_auditoria";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = AuditoriaSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllAuditorias);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllAuditorias = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllAuditorias;
        }

        // GET ID
        public DataTable GetIdUser(DB_auditoria AuditoriaID)
        {
            string respuesta = "";
            DataTable AllAuditorias = new DataTable("auditoria");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_auditoria";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDAUDITORIAUSER = new SqlParameter();
                IDAUDITORIAUSER.ParameterName = "@idauditoria";
                IDAUDITORIAUSER.SqlDbType = SqlDbType.Int;
                IDAUDITORIAUSER.Size = 256;
                IDAUDITORIAUSER.Value = AuditoriaID.Auditoria_id;
                SQL_comando.Parameters.Add(IDAUDITORIAUSER);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllAuditorias);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllAuditorias = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllAuditorias;
        }

        // INSERT
        public string Create(DB_auditoria AuditoriaNew)
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
                SQL_comando.CommandText = "POSTauditoria"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter AUDITORIAid = new SqlParameter(); // instanciamos
                AUDITORIAid.ParameterName = "@idauditoria"; // nombre de variable
                AUDITORIAid.SqlDbType = SqlDbType.Int; // tipo de variable
                AUDITORIAid.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(AUDITORIAid); // Añadimos al comando

                SqlParameter USER = new SqlParameter(); // instanciamos
                USER.ParameterName = "@usuario_id"; // nombre de variable
                USER.SqlDbType = SqlDbType.Int; // tipo de variable
                USER.Size = 256;
                USER.Value = AuditoriaNew.Usuario_id;
                SQL_comando.Parameters.Add(USER); // Añadimos al comando

                SqlParameter FECHA = new SqlParameter(); // instanciamos
                FECHA.ParameterName = "@auditoria_fecha"; // nombre de variable
                FECHA.SqlDbType = SqlDbType.Date; // tipo de variable
                FECHA.Value = AuditoriaNew.Auditoria_fecha;
                SQL_comando.Parameters.Add(FECHA); // Añadimos al comando

                SqlParameter ACCION = new SqlParameter(); // instanciamos
                ACCION.ParameterName = "@auditoria_accion"; // nombre de variable
                ACCION.SqlDbType = SqlDbType.VarChar; // tipo de variable
                ACCION.Size = 500; // Tamaño de variable
                ACCION.Value = AuditoriaNew.Auditoria_accion; // Valor de la variable
                SQL_comando.Parameters.Add(ACCION); // Añadimos al comando

                SqlParameter DESCRIPCION = new SqlParameter(); // instanciamos
                DESCRIPCION.ParameterName = "@auditoria_descripcion"; // nombre de variable
                DESCRIPCION.SqlDbType = SqlDbType.VarChar; // tipo de variable
                DESCRIPCION.Size = 500; // Tamaño de variable
                DESCRIPCION.Value = AuditoriaNew.Auditoria_descripcion; // Valor de la variable
                SQL_comando.Parameters.Add(DESCRIPCION); // Añadimos al comando

                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar la auditoria";
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

        // EDIT
        public string Edit(DB_auditoria AuditoriaEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTauditoria";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Auditoriaiddd = new SqlParameter();
                Auditoriaiddd.ParameterName = "@idauditoria";
                Auditoriaiddd.SqlDbType = SqlDbType.Int;
                Auditoriaiddd.Size = 250;
                Auditoriaiddd.Value = AuditoriaEdit.Auditoria_id;
                SQL_comando.Parameters.Add(Auditoriaiddd);

                SqlParameter USER = new SqlParameter(); // instanciamos
                USER.ParameterName = "@usuario_id"; // nombre de variable
                USER.SqlDbType = SqlDbType.Int; // tipo de variable
                USER.Size = 256;
                USER.Value = AuditoriaEdit.Usuario_id;
                SQL_comando.Parameters.Add(USER); // Añadimos al comando

                SqlParameter FECHA = new SqlParameter(); // instanciamos
                FECHA.ParameterName = "@auditoria_fecha"; // nombre de variable
                FECHA.SqlDbType = SqlDbType.Date; // tipo de variable
                FECHA.Value = AuditoriaEdit.Auditoria_fecha;
                SQL_comando.Parameters.Add(FECHA); // Añadimos al comando

                SqlParameter ACCION = new SqlParameter(); // instanciamos
                ACCION.ParameterName = "@auditoria_accion"; // nombre de variable
                ACCION.SqlDbType = SqlDbType.VarChar; // tipo de variable
                ACCION.Size = 500; // Tamaño de variable
                ACCION.Value = AuditoriaEdit.Auditoria_accion; // Valor de la variable
                SQL_comando.Parameters.Add(ACCION); // Añadimos al comando

                SqlParameter DESCRIPCION = new SqlParameter(); // instanciamos
                DESCRIPCION.ParameterName = "@auditoria_descripcion"; // nombre de variable
                DESCRIPCION.SqlDbType = SqlDbType.VarChar; // tipo de variable
                DESCRIPCION.Size = 500; // Tamaño de variable
                DESCRIPCION.Value = AuditoriaEdit.Auditoria_descripcion; // Valor de la variable
                SQL_comando.Parameters.Add(DESCRIPCION); // Añadimos al comando

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar la auditoria";
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

        // DELETE
        public string Delete(DB_auditoria AuditoriaDelete)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEauditoria";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Auditoriaiddd = new SqlParameter();
                Auditoriaiddd.ParameterName = "@idauditoria";
                Auditoriaiddd.SqlDbType = SqlDbType.Int;
                Auditoriaiddd.Size = 250;
                Auditoriaiddd.Value = AuditoriaDelete.Auditoria_id;
                SQL_comando.Parameters.Add(Auditoriaiddd);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar la auditoria";
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
