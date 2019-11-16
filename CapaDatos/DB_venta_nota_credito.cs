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
    public class DB_venta_nota_credito
    {
        private int _venta_cliente_nota_credito_id;
        private int _venta_id;
        private string _venta_cliente_nota_credito_fecha;
        private decimal _venta_cliente_nota_credito_gastado;
        private int _venta_cliente_nota_credito_valido;
        private string _search_value;
        
        public int Venta_cliente_nota_credito_id
        {
            get { return _venta_cliente_nota_credito_id; }
            set { _venta_cliente_nota_credito_id = value; }
        }

        public int Venta_id
        {
            get { return _venta_id; }
            set { _venta_id = value; }
        }

        public string Venta_cliente_nota_credito_fecha
        {
            get { return _venta_cliente_nota_credito_fecha; }
            set { _venta_cliente_nota_credito_fecha = value; }
        }

        public decimal Venta_cliente_nota_credito_gastado
        {
            get { return _venta_cliente_nota_credito_gastado; }
            set { _venta_cliente_nota_credito_gastado = value; }
        }

        public int Venta_cliente_nota_credito_valido
        {
            get { return _venta_cliente_nota_credito_valido; }
            set { _venta_cliente_nota_credito_valido = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_venta_nota_credito()
        {
            //
        }

        public DB_venta_nota_credito(int _venta_cliente_nota_credito_id, int _venta_id, string _venta_cliente_nota_credito_fecha, decimal _venta_cliente_nota_credito_gastado, int _venta_cliente_nota_credito_valido, string _search_value)
        {
            this._venta_cliente_nota_credito_id = _venta_cliente_nota_credito_id;
            this._venta_id = _venta_id;
            this._venta_cliente_nota_credito_fecha = _venta_cliente_nota_credito_fecha;
            this._venta_cliente_nota_credito_gastado = _venta_cliente_nota_credito_gastado;
            this._venta_cliente_nota_credito_valido = _venta_cliente_nota_credito_valido;
            this._search_value = _search_value;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllNotasCreditos = new DataTable("venta_cliente_nota_credito");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_venta_cliente_nota_credito";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllNotasCreditos);

            } catch (Exception error) {
                respuesta = error.Message;
                AllNotasCreditos = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllNotasCreditos;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_venta_nota_credito NotaCreditoSearch)
        {
            string respuesta = "";
            DataTable AllNotasCreditos = new DataTable("venta_cliente_nota_credito");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_venta_cliente_nota_credito";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = NotaCreditoSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllNotasCreditos);

            } catch (Exception error) {
                respuesta = error.Message;
                AllNotasCreditos = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllNotasCreditos;
        }

        // GET ID
        public DataTable GetNOTAID(DB_venta_nota_credito NotaCreditoID)
        {
            string respuesta = "";
            DataTable AllNotasCreditos = new DataTable("venta_cliente_nota_credito");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_venta_cliente_nota_credito";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter NOTAID = new SqlParameter();
                NOTAID.ParameterName = "@idventa_cliente_nota_credito";
                NOTAID.SqlDbType = SqlDbType.Int;
                NOTAID.Size = 256;
                NOTAID.Value = NotaCreditoID.Venta_cliente_nota_credito_id;
                SQL_comando.Parameters.Add(NOTAID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllNotasCreditos);

            } catch (Exception error) {
                respuesta = error.Message;
                AllNotasCreditos = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllNotasCreditos;
        }

        // INSERT
        public string Create(DB_venta_nota_credito NotaCreditoNew)
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
                SQL_comando.CommandText = "POSTventa_cliente_nota_credito"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter NOTAID = new SqlParameter(); // instanciamos
                NOTAID.ParameterName = "@idventa_cliente_nota_credito"; // nombre de variable
                NOTAID.SqlDbType = SqlDbType.Int; // tipo de variable
                NOTAID.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(NOTAID); // Añadimos al comando

                SqlParameter IDVENTA = new SqlParameter(); // instanciamos
                IDVENTA.ParameterName = "@venta_id"; // nombre de variable
                IDVENTA.SqlDbType = SqlDbType.Int; // tipo de variable
                IDVENTA.Size = 256;
                IDVENTA.Value = NotaCreditoNew.Venta_id;
                SQL_comando.Parameters.Add(IDVENTA); // Añadimos al comando
                
                SqlParameter FECHA = new SqlParameter(); // instanciamos
                FECHA.ParameterName = "@venta_cliente_nota_credito_fecha"; // nombre de variable
                FECHA.SqlDbType = SqlDbType.Date; // tipo de variable
                FECHA.Value = NotaCreditoNew.Venta_cliente_nota_credito_fecha; // valor de la variable
                SQL_comando.Parameters.Add(FECHA); // Añadimos al comando         

                SqlParameter GASTADO = new SqlParameter(); // instanciamos
                GASTADO.ParameterName = "@venta_cliente_nota_credito_gastado"; // nombre de variable
                GASTADO.SqlDbType = SqlDbType.Decimal; // tipo de variable
                GASTADO.Size = 300; // Tamaño de variable
                GASTADO.Value = NotaCreditoNew.Venta_cliente_nota_credito_gastado; // valor de la variable
                SQL_comando.Parameters.Add(GASTADO); // Añadimos al comando

                SqlParameter VALIDO = new SqlParameter(); // instanciamos
                VALIDO.ParameterName = "@venta_cliente_nota_credito_valido"; // nombre de variable
                VALIDO.SqlDbType = SqlDbType.Int; // tipo de variable
                VALIDO.Size = 1;
                VALIDO.Value = NotaCreditoNew.Venta_cliente_nota_credito_valido;
                SQL_comando.Parameters.Add(VALIDO); // Añadimos al comando

                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar la nota de credito";
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
        public string Edit(DB_venta_nota_credito NotaCreditoEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTventa_cliente_nota_credito";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter NOTAID = new SqlParameter();
                NOTAID.ParameterName = "@idventa_cliente_nota_credito";
                NOTAID.SqlDbType = SqlDbType.Int;
                NOTAID.Size = 250;
                NOTAID.Value = NotaCreditoEdit.Venta_cliente_nota_credito_id;
                SQL_comando.Parameters.Add(NOTAID);

                SqlParameter IDVENTA = new SqlParameter(); // instanciamos
                IDVENTA.ParameterName = "@venta_id"; // nombre de variable
                IDVENTA.SqlDbType = SqlDbType.Int; // tipo de variable
                IDVENTA.Size = 256;
                IDVENTA.Value = NotaCreditoEdit.Venta_id;
                SQL_comando.Parameters.Add(IDVENTA); // Añadimos al comando

                SqlParameter FECHA = new SqlParameter(); // instanciamos
                FECHA.ParameterName = "@venta_cliente_nota_credito_fecha"; // nombre de variable
                FECHA.SqlDbType = SqlDbType.Date; // tipo de variable
                FECHA.Value = NotaCreditoEdit.Venta_cliente_nota_credito_fecha; // valor de la variable
                SQL_comando.Parameters.Add(FECHA); // Añadimos al comando         

                SqlParameter GASTADO = new SqlParameter(); // instanciamos
                GASTADO.ParameterName = "@venta_cliente_nota_credito_gastado"; // nombre de variable
                GASTADO.SqlDbType = SqlDbType.Decimal; // tipo de variable
                GASTADO.Size = 300; // Tamaño de variable
                GASTADO.Value = NotaCreditoEdit.Venta_cliente_nota_credito_gastado; // valor de la variable
                SQL_comando.Parameters.Add(GASTADO); // Añadimos al comando

                SqlParameter VALIDO = new SqlParameter(); // instanciamos
                VALIDO.ParameterName = "@venta_cliente_nota_credito_valido"; // nombre de variable
                VALIDO.SqlDbType = SqlDbType.Int; // tipo de variable
                VALIDO.Size = 1;
                VALIDO.Value = NotaCreditoEdit.Venta_cliente_nota_credito_valido;
                SQL_comando.Parameters.Add(VALIDO); // Añadimos al comando

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar la nota de credito";
            } catch (Exception error) {
                respuesta = error.Message;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }

        // DELETE
        public string Delete(DB_venta_nota_credito NotaCreditoDelete)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEventa_cliente_nota_credito";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter NOTAID = new SqlParameter();
                NOTAID.ParameterName = "@idventa_cliente_nota_credito";
                NOTAID.SqlDbType = SqlDbType.Int;
                NOTAID.Size = 250;
                NOTAID.Value = NotaCreditoDelete.Venta_cliente_nota_credito_id;
                SQL_comando.Parameters.Add(NOTAID);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar la nota de credito";
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
