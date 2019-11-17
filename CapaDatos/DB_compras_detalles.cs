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
    public class DB_compras_detalles
    {
        private int _compra_detalle_id;
        private int _compra_id;
        private int _stock_id;
        private int _compra_detalle_cantidad;
        private decimal _compra_detalle_precio_unidad;
        private decimal _compra_detalle_precio_total;
        private string _search_value;
        
        public int Compra_detalle_id
        {
            get { return _compra_detalle_id; }
            set { _compra_detalle_id = value; }
        }

        public int Compra_id
        {
            get { return _compra_id; }
            set { _compra_id = value; }
        }

        public int Stock_id
        {
            get { return _stock_id; }
            set { _stock_id = value; }
        }

        public int Compra_detalle_cantidad
        {
            get { return _compra_detalle_cantidad; }
            set { _compra_detalle_cantidad = value; }
        }

        public decimal Compra_detalle_precio_unidad
        {
            get { return _compra_detalle_precio_unidad; }
            set { _compra_detalle_precio_unidad = value; }
        }

        public decimal Compra_detalle_precio_total
        {
            get { return _compra_detalle_cantidad * _compra_detalle_precio_unidad; }
            set { _compra_detalle_precio_total = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Contructor Vacio
        public DB_compras_detalles()
        {
            //
        }

        public DB_compras_detalles(int _compra_detalle_id, int _compra_id, int _stock_id, int _compra_detalle_cantidad, decimal _compra_detalle_precio_unidad, decimal _compra_detalle_precio_total, string _search_value)
        {
            this._compra_detalle_id = _compra_detalle_id;
            this._compra_id = _compra_id;
            this._stock_id = _stock_id;
            this._compra_detalle_cantidad = _compra_detalle_cantidad;
            this._compra_detalle_precio_unidad = _compra_detalle_precio_unidad;
            this._compra_detalle_precio_total = _compra_detalle_precio_total;
            this._search_value = _search_value;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllComprasDetalles = new DataTable("compras_detalles");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_compras_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllComprasDetalles);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllComprasDetalles = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllComprasDetalles;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_compras_detalles DetalleCompraSearch)
        {
            string respuesta = "";
            DataTable AllComprasDetalles = new DataTable("compras_detalles");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_compras_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = DetalleCompraSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllComprasDetalles);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllComprasDetalles = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllComprasDetalles;
        }

        // GET ID
        public DataTable GetDetalleID(DB_compras_detalles DetalleCompraID)
        {
            string respuesta = "";
            DataTable AllComprasDetalles = new DataTable("compras_detalles");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_compras_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@idcompra_detalle";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 256;
                DetalleID.Value = DetalleCompraID.Compra_detalle_id;
                SQL_comando.Parameters.Add(DetalleID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllComprasDetalles);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllComprasDetalles = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllComprasDetalles;
        }

        // INSERT
        public string Create(DB_compras_detalles DetalleNew)
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
                SQL_comando.CommandText = "POSTcompras_detalles"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter DETALLE = new SqlParameter(); // instanciamos
                DETALLE.ParameterName = "@idcompra_detalle"; // nombre de variable
                DETALLE.SqlDbType = SqlDbType.Int; // tipo de variable
                DETALLE.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(DETALLE); // Añadimos al comando

                SqlParameter COMPRA = new SqlParameter(); // instanciamos
                COMPRA.ParameterName = "@compra_id"; // nombre de variable
                COMPRA.SqlDbType = SqlDbType.Int; // tipo de variable
                COMPRA.Size = 256;
                COMPRA.Value = DetalleNew.Compra_id;
                SQL_comando.Parameters.Add(COMPRA); // Añadimos al comando

                SqlParameter STOCK = new SqlParameter(); // instanciamos
                STOCK.ParameterName = "@stock_id"; // nombre de variable
                STOCK.SqlDbType = SqlDbType.Int; // tipo de variable
                STOCK.Size = 256;
                STOCK.Value = DetalleNew.Stock_id; // valor de la variable
                SQL_comando.Parameters.Add(STOCK); // Añadimos al comando         

                SqlParameter CANTIDAD = new SqlParameter(); // instanciamos
                CANTIDAD.ParameterName = "@compra_detalle_cantidad"; // nombre de variable
                CANTIDAD.SqlDbType = SqlDbType.Int; // tipo de variable
                CANTIDAD.Size = 120; // Tamaño de variable
                CANTIDAD.Value = DetalleNew.Compra_detalle_cantidad; // valor de la variable
                SQL_comando.Parameters.Add(CANTIDAD); // Añadimos al comando

                SqlParameter PRECIO = new SqlParameter(); // instanciamos
                PRECIO.ParameterName = "@compra_detalle_precio_unidad"; // nombre de variable
                PRECIO.SqlDbType = SqlDbType.Decimal; // tipo de variable
                PRECIO.Size = 256;
                PRECIO.Value = DetalleNew.Compra_detalle_precio_unidad;
                SQL_comando.Parameters.Add(PRECIO); // Añadimos al comando

                SqlParameter TOTAL = new SqlParameter(); // instanciamos
                TOTAL.ParameterName = "@compra_detalle_precio_total"; // nombre de variable
                TOTAL.SqlDbType = SqlDbType.Decimal; // tipo de variable
                TOTAL.Size = 256;
                TOTAL.Value = DetalleNew.Compra_detalle_precio_total;
                SQL_comando.Parameters.Add(TOTAL); // Añadimos al comando

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

        // EDIT
        public string Edit(DB_compras_detalles DetalleEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTcompras_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DETALLE = new SqlParameter();
                DETALLE.ParameterName = "@idcompra_detalle";
                DETALLE.SqlDbType = SqlDbType.Int;
                DETALLE.Size = 250;
                DETALLE.Value = DetalleEdit.Compra_detalle_id;
                SQL_comando.Parameters.Add(DETALLE);

                SqlParameter COMPRA = new SqlParameter(); // instanciamos
                COMPRA.ParameterName = "@compra_id"; // nombre de variable
                COMPRA.SqlDbType = SqlDbType.Int; // tipo de variable
                COMPRA.Size = 256;
                COMPRA.Value = DetalleEdit.Compra_id;
                SQL_comando.Parameters.Add(COMPRA); // Añadimos al comando

                SqlParameter STOCK = new SqlParameter(); // instanciamos
                STOCK.ParameterName = "@stock_id"; // nombre de variable
                STOCK.SqlDbType = SqlDbType.Int; // tipo de variable
                STOCK.Size = 256;
                STOCK.Value = DetalleEdit.Stock_id; // valor de la variable
                SQL_comando.Parameters.Add(STOCK); // Añadimos al comando         

                SqlParameter CANTIDAD = new SqlParameter(); // instanciamos
                CANTIDAD.ParameterName = "@compra_detalle_cantidad"; // nombre de variable
                CANTIDAD.SqlDbType = SqlDbType.Int; // tipo de variable
                CANTIDAD.Size = 120; // Tamaño de variable
                CANTIDAD.Value = DetalleEdit.Compra_detalle_cantidad; // valor de la variable
                SQL_comando.Parameters.Add(CANTIDAD); // Añadimos al comando

                SqlParameter PRECIO = new SqlParameter(); // instanciamos
                PRECIO.ParameterName = "@compra_detalle_precio_unidad"; // nombre de variable
                PRECIO.SqlDbType = SqlDbType.Decimal; // tipo de variable
                PRECIO.Size = 256;
                PRECIO.Value = DetalleEdit.Compra_detalle_precio_unidad;
                SQL_comando.Parameters.Add(PRECIO); // Añadimos al comando

                SqlParameter TOTAL = new SqlParameter(); // instanciamos
                TOTAL.ParameterName = "@compra_detalle_precio_total"; // nombre de variable
                TOTAL.SqlDbType = SqlDbType.Decimal; // tipo de variable
                TOTAL.Size = 256;
                TOTAL.Value = DetalleEdit.Compra_detalle_precio_total;
                SQL_comando.Parameters.Add(TOTAL); // Añadimos al comando

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar el item del carrito";
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
        public string Delete(DB_compras_detalles DetalleDelte)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEcompras_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DETALLE = new SqlParameter();
                DETALLE.ParameterName = "@idcompra_detalle";
                DETALLE.SqlDbType = SqlDbType.Int;
                DETALLE.Size = 250;
                DETALLE.Value = DetalleDelte.Compra_detalle_id;
                SQL_comando.Parameters.Add(DETALLE);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar el item del carrito";
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
