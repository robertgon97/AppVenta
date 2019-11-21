using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    class N_stock
    {
        public static DataTable obtenerTodoelStock(int miUsuarioID)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo Stock", "El Usuario solicito todo el Stock", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DataTable TodoelStock = new DB_stock().GetAll();
            return TodoelStock;
        }

        public static DataTable obtenerStock(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Obtuvo informacion del Stock", "El Usuario solicito todos los datos del Stock", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_stock Stock = new DB_stock(id, 0, 0, "0");
            DataTable StockEnTabla = Stock.GetStockID(Stock);
            return StockEnTabla;
        }

        public static DataTable buscarStocks(int miUsuarioID, string search)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Solicito buscar informacion de Stock", "El Usuario solicito la busqueda de todos los datos del Stock en la base de datos", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_stock Stock = new DB_stock(0, 0, 0, search);
            DataTable StockEnTabla = Stock.GetSearch(Stock);
            return StockEnTabla;
        }

        public static string agregarStock(int miUsuarioID, int _stock_id, int _articulo_id, int _stock_cantidad, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Se Registro nuevo Stock", "El Usuario solicito el registro de otro Stock", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_stock nuevoStock = new DB_stock(_stock_id, _articulo_id, _stock_cantidad, buscar);
            return nuevoStock.Create(nuevoStock);
        }

        public static string modificarStock(int miUsuarioID, int _stock_id, int _articulo_id, int _stock_cantidad, string buscar)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Modifico informacion de una Stock", "El Usuario solicito modificar los datos del  Stock", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_stock actualStock = new DB_stock(_stock_id, _articulo_id, _stock_cantidad, buscar);
            return actualStock.Edit(actualStock);
        }

        public static string eliminarStock(int miUsuarioID, int id)
        {
            // Auditamos la Accion
            string _fechaActual = DateTime.Now.ToLongDateString();
            DB_auditoria nuevaAuditoria = new DB_auditoria(0, miUsuarioID, _fechaActual, "Elimino informacion del Stock", "El Usuario solicito eliminar los datos del Stock", "");
            nuevaAuditoria.Create(nuevaAuditoria);

            // Ejecutamos la Accion
            DB_stock eliminarStock = new DB_stock(id, 0, 0, "0");
            return eliminarStock.Delete(eliminarStock);
        }
    }
}
