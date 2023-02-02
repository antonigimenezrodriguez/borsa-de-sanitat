using BorsaSanitatGUI.Models;
using BorsaSanitatGUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorsaSanitatGUI.Vista
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            button1.Enabled = false;
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

            var responseString = await Metodos.realizarDescargaWeb(Constantes.URL_PUNTUACIO, valuesPuntuacio);

            var subString = responseString.Substring(responseString.IndexOf("<table"));

            var tablaPunts = Metodos.HtmlTable2List(subString);

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


            responseString = await Metodos.realizarDescargaWeb(Constantes.URL_SITUACIO, valuesSituacio);

            subString = responseString.Substring(responseString.IndexOf("<table"));

            var tablaSituacio = Metodos.HtmlTable2List(subString);


            List<Persona> personas = new List<Persona>();
            int index = 0;
            foreach (var tableItem in tablaPunts)
            {
                Persona persona = new Persona()
                {
                    NumeroLlista = Int32.Parse(tableItem.ElementAt(0).Replace("&nbsp;", "")),
                    Nom = tableItem.ElementAt(1),
                    puntuacio = Double.Parse(tableItem.ElementAt(2).Replace('.', ',')),
                    Categoria = tablaSituacio.ElementAt(index).ElementAt(3),
                    Departament = tablaSituacio.ElementAt(index).ElementAt(4),
                    Situacio = tablaSituacio.ElementAt(index).ElementAt(2),
                };
                personas.Add(persona);
                index++;
            }

            var asd = "";

            /*  foreach (var persona in personas)
              {
                  Console.WriteLine($"Número: {persona.NumeroLlista} Nom: {persona.Nom} Puntuació: {persona.puntuacio} Situació: {persona.Situacio} Categoria: {persona.Categoria} Departament: {persona.Departament}");
                  lb_listado.Items.Add(personas);
              }*/

            DGV_Listado.DataSource = personas;

            Cursor.Current = Cursors.Default;
            button1.Enabled = true;
        }
    }
}
