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
    public class DB_articulos
    {
        private int _articulo_id;
        private int _categoria_id;
        private int _presentacion_id;
        private string _articulo_nombre;
        private string _articulo_codigo_barra;
        private string _articulo_descripcion;
        private string _articulo_imagen;
        private decimal _articulo_precio;
        private string _search_value;
        
        public int Articulo_id
        {
            get { return _articulo_id; }
            set { _articulo_id = value; }
        }

        public int Categoria_id
        {
            get { return _categoria_id; }
            set { _categoria_id = value; }
        }

        public int Presentacion_id
        {
            get { return _presentacion_id; }
            set { _presentacion_id = value; }
        }

        public string Articulo_nombre
        {
            get { return _articulo_nombre; }
            set { _articulo_nombre = value; }
        }

        public string Articulo_codigo_barra
        {
            get { return _articulo_codigo_barra; }
            set { _articulo_codigo_barra = value; }
        }

        public string Articulo_descripcion
        {
            get { return _articulo_descripcion; }
            set { _articulo_descripcion = value; }
        }

        public string Articulo_imagen
        {
            get { return _articulo_imagen; }
            set { _articulo_imagen = value; }
        }

        public decimal Articulo_precio
        {
            get { return _articulo_precio; }
            set { _articulo_precio = value; }
        }

        public string Search_value
        {
            get { return _search_value; }
            set { _search_value = value; }
        }

        // Constructor Vacio
        public DB_articulos()
        {
            //
        }

        public DB_articulos(int _articulo_id, int _categoria_id, int _presentacion_id, string _articulo_nombre, string _articulo_codigo_barra, string _articulo_descripcion, string _articulo_imagen, decimal _articulo_precio, string _search_value)
        {
            this._articulo_id = _articulo_id;
            this._categoria_id = _categoria_id;
            this._presentacion_id = _presentacion_id;
            this._articulo_nombre = _articulo_nombre;
            this._articulo_codigo_barra = _articulo_codigo_barra;
            this._articulo_descripcion = _articulo_descripcion;
            this._articulo_imagen = _articulo_imagen;
            this._articulo_precio = _articulo_precio;
            this._search_value = _search_value;
        }

        // Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllArticulos = new DataTable("articulos");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_articulos";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllArticulos);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllArticulos = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllArticulos;
        }

        // GET SEARCH
        public DataTable GetSearch(DB_articulos ArticulosSearch)
        {
            string respuesta = "";
            DataTable AllArticulos = new DataTable("articulos");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_SEARCH_articulos";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Search = new SqlParameter();
                Search.ParameterName = "@search";
                Search.SqlDbType = SqlDbType.VarChar;
                Search.Size = 256;
                Search.Value = ArticulosSearch.Search_value;
                SQL_comando.Parameters.Add(Search);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllArticulos);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllArticulos = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllArticulos;
        }

        // GET ID
        public DataTable GetArticleId(DB_articulos ArticuloId)
        {
            string respuesta = "";
            DataTable AllArticulos = new DataTable("articulos");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_articulos";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter ID = new SqlParameter();
                ID.ParameterName = "@idarticulo";
                ID.SqlDbType = SqlDbType.Int;
                ID.Size = 256;
                ID.Value = ArticuloId.Articulo_id;
                SQL_comando.Parameters.Add(ID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllArticulos);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllArticulos = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllArticulos;
        }

        // INSERT
        public string Create(DB_articulos ArticuloNew)
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
                SQL_comando.CommandText = "POSTarticulos"; // comando de procedimiento almacenado
                SQL_comando.CommandType = CommandType.StoredProcedure; // Indicamos que es un procedimiento almacenado

                // Creamos parametros de ejecucion SQL
                SqlParameter ArticuloId = new SqlParameter(); // instanciamos
                ArticuloId.ParameterName = "@idarticulo"; // nombre de variable
                ArticuloId.SqlDbType = SqlDbType.Int; // tipo de variable
                ArticuloId.Direction = ParameterDirection.Output; // formato de entrada / salida
                SQL_comando.Parameters.Add(ArticuloId); // Añadimos al comando

                SqlParameter CATEGORIA = new SqlParameter(); // instanciamos
                CATEGORIA.ParameterName = "@categoria_id"; // nombre de variable
                CATEGORIA.SqlDbType = SqlDbType.Int; // tipo de variable
                CATEGORIA.Size = 256;
                CATEGORIA.Value = ArticuloNew.Categoria_id;
                SQL_comando.Parameters.Add(CATEGORIA); // Añadimos al comando

                SqlParameter PRESENTACION = new SqlParameter(); // instanciamos
                PRESENTACION.ParameterName = "@presentacion_id"; // nombre de variable
                PRESENTACION.SqlDbType = SqlDbType.Int; // tipo de variable
                PRESENTACION.Size = 256;
                PRESENTACION.Value = ArticuloNew.Presentacion_id;
                SQL_comando.Parameters.Add(PRESENTACION); // Añadimos al comando

                SqlParameter NOMBRE = new SqlParameter(); // instanciamos
                NOMBRE.ParameterName = "@articulo_nombre"; // nombre de variable
                NOMBRE.SqlDbType = SqlDbType.VarBinary; // tipo de variable
                NOMBRE.Size = 256;
                NOMBRE.Value = ArticuloNew.Articulo_nombre; // valor de la variable
                SQL_comando.Parameters.Add(NOMBRE); // Añadimos al comando 

                SqlParameter CODIGOBARRA = new SqlParameter(); // instanciamos
                CODIGOBARRA.ParameterName = "@articulo_codigo_barra"; // nombre de variable
                CODIGOBARRA.SqlDbType = SqlDbType.VarBinary; // tipo de variable
                CODIGOBARRA.Size = 256;
                CODIGOBARRA.Value = ArticuloNew.Articulo_codigo_barra; // valor de la variable
                SQL_comando.Parameters.Add(CODIGOBARRA); // Añadimos al comando 

                SqlParameter DESCRIPCION = new SqlParameter(); // instanciamos
                DESCRIPCION.ParameterName = "@articulo_descripcion"; // nombre de variable
                DESCRIPCION.SqlDbType = SqlDbType.VarBinary; // tipo de variable
                DESCRIPCION.Size = 256;
                DESCRIPCION.Value = ArticuloNew.Articulo_descripcion; // valor de la variable
                SQL_comando.Parameters.Add(DESCRIPCION); // Añadimos al comando 

                SqlParameter IMAGEN = new SqlParameter(); // instanciamos
                IMAGEN.ParameterName = "@articulo_imagen"; // nombre de variable
                IMAGEN.SqlDbType = SqlDbType.VarBinary; // tipo de variable
                IMAGEN.Size = 256;
                IMAGEN.Value = ArticuloNew.Articulo_imagen; // valor de la variable
                SQL_comando.Parameters.Add(IMAGEN); // Añadimos al comando 

                SqlParameter PRECIO = new SqlParameter(); // instanciamos
                PRECIO.ParameterName = "@articulo_precio"; // nombre de variable
                PRECIO.SqlDbType = SqlDbType.Decimal; // tipo de variable
                PRECIO.Size = 256;
                PRECIO.Value = ArticuloNew.Articulo_nombre; // valor de la variable
                SQL_comando.Parameters.Add(PRECIO); // Añadimos al comando 


                // Ejecutar consulta
                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al guardar articulos";
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
        public string Edit(DB_articulos ArticuloEdit)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "PUTarticulos";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter ID = new SqlParameter();
                ID.ParameterName = "@idarticulo";
                ID.SqlDbType = SqlDbType.Int;
                ID.Size = 250;
                ID.Value = ArticuloEdit.Articulo_id;
                SQL_comando.Parameters.Add(ID);

                SqlParameter CATEGORIA = new SqlParameter(); // instanciamos
                CATEGORIA.ParameterName = "@categoria_id"; // nombre de variable
                CATEGORIA.SqlDbType = SqlDbType.Int; // tipo de variable
                CATEGORIA.Size = 256;
                CATEGORIA.Value = ArticuloEdit.Categoria_id;
                SQL_comando.Parameters.Add(CATEGORIA); // Añadimos al comando

                SqlParameter PRESENTACION = new SqlParameter(); // instanciamos
                PRESENTACION.ParameterName = "@presentacion_id"; // nombre de variable
                PRESENTACION.SqlDbType = SqlDbType.Int; // tipo de variable
                PRESENTACION.Size = 256;
                PRESENTACION.Value = ArticuloEdit.Presentacion_id;
                SQL_comando.Parameters.Add(PRESENTACION); // Añadimos al comando

                SqlParameter NOMBRE = new SqlParameter(); // instanciamos
                NOMBRE.ParameterName = "@articulo_nombre"; // nombre de variable
                NOMBRE.SqlDbType = SqlDbType.VarBinary; // tipo de variable
                NOMBRE.Size = 256;
                NOMBRE.Value = ArticuloEdit.Articulo_nombre; // valor de la variable
                SQL_comando.Parameters.Add(NOMBRE); // Añadimos al comando 

                SqlParameter CODIGOBARRA = new SqlParameter(); // instanciamos
                CODIGOBARRA.ParameterName = "@articulo_codigo_barra"; // nombre de variable
                CODIGOBARRA.SqlDbType = SqlDbType.VarBinary; // tipo de variable
                CODIGOBARRA.Size = 256;
                CODIGOBARRA.Value = ArticuloEdit.Articulo_codigo_barra; // valor de la variable
                SQL_comando.Parameters.Add(CODIGOBARRA); // Añadimos al comando 

                SqlParameter DESCRIPCION = new SqlParameter(); // instanciamos
                DESCRIPCION.ParameterName = "@articulo_descripcion"; // nombre de variable
                DESCRIPCION.SqlDbType = SqlDbType.VarBinary; // tipo de variable
                DESCRIPCION.Size = 256;
                DESCRIPCION.Value = ArticuloEdit.Articulo_descripcion; // valor de la variable
                SQL_comando.Parameters.Add(DESCRIPCION); // Añadimos al comando 

                SqlParameter IMAGEN = new SqlParameter(); // instanciamos
                IMAGEN.ParameterName = "@articulo_imagen"; // nombre de variable
                IMAGEN.SqlDbType = SqlDbType.VarBinary; // tipo de variable
                IMAGEN.Size = 256;
                IMAGEN.Value = ArticuloEdit.Articulo_imagen; // valor de la variable
                SQL_comando.Parameters.Add(IMAGEN); // Añadimos al comando 

                SqlParameter PRECIO = new SqlParameter(); // instanciamos
                PRECIO.ParameterName = "@articulo_precio"; // nombre de variable
                PRECIO.SqlDbType = SqlDbType.Decimal; // tipo de variable
                PRECIO.Size = 256;
                PRECIO.Value = ArticuloEdit.Articulo_nombre; // valor de la variable
                SQL_comando.Parameters.Add(PRECIO); // Añadimos al comando   

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al modificar articulos";
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
        public string Delete(DB_articulos ArticuloDelete)
        {
            string respuesta = "";
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SQL.Open();

                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;
                SQL_comando.CommandText = "DELETEarticulos";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter ID = new SqlParameter();
                ID.ParameterName = "@idarticulo";
                ID.SqlDbType = SqlDbType.Int;
                ID.Size = 250;
                ID.Value = ArticuloDelete.Articulo_id;
                SQL_comando.Parameters.Add(ID);

                respuesta = SQL_comando.ExecuteNonQuery() == 1 || true ? "Realizado Exitosamente" : "Error al eliminar articulo del stock";
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
