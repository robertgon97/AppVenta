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
    class DB_preguntas
    {
        private int _usuarios_pregunta_seguridad_id;
        private int _usuario_id;
        private string _usuarios_pregunta_seguridad_pregunta;
        private string _usuarios_pregunta_seguridad_respuesta;
        private string _search_value;

        private string Encriptar(string valor)
        {
            valor = "ASDFGHJKLOIUYTREWQASDFGESASDASDASDWQECVSDFSDFSDFSFSZDFSDFSF";
            return valor;
        }

        private string Descriptar(string valor)
        {
            valor = "DESENCRIPTE";
            return valor;
        }

        public int Usuarios_pregunta_seguridad_id
        {
            get { return _usuarios_pregunta_seguridad_id; }
            set { _usuarios_pregunta_seguridad_id = value; }
        }

        public int Usuario_id
        {
            get { return _usuario_id; }
            set { _usuario_id = value; }
        }

        public string Usuarios_pregunta_seguridad_pregunta
        {
            get { return _usuarios_pregunta_seguridad_pregunta; }
            set { _usuarios_pregunta_seguridad_pregunta = value; }
        }

        public string Usuarios_pregunta_seguridad_respuesta
        {
            get { return Descriptar(_usuarios_pregunta_seguridad_respuesta); }
            set { _usuarios_pregunta_seguridad_respuesta = Encriptar(value); }
        }

        public string Search_value
        { // Encapsulamiento de _search_value
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_preguntas()
        {
            //
        }

        public DB_preguntas(int id, int iduser, string pregunta, string contrasena, string search)
        {
            this._usuarios_pregunta_seguridad_id = id;
            this._usuario_id = iduser;
            this._usuarios_pregunta_seguridad_pregunta = pregunta;
            this._usuarios_pregunta_seguridad_respuesta = contrasena;
            this._search_value = search;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable ALLPREGUNTAS = new DataTable("usuarios_pregunta_seguridad");
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_usuarios_pregunta_seguridad";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(ALLPREGUNTAS);

            } catch (Exception error) {
                respuesta = error.Message;
                ALLPREGUNTAS = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return ALLPREGUNTAS;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_preguntas PreguntaSearch)
        {
            string respuesta = "";
            DataTable ALLPREGUNTAS = new DataTable("usuarios_pregunta_seguridad");
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_usuarios_pregunta_seguridad";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = PreguntaSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(ALLPREGUNTAS);

            } catch (Exception error) {
                respuesta = error.Message;
                ALLPREGUNTAS = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return ALLPREGUNTAS;
        }

        // GET ID
        public DataTable GetIdPregunta(DB_preguntas PreguntaID)
        {
            string respuesta = "";
            DataTable ALLPREGUNTAS = new DataTable("usuarios_pregunta_seguridad");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_usuarios_pregunta_seguridad";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDPREGUTNA = new SqlParameter();
                IDPREGUTNA.ParameterName = "@idpregunta";
                IDPREGUTNA.SqlDbType = SqlDbType.Int;
                IDPREGUTNA.Size = 256;
                IDPREGUTNA.Value = PreguntaID.Usuarios_pregunta_seguridad_id;
                SQL_comando.Parameters.Add(IDPREGUTNA);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(ALLPREGUNTAS);

            } catch (Exception error) {
                respuesta = error.Message;
                ALLPREGUNTAS = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return ALLPREGUNTAS;
        }

        // GET IDUSER
        public DataTable GetAllPreguntaByUser(DB_preguntas PreguntaUser)
        {
            string respuesta = "";
            DataTable ALLPREGUNTAS = new DataTable("usuarios_pregunta_seguridad");
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_BY_usuarios_pregunta_seguridad";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDPREGUTNA = new SqlParameter();
                IDPREGUTNA.ParameterName = "@usuario";
                IDPREGUTNA.SqlDbType = SqlDbType.Int;
                IDPREGUTNA.Size = 256;
                IDPREGUTNA.Value = PreguntaUser.Usuario_id;
                SQL_comando.Parameters.Add(IDPREGUTNA);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(ALLPREGUNTAS);

            } catch (Exception error) {
                respuesta = error.Message;
                ALLPREGUNTAS = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return ALLPREGUNTAS;
        }

        // INSERT
        public string Create(DB_preguntas PreguntNew)
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
                SQL_comando.CommandText = "POSTusuarios_pregunta_seguridad"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter IDPREGUNTA = new SqlParameter(); // instanciamos
                IDPREGUNTA.ParameterName = "@idpregunta"; // nombre de variable
                IDPREGUNTA.SqlDbType = SqlDbType.Int; // tipo de variable
                IDPREGUNTA.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(IDPREGUNTA); // Añadimos al comando

                SqlParameter IDUSER = new SqlParameter(); // instanciamos
                IDUSER.ParameterName = "@usuario"; // nombre de variable
                IDUSER.SqlDbType = SqlDbType.Int; // tipo de variable
                IDUSER.Size = 256;
                IDUSER.Value = PreguntNew.Usuario_id;
                SQL_comando.Parameters.Add(IDUSER); // Añadimos al comando
                
                SqlParameter PREGUNTA = new SqlParameter(); // instanciamos
                PREGUNTA.ParameterName = "@pregunta"; // nombre de variable
                PREGUNTA.SqlDbType = SqlDbType.VarChar; // tipo de variable
                PREGUNTA.Size = 150; // Tamaño de variable
                PREGUNTA.Value = PreguntNew.Usuarios_pregunta_seguridad_pregunta; // Valor de la variable
                SQL_comando.Parameters.Add(PREGUNTA); // Añadimos al comando

                SqlParameter RESPUESTA = new SqlParameter(); // instanciamos
                RESPUESTA.ParameterName = "@respuesta"; // nombre de variable
                RESPUESTA.SqlDbType = SqlDbType.VarChar; // tipo de variable
                RESPUESTA.Size = 500; // Tamaño de variable
                RESPUESTA.Value = PreguntNew.Usuarios_pregunta_seguridad_respuesta; // valor de la variable
                SQL_comando.Parameters.Add(RESPUESTA); // Añadimos al comando
                
                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar la pregunta del usuario";
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
        public string Edit(DB_preguntas PreguntEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTusuarios_pregunta_seguridad";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDPREGUNTA = new SqlParameter();
                IDPREGUNTA.ParameterName = "@idpregunta";
                IDPREGUNTA.SqlDbType = SqlDbType.Int;
                IDPREGUNTA.Size = 250;
                IDPREGUNTA.Value = PreguntEdit.Usuarios_pregunta_seguridad_id;
                SQL_comando.Parameters.Add(IDPREGUNTA);

                SqlParameter IDUSER = new SqlParameter(); // instanciamos
                IDUSER.ParameterName = "@usuario"; // nombre de variable
                IDUSER.SqlDbType = SqlDbType.Int; // tipo de variable
                IDUSER.Size = 256;
                IDUSER.Value = PreguntEdit.Usuario_id;
                SQL_comando.Parameters.Add(IDUSER); // Añadimos al comando

                SqlParameter PREGUNTA = new SqlParameter(); // instanciamos
                PREGUNTA.ParameterName = "@pregunta"; // nombre de variable
                PREGUNTA.SqlDbType = SqlDbType.VarChar; // tipo de variable
                PREGUNTA.Size = 150; // Tamaño de variable
                PREGUNTA.Value = PreguntEdit.Usuarios_pregunta_seguridad_pregunta; // Valor de la variable
                SQL_comando.Parameters.Add(PREGUNTA); // Añadimos al comando

                SqlParameter RESPUESTA = new SqlParameter(); // instanciamos
                RESPUESTA.ParameterName = "@respuesta"; // nombre de variable
                RESPUESTA.SqlDbType = SqlDbType.VarChar; // tipo de variable
                RESPUESTA.Size = 500; // Tamaño de variable
                RESPUESTA.Value = PreguntEdit.Usuarios_pregunta_seguridad_respuesta; // valor de la variable
                SQL_comando.Parameters.Add(RESPUESTA); // Añadimos al comando
                
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar la pregunta";

            } catch (Exception error) {
                respuesta = error.Message;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }

        // DELETE
        public string Delete(DB_preguntas PreguntDelete)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEusuarios_pregunta_seguridad";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDPREGUNTA = new SqlParameter();
                IDPREGUNTA.ParameterName = "@idpregunta";
                IDPREGUNTA.SqlDbType = SqlDbType.Int;
                IDPREGUNTA.Size = 250;
                IDPREGUNTA.Value = PreguntDelete.Usuarios_pregunta_seguridad_id;
                SQL_comando.Parameters.Add(IDPREGUNTA);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar la pregunta de seguridad";
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
