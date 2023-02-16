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
        public IDictionary<string, string> Puntuaciones { get; set; }
        public DatosPersonales()
        {
            RepositoryGVA = new RepositoryGVA();
            Puntuaciones = RepositoryGVA.ObtenerEtiquetasPuntuaciones();
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

                if (categoriaPuntos.ElementAt(0) != null)
                    RellenarDataGridView(DGV_Categoria1, DGV_Categoria1Departaments, categoriaPuntos.ElementAt(0));
                if (categoriaPuntos.ElementAt(1) != null)
                    RellenarDataGridView(DGV_Categoria2, DGV_Categoria2Departaments, categoriaPuntos.ElementAt(1));
                if (categoriaPuntos.ElementAt(2) != null)
                    RellenarDataGridView(DGV_Categoria3, DGV_Categoria3Departaments, categoriaPuntos.ElementAt(2));

                LB_Cargando.Visible = false;
            }
            else
            {
                MessageBox.Show("No es troba la informació sol·licitada. Canvia els paràmetres de búsqueda o prova passats uns minuts");
            }
        }

        public void RellenarDataGridView(DataGridView dataGridViewCategoria, DataGridView dataGridViewDepartamentos, CategoriaPuntos categoriaPuntos)
        {
            List<GridViewPuntuacion> listaCategoria = new List<GridViewPuntuacion>();
            List<GridViewPosicionDepartamentos> listaCategoriaDepartamentos = new List<GridViewPosicionDepartamentos>();
            if (categoriaPuntos != null)
            {
                LB_Categoria1.Text = categoriaPuntos.Categoria;
                LB_Categoria1.Visible = true;
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_SERVICIOS_PRESTADOS], Valor = categoriaPuntos.ServiciosPrestados });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_SERVICIOS_IIS_PUBLICAS_MISMA_CATEGORIA], Valor = categoriaPuntos.ServiciosEnIISSPublicasMismaCategoria });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_SERVICIOS_IIS_DISTINTA_CATEGORIA], Valor = categoriaPuntos.ServiciosEnIISSPublicasDistintaCategoria });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_SERVICIOS_MILITARES_PENITENCIARIOS_SOCIO_SANITARIO], Valor = categoriaPuntos.ServiciosMilitaresPenitenciariosSocioSanitario });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_SERVICIOS_CONCERTADOS_MUTUAS], Valor = categoriaPuntos.ServiciosConcertadosMutuas });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_NOTA_OPOSICION], Valor = categoriaPuntos.NotaOposicion });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_VALENCIANO], Valor = categoriaPuntos.Valencia });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_FORMACION_ESPECIALIZADA], Valor = categoriaPuntos.FormacionEspecializadaCategoriaEspecialidad });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_FORMACION_CONTINUA_Y_CONTINUADA], Valor = categoriaPuntos.FormacionContinuaYContinuada });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_SERVICIOS_DIVERSIDAD_FUNCIONAL], Valor = categoriaPuntos.DiversidadFuncional });
                listaCategoria.Add(new GridViewPuntuacion() { TipoPuntuacion = Puntuaciones[Constantes.CLAVE_SERVICIOS_TOTAL], Valor = categoriaPuntos.Total });

                listaCategoriaDepartamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.Departamento1Nombre, Posicion = categoriaPuntos.Departamento1Lugar, TotalInscritos = categoriaPuntos.Departamento1Total, Porcent = double.Round(((double)categoriaPuntos.Departamento1Lugar / (double)categoriaPuntos.Departamento1Total) * 100, 2) });
                listaCategoriaDepartamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.Departamento2Nombre, Posicion = categoriaPuntos.Departamento2Lugar, TotalInscritos = categoriaPuntos.Departamento2Total, Porcent = double.Round(((double)categoriaPuntos.Departamento2Lugar / (double)categoriaPuntos.Departamento2Total) * 100, 2) });
                listaCategoriaDepartamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.Departamento3Nombre, Posicion = categoriaPuntos.Departamento3Lugar, TotalInscritos = categoriaPuntos.Departamento3Total, Porcent = double.Round(((double)categoriaPuntos.Departamento3Lugar / (double)categoriaPuntos.Departamento3Total) * 100, 2) });
                listaCategoriaDepartamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.Departamento4Nombre, Posicion = categoriaPuntos.Departamento4Lugar, TotalInscritos = categoriaPuntos.Departamento4Total, Porcent = double.Round(((double)categoriaPuntos.Departamento4Lugar / (double)categoriaPuntos.Departamento4Total) * 100, 2) });
                listaCategoriaDepartamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.Departamento5Nombre, Posicion = categoriaPuntos.Departamento5Lugar, TotalInscritos = categoriaPuntos.Departamento5Total, Porcent = double.Round(((double)categoriaPuntos.Departamento5Lugar / (double)categoriaPuntos.Departamento5Total) * 100, 2) });
                listaCategoriaDepartamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.Departamento6Nombre, Posicion = categoriaPuntos.Departamento6Lugar, TotalInscritos = categoriaPuntos.Departamento6Total, Porcent = double.Round(((double)categoriaPuntos.Departamento6Lugar / (double)categoriaPuntos.Departamento6Total) * 100, 2) });
                listaCategoriaDepartamentos.Add(new GridViewPosicionDepartamentos() { Departamento = categoriaPuntos.Departamento7Nombre, Posicion = categoriaPuntos.Departamento7Lugar, TotalInscritos = categoriaPuntos.Departamento7Total, Porcent = double.Round(((double)categoriaPuntos.Departamento7Lugar / (double)categoriaPuntos.Departamento7Total) * 100, 2) });
            }
            dataGridViewCategoria.DataSource = listaCategoria;
            dataGridViewCategoria.AutoResizeColumns();
            dataGridViewCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (DataGridViewColumn column in dataGridViewCategoria.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dataGridViewDepartamentos.DataSource = listaCategoriaDepartamentos;
            dataGridViewDepartamentos.AutoResizeColumns();
            dataGridViewDepartamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (DataGridViewColumn column in dataGridViewDepartamentos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
    }
}
