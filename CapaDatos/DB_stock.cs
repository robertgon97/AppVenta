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
    public class DB_stock
    {
        private int _stock_id;
        private int _articulo_id;
        private int _stock_cantidad;
        private string _search_value;
        
        public int Stock_id
        {
            get { return _stock_id; }
            set { _stock_id = value; }
        }

        public int Articulo_id
        {
            get { return _articulo_id; }
            set { _articulo_id = value; }
        }

        public int Stock_cantidad
        {
            get { return _stock_cantidad; }
            set { _stock_cantidad = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_stock()
        {
            //
        }

        public DB_stock(int _stock_id, int _articulo_id, int _stock_cantidad, string _search_value)
        {
            this._stock_id = _stock_id;
            this._articulo_id = _articulo_id;
            this._stock_cantidad = _stock_cantidad;
            this._search_value = _search_value;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllStock = new DataTable("stock");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_stock";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllStock);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllStock = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllStock;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_stock StockSearch)
        {
            string respuesta = "";
            DataTable AllStock = new DataTable("stock");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_stock";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = StockSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllStock);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllStock = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllStock;
        }

        // GET ID
        public DataTable GetStockID(DB_stock StockID)
        {
            string respuesta = "";
            DataTable AllStock = new DataTable("stock");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_stock";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter ID = new SqlParameter();
                ID.ParameterName = "@idstock";
                ID.SqlDbType = SqlDbType.Int;
                ID.Size = 256;
                ID.Value = StockID.Stock_id;
                SQL_comando.Parameters.Add(ID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllStock);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllStock = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllStock;
        }

        // INSERT
        public string Create(DB_stock StockNew)
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
                SQL_comando.CommandText = "POSTstock"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter StockID = new SqlParameter(); // instanciamos
                StockID.ParameterName = "@idstock"; // nombre de variable
                StockID.SqlDbType = SqlDbType.Int; // tipo de variable
                StockID.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(StockID); // Añadimos al comando

                SqlParameter ARTICULO = new SqlParameter(); // instanciamos
                ARTICULO.ParameterName = "@articulo_id"; // nombre de variable
                ARTICULO.SqlDbType = SqlDbType.Int; // tipo de variable
                ARTICULO.Size = 256;
                ARTICULO.Value = StockNew.Stock_id;
                SQL_comando.Parameters.Add(ARTICULO); // Añadimos al comando

                SqlParameter CANTIDAD = new SqlParameter(); // instanciamos
                CANTIDAD.ParameterName = "@stock_cantidad"; // nombre de variable
                CANTIDAD.SqlDbType = SqlDbType.Int; // tipo de variable
                CANTIDAD.Size = 256;
                CANTIDAD.Value = StockNew.Stock_id; // valor de la variable
                SQL_comando.Parameters.Add(CANTIDAD); // Añadimos al comando         
                

                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar la cantidad de articulos al stock";
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
        public string Edit(DB_stock StockEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTstock";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter StockID = new SqlParameter();
                StockID.ParameterName = "@idstock";
                StockID.SqlDbType = SqlDbType.Int;
                StockID.Size = 250;
                StockID.Value = StockEdit.Stock_id;
                SQL_comando.Parameters.Add(StockID);

                SqlParameter ARTICULO = new SqlParameter(); // instanciamos
                ARTICULO.ParameterName = "@articulo_id"; // nombre de variable
                ARTICULO.SqlDbType = SqlDbType.Int; // tipo de variable
                ARTICULO.Size = 256;
                ARTICULO.Value = StockEdit.Stock_id;
                SQL_comando.Parameters.Add(ARTICULO); // Añadimos al comando

                SqlParameter CANTIDAD = new SqlParameter(); // instanciamos
                CANTIDAD.ParameterName = "@stock_cantidad"; // nombre de variable
                CANTIDAD.SqlDbType = SqlDbType.Int; // tipo de variable
                CANTIDAD.Size = 256;
                CANTIDAD.Value = StockEdit.Stock_id; // valor de la variable
                SQL_comando.Parameters.Add(CANTIDAD); // Añadimos al comando   

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar la cantidad de articulos en el stock";
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
        public string Delete(DB_stock StockDelete)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEstock";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter StockID = new SqlParameter();
                StockID.ParameterName = "@idstock";
                StockID.SqlDbType = SqlDbType.Int;
                StockID.Size = 250;
                StockID.Value = StockDelete.Stock_id;
                SQL_comando.Parameters.Add(StockID);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar las cantidades del articulo del stock";
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
