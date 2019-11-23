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
    public class DB_tipo_documento
    {
        private int _tipo_documento_id;
        private string _tipo_documento_letra;
        private string _tipo_documento_nombre;

       public int Tipo_documento_id
        {
            get { return _tipo_documento_id; }
            set { _tipo_documento_id = value; }
        }

        public string Tipo_documento_letra
        {
            get { return _tipo_documento_letra; }
            set { _tipo_documento_letra = value; }
        }

        public string Tipo_documento_nombre
        {
            get { return _tipo_documento_nombre; }
            set { _tipo_documento_nombre = value; }
        }

        // Constructor Vacio
        public DB_tipo_documento()
        {
            //
        }

        public DB_tipo_documento(int _tipo_documento_id, string _tipo_documento_letra, string _tipo_documento_nombre)
        {
            this.Tipo_documento_id = _tipo_documento_id;
            this.Tipo_documento_letra = _tipo_documento_letra;
            this.Tipo_documento_nombre = _tipo_documento_nombre;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllDocumentos = new DataTable("tipo_documento");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ALL_tipo_documento";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllDocumentos);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllDocumentos = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllDocumentos;
        }

        // GET ID
        public DataTable GetDetalleID(DB_tipo_documento DocumentoID)
        {
            string respuesta = "";
            DataTable AllDocumentos = new DataTable("tipo_documento");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_tipo_documento";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@idtipo_documento";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 256;
                DetalleID.Value = DocumentoID.Tipo_documento_id;
                SQL_comando.Parameters.Add(DetalleID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllDocumentos);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllDocumentos = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllDocumentos;
        }
    }
}
