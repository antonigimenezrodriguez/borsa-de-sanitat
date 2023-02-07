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
        public string NombreDepartamento { get; set; }
        public string CodigoDepartamento { get; set; }

        public override string ToString()
        {
            return CodigoDepartamento;
        }
    }
}

