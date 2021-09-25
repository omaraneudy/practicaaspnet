using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Datos
{
    public class Conexion
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;database=empresa;user=root;password=1234;sslmode=none;port=3306");

        public MySqlConnection Abrir()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();

            return conexion;
        }
        public MySqlConnection Cerrar()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }

        public MySqlConnection GetCon()
        {
            return conexion;
        }
    }
}
