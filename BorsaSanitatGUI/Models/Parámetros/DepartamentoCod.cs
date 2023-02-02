using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BorsaSanitatGUI.Models.Parámetros
{
    public class DepartamentoCod
    {
        public string Clave { get; set; }
        public string Valor { get; set; }

        public override string ToString()
        {
            return Valor;
        }
    }
}
