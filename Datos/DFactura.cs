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
    public class DFactura
    {
        Conexion con = new Conexion();
        Convertidor convertidor = new Convertidor();
        EFactura EFactura = new EFactura();

        public int IFactura(EFactura eFactura)
        {
            eFactura.fecha = DateTime.Now;

            MySqlDataAdapter da = new MySqlDataAdapter("IFactura", con.Abrir());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            da.SelectCommand.Parameters.Add("@prm_id_cliente", MySqlDbType.Double).Value = eFactura.id_cliente;
            da.SelectCommand.Parameters.Add("@prm_fecha", MySqlDbType.DateTime).Value = eFactura.fecha;
            da.SelectCommand.Parameters.Add("@prm_estado", MySqlDbType.VarChar).Value = eFactura.estado;
            da.SelectCommand.Parameters.Add("@prm_valor", MySqlDbType.Double).Value = eFactura.valor;
            da.SelectCommand.Parameters.Add("@prm_balance", MySqlDbType.Double).Value = eFactura.balance;

            return convertidor.IntParse(da.SelectCommand.ExecuteScalar());
        }

        public DataTable SFactura(int codigo)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SFactura", con.GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@prm_id_factura", MySqlDbType.Int32).Value = codigo;
            da.Fill(dt);
            return dt;
        }

        public void UFactura(EFactura eFactura)
        {
            eFactura.fecha = DateTime.Now;
            using (con.Abrir())
            { 

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "UFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con.Abrir();
                cmd.Parameters.Add("@prm_id_cliente", MySqlDbType.Int32).Value = eFactura.id_cliente;
                cmd.Parameters.Add("@prm_id_factura", MySqlDbType.Int32).Value = eFactura.id_factura;
                cmd.Parameters.Add("@prm_fecha", MySqlDbType.DateTime).Value = eFactura.fecha;
                cmd.Parameters.Add("@prm_estado", MySqlDbType.VarChar).Value = eFactura.estado;
                cmd.Parameters.Add("@prm_valor", MySqlDbType.Double).Value = eFactura.valor;
                cmd.Parameters.Add("@prm_balance", MySqlDbType.Double).Value = eFactura.balance;
                cmd.ExecuteNonQuery();
            }
        }

        public void UAnularFactura(int codigo)
        {
            EFactura eFactura = new EFactura();
            using (con.Abrir())
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "UAnularFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con.Abrir();
                cmd.Parameters.Add("@prm_id_cliente", MySqlDbType.Int32).Value = eFactura.id_cliente;
                cmd.Parameters.Add("@prm_id_factura", MySqlDbType.Int32).Value = eFactura.id_factura;
                cmd.Parameters.Add("@prm_fecha", MySqlDbType.DateTime).Value = eFactura.fecha;
                cmd.Parameters.Add("@prm_estado", MySqlDbType.VarChar).Value = eFactura.estado;
                cmd.Parameters.Add("@prm_valor", MySqlDbType.Double).Value = eFactura.valor;
                cmd.Parameters.Add("@prm_balance", MySqlDbType.Double).Value = eFactura.balance;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
