using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EProducto
    {
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public double precio { get; set; } 
        public string estado_producto { get; set; }
    }
}
