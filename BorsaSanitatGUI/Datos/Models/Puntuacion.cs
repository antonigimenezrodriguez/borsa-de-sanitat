using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Datos.Models
{
    public class Puntuacion
    {
        [Key]
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }
}
