using BorsaSanitatGUI.Datos.Models;
using BorsaSanitatGUI.Datos.Models.Parametros;
using BorsaSanitatGUI.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Datos.EntityFramework
{
    public class BorsaSanitatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=BorsaSanitatDB;User ID=sa;Password=234b10e1;Trust Server Certificate=true");
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CodigoEdicion> CodigosEdiciones { get; set; }
        public DbSet<Puntuacion> TiposPuntuaciones { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Puntuacion>().HasData(
                new Puntuacion() { Tipo = Constantes.CLAVE_SERVICIOS_PRESTADOS, Descripcion = "1. Servicios prestados" },
                new Puntuacion() { Tipo = Constantes.CLAVE_SERVICIOS_IIS_PUBLICAS_MISMA_CATEGORIA, Descripcion = "1.1.1. Servicios en IISS públicas - Misma categoría" },
                new Puntuacion() { Tipo = Constantes.CLAVE_SERVICIOS_IIS_DISTINTA_CATEGORIA, Descripcion = "1.1.2. Servicios en IISS públicas - Distinta categoría" },
                new Puntuacion() { Tipo = Constantes.CLAVE_SERVICIOS_MILITARES_PENITENCIARIOS_SOCIO_SANITARIO, Descripcion = "1.2. Servicios Milit., penit., socio-sanitario" },
                new Puntuacion() { Tipo = Constantes.CLAVE_SERVICIOS_CONCERTADOS_MUTUAS, Descripcion = "1.3. Servicios Concertados, Mutuas" },
                new Puntuacion() { Tipo = Constantes.CLAVE_NOTA_OPOSICION, Descripcion = "2. Nota de oposición" },
                new Puntuacion() { Tipo = Constantes.CLAVE_VALENCIANO, Descripcion = "3. Valenciano" },
                new Puntuacion() { Tipo = Constantes.CLAVE_FORMACION_ESPECIALIZADA, Descripcion = "4. Formación especializada categoría y especialidad" },
                new Puntuacion() { Tipo = Constantes.CLAVE_FORMACION_CONTINUA_Y_CONTINUADA, Descripcion = "5. Formación contínua y continuada" },
                new Puntuacion() { Tipo = Constantes.CLAVE_SERVICIOS_DIVERSIDAD_FUNCIONAL, Descripcion = "6. Diversidad funcional" },
                new Puntuacion() { Tipo = Constantes.CLAVE_SERVICIOS_TOTAL, Descripcion = "Total" }
                );

            modelBuilder.Entity<CodigoEdicion>().HasData(
                new CodigoEdicion() { Tipo = Constantes.CLAVE_EDICION_LISTADO_PUNTUACION, Edicion = "20.0.2.0" },
                new CodigoEdicion() { Tipo = Constantes.CLAVE_EDICION_DATOS_PERSONALES, Edicion = "20.0.2.0" }
                );

            modelBuilder.Entity<Departamento>().HasData(
                new Departamento() { NombreDepartamento = "Alicante", CodigoDepartamento = "ALI" },
                new Departamento() { NombreDepartamento = "Alcoy", CodigoDepartamento = "ALY" },
                new Departamento() { NombreDepartamento = "Arnau", CodigoDepartamento = "ARN" },
                new Departamento() { NombreDepartamento = "Castellon", CodigoDepartamento = "CAS" },
                new Departamento() { NombreDepartamento = "Clinico", CodigoDepartamento = "CLI" },
                new Departamento() { NombreDepartamento = "Denia", CodigoDepartamento = "DEN" },
                new Departamento() { NombreDepartamento = "Elda", CodigoDepartamento = "ELD" },
                new Departamento() { NombreDepartamento = "Elx", CodigoDepartamento = "ELX" },
                new Departamento() { NombreDepartamento = "Gandia", CodigoDepartamento = "GAN" },
                new Departamento() { NombreDepartamento = "General", CodigoDepartamento = "GEN" },
                new Departamento() { NombreDepartamento = "La Fe", CodigoDepartamento = "LFE" },
                new Departamento() { NombreDepartamento = "Marina", CodigoDepartamento = "MBA" },
                new Departamento() { NombreDepartamento = "Orihuela", CodigoDepartamento = "ORI" },
                new Departamento() { NombreDepartamento = "Peset", CodigoDepartamento = "PES" },
                new Departamento() { NombreDepartamento = "La Plana", CodigoDepartamento = "PLA" },
                new Departamento() { NombreDepartamento = "Requena", CodigoDepartamento = "REQ" },
                new Departamento() { NombreDepartamento = "Ribera", CodigoDepartamento = "RIB" },
                new Departamento() { NombreDepartamento = "SA", CodigoDepartamento = "SA" },
                new Departamento() { NombreDepartamento = "Sagunto", CodigoDepartamento = "SAG" },
                new Departamento() { NombreDepartamento = "SES Castelló", CodigoDepartamento = "SC" },
                new Departamento() { NombreDepartamento = "Serveis Centrals", CodigoDepartamento = "SCC" },
                new Departamento() { NombreDepartamento = "S.P. Alacant", CodigoDepartamento = "SPA" },
                new Departamento() { NombreDepartamento = "S.P. Castelló", CodigoDepartamento = "SPC" },
                new Departamento() { NombreDepartamento = "S.P. Valencia", CodigoDepartamento = "SPV" },
                new Departamento() { NombreDepartamento = "S.P. Alcoy", CodigoDepartamento = "SPY" },
                new Departamento() { NombreDepartamento = "SV", CodigoDepartamento = "SV" },
                new Departamento() { NombreDepartamento = "Torrevieja", CodigoDepartamento = "TRV" },
                new Departamento() { NombreDepartamento = "Vinaroz", CodigoDepartamento = "VIN" },
                new Departamento() { NombreDepartamento = "Xativa", CodigoDepartamento = "XAT" });

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria() { NombreCategoria = "Enginyer D'Aplicacions I Sistemes", CodigoCategoria = "0001" },
                new Categoria() { NombreCategoria = "Analista Programador I De Sistemes", CodigoCategoria = "0002" },
                new Categoria() { NombreCategoria = "Metge Conductes Addictives", CodigoCategoria = "0004" },
                new Categoria() { NombreCategoria = "Metge Unitat De Curta Estada", CodigoCategoria = "0006" },
                new Categoria() { NombreCategoria = "Metge Unitat De Prevenció Càncer De Mama", CodigoCategoria = "0007" },
                new Categoria() { NombreCategoria = "Metge Unitat Hospitalitzaciò A Domicili", CodigoCategoria = "0008" },
                new Categoria() { NombreCategoria = "Tècnic D'Informatica", CodigoCategoria = "0009" },
                new Categoria() { NombreCategoria = "Metge Documentació Clínica I Admissió", CodigoCategoria = "0010" },
                new Categoria() { NombreCategoria = "Auxiliar Administratiu", CodigoCategoria = "0011" },
                new Categoria() { NombreCategoria = "Tècnic De Manteniment", CodigoCategoria = "0015" },
                new Categoria() { NombreCategoria = "T.E. Medicina Nuclear", CodigoCategoria = "0016" },
                new Categoria() { NombreCategoria = "T.E. Radioteràpia", CodigoCategoria = "0017" },
                new Categoria() { NombreCategoria = "Metge Planificació Familiar", CodigoCategoria = "0018" },
                new Categoria() { NombreCategoria = "Farmacèutic D'Àrea", CodigoCategoria = "0019" },
                new Categoria() { NombreCategoria = "Metge Equip Mòbil", CodigoCategoria = "0020" },
                new Categoria() { NombreCategoria = "F. Esp. Bioquímica Clínica", CodigoCategoria = "0037" },
                new Categoria() { NombreCategoria = "Treballador Social", CodigoCategoria = "0057" },
                new Categoria() { NombreCategoria = "Administratiu", CodigoCategoria = "0087" },
                new Categoria() { NombreCategoria = "Metge De Familia E.A.P.", CodigoCategoria = "0244" },
                new Categoria() { NombreCategoria = "Infermera/Er Especialista Obstétrico-Ginecològica", CodigoCategoria = "0246" },
                new Categoria() { NombreCategoria = "F. Esp. Psiquiatria", CodigoCategoria = "0257" },
                new Categoria() { NombreCategoria = "T.E. Laboratori", CodigoCategoria = "0258" },
                new Categoria() { NombreCategoria = "F. Esp. Inmunologia", CodigoCategoria = "0259" },
                new Categoria() { NombreCategoria = "Conductor D Sense Limitació Radi Acció", CodigoCategoria = "0260" },
                new Categoria() { NombreCategoria = "Tècnic/A En Cures Auxiliars D'Infermeria", CodigoCategoria = "0275" },
                new Categoria() { NombreCategoria = "Fisioterapeuta", CodigoCategoria = "0276" },
                new Categoria() { NombreCategoria = "Zelador", CodigoCategoria = "0277" },
                new Categoria() { NombreCategoria = "Odontòlegs De Primària", CodigoCategoria = "0279" },
                new Categoria() { NombreCategoria = "T.E. Radiodiagnòstic", CodigoCategoria = "0280" },
                new Categoria() { NombreCategoria = "Infermera/Er", CodigoCategoria = "0285" },
                new Categoria() { NombreCategoria = "F. Esp. Medicina Interna", CodigoCategoria = "0302" },
                new Categoria() { NombreCategoria = "F. Esp. Reumatologia", CodigoCategoria = "0303" },
                new Categoria() { NombreCategoria = "F. Esp. Neurologia", CodigoCategoria = "0304" },
                new Categoria() { NombreCategoria = "F. Esp. Endocrinologia I Nutrició", CodigoCategoria = "0305" },
                new Categoria() { NombreCategoria = "F. Esp. Aparell Digestiu / Medicina Digestiva", CodigoCategoria = "0306" },
                new Categoria() { NombreCategoria = "F. Esp. Neumologia", CodigoCategoria = "0307" },
                new Categoria() { NombreCategoria = "F. Esp. Cardiologia", CodigoCategoria = "0308" },
                new Categoria() { NombreCategoria = "F. Esp. Dermatologia M-Q Y Venereologia", CodigoCategoria = "0310" },
                new Categoria() { NombreCategoria = "F. Esp. Urologia", CodigoCategoria = "0311" },
                new Categoria() { NombreCategoria = "F. Esp. Oftalmologia", CodigoCategoria = "0312" },
                new Categoria() { NombreCategoria = "F. Esp. Otorrinolaringologia", CodigoCategoria = "0313" },
                new Categoria() { NombreCategoria = "F. Esp. Traumatologia I Cirurgia Ortopèdica", CodigoCategoria = "0314" },
                new Categoria() { NombreCategoria = "F. Esp. Obstetricia / Ginecologia", CodigoCategoria = "0315" },
                new Categoria() { NombreCategoria = "F. Esp. Anàlisis Cliniques", CodigoCategoria = "0317" },
                new Categoria() { NombreCategoria = "F. Esp. Farmàcia Clinica", CodigoCategoria = "0350" },
                new Categoria() { NombreCategoria = "F. Esp. Farmàcia Hospitalaria", CodigoCategoria = "0362" },
                new Categoria() { NombreCategoria = "F. Esp. Medicina Preventiva I Salut Publica", CodigoCategoria = "0363" },
                new Categoria() { NombreCategoria = "F. Esp. Anatomia Patològica", CodigoCategoria = "0364" },
                new Categoria() { NombreCategoria = "F. Esp. Radiodiagnòstic", CodigoCategoria = "0365" },
                new Categoria() { NombreCategoria = "F. Esp. Microbiologia I Parasitologia", CodigoCategoria = "0366" },
                new Categoria() { NombreCategoria = "F. Esp. Rehabilitació", CodigoCategoria = "0367" },
                new Categoria() { NombreCategoria = "F. Esp. Medicina Intensiva", CodigoCategoria = "0368" },
                new Categoria() { NombreCategoria = "F. Esp. Pediatria I Àrees Especifiques", CodigoCategoria = "0369" },
                new Categoria() { NombreCategoria = "F. Esp. Cirurgia General I De L'Aparell Digestiu", CodigoCategoria = "0370" },
                new Categoria() { NombreCategoria = "F. Esp. Anestesiologia / Reanimació", CodigoCategoria = "0371" },
                new Categoria() { NombreCategoria = "F. Esp. Radiofísica Hospitàlaria", CodigoCategoria = "0375" },
                new Categoria() { NombreCategoria = "Terapeuta Ocupacional", CodigoCategoria = "0382" },
                new Categoria() { NombreCategoria = "F. Esp. Rafiofarmàcia", CodigoCategoria = "0400" },
                new Categoria() { NombreCategoria = "Locutor C.I.C.U.", CodigoCategoria = "0402" },
                new Categoria() { NombreCategoria = "Governanta", CodigoCategoria = "0404" },
                new Categoria() { NombreCategoria = "Conductor", CodigoCategoria = "0415" },
                new Categoria() { NombreCategoria = "F. Esp. Neurofisiologia Clínica", CodigoCategoria = "0441" },
                new Categoria() { NombreCategoria = "Veterinari Salut Pública", CodigoCategoria = "0442" },
                new Categoria() { NombreCategoria = "F. Esp. Al.Lergologia", CodigoCategoria = "0443" },
                new Categoria() { NombreCategoria = "F. Esp. Nefrologia", CodigoCategoria = "0444" },
                new Categoria() { NombreCategoria = "F. Esp. Oncologia Medica", CodigoCategoria = "0446" },
                new Categoria() { NombreCategoria = "F. Esp. Cirurgia Pediàtrica", CodigoCategoria = "0449" },
                new Categoria() { NombreCategoria = "F. Esp. Cirurgia Cardiovascular", CodigoCategoria = "0450" },
                new Categoria() { NombreCategoria = "F. Esp. Cirurgia Maxil.Lofacial", CodigoCategoria = "0451" },
                new Categoria() { NombreCategoria = "F. Esp. Neurocirurgia", CodigoCategoria = "0452" },
                new Categoria() { NombreCategoria = "T.E. Anatomia Patològica", CodigoCategoria = "0455" },
                new Categoria() { NombreCategoria = "F. Esp. Oncologia Radioterapica", CodigoCategoria = "0457" },
                new Categoria() { NombreCategoria = "F. Esp. Angiologia I Cirurgia Vascular", CodigoCategoria = "0459" },
                new Categoria() { NombreCategoria = "F. Esp. Geriatria", CodigoCategoria = "0460" },
                new Categoria() { NombreCategoria = "F. Esp. Hematologia I Hemoterapia", CodigoCategoria = "0463" },
                new Categoria() { NombreCategoria = "F. Esp. Cirurgia Plàstica I Reparadora", CodigoCategoria = "0473" },
                new Categoria() { NombreCategoria = "F. Esp. Medicina Nuclear", CodigoCategoria = "0476" },
                new Categoria() { NombreCategoria = "Pediatria Ap", CodigoCategoria = "0477" },
                new Categoria() { NombreCategoria = "Tècnic De Funció Administrativa", CodigoCategoria = "0483" },
                new Categoria() { NombreCategoria = "Gestió Funció Administrativa", CodigoCategoria = "0484" },
                new Categoria() { NombreCategoria = "F. Esp. Cirurgia Toràcica", CodigoCategoria = "0486" },
                new Categoria() { NombreCategoria = "Enginyer Tècnic", CodigoCategoria = "0516" },
                new Categoria() { NombreCategoria = "Metge Urgència Hospitalaria", CodigoCategoria = "0557" },
                new Categoria() { NombreCategoria = "Higienista Dental", CodigoCategoria = "1001" },
                new Categoria() { NombreCategoria = "Gestió Seguretat Alimentaria I Laboratori", CodigoCategoria = "1014" },
                new Categoria() { NombreCategoria = "Seguretat Alimentària", CodigoCategoria = "1015" },
                new Categoria() { NombreCategoria = "Laboratori Analisis Microbiològiques", CodigoCategoria = "1019" },
                new Categoria() { NombreCategoria = "Laboratori D'Analisi Químic", CodigoCategoria = "1020" },
                new Categoria() { NombreCategoria = "Especialista Salut Pública", CodigoCategoria = "1022" },
                new Categoria() { NombreCategoria = "Farmacèutic Admó Sanitària I Salut Pública", CodigoCategoria = "1024" },
                new Categoria() { NombreCategoria = "Farmacèutic D'Administració Sanitària", CodigoCategoria = "1025" },
                new Categoria() { NombreCategoria = "Metge D'Admó Sanitària I Salut Pública", CodigoCategoria = "1026" },
                new Categoria() { NombreCategoria = "Anàlisis Epidemiològiques I Estadístiques Sa", CodigoCategoria = "1027" },
                new Categoria() { NombreCategoria = "Infermera/Er Gestió Sanitària I Salut Pública", CodigoCategoria = "1028" },
                new Categoria() { NombreCategoria = "Infermera/Er Especialista Infermeria Familiar I Comunitaria", CodigoCategoria = "1050" },
                new Categoria() { NombreCategoria = "Infermera/Er Especialista Infermeria Del Treball", CodigoCategoria = "1051" },
                new Categoria() { NombreCategoria = "Dietista-Nutricionista", CodigoCategoria = "1052" },
                new Categoria() { NombreCategoria = "Òptic-Optometrista", CodigoCategoria = "1053" },
                new Categoria() { NombreCategoria = "Podòleg/Oga", CodigoCategoria = "1054" },
                new Categoria() { NombreCategoria = "Tècnic Especialista En Audologia-Protèsica", CodigoCategoria = "1055" },
                new Categoria() { NombreCategoria = "Tècnic Emergencies Sanitarias", CodigoCategoria = "1056" },
                new Categoria() { NombreCategoria = "Auxiliar De Farmàcia", CodigoCategoria = "1057" },
                new Categoria() { NombreCategoria = "Superior D'Administració General Sanitaria", CodigoCategoria = "1058" },
                new Categoria() { NombreCategoria = "Sanitat Ambiental (A1-S03-04)", CodigoCategoria = "1059" },
                new Categoria() { NombreCategoria = "Metge Administració Sanitària", CodigoCategoria = "1060" },
                new Categoria() { NombreCategoria = "Gestió Administració Sanitària De La Generalitat", CodigoCategoria = "1061" },
                new Categoria() { NombreCategoria = "Superior Gestió Sanitat Ambiental (A2-S03-03)", CodigoCategoria = "1062" },
                new Categoria() { NombreCategoria = "Infermera/Er Samu", CodigoCategoria = "2000" },
                new Categoria() { NombreCategoria = "Metge Samu", CodigoCategoria = "2001" },
                new Categoria() { NombreCategoria = "Infermera/Er Especialista En Infermeria De Salut Mental", CodigoCategoria = "3001" },
                new Categoria() { NombreCategoria = "Facultatiu Especilista En Medicina Del Treball", CodigoCategoria = "3002" },
                new Categoria() { NombreCategoria = "Logopeda", CodigoCategoria = "3003" },
                new Categoria() { NombreCategoria = "Tècnic Intermedi En Prevenció De Riscos Laborals", CodigoCategoria = "3004" },
                new Categoria() { NombreCategoria = "Tècnic Superior En Higiene Del Treball", CodigoCategoria = "3005" },
                new Categoria() { NombreCategoria = "Tècnic Superior En Seguretat En El Treball", CodigoCategoria = "3006" },
                new Categoria() { NombreCategoria = "Tècnic Superior En Psicosociologia I Ergonomia En El Treball", CodigoCategoria = "3007" },
                new Categoria() { NombreCategoria = "Tècnic Especialista En Documentació Sanitaria", CodigoCategoria = "3008" },
                new Categoria() { NombreCategoria = "Infermera/Er Inspector", CodigoCategoria = "3100" },
                new Categoria() { NombreCategoria = "Fac. Esp. Psicología Clínica", CodigoCategoria = "3101" },
                new Categoria() { NombreCategoria = "Farmacèutic Inspector", CodigoCategoria = "3102" },
                new Categoria() { NombreCategoria = "Inspector Metge", CodigoCategoria = "3103" },
                new Categoria() { NombreCategoria = "Infermer/A Especialista Pediatria", CodigoCategoria = "3200" },
                new Categoria() { NombreCategoria = "Infermer/A/Er Especilista En Infermeria Geriàtrica", CodigoCategoria = "3201" },
                new Categoria() { NombreCategoria = "Periodista", CodigoCategoria = "3202" },
                new Categoria() { NombreCategoria = "Operador/A Cambra Hiperbàrica", CodigoCategoria = "3203" },
                new Categoria() { NombreCategoria = "Enginyer/A Superior", CodigoCategoria = "3204" });
        }
    }
}
