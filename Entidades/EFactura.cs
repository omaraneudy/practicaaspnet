using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EFactura
    {
        public int id_factura { get; set; }
        public int id_cliente { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public double valor { get; set; }
        public double balance { get; set; }

    }
}
