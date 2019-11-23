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
    public class DB_articulos_categorias
    {
        private int _categoria_id;
        private string _categoria_nombre;
        private string _categoria_descripcion;
        
        public int Categoria_id
        {
            get { return _categoria_id; }
            set { _categoria_id = value; }
        }

        public string Categoria_nombre
        {
            get { return _categoria_nombre; }
            set { _categoria_nombre = value; }
        }

        public string Categoria_descripcion
        {
            get { return _categoria_descripcion; }
            set { _categoria_descripcion = value; }
        }

        // Constructor Vacio

        public DB_articulos_categorias()
        {
            //
        }

        public DB_articulos_categorias(int _categoria_id, string _categoria_nombre, string _categoria_descripcion)
        {
            this._categoria_id = _categoria_id;
            this._categoria_nombre = _categoria_nombre;
            this._categoria_descripcion = _categoria_descripcion;
        }

        //Metodos DB

        // GET ALL
        public DataTable GetAll()
        {
            string respuesta = "";
            DataTable AllCategorias = new DataTable("categorias");
            SqlConnection SQL = new SqlConnection();
            try
            {

                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ALL_categorias";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllCategorias);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllCategorias = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllCategorias;
        }

        // GET ID
        public DataTable GetDetalleID(DB_compras_detalles DetalleCompraID)
        {
            string respuesta = "";
            DataTable AllCategorias = new DataTable("categorias");
            SqlConnection SQL = new SqlConnection();
            try
            {
                SQL.ConnectionString = ConexionDB.StringConection;
                SqlCommand SQL_comando = new SqlCommand();
                SQL_comando.Connection = SQL;

                SQL_comando.CommandText = "GET_ID_categorias";
                SQL_comando.CommandType = CommandType.StoredProcedure;

                SqlParameter DetalleID = new SqlParameter();
                DetalleID.ParameterName = "@idcategoria";
                DetalleID.SqlDbType = SqlDbType.Int;
                DetalleID.Size = 256;
                DetalleID.Value = DetalleCompraID.Compra_detalle_id;
                SQL_comando.Parameters.Add(DetalleID);

                SqlDataAdapter RespuestaSQL = new SqlDataAdapter(SQL_comando);
                RespuestaSQL.Fill(AllCategorias);

            }
            catch (Exception error)
            {
                respuesta = error.Message;
                AllCategorias = null;
                throw;
            }
            finally
            {
                if (SQL.State == ConnectionState.Open) SQL.Close();
            }
            return AllCategorias;
        }
        

    }
}
