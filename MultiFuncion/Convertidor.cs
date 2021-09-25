using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiFuncion
{
    public class Convertidor
    {
        public int IntParse(object valor)
        {
            string cadena = valor != null ? valor.ToString() : "";
            int numero = 0;

            int.TryParse(cadena, out numero);

            return numero;
        }

        public double DoubleParse(object valor)
        {
            string cadena = valor != null ? valor.ToString() : "";
            double numero = 0;

            double.TryParse(cadena, out numero);

            return numero;
        }
    }
}
