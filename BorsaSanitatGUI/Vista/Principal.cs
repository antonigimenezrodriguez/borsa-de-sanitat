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
        List<Persona> personas = new List<Persona>();
        bool sortNumeroAsc = true;
        bool sortNombreAsc = true;
        bool sortPuntosAsc = true;
        bool sortSituacionAsc = true;
        bool sortCategoriaAsc = true;
        bool sortDepartamentAsc = true;
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
                    {"categoriaCod", CB_Categoria.SelectedItem.ToString() },
                    {"posicionFinal", NUD_Final.Value.ToString() },
                    {"posicionInicial", NUD_Inicio.Value.ToString() },
                    {"nw", "true" },
                };

            var responseString = await Metodos.realizarDescargaWeb(Constantes.URL_PUNTUACIO, valuesPuntuacio);

            var subString = responseString.Substring(responseString.IndexOf("<table"));

            var tablaPunts = Metodos.HtmlTable2List(subString);

            var valuesSituacio = new Dictionary<string, string>
{
                    {"codedicion", "19.0" },
                    {"turnoCod","O" },
                    {"categoriaCod", CB_Categoria.SelectedItem.ToString() },
                    {"departamentoCod", CB_Departamento.SelectedItem.ToString() },
                    {"posicionFinal", NUD_Final.Value.ToString() },
                    {"posicionInicial", NUD_Inicio.Value.ToString() },
                    {"nw", "true" },
                };


            responseString = await Metodos.realizarDescargaWeb(Constantes.URL_SITUACIO, valuesSituacio);

            subString = responseString.Substring(responseString.IndexOf("<table"));

            var tablaSituacio = Metodos.HtmlTable2List(subString);


            personas = new List<Persona>();
            int index = 0;
            foreach (var tableItem in tablaPunts)
            {
                Persona persona = new Persona()
                {
                    NumeroLlista = Int32.Parse(tableItem.ElementAt(0).Replace("&nbsp;", "")),
                    Nom = tableItem.ElementAt(1),
                    Puntuacio = Double.Parse(tableItem.ElementAt(2).Replace('.', ',')),
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
            foreach (DataGridViewColumn column in DGV_Listado.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
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
            CB_Departamento.SelectedIndex = 0;


            CB_Categoria.DisplayMember = "Clave";
            CB_Categoria.ValueMember = "Valor";
            foreach (var element in Constantes.categoriaCod.OrderBy(o => o.Clave))
            {
                CB_Categoria.Items.Add(element);
            }
            CB_Categoria.SelectedIndex = 0;
        }

        private void DGV_Listado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0: //Numero de llista
                    if (sortNumeroAsc)
                        DGV_Listado.DataSource = personas.OrderBy(o => o.NumeroLlista).ToList();
                    else
                        DGV_Listado.DataSource = personas.OrderByDescending(o => o.NumeroLlista).ToList();
                    sortNumeroAsc = !sortNumeroAsc;
                    break;
                case 1: //Nom
                    if (sortNombreAsc)
                        DGV_Listado.DataSource = personas.OrderBy(o => o.Nom).ToList();
                    else
                        DGV_Listado.DataSource = personas.OrderByDescending(o => o.Nom).ToList();
                    sortNombreAsc = !sortNombreAsc;
                    break;
                case 2: //Puntuacio
                    if (sortPuntosAsc)
                        DGV_Listado.DataSource = personas.OrderBy(o => o.Puntuacio).ToList();
                    else
                        DGV_Listado.DataSource = personas.OrderByDescending(o => o.Puntuacio).ToList();
                    sortPuntosAsc = !sortPuntosAsc;
                    break;
                case 3: //Situacio
                    if (sortSituacionAsc)
                        DGV_Listado.DataSource = personas.OrderBy(o => o.Situacio).ToList();
                    else
                        DGV_Listado.DataSource = personas.OrderByDescending(o => o.Situacio).ToList();
                    sortSituacionAsc = !sortSituacionAsc;
                    break;
                case 4: //Categoria
                    if (sortCategoriaAsc)
                        DGV_Listado.DataSource = personas.OrderBy(o => o.Categoria).ToList();
                    else
                        DGV_Listado.DataSource = personas.OrderByDescending(o => o.Categoria).ToList();
                    sortCategoriaAsc = !sortCategoriaAsc;
                    break;
                case 5: //Departament
                    if (sortDepartamentAsc)
                        DGV_Listado.DataSource = personas.OrderBy(o => o.Departament).ToList();
                    else
                        DGV_Listado.DataSource = personas.OrderByDescending(o => o.Departament).ToList();
                    sortDepartamentAsc = !sortDepartamentAsc;
                    break;

            }

        }
    }
}
