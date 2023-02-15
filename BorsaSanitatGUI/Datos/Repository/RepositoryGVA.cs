using BorsaSanitatGUI.Datos.EntityFramework;
using BorsaSanitatGUI.Datos.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Datos.Repository
{
    internal class RepositoryGVA : IRepositoryGVA
    {
        public BorsaSanitatContext Context { get; set; }
        public RepositoryGVA()
        {
            this.Context = new BorsaSanitatContext();
        }
        public IList<Departamento> ObtenerDepartamentos()
        {
            return Context.Departamentos.ToList();
        }

        public IList<Categoria> ObtenerCategorias()
        {
            return Context.Categorias.ToList();
        }
        public string ObtenerCodigoEdicionPorTipo(string tipo)
        {
            return Context.CodigosEdiciones.Where(w => w.Tipo == tipo).FirstOrDefault()?.Edicion;
        }
    }
}
