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
            var asd2 = CB_Departamento.SelectedItem.ToString();
            Cursor.Current = Cursors.WaitCursor;
            button1.Enabled = false;
            var valuesPuntuacio = new Dictionary<string, string>
                {
                    {"codedicion", "19.0.7.0" },
                    {"turnoCode","O" },
                    {"departamentoCod", CB_Departamento.SelectedItem.ToString() },
                    {"categoriaCod", "0001" },
                    {"posicionFinal", "80" },
                    {"posicionInicial", "1" },
                    {"nw", "true" },
                };

            var responseString = await Metodos.realizarDescargaWeb(Constantes.URL_PUNTUACIO, valuesPuntuacio);

            var subString = responseString.Substring(responseString.IndexOf("<table"));

            var tablaPunts = Metodos.HtmlTable2List(subString);

            var valuesSituacio = new Dictionary<string, string>
{
                    {"codedicion", "19.0" },
                    {"turnoCod","O" },
                    {"categoriaCod", "0001" },
                    {"departamentoCod", CB_Departamento.SelectedItem.ToString() },
                    {"posicionInicial", "1" },
                    {"posicionFinal", "80" },
                    {"nw", "true" },
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

            DGV_Listado.DataSource = personas;
            DGV_Listado.AutoResizeColumns();
            DGV_Listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor.Current = Cursors.Default;
            button1.Enabled = true;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            CB_Departamento.DisplayMember = "Clave";
            CB_Departamento.ValueMember = "Valor";
            foreach (var element in Constantes.departamentoCod)
            {
                CB_Departamento.Items.Add(element);
            }
        }
    }
}
