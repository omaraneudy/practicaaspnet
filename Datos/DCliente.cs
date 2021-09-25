using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Entidades;
using MultiFuncion;

namespace Datos
{
    public class DCliente
    {
        Conexion con = new Conexion();
        Convertidor convertidor = new Convertidor();
        DateTime fechaActual = DateTime.Now;

        public int ICliente(ECliente eCliente)
        {
            eCliente.fechacreado = fechaActual;
            using (con.Abrir())
            {
                MySqlCommand cmd = new MySqlCommand("ICliente", con.Abrir());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prm_nombre", eCliente.nombre);
                cmd.Parameters.AddWithValue("@prm_direccion", eCliente.direccion);
                cmd.Parameters.AddWithValue("@prm_telefono", eCliente.telefono);
                cmd.Parameters.AddWithValue("@prm_fecha_creado", eCliente.fechacreado);
                cmd.Parameters.AddWithValue("@prm_sexo", eCliente.sexo);
                cmd.Parameters.AddWithValue("@prm_estado", eCliente.estado);
                cmd.Parameters.AddWithValue("@prm_notificacion", eCliente.notificacion);
                cmd.Parameters.AddWithValue("@prm_comentario", eCliente.comentario);
                return convertidor.IntParse(cmd.ExecuteScalar());
            }
        }

        public DataTable ListarCliente(string estado)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SListaCliente", con.GetCon());
            da.SelectCommand.Parameters.Add("prm_estado", MySqlDbType.VarChar).Value = estado;

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);

            return dt;
        }

        public DataTable SCliente(int codigo)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SCliente", con.GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("prm_codigo_cli", MySqlDbType.Int32).Value = codigo;
            da.Fill(dt);

            return dt;
        }

        public void UCliente(ECliente cliente)
        {
            using (con.Abrir())
            {
                MySqlCommand cmd = new MySqlCommand("UCliente", con.Abrir());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prm_codigo_cli",cliente.id_cli);
                cmd.Parameters.AddWithValue("@prm_nombre",cliente.nombre);
                cmd.Parameters.AddWithValue("@prm_direccion",cliente.direccion);
                cmd.Parameters.AddWithValue("@prm_telefono",cliente.telefono);
                cmd.Parameters.AddWithValue("@prm_sexo",cliente.sexo);
                cmd.Parameters.AddWithValue("@prm_estado", cliente.estado);
                cmd.Parameters.AddWithValue("@prm_notificacion", cliente.notificacion);
                cmd.Parameters.AddWithValue("@prm_comentario", cliente.comentario);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
