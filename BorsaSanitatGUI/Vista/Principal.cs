using BorsaSanitatGUI.EntityFramework;
using BorsaSanitatGUI.Models;
using BorsaSanitatGUI.Models.Parámetros;
using BorsaSanitatGUI.Utils;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public BorsaSanitatContext context { get; set; }
        public Principal()
        {
            context = new BorsaSanitatContext();
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            LB_Cargando.Visible = true;
            DGV_Listado.DataSource = new List<Persona>();
            Cursor.Current = Cursors.WaitCursor;
            BT_Buscar.Enabled = false;
            BT_ExportarExcel.Enabled = false;
            TB_Filtrar.Enabled = false;
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
            Cursor.Current = Cursors.WaitCursor;
            if (responseString.Contains("<table"))
            {
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
                Cursor.Current = Cursors.WaitCursor;
                if (responseString.Contains("<table"))
                {
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
                        };
                        personas.Add(persona);
                        index++;
                    }

                    foreach (var tableItem in tablaSituacio)
                    {
                        var persona = personas.Where(w => w.Nom == tableItem.ElementAt(1)).FirstOrDefault();
                        if (persona != null)
                        {
                            persona.Categoria = tableItem.ElementAt(3);
                            persona.Departament = tableItem.ElementAt(4);
                            persona.Situacio = tableItem.ElementAt(2);
                        }
                    }

                    DGV_Listado.DataSource = personas;
                    DGV_Listado.AutoResizeColumns();
                    DGV_Listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    foreach (DataGridViewColumn column in DGV_Listado.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                }
                else
                {
                    MessageBox.Show("No es troba la informació sol·licitada. Canvia els paràmetres de búsqueda o prova passats uns minuts");
                    DGV_Listado.DataSource = new List<Persona>();
                }
            }
            else
            {
                MessageBox.Show("No es troba la informació sol·licitada. Canvia els paràmetres de búsqueda o prova passats uns minuts");
                DGV_Listado.DataSource = new List<Persona>();
            }
            Cursor.Current = Cursors.Default;
            BT_Buscar.Enabled = true;
            BT_ExportarExcel.Enabled = true;
            TB_Filtrar.Enabled = true;
            LB_Cargando.Visible = false;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            CB_Departamento.DisplayMember = "NombreDepartamento";
            CB_Departamento.ValueMember = "CodigoDepartamento";
            List<Departamento> departamentos = context.Departamentos.OrderBy(o => o.NombreDepartamento).ToList();
            foreach (var element in departamentos)
            {
                CB_Departamento.Items.Add(element);
            }
            CB_Departamento.SelectedIndex = 0;


            CB_Categoria.DisplayMember = "NombreCategoria";
            CB_Categoria.ValueMember = "CodigoCategoria";
            List<Categoria> categorias = context.Categorias.OrderBy(o => o.NombreCategoria).ToList();
            foreach (var element in categorias)
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

        private void TB_Filtrar_TextChanged(object sender, EventArgs e)
        {
            DGV_Listado.DataSource = personas.Where(w => w.NumeroLlista.ToString().ToUpper().Contains(TB_Filtrar.Text.ToUpper())
                        || w.Categoria.ToUpper().Contains(TB_Filtrar.Text.ToUpper())
                        || w.Departament.ToUpper().Contains(TB_Filtrar.Text.ToUpper())
                        || w.Nom.ToUpper().Contains(TB_Filtrar.Text.ToUpper())
                        || w.Puntuacio.ToString().ToUpper().Contains(TB_Filtrar.Text.ToUpper())
                        || w.Situacio.ToUpper().Contains(TB_Filtrar.Text.ToUpper())).ToList();
        }

        private void BT_ExportarExcel_Click(object sender, EventArgs e)
        {
            DataTable tablaPersonas = new DataTable("Bolsa");
            tablaPersonas.Columns.AddRange(new DataColumn[] { new DataColumn("Numero", typeof(int)), new DataColumn("Nom"), new DataColumn("Puntuació", typeof(Double)), new DataColumn("Situació"), new DataColumn("Categoria"), new DataColumn("Departament") });

            foreach (Persona persona in personas)
            {
                tablaPersonas.Rows.Add(persona.NumeroLlista, persona.Nom, persona.Puntuacio, persona.Situacio, persona.Categoria, persona.Departament);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(tablaPersonas);
                ws.Columns().AdjustToContents();
                using (MemoryStream stream = new MemoryStream())
                {
                    try
                    {
                        SaveFileDialog dialogo = new SaveFileDialog
                        {
                            Filter = "Archivo Excel|*.xlsx",
                            Title = "Guardar Excel",
                            FileName = "Borsa sanitat"
                        };
                        dialogo.ShowDialog();
                        if (dialogo.FileName != "")
                        {
                            wb.SaveAs(dialogo.FileName);
                            MessageBox.Show("Excel generado con éxito");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se ha producido un error " + ex.Message);
                    }
                }
            }
        }

        private void BT_Datos_Click(object sender, EventArgs e)
        {
            DatosPersonales formDatosPersonales = new DatosPersonales();
            formDatosPersonales.ShowDialog();
        }
    }
}
