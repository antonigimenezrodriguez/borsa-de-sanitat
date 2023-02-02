using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Models.Parámetros
{
    public class CategoriaCod
    {
        public string Clave { get; set; }
        public string Valor { get; set; }

        public override string ToString()
        {
            return Valor;
        }
    }
}
