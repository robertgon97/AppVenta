using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using CapaDatos;
using System.Data;

namespace CapaNegocio
{
  public  class N_articulos
    {
        public static DataTable obtenerTodosLosArticulos(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Todos Los Articulos", "El Usuario solicito todos los Articulos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable TodosLosArticulos = new DB_articulos().GetAll();
            return TodosLosArticulos;
        }

        public static DataTable obtenerUnArticulo(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion un artículo", "El Usuario solicito todos los datos de un artículo", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_articulos Articulo = new DB_articulos(id, 0, 0, "0", "0", "0", "0", 0, "0");
            DataTable ArticuloEnTabla = Articulo.GetArticleId(Articulo);
            return ArticuloEnTabla;
        }

        public static DataTable buscarArticulos(int miUsuarioID, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito buscar informacion de un artículo", "El Usuario solicito la busqueda de todos los datos de los artículos en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_articulos Articulos = new DB_articulos( 0, 0, 0, "0", "0", "0", "0", 0, search);
            DataTable ArticulosEnTabla = Articulos.GetSearch(Articulos);
            return ArticulosEnTabla;
        }

        public static string agregarArticulo(int miUsuarioID, int _articulo_id, int _categoria_id, int _presentacion_id, string _articulo_nombre, string _articulo_codigo_barra, string _articulo_descripcion, string _articulo_imagen, decimal _articulo_precio,  string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Registro un nuevo artículo", "El Usuario solicito el registro de otro artículo", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_articulos nuevoArticulo = new DB_articulos(_articulo_id, _categoria_id, _presentacion_id, _articulo_nombre, _articulo_codigo_barra, _articulo_descripcion, _articulo_imagen, _articulo_precio, buscar);
            return nuevoArticulo.Create(nuevoArticulo);
        }

        public static string modificarArticulo(int miUsuarioID, int _articulo_id, int _categoria_id, int _presentacion_id, string _articulo_nombre, string _articulo_codigo_barra, string _articulo_descripcion, string _articulo_imagen, decimal _articulo_precio, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Modifico informacion de un Artículo", "El Usuario solicito modificar los datos de un artículo", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_articulos actualArticulo = new DB_articulos(_articulo_id, _categoria_id, _presentacion_id, _articulo_nombre, _articulo_codigo_barra, _articulo_descripcion, _articulo_imagen, _articulo_precio, buscar);
            return actualArticulo.Edit(actualArticulo);
        }

        public static string eliminarArticulo(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Elimino informacion de un articulo", "El Usuario solicito eliminar los datos de un artículo", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_articulos eliminarArticulo = new DB_articulos(id, 0, 0, "0", "0", "0", "0",0, "0" );
            return eliminarArticulo.Delete(eliminarArticulo);
        }
    }

}

