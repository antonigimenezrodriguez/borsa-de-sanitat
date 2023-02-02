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
        public const string URL_SITUACIO = "https://www2.san.gva.es/bolsa/lstSituacionCandidatos.jsp";
        public const string URL_PUNTUACIO = "https://www2.san.gva.es/bolsa/lstCandidatosListaOperativa.jsp";

        public static List<DepartamentoCod> departamentoCod = new List<DepartamentoCod>()
        {
            new DepartamentoCod() { Clave = "Alicante", Valor = "ALI"},
            new DepartamentoCod() { Clave = "Alcoy", Valor = "ALY"},
            new DepartamentoCod() { Clave = "Arnau", Valor = "ARN"},
            new DepartamentoCod() { Clave = "Castellon", Valor = "CAS"},
            new DepartamentoCod() { Clave = "Clinico", Valor = "CLI"},
            new DepartamentoCod() { Clave = "Denia", Valor = "DEN"},
            new DepartamentoCod() { Clave = "Elda", Valor = "ELD"},
            new DepartamentoCod() { Clave = "Elx", Valor = "ELX"},
            new DepartamentoCod() { Clave = "Gandia", Valor = "GAN"},
            new DepartamentoCod() { Clave = "General", Valor = "GEN"},
            new DepartamentoCod() { Clave = "La Fe", Valor = "LFE"},
            new DepartamentoCod() { Clave = "Marina", Valor = "MBA"},
            new DepartamentoCod() { Clave = "Orihuela", Valor = "ORI"},
            new DepartamentoCod() { Clave = "Peset", Valor = "PES"},
            new DepartamentoCod() { Clave = "La Plana", Valor = "PLA"},
            new DepartamentoCod() { Clave = "Requena", Valor = "REQ"},
            new DepartamentoCod() { Clave = "Ribera", Valor = "RIB"},
            new DepartamentoCod() { Clave = "SA", Valor = "SA"},
            new DepartamentoCod() { Clave = "Sagunto", Valor = "SAG"},
            new DepartamentoCod() { Clave = "SES Castelló", Valor = "SC"},
            new DepartamentoCod() { Clave = "Serveis Centrals", Valor = "SCC"},
            new DepartamentoCod() { Clave = "S.P. Alacant", Valor = "SPA"},
            new DepartamentoCod() { Clave = "S.P. Castelló", Valor = "SPC"},
            new DepartamentoCod() { Clave = "S.P. Valencia", Valor = "SPV"},
            new DepartamentoCod() { Clave = "S.P. Alcoy", Valor = "SPY"},
            new DepartamentoCod() { Clave = "SV", Valor = "SV"},
            new DepartamentoCod() { Clave = "Torrevieja", Valor = "TRV"},
            new DepartamentoCod() { Clave = "Vinaroz", Valor = "VIN"},
            new DepartamentoCod() { Clave = "Xativa", Valor = "XAT"},

        };

        public static List<DepartamentoCod> categoriaCod = new List<DepartamentoCod>()
        {
            new DepartamentoCod() { Clave = "Telefonista", Valor = "0095"}, 
            new DepartamentoCod() { Clave = "Infermer/a especialista obstétrico-ginecològica", Valor = "0246"}, 
            new DepartamentoCod() { Clave = "Graduats en infermeria", Valor = "8001"}, 
            new DepartamentoCod() { Clave = "Infermer/a", Valor = "0285"}, 
            new DepartamentoCod() { Clave = "Tècnic d'informàtica", Valor = "0009"}, 
            new DepartamentoCod() { Clave = "Analista programador i de sistemes", Valor = "0002"}, 
            new DepartamentoCod() { Clave = "Enginyer d'aplicacions i sistemes", Valor = "0001"},
        };

    }
}
