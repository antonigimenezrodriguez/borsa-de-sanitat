using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Models.Parámetros
{
    public class Categoria
    {
        public string NombreCategoria { get; set; }
        [Key]
        public string CodigoCategoria { get; set; }

        public override string ToString()
        {
            return CodigoCategoria;
        }
    }
}
