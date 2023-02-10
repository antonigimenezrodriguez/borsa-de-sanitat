using BorsaSanitatGUI.Models.Parámetros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Utils
{
    public static class Constantes
    {
        private const string HOST = "https://www2.san.gva.es";
        public const string URL_SITUACIO = $"{HOST}/bolsa/lstSituacionCandidatos.jsp";
        public const string URL_PUNTUACIO = $"{HOST}/bolsa/lstCandidatosListaOperativa.jsp";
        public const string URL_DADES_PERSONALS = $"{HOST}/bolsa/lstDniApellido.jsp";
    }
}
