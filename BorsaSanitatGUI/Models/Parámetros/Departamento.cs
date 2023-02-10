using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BorsaSanitatGUI.Models.Parámetros
{
    public class Departamento
    {
        public string NombreDepartamento { get; set; }
        [Key]
        public string CodigoDepartamento { get; set; }

        public override string ToString()
        {
            return CodigoDepartamento;
        }
    }
}

