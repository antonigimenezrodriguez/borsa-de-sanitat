// See https://aka.ms/new-console-template for more information
using BorsaSanitat;
using System.Numerics;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

var valuesPuntuacio = new Dictionary<string, string>
{
    {"codedicion", "19.0.7.0" },
    {"turnoCode","O" },
    {"departamentoCod", "ALY" },
    {"categoriaCod", "0001" },
    {"turnoDesc", "Ordinari" },
    {"categoriaDesc", "ENGINYER D'APLICACIONS I SISTEMES" },
    {"departamentoDesc", "ALCOY" },
    {"posicionFinal", "50" },
    {"posicionInicial", "1" },
    {"nw", "true" },
    {"titulo", "Reedició de les llistes d`ocupació temporal de l`edició 19.0.7 (resolución recursos i correccions). Publicació i entrada en vigor 13/01/2023." }
};

var responseString = await Utils.realizarDescargaWeb(Constantes.URL_PUNTUACIO, valuesPuntuacio);

var subString = responseString.Substring(responseString.IndexOf("<table"));

var tablaPunts = Utils.HtmlTable2List(subString);

var valuesSituacio = new Dictionary<string, string>
{
    {"codedicion", "19.0" },
    {"turnoCod","O" },
    {"categoriaCod", "0001" },
    {"departamentoCod", "ALY" },
    {"turnoDesc", "Ordinari" },
    {"categoriaDesc", "ENGINYER+D%27APLICACIONS+I+SISTEMES" },
    {"departamentoDesc", "ALCOY" },
    {"posicionInicial", "1" },
    {"posicionFinal", "50" },
    {"nw", "true" },
    //{"titulo", "Consulta de la situació en les llistes d'ocupació temporal de cada un dels candidats inscrits, a les 00:00 hores del dia de publicació (01/02/2023)" }
};


responseString = await Utils.realizarDescargaWeb(Constantes.URL_SITUACIO, valuesSituacio);




List<Persona> personas = new List<Persona>();
foreach (var tableItem in tablaPunts)
{
    Persona persona = new Persona()
    {
        NumeroLlista = Int32.Parse(tableItem.ElementAt(0).Replace("&nbsp;","")),
        Nom = tableItem.ElementAt(1),
        puntuacio = Double.Parse(tableItem.ElementAt(2))
    };
    personas.Add(persona);
}

var asd = "";

