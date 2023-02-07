using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Models.Parámetros
{
    public class CategoriaCod
    {
        public string NombreCategoria { get; set; }
        public string CodigoCategoria { get; set; }

        public override string ToString()
        {
            return CodigoCategoria;
        }
    }
}
