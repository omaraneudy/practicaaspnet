using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ECliente
    {
        public int id_cli { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public DateTime fechacreado { get; set; }
        public string sexo { get; set; }
        public string estado { get; set; }
        public string notificacion { get; set; }
        public string comentario { get; set; }

    }
}
