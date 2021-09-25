using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using MySql.Data.MySqlClient;
using MultiFuncion;



namespace Datos
{
    public class DProducto
    {
        Conexion con = new Conexion();
        Convertidor convertidor = new Convertidor();

        public int IProducto(EProducto eProducto)
        {
            using (con.Abrir())
            {
                MySqlCommand cmd = new MySqlCommand("IProducto", con.GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@prm_nombre_producto", MySqlDbType.VarChar).Value = eProducto.nombre_producto;
                cmd.Parameters.Add("@prm_precio", MySqlDbType.Double).Value = eProducto.precio;
                cmd.Parameters.Add("@prm_estado_producto", MySqlDbType.VarChar).Value = eProducto.estado_producto;
                return convertidor.IntParse(cmd.ExecuteScalar());
            }
        }

        public void UProducto(EProducto eProducto)
        {
            using (con.Abrir())
            {
                MySqlCommand cmd = new MySqlCommand("UProducto", con.GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@prm_id_producto", MySqlDbType.Int32).Value = eProducto.id_producto;
                cmd.Parameters.Add("@prm_nombre_producto", MySqlDbType.VarChar).Value = eProducto.nombre_producto;
                cmd.Parameters.Add("@prm_precio", MySqlDbType.Double).Value = eProducto.precio;
                cmd.Parameters.Add("@prm_estado_producto", MySqlDbType.VarChar).Value = eProducto.estado_producto;
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable SProducto(int codigo)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SProducto", con.GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@prm_id_producto", MySqlDbType.Int32).Value = codigo;

            da.Fill(dt);
            return dt;
        }
        public DataTable SListaProducto(string estado = "", string nombre = "")
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SListaProducto", con.GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@prm_estado_producto", MySqlDbType.VarChar).Value = estado;
            da.SelectCommand.Parameters.Add("prm_nombre", MySqlDbType.Text).Value = nombre;
            da.Fill(dt);
            return dt;
        }

        public void DelProducto(int codigo)
        {
            MySqlCommand cmd = new MySqlCommand("DProducto", con.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_id_producto", MySqlDbType.Int32).Value = codigo;
            con.Abrir();
            cmd.ExecuteNonQuery();

        }

    }
}
