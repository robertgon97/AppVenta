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
    class DB_ventas
    {
        private int _venta_id;
        private int _ventas_tipo_id;
        private int _status_id;
        private int _cliente_id;
        private int _usuario_id;
        private string _venta_correlativo;
        private string _venta_factura;
        private int _venta_anulado;
        private string _venta_fecha;
        private string _venta_serie;
        private int _venta_iva;
        private decimal _venta_total_iva;
        private decimal _venta_total_sin_iva;
        private string _search_value;

        private string GetCorrelativo()
        {
            string valor = "ASDFGHJKLOIUYTREWQASDFGESASDASDASDWQECVSDFSDFSDFSFSZDFSDFSF";
            return valor;
        }

        public int Venta_id
        {
            get { return _venta_id; }
            set { _venta_id = value; }
        }

        public int Ventas_tipo_id
        {
            get { return _ventas_tipo_id; }
            set { _ventas_tipo_id = value; }
        }

        public int Status_id
        {
            get { return _status_id; }
            set { _status_id = value; }
        }

        public int Cliente_id
        {
            get { return _cliente_id; }
            set { _cliente_id = value; }
        }

        public int Usuario_id
        {
            get { return _usuario_id; }
            set { _usuario_id = value; }
        }

        public string Venta_correlativo
        {
            get {
                // if (_venta_correlativo == null || _venta_correlativo == "") return GetCorrelativo();
                // else return _venta_correlativo;

                if (_venta_correlativo != null || _venta_correlativo != "") return _venta_correlativo;
                else return GetCorrelativo();
            }
            set { _venta_correlativo = value; }
        }

        public string Venta_factura
        {
            get { return _venta_factura; }
            set { _venta_factura = value; }
        }

        public int Venta_anulado
        {
            get { return _venta_anulado; }
            set { _venta_anulado = value; }
        }

        public string Venta_fecha
        {
            get { return _venta_fecha; }
            set { _venta_fecha = value; }
        }

        public string Venta_serie
        {
            get { return _venta_serie; }
            set { _venta_serie = value; }
        }

        public int Venta_iva
        {
            get { return _venta_iva; }
            set { _venta_iva = value; }
        }

        public decimal Venta_total_iva
        {
            get { return _venta_total_iva; }
            set { _venta_total_iva = value; }
        }

        public decimal Venta_total_sin_iva
        {
            get { return _venta_total_sin_iva; }
            set { _venta_total_sin_iva = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_ventas()
        {
            //
        }

        public DB_ventas(int id, int tipoventa, int status, int cliente, int usuario, string correlativo, string factura, int anulado, string fecha, string serie, int iva, decimal totalIva, decimal total, string search)
        {
            this._venta_id = id;
            this._ventas_tipo_id = tipoventa;
            this._status_id = status;
            this._cliente_id = cliente;
            this._usuario_id = usuario;
            this._venta_correlativo = correlativo;
            this._venta_factura = factura;
            this._venta_anulado = anulado;
            this._venta_fecha = fecha;
            this._venta_serie = serie;
            this._venta_iva = iva;
            this._venta_total_iva = totalIva;
            this._venta_total_sin_iva = total;
            this._search_value = search;
        }

        // Metodos DB
        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllVentas = new DataTable("ventas");
            SqlConnection SQL = new SqlConnection();
            try {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ventas";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllVentas);

            } catch (Exception error) {
                respuesta = error.Message;
                AllVentas = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllVentas;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_ventas VentaSearch)
        {
            string respuesta = "";
            DataTable AllVentas = new DataTable("ventas");
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_ventas";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = VentaSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllVentas);

            } catch (Exception error) {
                respuesta = error.Message;
                AllVentas = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllVentas;
        }

        // GET ID
        public DataTable GetIDVenta(DB_ventas VentaID)
        {
            string respuesta = "";
            DataTable AllVentas = new DataTable("ventas");
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_ventas";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDVENTA = new SqlParameter();
                IDVENTA.ParameterName = "@idventa";
                IDVENTA.SqlDbType = SqlDbType.Int;
                IDVENTA.Size = 256;
                IDVENTA.Value = VentaID.Venta_id;
                SQL_comando.Parameters.Add(IDVENTA);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllVentas);

            } catch (Exception error) {
                respuesta = error.Message;
                AllVentas = null;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllVentas;
        }

        // INSERT
        public string Create(DB_ventas VentaNew)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try {
                // Conexion
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                // Establecer Procedimiento
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL; // Heredar conexion
                SQL_comando.CommandText = "POSTventas"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter IDVENTA = new SqlParameter(); // instanciamos
                IDVENTA.ParameterName = "@idventa"; // nombre de variable
                IDVENTA.SqlDbType = SqlDbType.Int; // tipo de variable
                IDVENTA.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(IDVENTA); // Añadimos al comando

                SqlParameter TIPOVENTA = new SqlParameter(); // instanciamos
                TIPOVENTA.ParameterName = "@ventas_tipo_id"; // nombre de variable
                TIPOVENTA.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPOVENTA.Size = 256;
                TIPOVENTA.Value = VentaNew.Ventas_tipo_id;
                SQL_comando.Parameters.Add(TIPOVENTA); // Añadimos al comando

                SqlParameter STAUTS = new SqlParameter(); // instanciamos
                STAUTS.ParameterName = "@status_id"; // nombre de variable
                STAUTS.SqlDbType = SqlDbType.Int; // tipo de variable
                STAUTS.Size = 256;
                STAUTS.Value = VentaNew.Status_id;
                SQL_comando.Parameters.Add(STAUTS); // Añadimos al comando

                SqlParameter CLIENTE = new SqlParameter(); // instanciamos
                CLIENTE.ParameterName = "@cliente_id"; // nombre de variable
                CLIENTE.SqlDbType = SqlDbType.Int; // tipo de variable
                CLIENTE.Size = 256;
                CLIENTE.Value = VentaNew.Cliente_id;
                SQL_comando.Parameters.Add(CLIENTE); // Añadimos al comando

                SqlParameter VENDEDOR = new SqlParameter(); // instanciamos
                VENDEDOR.ParameterName = "@usuario_id"; // nombre de variable
                VENDEDOR.SqlDbType = SqlDbType.Int; // tipo de variable
                VENDEDOR.Size = 256;
                VENDEDOR.Value = VentaNew.Usuario_id;
                SQL_comando.Parameters.Add(VENDEDOR); // Añadimos al comando

                SqlParameter CORRELATIVO = new SqlParameter(); // instanciamos
                CORRELATIVO.ParameterName = "@venta_correlativo"; // nombre de variable
                CORRELATIVO.SqlDbType = SqlDbType.VarChar; // tipo de variable
                CORRELATIVO.Size = 150; // Tamaño de variable
                CORRELATIVO.Value = VentaNew.Venta_correlativo; // Valor de la variable
                SQL_comando.Parameters.Add(CORRELATIVO); // Añadimos al comando

                SqlParameter FACTURA = new SqlParameter(); // instanciamos
                FACTURA.ParameterName = "@venta_factura"; // nombre de variable
                FACTURA.SqlDbType = SqlDbType.VarChar; // tipo de variable
                FACTURA.Size = 500; // Tamaño de variable
                FACTURA.Value = VentaNew.Venta_factura; // valor de la variable
                SQL_comando.Parameters.Add(FACTURA); // Añadimos al comando

                SqlParameter ANULADO = new SqlParameter(); // instanciamos
                ANULADO.ParameterName = "@venta_anulado"; // nombre de variable
                ANULADO.SqlDbType = SqlDbType.Int; // tipo de variable
                ANULADO.Size = 1; // Tamaño de variable
                ANULADO.Value = VentaNew.Venta_anulado; // valor de la variable
                SQL_comando.Parameters.Add(ANULADO); // Añadimos al comando

                SqlParameter FECHA = new SqlParameter(); // instanciamos
                FECHA.ParameterName = "@venta_fecha"; // nombre de variable
                FECHA.SqlDbType = SqlDbType.Date; // tipo de variable
                FECHA.Value = VentaNew.Venta_fecha; // valor de la variable
                SQL_comando.Parameters.Add(FECHA); // Añadimos al comando

                SqlParameter SERIE = new SqlParameter(); // instanciamos
                SERIE.ParameterName = "@venta_serie"; // nombre de variable
                SERIE.SqlDbType = SqlDbType.VarChar; // tipo de variable
                SERIE.Size = 300; // Tamaño de variable
                SERIE.Value = VentaNew.Venta_serie; // valor de la variable
                SQL_comando.Parameters.Add(SERIE); // Añadimos al comando
                
                SqlParameter IVA = new SqlParameter(); // instanciamos
                IVA.ParameterName = "@venta_iva"; // nombre de variable
                IVA.SqlDbType = SqlDbType.Int; // tipo de variable
                IVA.Size = 2;
                IVA.Value = VentaNew.Venta_iva;
                SQL_comando.Parameters.Add(IVA); // Añadimos al comando

                SqlParameter VENTAIVA = new SqlParameter(); // instanciamos
                VENTAIVA.ParameterName = "@venta_total_iva"; // nombre de variable
                VENTAIVA.SqlDbType = SqlDbType.Decimal; // tipo de variable
                VENTAIVA.Size = 250;
                VENTAIVA.Value = VentaNew.Venta_total_iva;
                SQL_comando.Parameters.Add(VENTAIVA); // Añadimos al comando

                SqlParameter VENTASINIVA = new SqlParameter(); // instanciamos
                VENTASINIVA.ParameterName = "@venta_total_sin_iva"; // nombre de variable
                VENTASINIVA.SqlDbType = SqlDbType.Decimal; // tipo de variable
                VENTASINIVA.Size = 250;
                VENTASINIVA.Value = VentaNew.Venta_total_sin_iva;
                SQL_comando.Parameters.Add(VENTASINIVA); // Añadimos al comando

                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar la venta";
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
        public string Edit(DB_ventas VentaEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTventas";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDVENTA = new SqlParameter();
                IDVENTA.ParameterName = "@idventa";
                IDVENTA.SqlDbType = SqlDbType.Int;
                IDVENTA.Size = 250;
                IDVENTA.Value = VentaEdit.Venta_id;
                SQL_comando.Parameters.Add(IDVENTA);

                SqlParameter TIPOVENTA = new SqlParameter(); // instanciamos
                TIPOVENTA.ParameterName = "@ventas_tipo_id"; // nombre de variable
                TIPOVENTA.SqlDbType = SqlDbType.Int; // tipo de variable
                TIPOVENTA.Size = 256;
                TIPOVENTA.Value = VentaEdit.Ventas_tipo_id;
                SQL_comando.Parameters.Add(TIPOVENTA); // Añadimos al comando

                SqlParameter STAUTS = new SqlParameter(); // instanciamos
                STAUTS.ParameterName = "@status_id"; // nombre de variable
                STAUTS.SqlDbType = SqlDbType.Int; // tipo de variable
                STAUTS.Size = 256;
                STAUTS.Value = VentaEdit.Status_id;
                SQL_comando.Parameters.Add(STAUTS); // Añadimos al comando

                SqlParameter CLIENTE = new SqlParameter(); // instanciamos
                CLIENTE.ParameterName = "@cliente_id"; // nombre de variable
                CLIENTE.SqlDbType = SqlDbType.Int; // tipo de variable
                CLIENTE.Size = 256;
                CLIENTE.Value = VentaEdit.Cliente_id;
                SQL_comando.Parameters.Add(CLIENTE); // Añadimos al comando

                SqlParameter VENDEDOR = new SqlParameter(); // instanciamos
                VENDEDOR.ParameterName = "@usuario_id"; // nombre de variable
                VENDEDOR.SqlDbType = SqlDbType.Int; // tipo de variable
                VENDEDOR.Size = 256;
                VENDEDOR.Value = VentaEdit.Usuario_id;
                SQL_comando.Parameters.Add(VENDEDOR); // Añadimos al comando

                SqlParameter CORRELATIVO = new SqlParameter(); // instanciamos
                CORRELATIVO.ParameterName = "@venta_correlativo"; // nombre de variable
                CORRELATIVO.SqlDbType = SqlDbType.VarChar; // tipo de variable
                CORRELATIVO.Size = 150; // Tamaño de variable
                CORRELATIVO.Value = VentaEdit.Venta_correlativo; // Valor de la variable
                SQL_comando.Parameters.Add(CORRELATIVO); // Añadimos al comando

                SqlParameter FACTURA = new SqlParameter(); // instanciamos
                FACTURA.ParameterName = "@venta_factura"; // nombre de variable
                FACTURA.SqlDbType = SqlDbType.VarChar; // tipo de variable
                FACTURA.Size = 500; // Tamaño de variable
                FACTURA.Value = VentaEdit.Venta_factura; // valor de la variable
                SQL_comando.Parameters.Add(FACTURA); // Añadimos al comando

                SqlParameter ANULADO = new SqlParameter(); // instanciamos
                ANULADO.ParameterName = "@venta_anulado"; // nombre de variable
                ANULADO.SqlDbType = SqlDbType.Int; // tipo de variable
                ANULADO.Size = 1; // Tamaño de variable
                ANULADO.Value = VentaEdit.Venta_anulado; // valor de la variable
                SQL_comando.Parameters.Add(ANULADO); // Añadimos al comando

                SqlParameter FECHA = new SqlParameter(); // instanciamos
                FECHA.ParameterName = "@venta_fecha"; // nombre de variable
                FECHA.SqlDbType = SqlDbType.Date; // tipo de variable
                FECHA.Value = VentaEdit.Venta_fecha; // valor de la variable
                SQL_comando.Parameters.Add(FECHA); // Añadimos al comando

                SqlParameter SERIE = new SqlParameter(); // instanciamos
                SERIE.ParameterName = "@venta_serie"; // nombre de variable
                SERIE.SqlDbType = SqlDbType.VarChar; // tipo de variable
                SERIE.Size = 300; // Tamaño de variable
                SERIE.Value = VentaEdit.Venta_serie; // valor de la variable
                SQL_comando.Parameters.Add(SERIE); // Añadimos al comando

                SqlParameter IVA = new SqlParameter(); // instanciamos
                IVA.ParameterName = "@venta_iva"; // nombre de variable
                IVA.SqlDbType = SqlDbType.Int; // tipo de variable
                IVA.Size = 2;
                IVA.Value = VentaEdit.Venta_iva;
                SQL_comando.Parameters.Add(IVA); // Añadimos al comando

                SqlParameter VENTAIVA = new SqlParameter(); // instanciamos
                VENTAIVA.ParameterName = "@venta_total_iva"; // nombre de variable
                VENTAIVA.SqlDbType = SqlDbType.Decimal; // tipo de variable
                VENTAIVA.Size = 250;
                VENTAIVA.Value = VentaEdit.Venta_total_iva;
                SQL_comando.Parameters.Add(VENTAIVA); // Añadimos al comando

                SqlParameter VENTASINIVA = new SqlParameter(); // instanciamos
                VENTASINIVA.ParameterName = "@venta_total_sin_iva"; // nombre de variable
                VENTASINIVA.SqlDbType = SqlDbType.Decimal; // tipo de variable
                VENTASINIVA.Size = 250;
                VENTASINIVA.Value = VentaEdit.Venta_total_sin_iva;
                SQL_comando.Parameters.Add(VENTASINIVA); // Añadimos al comando

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar la venta";
            } catch (Exception error) {
                respuesta = error.Message;
                throw;
            } finally {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return respuesta;
        }

        // DELETE
        public string Delete(DB_ventas VentaDelete)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEventas";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter IDVENTA = new SqlParameter();
                IDVENTA.ParameterName = "@idventa";
                IDVENTA.SqlDbType = SqlDbType.Int;
                IDVENTA.Size = 250;
                IDVENTA.Value = VentaDelete.Venta_id;
                SQL_comando.Parameters.Add(IDVENTA);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar la venta";
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
