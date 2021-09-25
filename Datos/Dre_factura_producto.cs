using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MultiFuncion;
using MySql.Data.MySqlClient;
using System.Data;

namespace Datos
{
    public class Dre_factura_producto
    {
        Conexion con = new Conexion();
        Ere_factura_producto ere_Factura_Producto = new Ere_factura_producto();
        Convertidor convertidor = new Convertidor();

        public DataTable SREFacturaProducto(int codigo)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SREFacturaProducto", con.GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@prm_id_factura", MySqlDbType.Int32).Value = codigo;
            da.Fill(dt);
            return dt;

        }

        public void DREFacturaProducto(int codigo)
        {
            MySqlCommand cmd = new MySqlCommand("DREFacturaProducto", con.Abrir());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_id_factura", MySqlDbType.Int32).Value = codigo;
            cmd.ExecuteNonQuery();
            con.Cerrar();
        }

        public void IREFacturaProductoTabla(DataTable dtDetalle)
        {
            using (con.Abrir())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                Ere_factura_producto ere_Factura_Producto = new Ere_factura_producto();

                foreach (DataRow dRow in dtDetalle.Rows)
                {
                    ere_Factura_Producto.id_factura = convertidor.IntParse(dRow["id_factura"]);
                    ere_Factura_Producto.id_producto = convertidor.IntParse(dRow["id_producto"]);
                    ere_Factura_Producto.precio = convertidor.DoubleParse(dRow["precio"]);
                    ere_Factura_Producto.cantidad = convertidor.DoubleParse(dRow["cantidad"]);
                    ere_Factura_Producto.total = convertidor.DoubleParse(dRow["total"]);

                    IREFacturaProducto(ere_Factura_Producto, cmd);
                }
            }
        }

        public void IREFacturaProducto(Ere_factura_producto ere_Factura_Producto, MySqlCommand cmd = null)
        {
            if (cmd == null)
            {
                cmd = new MySqlCommand();
                cmd.Connection = con.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
            }
            cmd.Parameters.Clear();
            cmd.CommandText = "IREFacturaProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_id_re_factura_producto", MySqlDbType.Int32).Value = ere_Factura_Producto.id_re_factura_producto;
            cmd.Parameters.Add("@prm_id_factura", MySqlDbType.Int32).Value = ere_Factura_Producto.id_factura;
            cmd.Parameters.Add("@prm_id_producto", MySqlDbType.Int32).Value = ere_Factura_Producto.id_producto;
            cmd.Parameters.Add("@prm_precio", MySqlDbType.Double).Value = ere_Factura_Producto.precio;
            cmd.Parameters.Add("@prm_cantidad", MySqlDbType.Double).Value = ere_Factura_Producto.cantidad;
            cmd.Parameters.Add("@prm_total", MySqlDbType.Double).Value = ere_Factura_Producto.total;
            cmd.ExecuteNonQuery();
        }

        public void UREFacturaProductoTabla(DataTable dtDetalle)
        {
            using (con.Abrir())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                Ere_factura_producto ere_Factura_Producto = new Ere_factura_producto();

                foreach (DataRow dRow in dtDetalle.Rows)
                {
                    ere_Factura_Producto.id_re_factura_producto = convertidor.IntParse(dRow["id_re_factura_producto"]);
                    ere_Factura_Producto.id_factura = convertidor.IntParse(dRow["id_factura"]);
                    ere_Factura_Producto.id_producto = convertidor.IntParse(dRow["id_producto"]);
                    ere_Factura_Producto.precio = convertidor.DoubleParse(dRow["precio"]);
                    ere_Factura_Producto.cantidad = convertidor.DoubleParse(dRow["cantidad"]);
                    ere_Factura_Producto.total = convertidor.DoubleParse(dRow["total"]);

                    UREFacturaProducto(ere_Factura_Producto, cmd);
                }
            }
        }

        public void UREFacturaProducto(Ere_factura_producto ere_Factura_Producto, MySqlCommand cmd = null)
        {
            {
                cmd = new MySqlCommand();
                cmd.Connection = con.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
            }
            cmd.Parameters.Clear();
            cmd.CommandText = "UREFacturaProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_id_re_factura_producto", MySqlDbType.Int32).Value = ere_Factura_Producto.id_re_factura_producto;
            cmd.Parameters.Add("@prm_id_factura", MySqlDbType.Int32).Value = ere_Factura_Producto.id_factura;
            cmd.Parameters.Add("@prm_id_producto", MySqlDbType.Int32).Value = ere_Factura_Producto.id_producto;
            cmd.Parameters.Add("@prm_precio", MySqlDbType.Double).Value = ere_Factura_Producto.precio;
            cmd.Parameters.Add("@prm_cantidad", MySqlDbType.Double).Value = ere_Factura_Producto.cantidad;
            cmd.Parameters.Add("@prm_total", MySqlDbType.Double).Value = ere_Factura_Producto.total;
            cmd.ExecuteNonQuery();
        }

   
    }
}
