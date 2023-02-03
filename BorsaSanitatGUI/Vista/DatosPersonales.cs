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
using System.IO;

namespace BorsaSanitatGUI.Vista
{
    public partial class DatosPersonales : Form
    {
        public DatosPersonales()
        {
            InitializeComponent();
        }

        private async void BT_Buscar_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\tmp\\formato.txt"))
            {
                File.Delete("C:\\tmp\\formato.txt");
            }
            if (File.Exists("C:\\tmp\\respuesta.txt"))
            {
                File.Delete("C:\\tmp\\respuesta.txt");
            }
            StreamWriter sw = new StreamWriter("C:\\tmp\\formato.txt");
            StreamWriter sw2 = new StreamWriter("C:\\tmp\\respuesta.txt");
            LB_Cargando.Visible = true;
            var valuesDadesPersonals = new Dictionary<string, string>
            {
                {"codedicion", "19.0.7.0" },
                {"nw", "true" },
                {"dni", TB_DNI.Text },
                {"apellido",  TB_Apellido.Text}
            };
            var responseString = await Metodos.realizarDescargaWeb(Constantes.URL_DADES_PERSONALS, valuesDadesPersonals);
            sw2.WriteLine(responseString);
            if (responseString.Contains("<table"))
            {
                var subString = responseString.Substring(responseString.IndexOf("<table"));

                var tablaDatos = Metodos.HtmlTable2List(subString);

                foreach (var datos in tablaDatos)
                {
                    foreach (var item in datos)
                    {
                        sw.WriteLine(item);
                    }
                }
                sw.Close();
                LB_Cargando.Visible = false;
            }
            else
            {
                MessageBox.Show("No es troba la informació sol·licitada. Canvia els paràmetres de búsqueda o prova passats uns minuts");
            }
        }
    }
}
