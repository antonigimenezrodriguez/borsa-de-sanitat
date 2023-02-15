using BorsaSanitatGUI.Datos.Models;
using BorsaSanitatGUI.Datos.Models.GridViews;
using BorsaSanitatGUI.Datos.Repository;
using BorsaSanitatGUI.Utils;
using System.Data;

namespace BorsaSanitatGUI.Vista
{
    public partial class DatosPersonales : Form
    {
        public IRepositoryGVA RepositoryGVA { get; set; }
        public DatosPersonales()
        {
            this.RepositoryGVA = new RepositoryGVA();
            InitializeComponent();
        }

        private async void BT_Buscar_Click(object sender, EventArgs e)
        {
            List<CategoriaPuntos> categoriaPuntos = new List<CategoriaPuntos>();
            LB_Cargando.Visible = true;
            var valuesDadesPersonals = new Dictionary<string, string>
            {
                {"codedicion", RepositoryGVA.ObtenerCodigoEdicionPorTipo(Constantes.CLAVE_EDICION_DATOS_PERSONALES) },
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
                            categoriaPuntos.ElementAt(indice).ServiciosPrestados = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "1.1.1. Servicios en IISS públicas - Misma categoría":
                            categoriaPuntos.ElementAt(indice).ServiciosEnIISSPublicasMismaCategoria = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "1.1.2. Servicios en IISS públicas - Distinta categoría":
                            categoriaPuntos.ElementAt(indice).ServiciosEnIISSPublicasDistintaCategoria = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "1.2. Servicios Milit., penit., socio-sanitario":
                            categoriaPuntos.ElementAt(indice).ServiciosMilitaresPenitenciariosSocioSanitario = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "1.3. Servicios Concertados, Mutuas":
                            categoriaPuntos.ElementAt(indice).ServiciosConcertadosMutuas = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "2. Nota de oposición":
                            categoriaPuntos.ElementAt(indice).NotaOposicion = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "3. Valenciano":
                            categoriaPuntos.ElementAt(indice).Valencia = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "4. Formación especializada categoría y especialidad":
                            categoriaPuntos.ElementAt(indice).FormacionEspecializadaCategoriaEspecialidad = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "5. Formación contínua y continuada":
                            categoriaPuntos.ElementAt(indice).FormacionContinuaYContinuada = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "6. Diversidad funcional":
                            categoriaPuntos.ElementAt(indice).DiversidadFuncional = double.Parse(datos[1].Replace(".", ","));
                            break;
                        case "Total":
                            categoriaPuntos.ElementAt(indice).Total = double.Parse(datos[1].Replace(".", ","));
                            break;
                        default:

                            var departamento = RepositoryGVA.ObtenerDepartamentos().Where(w => w.CodigoDepartamento.Equals(datos[0])).FirstOrDefault();
                            if (departamento != null)
                            {
                                string[] posiciones;
                                switch (numeroDepartamento)
                                {
                                    case 0:
                                        categoriaPuntos.ElementAt(indice).Departamento1Nombre = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departamento1Lugar = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departamento1Total = int.Parse(posiciones[1]);
                                        break;
                                    case 1:
                                        categoriaPuntos.ElementAt(indice).Departamento2Nombre = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departamento2Lugar = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departamento2Total = int.Parse(posiciones[1]);
                                        break;
                                    case 2:
                                        categoriaPuntos.ElementAt(indice).Departamento3Nombre = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departamento3Lugar = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departamento3Total = int.Parse(posiciones[1]);
                                        break;
                                    case 3:
                                        categoriaPuntos.ElementAt(indice).Departamento4Nombre = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departamento4Lugar = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departamento4Total = int.Parse(posiciones[1]);
                                        break;
                                    case 4:
                                        categoriaPuntos.ElementAt(indice).Departamento5Nombre = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departamento5Lugar = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departamento5Total = int.Parse(posiciones[1]);
                                        break;
                                    case 5:
                                        categoriaPuntos.ElementAt(indice).Departamento6Nombre = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departamento6Lugar = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departamento6Total = int.Parse(posiciones[1]);
                                        break;
                                    case 6:
                                        categoriaPuntos.ElementAt(indice).Departamento7Nombre = departamento.NombreDepartamento;
                                        posiciones = datos[1].Replace(" ", "").Replace("\r\n", "").Split("/");
                                        categoriaPuntos.ElementAt(indice).Departamento7Lugar = int.Parse(posiciones[0]);
                                        categoriaPuntos.ElementAt(indice).Departamento7Total = int.Parse(posiciones[1]);
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
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1. Servicios prestados", Valor = categoriaPuntos.ElementAt(0).ServiciosPrestados });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.1. Servicios en IISS públicas - Misma categoría", Valor = categoriaPuntos.ElementAt(0).ServiciosEnIISSPublicasMismaCategoria });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.2. Servicios en IISS públicas - Distinta categoría", Valor = categoriaPuntos.ElementAt(0).ServiciosEnIISSPublicasDistintaCategoria });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.2. Servicios Milit., penit., socio-sanitario", Valor = categoriaPuntos.ElementAt(0).ServiciosMilitaresPenitenciariosSocioSanitario });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.3. Servicios Concertados, Mutuas", Valor = categoriaPuntos.ElementAt(0).ServiciosConcertadosMutuas });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "2. Nota de oposición", Valor = categoriaPuntos.ElementAt(0).NotaOposicion });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "3. Valenciano", Valor = categoriaPuntos.ElementAt(0).Valencia });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "4. Formación especializada categoría y especialidad", Valor = categoriaPuntos.ElementAt(0).FormacionEspecializadaCategoriaEspecialidad });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "5. Formación contínua y continuada", Valor = categoriaPuntos.ElementAt(0).FormacionContinuaYContinuada });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "6. Diversidad funcional", Valor = categoriaPuntos.ElementAt(0).DiversidadFuncional });
                    listaCategoria1.Add(new GridViewPuntuacion() { TipoPuntuacion = "Total", Valor = categoriaPuntos.ElementAt(0).Total });

                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departamento1Nombre, Posicion = categoriaPuntos.ElementAt(0).Departamento1Lugar, TotalInscritos = categoriaPuntos.ElementAt(0).Departamento1Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departamento1Lugar / (double)categoriaPuntos.ElementAt(0).Departamento1Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departamento2Nombre, Posicion = categoriaPuntos.ElementAt(0).Departamento2Lugar, TotalInscritos = categoriaPuntos.ElementAt(0).Departamento2Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departamento2Lugar / (double)categoriaPuntos.ElementAt(0).Departamento2Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departamento3Nombre, Posicion = categoriaPuntos.ElementAt(0).Departamento3Lugar, TotalInscritos = categoriaPuntos.ElementAt(0).Departamento3Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departamento3Lugar / (double)categoriaPuntos.ElementAt(0).Departamento3Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departamento4Nombre, Posicion = categoriaPuntos.ElementAt(0).Departamento4Lugar, TotalInscritos = categoriaPuntos.ElementAt(0).Departamento4Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departamento4Lugar / (double)categoriaPuntos.ElementAt(0).Departamento4Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departamento5Nombre, Posicion = categoriaPuntos.ElementAt(0).Departamento5Lugar, TotalInscritos = categoriaPuntos.ElementAt(0).Departamento5Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departamento5Lugar / (double)categoriaPuntos.ElementAt(0).Departamento5Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departamento6Nombre, Posicion = categoriaPuntos.ElementAt(0).Departamento6Lugar, TotalInscritos = categoriaPuntos.ElementAt(0).Departamento6Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departamento6Lugar / (double)categoriaPuntos.ElementAt(0).Departamento6Total) * 100, 2) });
                    listaCategoria1Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(0).Departamento7Nombre, Posicion = categoriaPuntos.ElementAt(0).Departamento7Lugar, TotalInscritos = categoriaPuntos.ElementAt(0).Departamento7Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(0).Departamento7Lugar / (double)categoriaPuntos.ElementAt(0).Departamento7Total) * 100, 2) });
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
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1. Servicios prestados", Valor = categoriaPuntos.ElementAt(1).ServiciosPrestados });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.1. Servicios en IISS públicas - Misma categoría", Valor = categoriaPuntos.ElementAt(1).ServiciosEnIISSPublicasMismaCategoria });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.2. Servicios en IISS públicas - Distinta categoría", Valor = categoriaPuntos.ElementAt(1).ServiciosEnIISSPublicasDistintaCategoria });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.2. Servicios Milit., penit., socio-sanitario", Valor = categoriaPuntos.ElementAt(1).ServiciosMilitaresPenitenciariosSocioSanitario });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.3. Servicios Concertados, Mutuas", Valor = categoriaPuntos.ElementAt(1).ServiciosConcertadosMutuas });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "2. Nota de oposición", Valor = categoriaPuntos.ElementAt(1).NotaOposicion });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "3. Valenciano", Valor = categoriaPuntos.ElementAt(1).Valencia });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "4. Formación especializada categoría y especialidad", Valor = categoriaPuntos.ElementAt(1).FormacionEspecializadaCategoriaEspecialidad });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "5. Formación contínua y continuada", Valor = categoriaPuntos.ElementAt(1).FormacionContinuaYContinuada });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "6. Diversidad funcional", Valor = categoriaPuntos.ElementAt(1).DiversidadFuncional });
                    listaCategoria2.Add(new GridViewPuntuacion() { TipoPuntuacion = "Total", Valor = categoriaPuntos.ElementAt(1).Total });

                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departamento1Nombre, Posicion = categoriaPuntos.ElementAt(1).Departamento1Lugar, TotalInscritos = categoriaPuntos.ElementAt(1).Departamento1Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departamento1Lugar / (double)categoriaPuntos.ElementAt(1).Departamento1Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departamento2Nombre, Posicion = categoriaPuntos.ElementAt(1).Departamento2Lugar, TotalInscritos = categoriaPuntos.ElementAt(1).Departamento2Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departamento2Lugar / (double)categoriaPuntos.ElementAt(1).Departamento2Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departamento3Nombre, Posicion = categoriaPuntos.ElementAt(1).Departamento3Lugar, TotalInscritos = categoriaPuntos.ElementAt(1).Departamento3Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departamento3Lugar / (double)categoriaPuntos.ElementAt(1).Departamento3Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departamento4Nombre, Posicion = categoriaPuntos.ElementAt(1).Departamento4Lugar, TotalInscritos = categoriaPuntos.ElementAt(1).Departamento4Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departamento4Lugar / (double)categoriaPuntos.ElementAt(1).Departamento4Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departamento5Nombre, Posicion = categoriaPuntos.ElementAt(1).Departamento5Lugar, TotalInscritos = categoriaPuntos.ElementAt(1).Departamento5Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departamento5Lugar / (double)categoriaPuntos.ElementAt(1).Departamento5Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departamento6Nombre, Posicion = categoriaPuntos.ElementAt(1).Departamento6Lugar, TotalInscritos = categoriaPuntos.ElementAt(1).Departamento6Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departamento6Lugar / (double)categoriaPuntos.ElementAt(1).Departamento6Total) * 100, 2) });
                    listaCategoria2Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(1).Departamento7Nombre, Posicion = categoriaPuntos.ElementAt(1).Departamento7Lugar, TotalInscritos = categoriaPuntos.ElementAt(1).Departamento7Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(1).Departamento7Lugar / (double)categoriaPuntos.ElementAt(1).Departamento7Total) * 100, 2) });
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
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1. Servicios prestados", Valor = categoriaPuntos.ElementAt(2).ServiciosPrestados });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.1. Servicios en IISS públicas - Misma categoría", Valor = categoriaPuntos.ElementAt(2).ServiciosEnIISSPublicasMismaCategoria });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.1.2. Servicios en IISS públicas - Distinta categoría", Valor = categoriaPuntos.ElementAt(2).ServiciosEnIISSPublicasDistintaCategoria });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.2. Servicios Milit., penit., socio-sanitario", Valor = categoriaPuntos.ElementAt(2).ServiciosMilitaresPenitenciariosSocioSanitario });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "1.3. Servicios Concertados, Mutuas", Valor = categoriaPuntos.ElementAt(2).ServiciosConcertadosMutuas });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "2. Nota de oposición", Valor = categoriaPuntos.ElementAt(2).NotaOposicion });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "3. Valenciano", Valor = categoriaPuntos.ElementAt(2).Valencia });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "4. Formación especializada categoría y especialidad", Valor = categoriaPuntos.ElementAt(2).FormacionEspecializadaCategoriaEspecialidad });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "5. Formación contínua y continuada", Valor = categoriaPuntos.ElementAt(2).FormacionContinuaYContinuada });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "6. Diversidad funcional", Valor = categoriaPuntos.ElementAt(2).DiversidadFuncional });
                    listaCategoria3.Add(new GridViewPuntuacion() { TipoPuntuacion = "Total", Valor = categoriaPuntos.ElementAt(2).Total });

                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departamento1Nombre, Posicion = categoriaPuntos.ElementAt(2).Departamento1Lugar, TotalInscritos = categoriaPuntos.ElementAt(2).Departamento1Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departamento1Lugar / (double)categoriaPuntos.ElementAt(2).Departamento1Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departamento2Nombre, Posicion = categoriaPuntos.ElementAt(2).Departamento2Lugar, TotalInscritos = categoriaPuntos.ElementAt(2).Departamento2Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departamento2Lugar / (double)categoriaPuntos.ElementAt(2).Departamento2Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departamento3Nombre, Posicion = categoriaPuntos.ElementAt(2).Departamento3Lugar, TotalInscritos = categoriaPuntos.ElementAt(2).Departamento3Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departamento3Lugar / (double)categoriaPuntos.ElementAt(2).Departamento3Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departamento4Nombre, Posicion = categoriaPuntos.ElementAt(2).Departamento4Lugar, TotalInscritos = categoriaPuntos.ElementAt(2).Departamento4Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departamento4Lugar / (double)categoriaPuntos.ElementAt(2).Departamento4Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departamento5Nombre, Posicion = categoriaPuntos.ElementAt(2).Departamento5Lugar, TotalInscritos = categoriaPuntos.ElementAt(2).Departamento5Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departamento5Lugar / (double)categoriaPuntos.ElementAt(2).Departamento5Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departamento6Nombre, Posicion = categoriaPuntos.ElementAt(2).Departamento6Lugar, TotalInscritos = categoriaPuntos.ElementAt(2).Departamento6Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departamento6Lugar / (double)categoriaPuntos.ElementAt(2).Departamento6Total) * 100, 2) });
                    listaCategoria3Departamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.ElementAt(2).Departamento7Nombre, Posicion = categoriaPuntos.ElementAt(2).Departamento7Lugar, TotalInscritos = categoriaPuntos.ElementAt(2).Departamento7Total, Porcent = double.Round(((double)categoriaPuntos.ElementAt(2).Departamento7Lugar / (double)categoriaPuntos.ElementAt(2).Departamento7Total) * 100, 2) });

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
