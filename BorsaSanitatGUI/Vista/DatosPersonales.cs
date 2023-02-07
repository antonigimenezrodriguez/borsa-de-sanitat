using BorsaSanitatGUI.Models;
using BorsaSanitatGUI.Models.GridViews;
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
                List<GridViewPuntuacion> listaCategoria1 = new List<GridViewPuntuacion>();
                List<GridViewPosicionDepartamentos> listaCategoria1Departamentos = new List<GridViewPosicionDepartamentos>();
                if (categoriaPuntos.ElementAt(0) != null)
                {
                    LB_Categoria1.Text = categoriaPuntos.ElementAt(0).Categoria;
                    LB_Categoria1.Visible = true;
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1. Servicios prestados", Valor = categoriaPuntos.ElementAt(0).ServeisPrestats });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.1. Servicios en IISS públicas - Misma categoría", Valor = categoriaPuntos.ElementAt(0).ServicisEnIISSPubliquesMateixaCategoria });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.2. Servicios en IISS públicas - Distinta categoría", Valor = categoriaPuntos.ElementAt(0).ServicisEnIISSPubliquesDistintaCategoria });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.2. Servicios Milit., penit., socio-sanitario", Valor = categoriaPuntos.ElementAt(0).ServicisMilitarsPenitenciarisSocioSanitari });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.3. Servicios Concertados, Mutuas", Valor = categoriaPuntos.ElementAt(0).ServicisConcertatsMutues });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "2. Nota de oposición", Valor = categoriaPuntos.ElementAt(0).NotaOposicio });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "3. Valenciano", Valor = categoriaPuntos.ElementAt(0).Valencia });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "4. Formación especializada categoría y especialidad", Valor = categoriaPuntos.ElementAt(0).FormacioEspecialitzadaCategoriaEspecialitat });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "5. Formación contínua y continuada", Valor = categoriaPuntos.ElementAt(0).FormacioContinuaIContinuada });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "6. Diversidad funcional", Valor = categoriaPuntos.ElementAt(0).DiversitatFuncional });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "Total", Valor = categoriaPuntos.ElementAt(0).Total });

                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departament1Nom, Posicion = categoriaPuntos.ElementAt(0).Departament1Lloc, TotalInscritos = categoriaPuntos.ElementAt(0).Departament1Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departament1Lloc / (double)categoriaPuntos.ElementAt(0).Departament1Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departament2Nom, Posicion = categoriaPuntos.ElementAt(0).Departament2Lloc, TotalInscritos = categoriaPuntos.ElementAt(0).Departament2Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departament2Lloc / (double)categoriaPuntos.ElementAt(0).Departament2Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departament3Nom, Posicion = categoriaPuntos.ElementAt(0).Departament3Lloc, TotalInscritos = categoriaPuntos.ElementAt(0).Departament3Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departament3Lloc / (double)categoriaPuntos.ElementAt(0).Departament3Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departament4Nom, Posicion = categoriaPuntos.ElementAt(0).Departament4Lloc, TotalInscritos = categoriaPuntos.ElementAt(0).Departament4Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departament4Lloc / (double)categoriaPuntos.ElementAt(0).Departament4Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departament5Nom, Posicion = categoriaPuntos.ElementAt(0).Departament5Lloc, TotalInscritos = categoriaPuntos.ElementAt(0).Departament5Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departament5Lloc / (double)categoriaPuntos.ElementAt(0).Departament5Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departament6Nom, Posicion = categoriaPuntos.ElementAt(0).Departament6Lloc, TotalInscritos = categoriaPuntos.ElementAt(0).Departament6Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departament6Lloc / (double)categoriaPuntos.ElementAt(0).Departament6Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departament7Nom, Posicion = categoriaPuntos.ElementAt(0).Departament7Lloc, TotalInscritos = categoriaPuntos.ElementAt(0).Departament7Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departament7Lloc / (double)categoriaPuntos.ElementAt(0).Departament7Total) * 100, 2) });
                }
                DGV_Categoria1.DataSource = listaCategoria1;
                DGV_Categoria1.AutoResizeColumns();
                DGV_Categoria1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataGridViewColumn column in DGV_Categoria1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                DGV_Categoria1Departaments.DataSource = listaCategoria1Departamentos;
                DGV_Categoria1Departaments.AutoResizeColumns();
                DGV_Categoria1Departaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataGridViewColumn column in DGV_Categoria1Departaments.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                List<GridViewPuntuacion> listaCategoria2 = new List<GridViewPuntuacion>();
                List<GridViewPosicionDepartamentos> listaCategoria2Departamentos = new List<GridViewPosicionDepartamentos>();
                if (categoriaPuntos.ElementAt(1) != null)
                {
                    LB_Categoria2.Text = categoriaPuntos.ElementAt(1).Categoria;
                    LB_Categoria2.Visible = true;
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1. Servicios prestados", Valor = categoriaPuntos.ElementAt(1).ServeisPrestats });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.1. Servicios en IISS públicas - Misma categoría", Valor = categoriaPuntos.ElementAt(1).ServicisEnIISSPubliquesMateixaCategoria });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.2. Servicios en IISS públicas - Distinta categoría", Valor = categoriaPuntos.ElementAt(1).ServicisEnIISSPubliquesDistintaCategoria });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.2. Servicios Milit., penit., socio-sanitario", Valor = categoriaPuntos.ElementAt(1).ServicisMilitarsPenitenciarisSocioSanitari });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.3. Servicios Concertados, Mutuas", Valor = categoriaPuntos.ElementAt(1).ServicisConcertatsMutues });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "2. Nota de oposición", Valor = categoriaPuntos.ElementAt(1).NotaOposicio });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "3. Valenciano", Valor = categoriaPuntos.ElementAt(1).Valencia });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "4. Formación especializada categoría y especialidad", Valor = categoriaPuntos.ElementAt(1).FormacioEspecialitzadaCategoriaEspecialitat });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "5. Formación contínua y continuada", Valor = categoriaPuntos.ElementAt(1).FormacioContinuaIContinuada });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "6. Diversidad funcional", Valor = categoriaPuntos.ElementAt(1).DiversitatFuncional });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "Total", Valor = categoriaPuntos.ElementAt(1).Total });

                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departament1Nom, Posicion = categoriaPuntos.ElementAt(1).Departament1Lloc, TotalInscritos = categoriaPuntos.ElementAt(1).Departament1Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departament1Lloc / (double)categoriaPuntos.ElementAt(1).Departament1Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departament2Nom, Posicion = categoriaPuntos.ElementAt(1).Departament2Lloc, TotalInscritos = categoriaPuntos.ElementAt(1).Departament2Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departament2Lloc / (double)categoriaPuntos.ElementAt(1).Departament2Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departament3Nom, Posicion = categoriaPuntos.ElementAt(1).Departament3Lloc, TotalInscritos = categoriaPuntos.ElementAt(1).Departament3Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departament3Lloc / (double)categoriaPuntos.ElementAt(1).Departament3Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departament4Nom, Posicion = categoriaPuntos.ElementAt(1).Departament4Lloc, TotalInscritos = categoriaPuntos.ElementAt(1).Departament4Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departament4Lloc / (double)categoriaPuntos.ElementAt(1).Departament4Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departament5Nom, Posicion = categoriaPuntos.ElementAt(1).Departament5Lloc, TotalInscritos = categoriaPuntos.ElementAt(1).Departament5Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departament5Lloc / (double)categoriaPuntos.ElementAt(1).Departament5Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departament6Nom, Posicion = categoriaPuntos.ElementAt(1).Departament6Lloc, TotalInscritos = categoriaPuntos.ElementAt(1).Departament6Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departament6Lloc / (double)categoriaPuntos.ElementAt(1).Departament6Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departament7Nom, Posicion = categoriaPuntos.ElementAt(1).Departament7Lloc, TotalInscritos = categoriaPuntos.ElementAt(1).Departament7Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departament7Lloc / (double)categoriaPuntos.ElementAt(1).Departament7Total) * 100, 2) });
                }
                DGV_Categoria2.DataSource = listaCategoria2;
                DGV_Categoria2.AutoResizeColumns();
                DGV_Categoria2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataGridViewColumn column in DGV_Categoria2.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                DGV_Categoria2Departaments.DataSource = listaCategoria2Departamentos;
                DGV_Categoria2Departaments.AutoResizeColumns();
                DGV_Categoria2Departaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataGridViewColumn column in DGV_Categoria2Departaments.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                List<GridViewPuntuacion> listaCategoria3 = new List<GridViewPuntuacion>();
                List<GridViewPosicionDepartamentos> listaCategoria3Departamentos = new List<GridViewPosicionDepartamentos>();

                if (categoriaPuntos.ElementAt(2) != null)
                {
                    LB_Categoria3.Text = categoriaPuntos.ElementAt(2).Categoria;
                    LB_Categoria3.Visible = true;
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1. Servicios prestados", Valor = categoriaPuntos.ElementAt(2).ServeisPrestats });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.1. Servicios en IISS públicas - Misma categoría", Valor = categoriaPuntos.ElementAt(2).ServicisEnIISSPubliquesMateixaCategoria });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.2. Servicios en IISS públicas - Distinta categoría", Valor = categoriaPuntos.ElementAt(2).ServicisEnIISSPubliquesDistintaCategoria });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.2. Servicios Milit., penit., socio-sanitario", Valor = categoriaPuntos.ElementAt(2).ServicisMilitarsPenitenciarisSocioSanitari });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.3. Servicios Concertados, Mutuas", Valor = categoriaPuntos.ElementAt(2).ServicisConcertatsMutues });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "2. Nota de oposición", Valor = categoriaPuntos.ElementAt(2).NotaOposicio });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "3. Valenciano", Valor = categoriaPuntos.ElementAt(2).Valencia });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "4. Formación especializada categoría y especialidad", Valor = categoriaPuntos.ElementAt(2).FormacioEspecialitzadaCategoriaEspecialitat });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "5. Formación contínua y continuada", Valor = categoriaPuntos.ElementAt(2).FormacioContinuaIContinuada });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "6. Diversidad funcional", Valor = categoriaPuntos.ElementAt(2).DiversitatFuncional });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "Total", Valor = categoriaPuntos.ElementAt(2).Total });

                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departament1Nom, Posicion = categoriaPuntos.ElementAt(2).Departament1Lloc, TotalInscritos = categoriaPuntos.ElementAt(2).Departament1Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departament1Lloc / (double)categoriaPuntos.ElementAt(2).Departament1Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departament2Nom, Posicion = categoriaPuntos.ElementAt(2).Departament2Lloc, TotalInscritos = categoriaPuntos.ElementAt(2).Departament2Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departament2Lloc / (double)categoriaPuntos.ElementAt(2).Departament2Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departament3Nom, Posicion = categoriaPuntos.ElementAt(2).Departament3Lloc, TotalInscritos = categoriaPuntos.ElementAt(2).Departament3Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departament3Lloc / (double)categoriaPuntos.ElementAt(2).Departament3Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departament4Nom, Posicion = categoriaPuntos.ElementAt(2).Departament4Lloc, TotalInscritos = categoriaPuntos.ElementAt(2).Departament4Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departament4Lloc / (double)categoriaPuntos.ElementAt(2).Departament4Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departament5Nom, Posicion = categoriaPuntos.ElementAt(2).Departament5Lloc, TotalInscritos = categoriaPuntos.ElementAt(2).Departament5Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departament5Lloc / (double)categoriaPuntos.ElementAt(2).Departament5Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departament6Nom, Posicion = categoriaPuntos.ElementAt(2).Departament6Lloc, TotalInscritos = categoriaPuntos.ElementAt(2).Departament6Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departament6Lloc / (double)categoriaPuntos.ElementAt(2).Departament6Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departament7Nom, Posicion = categoriaPuntos.ElementAt(2).Departament7Lloc, TotalInscritos = categoriaPuntos.ElementAt(2).Departament7Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departament7Lloc / (double)categoriaPuntos.ElementAt(2).Departament7Total) * 100, 2) });

                }
                DGV_Categoria3.DataSource = listaCategoria3;
                DGV_Categoria3.AutoResizeColumns();
                DGV_Categoria3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataGridViewColumn column in DGV_Categoria3.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                DGV_Categoria3Departaments.DataSource = listaCategoria3Departamentos;
                DGV_Categoria3Departaments.AutoResizeColumns();
                DGV_Categoria3Departaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataGridViewColumn column in DGV_Categoria3Departaments.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                LB_Cargando.Visible = false;
            }
            else
            {
                MessageBox.Show("No es troba la informació sol·licitada. Canvia els paràmetres de búsqueda o prova passats uns minuts");
            }
        }
    }
}
