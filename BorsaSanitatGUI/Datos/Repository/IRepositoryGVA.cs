using BorsaSanitatGUI.Datos.Models;
using BorsaSanitatGUI.Datos.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Datos.Repository
{
    public interface IRepositoryGVA
    {
        IList<Categoria> ObtenerCategorias();
        IList<Departamento> ObtenerDepartamentos();
        string ObtenerCodigoEdicionPorTipo(string tipo);
        IDictionary<string, string> ObtenerEtiquetasPuntuaciones();
    }
}
