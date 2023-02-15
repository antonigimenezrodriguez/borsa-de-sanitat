﻿// <auto-generated />
using BorsaSanitatGUI.Datos.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BorsaSanitatGUI.Migrations
{
    [DbContext(typeof(BorsaSanitatContext))]
    [Migration("20230215210059_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BorsaSanitatGUI.Datos.Models.CodigoEdicion", b =>
                {
                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Edicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Tipo");

                    b.ToTable("CodigosEdiciones");

                    b.HasData(
                        new
                        {
                            Tipo = "ListadoPuntuacion",
                            Edicion = "20.0.2.0"
                        },
                        new
                        {
                            Tipo = "DatosPersonales",
                            Edicion = "20.0.2.0"
                        });
                });

            modelBuilder.Entity("BorsaSanitatGUI.Datos.Models.Parametros.Categoria", b =>
                {
                    b.Property<string>("CodigoCategoria")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoCategoria");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CodigoCategoria = "0001",
                            NombreCategoria = "Enginyer D'Aplicacions I Sistemes"
                        },
                        new
                        {
                            CodigoCategoria = "0002",
                            NombreCategoria = "Analista Programador I De Sistemes"
                        },
                        new
                        {
                            CodigoCategoria = "0004",
                            NombreCategoria = "Metge Conductes Addictives"
                        },
                        new
                        {
                            CodigoCategoria = "0006",
                            NombreCategoria = "Metge Unitat De Curta Estada"
                        },
                        new
                        {
                            CodigoCategoria = "0007",
                            NombreCategoria = "Metge Unitat De Prevenció Càncer De Mama"
                        },
                        new
                        {
                            CodigoCategoria = "0008",
                            NombreCategoria = "Metge Unitat Hospitalitzaciò A Domicili"
                        },
                        new
                        {
                            CodigoCategoria = "0009",
                            NombreCategoria = "Tècnic D'Informatica"
                        },
                        new
                        {
                            CodigoCategoria = "0010",
                            NombreCategoria = "Metge Documentació Clínica I Admissió"
                        },
                        new
                        {
                            CodigoCategoria = "0011",
                            NombreCategoria = "Auxiliar Administratiu"
                        },
                        new
                        {
                            CodigoCategoria = "0015",
                            NombreCategoria = "Tècnic De Manteniment"
                        },
                        new
                        {
                            CodigoCategoria = "0016",
                            NombreCategoria = "T.E. Medicina Nuclear"
                        },
                        new
                        {
                            CodigoCategoria = "0017",
                            NombreCategoria = "T.E. Radioteràpia"
                        },
                        new
                        {
                            CodigoCategoria = "0018",
                            NombreCategoria = "Metge Planificació Familiar"
                        },
                        new
                        {
                            CodigoCategoria = "0019",
                            NombreCategoria = "Farmacèutic D'Àrea"
                        },
                        new
                        {
                            CodigoCategoria = "0020",
                            NombreCategoria = "Metge Equip Mòbil"
                        },
                        new
                        {
                            CodigoCategoria = "0037",
                            NombreCategoria = "F. Esp. Bioquímica Clínica"
                        },
                        new
                        {
                            CodigoCategoria = "0057",
                            NombreCategoria = "Treballador Social"
                        },
                        new
                        {
                            CodigoCategoria = "0087",
                            NombreCategoria = "Administratiu"
                        },
                        new
                        {
                            CodigoCategoria = "0244",
                            NombreCategoria = "Metge De Familia E.A.P."
                        },
                        new
                        {
                            CodigoCategoria = "0246",
                            NombreCategoria = "Infermera/Er Especialista Obstétrico-Ginecològica"
                        },
                        new
                        {
                            CodigoCategoria = "0257",
                            NombreCategoria = "F. Esp. Psiquiatria"
                        },
                        new
                        {
                            CodigoCategoria = "0258",
                            NombreCategoria = "T.E. Laboratori"
                        },
                        new
                        {
                            CodigoCategoria = "0259",
                            NombreCategoria = "F. Esp. Inmunologia"
                        },
                        new
                        {
                            CodigoCategoria = "0260",
                            NombreCategoria = "Conductor D Sense Limitació Radi Acció"
                        },
                        new
                        {
                            CodigoCategoria = "0275",
                            NombreCategoria = "Tècnic/A En Cures Auxiliars D'Infermeria"
                        },
                        new
                        {
                            CodigoCategoria = "0276",
                            NombreCategoria = "Fisioterapeuta"
                        },
                        new
                        {
                            CodigoCategoria = "0277",
                            NombreCategoria = "Zelador"
                        },
                        new
                        {
                            CodigoCategoria = "0279",
                            NombreCategoria = "Odontòlegs De Primària"
                        },
                        new
                        {
                            CodigoCategoria = "0280",
                            NombreCategoria = "T.E. Radiodiagnòstic"
                        },
                        new
                        {
                            CodigoCategoria = "0285",
                            NombreCategoria = "Infermera/Er"
                        },
                        new
                        {
                            CodigoCategoria = "0302",
                            NombreCategoria = "F. Esp. Medicina Interna"
                        },
                        new
                        {
                            CodigoCategoria = "0303",
                            NombreCategoria = "F. Esp. Reumatologia"
                        },
                        new
                        {
                            CodigoCategoria = "0304",
                            NombreCategoria = "F. Esp. Neurologia"
                        },
                        new
                        {
                            CodigoCategoria = "0305",
                            NombreCategoria = "F. Esp. Endocrinologia I Nutrició"
                        },
                        new
                        {
                            CodigoCategoria = "0306",
                            NombreCategoria = "F. Esp. Aparell Digestiu / Medicina Digestiva"
                        },
                        new
                        {
                            CodigoCategoria = "0307",
                            NombreCategoria = "F. Esp. Neumologia"
                        },
                        new
                        {
                            CodigoCategoria = "0308",
                            NombreCategoria = "F. Esp. Cardiologia"
                        },
                        new
                        {
                            CodigoCategoria = "0310",
                            NombreCategoria = "F. Esp. Dermatologia M-Q Y Venereologia"
                        },
                        new
                        {
                            CodigoCategoria = "0311",
                            NombreCategoria = "F. Esp. Urologia"
                        },
                        new
                        {
                            CodigoCategoria = "0312",
                            NombreCategoria = "F. Esp. Oftalmologia"
                        },
                        new
                        {
                            CodigoCategoria = "0313",
                            NombreCategoria = "F. Esp. Otorrinolaringologia"
                        },
                        new
                        {
                            CodigoCategoria = "0314",
                            NombreCategoria = "F. Esp. Traumatologia I Cirurgia Ortopèdica"
                        },
                        new
                        {
                            CodigoCategoria = "0315",
                            NombreCategoria = "F. Esp. Obstetricia / Ginecologia"
                        },
                        new
                        {
                            CodigoCategoria = "0317",
                            NombreCategoria = "F. Esp. Anàlisis Cliniques"
                        },
                        new
                        {
                            CodigoCategoria = "0350",
                            NombreCategoria = "F. Esp. Farmàcia Clinica"
                        },
                        new
                        {
                            CodigoCategoria = "0362",
                            NombreCategoria = "F. Esp. Farmàcia Hospitalaria"
                        },
                        new
                        {
                            CodigoCategoria = "0363",
                            NombreCategoria = "F. Esp. Medicina Preventiva I Salut Publica"
                        },
                        new
                        {
                            CodigoCategoria = "0364",
                            NombreCategoria = "F. Esp. Anatomia Patològica"
                        },
                        new
                        {
                            CodigoCategoria = "0365",
                            NombreCategoria = "F. Esp. Radiodiagnòstic"
                        },
                        new
                        {
                            CodigoCategoria = "0366",
                            NombreCategoria = "F. Esp. Microbiologia I Parasitologia"
                        },
                        new
                        {
                            CodigoCategoria = "0367",
                            NombreCategoria = "F. Esp. Rehabilitació"
                        },
                        new
                        {
                            CodigoCategoria = "0368",
                            NombreCategoria = "F. Esp. Medicina Intensiva"
                        },
                        new
                        {
                            CodigoCategoria = "0369",
                            NombreCategoria = "F. Esp. Pediatria I Àrees Especifiques"
                        },
                        new
                        {
                            CodigoCategoria = "0370",
                            NombreCategoria = "F. Esp. Cirurgia General I De L'Aparell Digestiu"
                        },
                        new
                        {
                            CodigoCategoria = "0371",
                            NombreCategoria = "F. Esp. Anestesiologia / Reanimació"
                        },
                        new
                        {
                            CodigoCategoria = "0375",
                            NombreCategoria = "F. Esp. Radiofísica Hospitàlaria"
                        },
                        new
                        {
                            CodigoCategoria = "0382",
                            NombreCategoria = "Terapeuta Ocupacional"
                        },
                        new
                        {
                            CodigoCategoria = "0400",
                            NombreCategoria = "F. Esp. Rafiofarmàcia"
                        },
                        new
                        {
                            CodigoCategoria = "0402",
                            NombreCategoria = "Locutor C.I.C.U."
                        },
                        new
                        {
                            CodigoCategoria = "0404",
                            NombreCategoria = "Governanta"
                        },
                        new
                        {
                            CodigoCategoria = "0415",
                            NombreCategoria = "Conductor"
                        },
                        new
                        {
                            CodigoCategoria = "0441",
                            NombreCategoria = "F. Esp. Neurofisiologia Clínica"
                        },
                        new
                        {
                            CodigoCategoria = "0442",
                            NombreCategoria = "Veterinari Salut Pública"
                        },
                        new
                        {
                            CodigoCategoria = "0443",
                            NombreCategoria = "F. Esp. Al.Lergologia"
                        },
                        new
                        {
                            CodigoCategoria = "0444",
                            NombreCategoria = "F. Esp. Nefrologia"
                        },
                        new
                        {
                            CodigoCategoria = "0446",
                            NombreCategoria = "F. Esp. Oncologia Medica"
                        },
                        new
                        {
                            CodigoCategoria = "0449",
                            NombreCategoria = "F. Esp. Cirurgia Pediàtrica"
                        },
                        new
                        {
                            CodigoCategoria = "0450",
                            NombreCategoria = "F. Esp. Cirurgia Cardiovascular"
                        },
                        new
                        {
                            CodigoCategoria = "0451",
                            NombreCategoria = "F. Esp. Cirurgia Maxil.Lofacial"
                        },
                        new
                        {
                            CodigoCategoria = "0452",
                            NombreCategoria = "F. Esp. Neurocirurgia"
                        },
                        new
                        {
                            CodigoCategoria = "0455",
                            NombreCategoria = "T.E. Anatomia Patològica"
                        },
                        new
                        {
                            CodigoCategoria = "0457",
                            NombreCategoria = "F. Esp. Oncologia Radioterapica"
                        },
                        new
                        {
                            CodigoCategoria = "0459",
                            NombreCategoria = "F. Esp. Angiologia I Cirurgia Vascular"
                        },
                        new
                        {
                            CodigoCategoria = "0460",
                            NombreCategoria = "F. Esp. Geriatria"
                        },
                        new
                        {
                            CodigoCategoria = "0463",
                            NombreCategoria = "F. Esp. Hematologia I Hemoterapia"
                        },
                        new
                        {
                            CodigoCategoria = "0473",
                            NombreCategoria = "F. Esp. Cirurgia Plàstica I Reparadora"
                        },
                        new
                        {
                            CodigoCategoria = "0476",
                            NombreCategoria = "F. Esp. Medicina Nuclear"
                        },
                        new
                        {
                            CodigoCategoria = "0477",
                            NombreCategoria = "Pediatria Ap"
                        },
                        new
                        {
                            CodigoCategoria = "0483",
                            NombreCategoria = "Tècnic De Funció Administrativa"
                        },
                        new
                        {
                            CodigoCategoria = "0484",
                            NombreCategoria = "Gestió Funció Administrativa"
                        },
                        new
                        {
                            CodigoCategoria = "0486",
                            NombreCategoria = "F. Esp. Cirurgia Toràcica"
                        },
                        new
                        {
                            CodigoCategoria = "0516",
                            NombreCategoria = "Enginyer Tècnic"
                        },
                        new
                        {
                            CodigoCategoria = "0557",
                            NombreCategoria = "Metge Urgència Hospitalaria"
                        },
                        new
                        {
                            CodigoCategoria = "1001",
                            NombreCategoria = "Higienista Dental"
                        },
                        new
                        {
                            CodigoCategoria = "1014",
                            NombreCategoria = "Gestió Seguretat Alimentaria I Laboratori"
                        },
                        new
                        {
                            CodigoCategoria = "1015",
                            NombreCategoria = "Seguretat Alimentària"
                        },
                        new
                        {
                            CodigoCategoria = "1019",
                            NombreCategoria = "Laboratori Analisis Microbiològiques"
                        },
                        new
                        {
                            CodigoCategoria = "1020",
                            NombreCategoria = "Laboratori D'Analisi Químic"
                        },
                        new
                        {
                            CodigoCategoria = "1022",
                            NombreCategoria = "Especialista Salut Pública"
                        },
                        new
                        {
                            CodigoCategoria = "1024",
                            NombreCategoria = "Farmacèutic Admó Sanitària I Salut Pública"
                        },
                        new
                        {
                            CodigoCategoria = "1025",
                            NombreCategoria = "Farmacèutic D'Administració Sanitària"
                        },
                        new
                        {
                            CodigoCategoria = "1026",
                            NombreCategoria = "Metge D'Admó Sanitària I Salut Pública"
                        },
                        new
                        {
                            CodigoCategoria = "1027",
                            NombreCategoria = "Anàlisis Epidemiològiques I Estadístiques Sa"
                        },
                        new
                        {
                            CodigoCategoria = "1028",
                            NombreCategoria = "Infermera/Er Gestió Sanitària I Salut Pública"
                        },
                        new
                        {
                            CodigoCategoria = "1050",
                            NombreCategoria = "Infermera/Er Especialista Infermeria Familiar I Comunitaria"
                        },
                        new
                        {
                            CodigoCategoria = "1051",
                            NombreCategoria = "Infermera/Er Especialista Infermeria Del Treball"
                        },
                        new
                        {
                            CodigoCategoria = "1052",
                            NombreCategoria = "Dietista-Nutricionista"
                        },
                        new
                        {
                            CodigoCategoria = "1053",
                            NombreCategoria = "Òptic-Optometrista"
                        },
                        new
                        {
                            CodigoCategoria = "1054",
                            NombreCategoria = "Podòleg/Oga"
                        },
                        new
                        {
                            CodigoCategoria = "1055",
                            NombreCategoria = "Tècnic Especialista En Audologia-Protèsica"
                        },
                        new
                        {
                            CodigoCategoria = "1056",
                            NombreCategoria = "Tècnic Emergencies Sanitarias"
                        },
                        new
                        {
                            CodigoCategoria = "1057",
                            NombreCategoria = "Auxiliar De Farmàcia"
                        },
                        new
                        {
                            CodigoCategoria = "1058",
                            NombreCategoria = "Superior D'Administració General Sanitaria"
                        },
                        new
                        {
                            CodigoCategoria = "1059",
                            NombreCategoria = "Sanitat Ambiental (A1-S03-04)"
                        },
                        new
                        {
                            CodigoCategoria = "1060",
                            NombreCategoria = "Metge Administració Sanitària"
                        },
                        new
                        {
                            CodigoCategoria = "1061",
                            NombreCategoria = "Gestió Administració Sanitària De La Generalitat"
                        },
                        new
                        {
                            CodigoCategoria = "1062",
                            NombreCategoria = "Superior Gestió Sanitat Ambiental (A2-S03-03)"
                        },
                        new
                        {
                            CodigoCategoria = "2000",
                            NombreCategoria = "Infermera/Er Samu"
                        },
                        new
                        {
                            CodigoCategoria = "2001",
                            NombreCategoria = "Metge Samu"
                        },
                        new
                        {
                            CodigoCategoria = "3001",
                            NombreCategoria = "Infermera/Er Especialista En Infermeria De Salut Mental"
                        },
                        new
                        {
                            CodigoCategoria = "3002",
                            NombreCategoria = "Facultatiu Especilista En Medicina Del Treball"
                        },
                        new
                        {
                            CodigoCategoria = "3003",
                            NombreCategoria = "Logopeda"
                        },
                        new
                        {
                            CodigoCategoria = "3004",
                            NombreCategoria = "Tècnic Intermedi En Prevenció De Riscos Laborals"
                        },
                        new
                        {
                            CodigoCategoria = "3005",
                            NombreCategoria = "Tècnic Superior En Higiene Del Treball"
                        },
                        new
                        {
                            CodigoCategoria = "3006",
                            NombreCategoria = "Tècnic Superior En Seguretat En El Treball"
                        },
                        new
                        {
                            CodigoCategoria = "3007",
                            NombreCategoria = "Tècnic Superior En Psicosociologia I Ergonomia En El Treball"
                        },
                        new
                        {
                            CodigoCategoria = "3008",
                            NombreCategoria = "Tècnic Especialista En Documentació Sanitaria"
                        },
                        new
                        {
                            CodigoCategoria = "3100",
                            NombreCategoria = "Infermera/Er Inspector"
                        },
                        new
                        {
                            CodigoCategoria = "3101",
                            NombreCategoria = "Fac. Esp. Psicología Clínica"
                        },
                        new
                        {
                            CodigoCategoria = "3102",
                            NombreCategoria = "Farmacèutic Inspector"
                        },
                        new
                        {
                            CodigoCategoria = "3103",
                            NombreCategoria = "Inspector Metge"
                        },
                        new
                        {
                            CodigoCategoria = "3200",
                            NombreCategoria = "Infermer/A Especialista Pediatria"
                        },
                        new
                        {
                            CodigoCategoria = "3201",
                            NombreCategoria = "Infermer/A/Er Especilista En Infermeria Geriàtrica"
                        },
                        new
                        {
                            CodigoCategoria = "3202",
                            NombreCategoria = "Periodista"
                        },
                        new
                        {
                            CodigoCategoria = "3203",
                            NombreCategoria = "Operador/A Cambra Hiperbàrica"
                        },
                        new
                        {
                            CodigoCategoria = "3204",
                            NombreCategoria = "Enginyer/A Superior"
                        });
                });

            modelBuilder.Entity("BorsaSanitatGUI.Datos.Models.Parametros.Departamento", b =>
                {
                    b.Property<string>("CodigoDepartamento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreDepartamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoDepartamento");

                    b.ToTable("Departamentos");

                    b.HasData(
                        new
                        {
                            CodigoDepartamento = "ALI",
                            NombreDepartamento = "Alicante"
                        },
                        new
                        {
                            CodigoDepartamento = "ALY",
                            NombreDepartamento = "Alcoy"
                        },
                        new
                        {
                            CodigoDepartamento = "ARN",
                            NombreDepartamento = "Arnau"
                        },
                        new
                        {
                            CodigoDepartamento = "CAS",
                            NombreDepartamento = "Castellon"
                        },
                        new
                        {
                            CodigoDepartamento = "CLI",
                            NombreDepartamento = "Clinico"
                        },
                        new
                        {
                            CodigoDepartamento = "DEN",
                            NombreDepartamento = "Denia"
                        },
                        new
                        {
                            CodigoDepartamento = "ELD",
                            NombreDepartamento = "Elda"
                        },
                        new
                        {
                            CodigoDepartamento = "ELX",
                            NombreDepartamento = "Elx"
                        },
                        new
                        {
                            CodigoDepartamento = "GAN",
                            NombreDepartamento = "Gandia"
                        },
                        new
                        {
                            CodigoDepartamento = "GEN",
                            NombreDepartamento = "General"
                        },
                        new
                        {
                            CodigoDepartamento = "LFE",
                            NombreDepartamento = "La Fe"
                        },
                        new
                        {
                            CodigoDepartamento = "MBA",
                            NombreDepartamento = "Marina"
                        },
                        new
                        {
                            CodigoDepartamento = "ORI",
                            NombreDepartamento = "Orihuela"
                        },
                        new
                        {
                            CodigoDepartamento = "PES",
                            NombreDepartamento = "Peset"
                        },
                        new
                        {
                            CodigoDepartamento = "PLA",
                            NombreDepartamento = "La Plana"
                        },
                        new
                        {
                            CodigoDepartamento = "REQ",
                            NombreDepartamento = "Requena"
                        },
                        new
                        {
                            CodigoDepartamento = "RIB",
                            NombreDepartamento = "Ribera"
                        },
                        new
                        {
                            CodigoDepartamento = "SA",
                            NombreDepartamento = "SES Alacant"
                        },
                        new
                        {
                            CodigoDepartamento = "SAG",
                            NombreDepartamento = "Sagunto"
                        },
                        new
                        {
                            CodigoDepartamento = "SJO",
                            NombreDepartamento = "San Joan"
                        },
                        new
                        {
                            CodigoDepartamento = "SC",
                            NombreDepartamento = "SES Castelló"
                        },
                        new
                        {
                            CodigoDepartamento = "SCC",
                            NombreDepartamento = "Serveis Centrals"
                        },
                        new
                        {
                            CodigoDepartamento = "SPA",
                            NombreDepartamento = "S.P. Alacant"
                        },
                        new
                        {
                            CodigoDepartamento = "SPC",
                            NombreDepartamento = "S.P. Castelló"
                        },
                        new
                        {
                            CodigoDepartamento = "SPV",
                            NombreDepartamento = "S.P. Valencia"
                        },
                        new
                        {
                            CodigoDepartamento = "SPY",
                            NombreDepartamento = "S.P. Alcoy"
                        },
                        new
                        {
                            CodigoDepartamento = "SV",
                            NombreDepartamento = "SV"
                        },
                        new
                        {
                            CodigoDepartamento = "TRV",
                            NombreDepartamento = "Torrevieja"
                        },
                        new
                        {
                            CodigoDepartamento = "VIN",
                            NombreDepartamento = "Vinaroz"
                        },
                        new
                        {
                            CodigoDepartamento = "XAT",
                            NombreDepartamento = "Xativa"
                        });
                });

            modelBuilder.Entity("BorsaSanitatGUI.Datos.Models.Puntuacion", b =>
                {
                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Tipo");

                    b.ToTable("TiposPuntuaciones");

                    b.HasData(
                        new
                        {
                            Tipo = "ServiciosPrestados",
                            Descripcion = "1. Servicios prestados"
                        },
                        new
                        {
                            Tipo = "ServiciosIISSPublicasMismaCategoria",
                            Descripcion = "1.1.1. Servicios en IISS públicas - Misma categoría"
                        },
                        new
                        {
                            Tipo = "ServiciosIISSPublicasDistintaCategoria",
                            Descripcion = "1.1.2. Servicios en IISS públicas - Distinta categoría"
                        },
                        new
                        {
                            Tipo = "ServiciosMilitaresPenitenciariosSocioSaniratio",
                            Descripcion = "1.2. Servicios Milit., penit., socio-sanitario"
                        },
                        new
                        {
                            Tipo = "ServiciosConcertadosMutuas",
                            Descripcion = "1.3. Servicios Concertados, Mutuas"
                        },
                        new
                        {
                            Tipo = "NotaOposicion",
                            Descripcion = "2. Nota de oposición"
                        },
                        new
                        {
                            Tipo = "Valenciano",
                            Descripcion = "3. Valenciano"
                        },
                        new
                        {
                            Tipo = "FormacionEspecializada",
                            Descripcion = "4. Formación especializada categoría y especialidad"
                        },
                        new
                        {
                            Tipo = "FormacionContinuaYContinuada",
                            Descripcion = "5. Formación contínua y continuada"
                        },
                        new
                        {
                            Tipo = "DiversidadFuncional",
                            Descripcion = "6. Diversidad funcional"
                        },
                        new
                        {
                            Tipo = "Total",
                            Descripcion = "Total"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
