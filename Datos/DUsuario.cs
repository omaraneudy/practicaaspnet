using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiFuncion;
using Entidades;
using MySql.Data.MySqlClient;
using System.Data;

namespace Datos
{
    public class DUsuario
    {
        Conexion con = new Conexion();

        public DataTable SUsuario(string nombreUsuario, string contrasena)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SUsuario", con.GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@prm_nombre_usuario", MySqlDbType.VarChar).Value = nombreUsuario;
            da.SelectCommand.Parameters.Add("@prm_contrasena", MySqlDbType.VarChar).Value = contrasena;

            da.Fill(dt);



            return dt;
        }
    }
}
