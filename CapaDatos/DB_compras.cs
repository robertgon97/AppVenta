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
    class DB_compras
    {
        private int _compra_id;
        private int _status_id;
        private int _proveedor_id;
        private int _usuario_id;
        private string _compra_correlativo;
        private string _compra_factura;
        private int _compra_anulado;
        private string _compra_fecha;
        private string _compra_serie;
        private int _compra_iva;
        private decimal _compra_total_iva;
        private decimal _compra_total_sin_iva;
        private string _search_value;
        
        private string GetCorrelativo()
        {
            string valor = "ASDFGHJKLOIUYTREWQASDFGESASDASDASDWQECVSDFSDFSDFSFSZDFSDFSF";
            return valor;
        }

        public int Compra_id
        {
            get { return _compra_id; }
            set { _compra_id = value; }
        }

        public int Status_id
        {
            get { return _status_id; }
            set { _status_id = value; }
        }

        public int Proveedor_id
        {
            get { return _proveedor_id; }
            set { _proveedor_id = value; }
        }

        public int Usuario_id
        {
            get { return _usuario_id; }
            set { _usuario_id = value; }
        }

        public string Compra_correlativo
        {
            get {
                // if (_compra_correlativo == null || _compra_correlativo == "") return GetCorrelativo();
                // else return _venta_correlativo;

                if (_compra_correlativo != null || _compra_correlativo != "") return _compra_correlativo;
                else return GetCorrelativo();
            }
            set { _compra_correlativo = value; }
        }

        public string Compra_factura
        {
            get { return _compra_factura; }
            set { _compra_factura = value; }
        }

        public int Compra_anulado
        {
            get { return _compra_anulado; }
            set { _compra_anulado = value; }
        }

        public string Compra_fecha
        {
            get { return _compra_fecha; }
            set { _compra_fecha = value; }
        }

        public string Compra_serie
        {
            get { return _compra_serie; }
            set { _compra_serie = value; }
        }

        public int Compra_iva
        {
            get { return _compra_iva; }
            set { _compra_iva = value; }
        }

        public decimal Compra_total_iva
        {
            get { return _compra_total_iva; }
            set { _compra_total_iva = value; }
        }

        public decimal Compra_total_sin_iva
        {
            get { return _compra_total_sin_iva; }
            set { _compra_total_sin_iva = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_compras()
        {
            //
        }

        public DB_compras(int _compra_id, int _status_id, int _proveedor_id, int _usuario_id, string _compra_correlativo, string _compra_factura, int _compra_anulado, string _compra_fecha, string _compra_serie, int _compra_iva, decimal _compra_total_iva, decimal _compra_total_sin_iva, string _search_value)
        {
            this._compra_id = _compra_id;
            this._status_id = _status_id;
            this._proveedor_id = _proveedor_id;
            this._usuario_id = _usuario_id;
            this._compra_correlativo = _compra_correlativo;
            this._compra_factura = _compra_factura;
            this._compra_anulado = _compra_anulado;
            this._compra_fecha = _compra_fecha;
            this._compra_serie = _compra_serie;
            this._compra_iva = _compra_iva;
            this._compra_total_iva = _compra_total_iva;
            this._compra_total_sin_iva = _compra_total_sin_iva;
            this._search_value = _search_value;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllCompras = new DataTable("compras");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_compras";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllCompras);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllCompras = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllCompras;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_compras CompraSearch)
        {
            string respuesta = "";
            DataTable AllCompras = new DataTable("compras");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_compras";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = CompraSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllCompras);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllCompras = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllCompras;
        }

        // GET ID
        public DataTable GetIDVenta(DB_compras CompraID)
        {
            string respuesta = "";
            DataTable AllCompras = new DataTable("compras");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_compras";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDVENTA = new SqlParameter();
                IDVENTA.ParameterName = "@idcompra";
                IDVENTA.SqlDbType = SqlDbType.Int;
                IDVENTA.Size = 256;
                IDVENTA.Value = CompraID.Compra_id;
                SQL_comando.Parameters.Add(IDVENTA);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllCompras);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllCompras = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllCompras;
        }

        // INSERT
        public string Create(DB_compras CompraNEW)
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
                SQL_comando.CommandText = "POSTcompras"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter COMPRA = new SqlParameter(); // instanciamos
                COMPRA.ParameterName = "@idcompra"; // nombre de variable
                COMPRA.SqlDbType = SqlDbType.Int; // tipo de variable
                COMPRA.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(COMPRA); // Añadimos al comando
                
                SqlParameter STAUTS = new SqlParameter(); // instanciamos
                STAUTS.ParameterName = "@status_id"; // nombre de variable
                STAUTS.SqlDbType = SqlDbType.Int; // tipo de variable
                STAUTS.Size = 256;
                STAUTS.Value = CompraNEW.Status_id;
                SQL_comando.Parameters.Add(STAUTS); // Añadimos al comando

                SqlParameter PROVEEDOR = new SqlParameter(); // instanciamos
                PROVEEDOR.ParameterName = "@proveedor_id"; // nombre de variable
                PROVEEDOR.SqlDbType = SqlDbType.Int; // tipo de variable
                PROVEEDOR.Size = 256;
                PROVEEDOR.Value = CompraNEW.Proveedor_id;
                SQL_comando.Parameters.Add(PROVEEDOR); // Añadimos al comando

                SqlParameter COMPRADOR = new SqlParameter(); // instanciamos
                COMPRADOR.ParameterName = "@usuario_id"; // nombre de variable
                COMPRADOR.SqlDbType = SqlDbType.Int; // tipo de variable
                COMPRADOR.Size = 256;
                COMPRADOR.Value = CompraNEW.Usuario_id;
                SQL_comando.Parameters.Add(COMPRADOR); // Añadimos al comando

                SqlParameter CORRELATIVO = new SqlParameter(); // instanciamos
                CORRELATIVO.ParameterName = "@compra_correlativ"; // nombre de variable
                CORRELATIVO.SqlDbType = SqlDbType.VarChar; // tipo de variable
                CORRELATIVO.Size = 150; // Tamaño de variable
                CORRELATIVO.Value = CompraNEW.Compra_correlativo; // Valor de la variable
                SQL_comando.Parameters.Add(CORRELATIVO); // Añadimos al comando

                SqlParameter FACTURA = new SqlParameter(); // instanciamos
                FACTURA.ParameterName = "@compra_factura"; // nombre de variable
                FACTURA.SqlDbType = SqlDbType.VarChar; // tipo de variable
                FACTURA.Size = 500; // Tamaño de variable
                FACTURA.Value = CompraNEW.Compra_factura; // valor de la variable
                SQL_comando.Parameters.Add(FACTURA); // Añadimos al comando

                SqlParameter ANULADO = new SqlParameter(); // instanciamos
                ANULADO.ParameterName = "@compra_anulado"; // nombre de variable
                ANULADO.SqlDbType = SqlDbType.Int; // tipo de variable
                ANULADO.Size = 1; // Tamaño de variable
                ANULADO.Value = CompraNEW.Compra_anulado; // valor de la variable
                SQL_comando.Parameters.Add(ANULADO); // Añadimos al comando

                SqlParameter FECHA = new SqlParameter(); // instanciamos
                FECHA.ParameterName = "@compra_fecha"; // nombre de variable
                FECHA.SqlDbType = SqlDbType.Date; // tipo de variable
                FECHA.Value = CompraNEW.Compra_fecha; // valor de la variable
                SQL_comando.Parameters.Add(FECHA); // Añadimos al comando

                SqlParameter SERIE = new SqlParameter(); // instanciamos
                SERIE.ParameterName = "@compra_serie"; // nombre de variable
                SERIE.SqlDbType = SqlDbType.VarChar; // tipo de variable
                SERIE.Size = 300; // Tamaño de variable
                SERIE.Value = CompraNEW.Compra_serie; // valor de la variable
                SQL_comando.Parameters.Add(SERIE); // Añadimos al comando

                SqlParameter IVA = new SqlParameter(); // instanciamos
                IVA.ParameterName = "@compra_iva"; // nombre de variable
                IVA.SqlDbType = SqlDbType.Int; // tipo de variable
                IVA.Size = 2;
                IVA.Value = CompraNEW.Compra_iva;
                SQL_comando.Parameters.Add(IVA); // Añadimos al comando

                SqlParameter COMPRAIVA = new SqlParameter(); // instanciamos
                COMPRAIVA.ParameterName = "@compra_total_iva"; // nombre de variable
                COMPRAIVA.SqlDbType = SqlDbType.Decimal; // tipo de variable
                COMPRAIVA.Size = 250;
                COMPRAIVA.Value = CompraNEW.Compra_total_iva;
                SQL_comando.Parameters.Add(COMPRAIVA); // Añadimos al comando

                SqlParameter COMPRASINIVA = new SqlParameter(); // instanciamos
                COMPRASINIVA.ParameterName = "@compra_total_sin_iva"; // nombre de variable
                COMPRASINIVA.SqlDbType = SqlDbType.Decimal; // tipo de variable
                COMPRASINIVA.Size = 250;
                COMPRASINIVA.Value = CompraNEW.Compra_total_sin_iva;
                SQL_comando.Parameters.Add(COMPRASINIVA); // Añadimos al comando

                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar la compra";
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
        public string Edit(DB_compras CompraEDIT)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTcompras";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                // Creamos parametros de ejecucion SQL
                SqlParameter COMPRA = new SqlParameter();
                COMPRA.ParameterName = "@idcompra";
                COMPRA.SqlDbType = SqlDbType.Int;
                COMPRA.Size = 250;
                COMPRA.Value = CompraEDIT.Compra_id;
                SQL_comando.Parameters.Add(COMPRA);

                SqlParameter STAUTS = new SqlParameter(); // instanciamos
                STAUTS.ParameterName = "@status_id"; // nombre de variable
                STAUTS.SqlDbType = SqlDbType.Int; // tipo de variable
                STAUTS.Size = 256;
                STAUTS.Value = CompraEDIT.Status_id;
                SQL_comando.Parameters.Add(STAUTS); // Añadimos al comando

                SqlParameter PROVEEDOR = new SqlParameter(); // instanciamos
                PROVEEDOR.ParameterName = "@proveedor_id"; // nombre de variable
                PROVEEDOR.SqlDbType = SqlDbType.Int; // tipo de variable
                PROVEEDOR.Size = 256;
                PROVEEDOR.Value = CompraEDIT.Proveedor_id;
                SQL_comando.Parameters.Add(PROVEEDOR); // Añadimos al comando

                SqlParameter COMPRADOR = new SqlParameter(); // instanciamos
                COMPRADOR.ParameterName = "@usuario_id"; // nombre de variable
                COMPRADOR.SqlDbType = SqlDbType.Int; // tipo de variable
                COMPRADOR.Size = 256;
                COMPRADOR.Value = CompraEDIT.Usuario_id;
                SQL_comando.Parameters.Add(COMPRADOR); // Añadimos al comando

                SqlParameter CORRELATIVO = new SqlParameter(); // instanciamos
                CORRELATIVO.ParameterName = "@compra_correlativ"; // nombre de variable
                CORRELATIVO.SqlDbType = SqlDbType.VarChar; // tipo de variable
                CORRELATIVO.Size = 150; // Tamaño de variable
                CORRELATIVO.Value = CompraEDIT.Compra_correlativo; // Valor de la variable
                SQL_comando.Parameters.Add(CORRELATIVO); // Añadimos al comando

                SqlParameter FACTURA = new SqlParameter(); // instanciamos
                FACTURA.ParameterName = "@compra_factura"; // nombre de variable
                FACTURA.SqlDbType = SqlDbType.VarChar; // tipo de variable
                FACTURA.Size = 500; // Tamaño de variable
                FACTURA.Value = CompraEDIT.Compra_factura; // valor de la variable
                SQL_comando.Parameters.Add(FACTURA); // Añadimos al comando

                SqlParameter ANULADO = new SqlParameter(); // instanciamos
                ANULADO.ParameterName = "@compra_anulado"; // nombre de variable
                ANULADO.SqlDbType = SqlDbType.Int; // tipo de variable
                ANULADO.Size = 1; // Tamaño de variable
                ANULADO.Value = CompraEDIT.Compra_anulado; // valor de la variable
                SQL_comando.Parameters.Add(ANULADO); // Añadimos al comando

                SqlParameter FECHA = new SqlParameter(); // instanciamos
                FECHA.ParameterName = "@compra_fecha"; // nombre de variable
                FECHA.SqlDbType = SqlDbType.Date; // tipo de variable
                FECHA.Value = CompraEDIT.Compra_fecha; // valor de la variable
                SQL_comando.Parameters.Add(FECHA); // Añadimos al comando

                SqlParameter SERIE = new SqlParameter(); // instanciamos
                SERIE.ParameterName = "@compra_serie"; // nombre de variable
                SERIE.SqlDbType = SqlDbType.VarChar; // tipo de variable
                SERIE.Size = 300; // Tamaño de variable
                SERIE.Value = CompraEDIT.Compra_serie; // valor de la variable
                SQL_comando.Parameters.Add(SERIE); // Añadimos al comando

                SqlParameter IVA = new SqlParameter(); // instanciamos
                IVA.ParameterName = "@compra_iva"; // nombre de variable
                IVA.SqlDbType = SqlDbType.Int; // tipo de variable
                IVA.Size = 2;
                IVA.Value = CompraEDIT.Compra_iva;
                SQL_comando.Parameters.Add(IVA); // Añadimos al comando

                SqlParameter COMPRAIVA = new SqlParameter(); // instanciamos
                COMPRAIVA.ParameterName = "@compra_total_iva"; // nombre de variable
                COMPRAIVA.SqlDbType = SqlDbType.Decimal; // tipo de variable
                COMPRAIVA.Size = 250;
                COMPRAIVA.Value = CompraEDIT.Compra_total_iva;
                SQL_comando.Parameters.Add(COMPRAIVA); // Añadimos al comando

                SqlParameter COMPRASINIVA = new SqlParameter(); // instanciamos
                COMPRASINIVA.ParameterName = "@compra_total_sin_iva"; // nombre de variable
                COMPRASINIVA.SqlDbType = SqlDbType.Decimal; // tipo de variable
                COMPRASINIVA.Size = 250;
                COMPRASINIVA.Value = CompraEDIT.Compra_total_sin_iva;
                SQL_comando.Parameters.Add(COMPRASINIVA); // Añadimos al comando

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar la compra";
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
        public string Delete(DB_compras Compradel)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEventas";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                // Creamos parametros de ejecucion SQL
                SqlParameter COMPRA = new SqlParameter();
                COMPRA.ParameterName = "@idcompra";
                COMPRA.SqlDbType = SqlDbType.Int;
                COMPRA.Size = 250;
                COMPRA.Value = Compradel.Compra_id;
                SQL_comando.Parameters.Add(COMPRA);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar la compra";
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
