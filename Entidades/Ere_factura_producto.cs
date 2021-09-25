using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ere_factura_producto
    {
        public int id_re_factura_producto { get; set; }
        public int id_factura { get; set; }
        public int id_producto { get; set; }
        public double precio { get; set; }
        public double cantidad { get; set; }
        public double total { get; set; }
        public string nombre_producto { get; set; }
    }
}
