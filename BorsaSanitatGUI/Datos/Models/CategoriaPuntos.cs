using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Datos.Models
{
    public class CategoriaPuntos
    {
        public string Categoria { get; set; }
        public double ServiciosPrestados { get; set; }
        public double ServiciosEnIISSPublicasMismaCategoria { get; set; }
        public double ServiciosEnIISSPublicasDistintaCategoria { get; set; }
        public double ServiciosMilitaresPenitenciariosSocioSanitario { get; set; }
        public double ServiciosConcertadosMutuas { get; set; }
        public double NotaOposicion { get; set; }
        public double Valencia { get; set; }
        public double FormacionEspecializadaCategoriaEspecialidad { get; set; }
        public double FormacionContinuaYContinuada { get; set; }
        public double DiversidadFuncional { get; set; }
        public double Total { get; set; }
        public string Departamento1Nombre { get; set; }
        public int Departamento1Lugar { get; set; }
        public int Departamento1Total { get; set; }
        public string Departamento2Nombre { get; set; }
        public int Departamento2Lugar { get; set; }
        public int Departamento2Total { get; set; }
        public string Departamento3Nombre { get; set; }
        public int Departamento3Lugar { get; set; }
        public int Departamento3Total { get; set; }
        public string Departamento4Nombre { get; set; }
        public int Departamento4Lugar { get; set; }
        public int Departamento4Total { get; set; }
        public string Departamento5Nombre { get; set; }
        public int Departamento5Lugar { get; set; }
        public int Departamento5Total { get; set; }
        public string Departamento6Nombre { get; set; }
        public int Departamento6Lugar { get; set; }
        public int Departamento6Total { get; set; }
        public string Departamento7Nombre { get; set; }
        public int Departamento7Lugar { get; set; }
        public int Departamento7Total { get; set; }
    }
}
