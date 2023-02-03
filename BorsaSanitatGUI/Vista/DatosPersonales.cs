using BorsaSanitatGUI.Models;
using BorsaSanitatGUI.Utils;
using System.Data;

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
            List<CategoriaPuntos> categoriaPuntos = new List<CategoriaPuntos>();
            LB_Cargando.Visible = true;
            var valuesDadesPersonals = new Dictionary<string, string>
            {
                {"codedicion", "19.0.7.0" },
                {"nw", "true" },
                {"dni", TB_DNI.Text },
                {"apellido",  TB_Apellido.Text}
            };
            var responseString = await Metodos.realizarDescargaWeb(Constantes.URL_DADES_PERSONALS, valuesDadesPersonals);

            if (responseString.Contains("<table"))
            {
                var subString = responseString.Substring(responseString.IndexOf("<table"));
                StringReader stream = new StringReader(subString);
                string linea;
                while ((linea = stream.ReadLine()) != null)
                {
                    if (linea.Contains("Categoría"))
                    {
                        linea = linea.Substring(linea.IndexOf("Categoría"));
                        linea = linea.Replace("Categoría: ", "");
                        linea = linea.Replace("<br>", "");
                        categoriaPuntos.Add(new CategoriaPuntos() { Categoria = linea });
                    }
                }
                var tablaDatos = Metodos.HtmlTable2List(subString);
                StringReader streamTablaDatos = new StringReader(subString);
                int indice = -1;
                int numeroDepartamento = 0;
                foreach (var datos in tablaDatos)
                {
                    switch (datos[0])
                    {
                        case "1. Servicios prestados":
                            indice++;
                            numeroDepartamento = 0;
                            categoriaPuntos.ElementAt(indice).ServeisPrestats = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "1.1.1. Servicios en IISS públicas - Misma categoría":
                            categoriaPuntos.ElementAt(indice).ServicisEnIISSPubliquesMateixaCategoria = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "1.1.2. Servicios en IISS públicas - Distinta categoría":
                            categoriaPuntos.ElementAt(indice).ServicisEnIISSPubliquesDistintaCategoria = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "1.2. Servicios Milit., penit., socio-sanitario":
                            categoriaPuntos.ElementAt(indice).ServicisMilitarsPenitenciarisSocioSanitari = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "1.3. Servicios Concertados, Mutuas":
                            categoriaPuntos.ElementAt(indice).ServicisConcertatsMutues = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "2. Nota de oposición":
                            categoriaPuntos.ElementAt(indice).NotaOposicio = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "3. Valenciano":
                            categoriaPuntos.ElementAt(indice).Valencia = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "4. Formación especializada categoría y especialidad":
                            categoriaPuntos.ElementAt(indice).FormacioEspecialitzadaCategoriaEspecialitat = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "5. Formación contínua y continuada":
                            categoriaPuntos.ElementAt(indice).FormacioContinuaIContinuada = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "6. Diversidad funcional":
                            categoriaPuntos.ElementAt(indice).DiversitatFuncional = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "Total":
                            categoriaPuntos.ElementAt(indice).Total = double.Parse(datos[1].Replace(".", ","));
                            break;
                        default:

                            var departamento = Constantes.departamentoCod.Where(w => w.CodigoDepartamento.Equals(datos[0])).FirstOrDefault();
                            if (departamento != null)
                            {
                                string[] posiciones;
                                switch (numeroDepartamento)
                                {
                                    case 0:
                                        categoriaPuntos.ElementAt(indice).Departament1Nom = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departament1Lloc = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departament1Total = int.Parse(posiciones[1]);
                                        break;
                                    case 1:
                                        categoriaPuntos.ElementAt(indice).Departament2Nom = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departament2Lloc = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departament2Total = int.Parse(posiciones[1]);
                                        break;
                                    case 2:
                                        categoriaPuntos.ElementAt(indice).Departament3Nom = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departament3Lloc = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departament3Total = int.Parse(posiciones[1]);
                                        break;
                                    case 3:
                                        categoriaPuntos.ElementAt(indice).Departament4Nom = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departament4Lloc = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departament4Total = int.Parse(posiciones[1]);
                                        break;
                                    case 4:
                                        categoriaPuntos.ElementAt(indice).Departament5Nom = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departament5Lloc = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departament5Total = int.Parse(posiciones[1]);
                                        break;
                                    case 5:
                                        categoriaPuntos.ElementAt(indice).Departament6Nom = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departament6Lloc = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departament6Total = int.Parse(posiciones[1]);
                                        break;
                                    case 6:
                                        categoriaPuntos.ElementAt(indice).Departament7Nom = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departament7Lloc = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departament7Total = int.Parse(posiciones[1]);
                                        break;
                                }
                            }
                            numeroDepartamento++;
                            break;
                    }
                }
                DGV_Departament1.DataSource = new List<CategoriaPuntos>();
                DGV_Departament1.DataSource = categoriaPuntos;
                LB_Cargando.Visible = false;
            }
            else
            {
                MessageBox.Show("No es troba la informació sol·licitada. Canvia els paràmetres de búsqueda o prova passats uns minuts");
            }
        }
    }
}
