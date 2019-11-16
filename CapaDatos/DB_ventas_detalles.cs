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
    public class DB_ventas_detalles
    {
        private int _detalle_venta_id;
        private int _venta_id;
        private int _stock_id;
        private int _detalle_venta_cantidad;
        private decimal _detalle_venta_precio_unidad;
        private decimal _detalle_venta_precio_total;
        private string _search_value;
        
        public int Detalle_venta_id
        {
            get { return _detalle_venta_id; }
            set { _detalle_venta_id = value; }
        }

        public int Venta_id
        {
            get { return _venta_id; }
            set { _venta_id = value; }
        }

        public int Stock_id
        {
            get { return _stock_id; }
            set { _stock_id = value; }
        }

        public int Detalle_venta_cantidad
        {
            get { return _detalle_venta_cantidad; }
            set { _detalle_venta_cantidad = value; }
        }

        public decimal Detalle_venta_precio_unidad
        {
            get { return _detalle_venta_precio_unidad; }
            set { _detalle_venta_precio_unidad = value; }
        }

        public decimal Detalle_venta_precio_total
        {
            get {
                decimal total = _detalle_venta_cantidad * _detalle_venta_precio_unidad;
                return total;
            }
            set { _detalle_venta_precio_total = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_ventas_detalles()
        {
            //
        }

        public DB_ventas_detalles(int _detalle_venta_id, int _venta_id, int _stock_id, int _detalle_venta_cantidad, decimal _detalle_venta_precio_unidad, decimal _detalle_venta_precio_total, string _search_value)
        {
            this._detalle_venta_id = _detalle_venta_id;
            this._venta_id = _venta_id;
            this._stock_id = _stock_id;
            this._detalle_venta_cantidad = _detalle_venta_cantidad;
            this._detalle_venta_precio_unidad = _detalle_venta_precio_unidad;
            this._detalle_venta_precio_total = _detalle_venta_precio_total;
            this._search_value = _search_value;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllVentasDetalles = new DataTable("ventas_detalles");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ventas_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllVentasDetalles);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllVentasDetalles = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllVentasDetalles;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_ventas_detalles NotaCreditoSearch)
        {
            string respuesta = "";
            DataTable AllVentasDetalles = new DataTable("ventas_detalles");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_ventas_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = NotaCreditoSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllVentasDetalles);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllVentasDetalles = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllVentasDetalles;
        }

        // GET ID
        public DataTable GetDetalleID(DB_ventas_detalles NotaCreditoID)
        {
            string respuesta = "";
            DataTable AllVentasDetalles = new DataTable("ventas_detalles");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_ventas_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@iddetalle_venta";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 256;
                DetalleID.Value = NotaCreditoID.Detalle_venta_id;
                SQL_comando.Parameters.Add(DetalleID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllVentasDetalles);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllVentasDetalles = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllVentasDetalles;
        }

        // INSERT
        public string Create(DB_ventas_detalles DetalleNew)
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
                SQL_comando.CommandText = "POSTventas_detalles"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter DetalleID = new SqlParameter(); // instanciamos
                DetalleID.ParameterName = "@iddetalle_venta"; // nombre de variable
                DetalleID.SqlDbType = SqlDbType.Int; // tipo de variable
                DetalleID.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(DetalleID); // Añadimos al comando

                SqlParameter IDVENTA = new SqlParameter(); // instanciamos
                IDVENTA.ParameterName = "@venta_id"; // nombre de variable
                IDVENTA.SqlDbType = SqlDbType.Int; // tipo de variable
                IDVENTA.Size = 256;
                IDVENTA.Value = DetalleNew.Venta_id;
                SQL_comando.Parameters.Add(IDVENTA); // Añadimos al comando

                SqlParameter STOCK = new SqlParameter(); // instanciamos
                STOCK.ParameterName = "@stock_id"; // nombre de variable
                STOCK.SqlDbType = SqlDbType.Int; // tipo de variable
                STOCK.Size = 256;
                STOCK.Value = DetalleNew.Stock_id; // valor de la variable
                SQL_comando.Parameters.Add(STOCK); // Añadimos al comando         

                SqlParameter CANTIDAD = new SqlParameter(); // instanciamos
                CANTIDAD.ParameterName = "@detalle_venta_cantidad"; // nombre de variable
                CANTIDAD.SqlDbType = SqlDbType.Int; // tipo de variable
                CANTIDAD.Size = 120; // Tamaño de variable
                CANTIDAD.Value = DetalleNew.Detalle_venta_cantidad; // valor de la variable
                SQL_comando.Parameters.Add(CANTIDAD); // Añadimos al comando

                SqlParameter PRECIO = new SqlParameter(); // instanciamos
                PRECIO.ParameterName = "@detalle_venta_precio_unidad"; // nombre de variable
                PRECIO.SqlDbType = SqlDbType.Decimal; // tipo de variable
                PRECIO.Size = 256;
                PRECIO.Value = DetalleNew.Detalle_venta_precio_unidad;
                SQL_comando.Parameters.Add(PRECIO); // Añadimos al comando

                SqlParameter TOTAL = new SqlParameter(); // instanciamos
                TOTAL.ParameterName = "@detalle_venta_precio_total"; // nombre de variable
                TOTAL.SqlDbType = SqlDbType.Decimal; // tipo de variable
                TOTAL.Size = 256;
                TOTAL.Value = DetalleNew.Detalle_venta_precio_total;
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
        public string Edit(DB_ventas_detalles DetalleEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTventas_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@iddetalle_venta";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 250;
                DetalleID.Value = DetalleEdit.Detalle_venta_id;
                SQL_comando.Parameters.Add(DetalleID);

                SqlParameter IDVENTA = new SqlParameter(); // instanciamos
                IDVENTA.ParameterName = "@venta_id"; // nombre de variable
                IDVENTA.SqlDbType = SqlDbType.Int; // tipo de variable
                IDVENTA.Size = 256;
                IDVENTA.Value = DetalleEdit.Venta_id;
                SQL_comando.Parameters.Add(IDVENTA); // Añadimos al comando

                SqlParameter STOCK = new SqlParameter(); // instanciamos
                STOCK.ParameterName = "@stock_id"; // nombre de variable
                STOCK.SqlDbType = SqlDbType.Int; // tipo de variable
                STOCK.Size = 256;
                STOCK.Value = DetalleEdit.Stock_id; // valor de la variable
                SQL_comando.Parameters.Add(STOCK); // Añadimos al comando         

                SqlParameter CANTIDAD = new SqlParameter(); // instanciamos
                CANTIDAD.ParameterName = "@detalle_venta_cantidad"; // nombre de variable
                CANTIDAD.SqlDbType = SqlDbType.Int; // tipo de variable
                CANTIDAD.Size = 120; // Tamaño de variable
                CANTIDAD.Value = DetalleEdit.Detalle_venta_cantidad; // valor de la variable
                SQL_comando.Parameters.Add(CANTIDAD); // Añadimos al comando

                SqlParameter PRECIO = new SqlParameter(); // instanciamos
                PRECIO.ParameterName = "@detalle_venta_precio_unidad"; // nombre de variable
                PRECIO.SqlDbType = SqlDbType.Decimal; // tipo de variable
                PRECIO.Size = 256;
                PRECIO.Value = DetalleEdit.Detalle_venta_precio_unidad;
                SQL_comando.Parameters.Add(PRECIO); // Añadimos al comando

                SqlParameter TOTAL = new SqlParameter(); // instanciamos
                TOTAL.ParameterName = "@detalle_venta_precio_total"; // nombre de variable
                TOTAL.SqlDbType = SqlDbType.Decimal; // tipo de variable
                TOTAL.Size = 256;
                TOTAL.Value = DetalleEdit.Detalle_venta_precio_total;
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
        public string Delete(DB_ventas_detalles DetalleDelte)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEventas_detalles";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@iddetalle_venta";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 250;
                DetalleID.Value = DetalleDelte.Detalle_venta_id;
                SQL_comando.Parameters.Add(DetalleID);

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
