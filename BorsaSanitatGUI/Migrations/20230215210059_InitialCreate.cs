using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BorsaSanitatGUI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CodigoCategoria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CodigoCategoria);
                });

            migrationBuilder.CreateTable(
                name: "CodigosEdiciones",
                columns: table => new
                {
                    Tipo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Edicion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigosEdiciones", x => x.Tipo);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    CodigoDepartamento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.CodigoDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "TiposPuntuaciones",
                columns: table => new
                {
                    Tipo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPuntuaciones", x => x.Tipo);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CodigoCategoria", "NombreCategoria" },
                values: new object[,]
                {
                    { "0001", "Enginyer D'Aplicacions I Sistemes" },
                    { "0002", "Analista Programador I De Sistemes" },
                    { "0004", "Metge Conductes Addictives" },
                    { "0006", "Metge Unitat De Curta Estada" },
                    { "0007", "Metge Unitat De Prevenció Càncer De Mama" },
                    { "0008", "Metge Unitat Hospitalitzaciò A Domicili" },
                    { "0009", "Tècnic D'Informatica" },
                    { "0010", "Metge Documentació Clínica I Admissió" },
                    { "0011", "Auxiliar Administratiu" },
                    { "0015", "Tècnic De Manteniment" },
                    { "0016", "T.E. Medicina Nuclear" },
                    { "0017", "T.E. Radioteràpia" },
                    { "0018", "Metge Planificació Familiar" },
                    { "0019", "Farmacèutic D'Àrea" },
                    { "0020", "Metge Equip Mòbil" },
                    { "0037", "F. Esp. Bioquímica Clínica" },
                    { "0057", "Treballador Social" },
                    { "0087", "Administratiu" },
                    { "0244", "Metge De Familia E.A.P." },
                    { "0246", "Infermera/Er Especialista Obstétrico-Ginecològica" },
                    { "0257", "F. Esp. Psiquiatria" },
                    { "0258", "T.E. Laboratori" },
                    { "0259", "F. Esp. Inmunologia" },
                    { "0260", "Conductor D Sense Limitació Radi Acció" },
                    { "0275", "Tècnic/A En Cures Auxiliars D'Infermeria" },
                    { "0276", "Fisioterapeuta" },
                    { "0277", "Zelador" },
                    { "0279", "Odontòlegs De Primària" },
                    { "0280", "T.E. Radiodiagnòstic" },
                    { "0285", "Infermera/Er" },
                    { "0302", "F. Esp. Medicina Interna" },
                    { "0303", "F. Esp. Reumatologia" },
                    { "0304", "F. Esp. Neurologia" },
                    { "0305", "F. Esp. Endocrinologia I Nutrició" },
                    { "0306", "F. Esp. Aparell Digestiu / Medicina Digestiva" },
                    { "0307", "F. Esp. Neumologia" },
                    { "0308", "F. Esp. Cardiologia" },
                    { "0310", "F. Esp. Dermatologia M-Q Y Venereologia" },
                    { "0311", "F. Esp. Urologia" },
                    { "0312", "F. Esp. Oftalmologia" },
                    { "0313", "F. Esp. Otorrinolaringologia" },
                    { "0314", "F. Esp. Traumatologia I Cirurgia Ortopèdica" },
                    { "0315", "F. Esp. Obstetricia / Ginecologia" },
                    { "0317", "F. Esp. Anàlisis Cliniques" },
                    { "0350", "F. Esp. Farmàcia Clinica" },
                    { "0362", "F. Esp. Farmàcia Hospitalaria" },
                    { "0363", "F. Esp. Medicina Preventiva I Salut Publica" },
                    { "0364", "F. Esp. Anatomia Patològica" },
                    { "0365", "F. Esp. Radiodiagnòstic" },
                    { "0366", "F. Esp. Microbiologia I Parasitologia" },
                    { "0367", "F. Esp. Rehabilitació" },
                    { "0368", "F. Esp. Medicina Intensiva" },
                    { "0369", "F. Esp. Pediatria I Àrees Especifiques" },
                    { "0370", "F. Esp. Cirurgia General I De L'Aparell Digestiu" },
                    { "0371", "F. Esp. Anestesiologia / Reanimació" },
                    { "0375", "F. Esp. Radiofísica Hospitàlaria" },
                    { "0382", "Terapeuta Ocupacional" },
                    { "0400", "F. Esp. Rafiofarmàcia" },
                    { "0402", "Locutor C.I.C.U." },
                    { "0404", "Governanta" },
                    { "0415", "Conductor" },
                    { "0441", "F. Esp. Neurofisiologia Clínica" },
                    { "0442", "Veterinari Salut Pública" },
                    { "0443", "F. Esp. Al.Lergologia" },
                    { "0444", "F. Esp. Nefrologia" },
                    { "0446", "F. Esp. Oncologia Medica" },
                    { "0449", "F. Esp. Cirurgia Pediàtrica" },
                    { "0450", "F. Esp. Cirurgia Cardiovascular" },
                    { "0451", "F. Esp. Cirurgia Maxil.Lofacial" },
                    { "0452", "F. Esp. Neurocirurgia" },
                    { "0455", "T.E. Anatomia Patològica" },
                    { "0457", "F. Esp. Oncologia Radioterapica" },
                    { "0459", "F. Esp. Angiologia I Cirurgia Vascular" },
                    { "0460", "F. Esp. Geriatria" },
                    { "0463", "F. Esp. Hematologia I Hemoterapia" },
                    { "0473", "F. Esp. Cirurgia Plàstica I Reparadora" },
                    { "0476", "F. Esp. Medicina Nuclear" },
                    { "0477", "Pediatria Ap" },
                    { "0483", "Tècnic De Funció Administrativa" },
                    { "0484", "Gestió Funció Administrativa" },
                    { "0486", "F. Esp. Cirurgia Toràcica" },
                    { "0516", "Enginyer Tècnic" },
                    { "0557", "Metge Urgència Hospitalaria" },
                    { "1001", "Higienista Dental" },
                    { "1014", "Gestió Seguretat Alimentaria I Laboratori" },
                    { "1015", "Seguretat Alimentària" },
                    { "1019", "Laboratori Analisis Microbiològiques" },
                    { "1020", "Laboratori D'Analisi Químic" },
                    { "1022", "Especialista Salut Pública" },
                    { "1024", "Farmacèutic Admó Sanitària I Salut Pública" },
                    { "1025", "Farmacèutic D'Administració Sanitària" },
                    { "1026", "Metge D'Admó Sanitària I Salut Pública" },
                    { "1027", "Anàlisis Epidemiològiques I Estadístiques Sa" },
                    { "1028", "Infermera/Er Gestió Sanitària I Salut Pública" },
                    { "1050", "Infermera/Er Especialista Infermeria Familiar I Comunitaria" },
                    { "1051", "Infermera/Er Especialista Infermeria Del Treball" },
                    { "1052", "Dietista-Nutricionista" },
                    { "1053", "Òptic-Optometrista" },
                    { "1054", "Podòleg/Oga" },
                    { "1055", "Tècnic Especialista En Audologia-Protèsica" },
                    { "1056", "Tècnic Emergencies Sanitarias" },
                    { "1057", "Auxiliar De Farmàcia" },
                    { "1058", "Superior D'Administració General Sanitaria" },
                    { "1059", "Sanitat Ambiental (A1-S03-04)" },
                    { "1060", "Metge Administració Sanitària" },
                    { "1061", "Gestió Administració Sanitària De La Generalitat" },
                    { "1062", "Superior Gestió Sanitat Ambiental (A2-S03-03)" },
                    { "2000", "Infermera/Er Samu" },
                    { "2001", "Metge Samu" },
                    { "3001", "Infermera/Er Especialista En Infermeria De Salut Mental" },
                    { "3002", "Facultatiu Especilista En Medicina Del Treball" },
                    { "3003", "Logopeda" },
                    { "3004", "Tècnic Intermedi En Prevenció De Riscos Laborals" },
                    { "3005", "Tècnic Superior En Higiene Del Treball" },
                    { "3006", "Tècnic Superior En Seguretat En El Treball" },
                    { "3007", "Tècnic Superior En Psicosociologia I Ergonomia En El Treball" },
                    { "3008", "Tècnic Especialista En Documentació Sanitaria" },
                    { "3100", "Infermera/Er Inspector" },
                    { "3101", "Fac. Esp. Psicología Clínica" },
                    { "3102", "Farmacèutic Inspector" },
                    { "3103", "Inspector Metge" },
                    { "3200", "Infermer/A Especialista Pediatria" },
                    { "3201", "Infermer/A/Er Especilista En Infermeria Geriàtrica" },
                    { "3202", "Periodista" },
                    { "3203", "Operador/A Cambra Hiperbàrica" },
                    { "3204", "Enginyer/A Superior" }
                });

            migrationBuilder.InsertData(
                table: "CodigosEdiciones",
                columns: new[] { "Tipo", "Edicion" },
                values: new object[,]
                {
                    { "DatosPersonales", "20.0.2.0" },
                    { "ListadoPuntuacion", "20.0.2.0" }
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "CodigoDepartamento", "NombreDepartamento" },
                values: new object[,]
                {
                    { "ALI", "Alicante" },
                    { "ALY", "Alcoy" },
                    { "ARN", "Arnau" },
                    { "CAS", "Castellon" },
                    { "CLI", "Clinico" },
                    { "DEN", "Denia" },
                    { "ELD", "Elda" },
                    { "ELX", "Elx" },
                    { "GAN", "Gandia" },
                    { "GEN", "General" },
                    { "LFE", "La Fe" },
                    { "MBA", "Marina" },
                    { "ORI", "Orihuela" },
                    { "PES", "Peset" },
                    { "PLA", "La Plana" },
                    { "REQ", "Requena" },
                    { "RIB", "Ribera" },
                    { "SA", "SES Alacant" },
                    { "SAG", "Sagunto" },
                    { "SC", "SES Castelló" },
                    { "SCC", "Serveis Centrals" },
                    { "SJO", "San Joan" },
                    { "SPA", "S.P. Alacant" },
                    { "SPC", "S.P. Castelló" },
                    { "SPV", "S.P. Valencia" },
                    { "SPY", "S.P. Alcoy" },
                    { "SV", "SV" },
                    { "TRV", "Torrevieja" },
                    { "VIN", "Vinaroz" },
                    { "XAT", "Xativa" }
                });

            migrationBuilder.InsertData(
                table: "TiposPuntuaciones",
                columns: new[] { "Tipo", "Descripcion" },
                values: new object[,]
                {
                    { "DiversidadFuncional", "6. Diversidad funcional" },
                    { "FormacionContinuaYContinuada", "5. Formación contínua y continuada" },
                    { "FormacionEspecializada", "4. Formación especializada categoría y especialidad" },
                    { "NotaOposicion", "2. Nota de oposición" },
                    { "ServiciosConcertadosMutuas", "1.3. Servicios Concertados, Mutuas" },
                    { "ServiciosIISSPublicasDistintaCategoria", "1.1.2. Servicios en IISS públicas - Distinta categoría" },
                    { "ServiciosIISSPublicasMismaCategoria", "1.1.1. Servicios en IISS públicas - Misma categoría" },
                    { "ServiciosMilitaresPenitenciariosSocioSaniratio", "1.2. Servicios Milit., penit., socio-sanitario" },
                    { "ServiciosPrestados", "1. Servicios prestados" },
                    { "Total", "Total" },
                    { "Valenciano", "3. Valenciano" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "CodigosEdiciones");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "TiposPuntuaciones");
        }
    }
}
