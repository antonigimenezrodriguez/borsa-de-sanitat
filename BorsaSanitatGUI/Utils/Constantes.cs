﻿using BorsaSanitatGUI.Models.Parámetros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsaSanitatGUI.Utils
{
    public static class Constantes
    {
        private const string HOST = "https://www2.san.gva.es";
        public const string URL_SITUACIO = $"{HOST}/bolsa/lstSituacionCandidatos.jsp";
        public const string URL_PUNTUACIO = $"{HOST}/bolsa/lstCandidatosListaOperativa.jsp";
        public const string URL_DADES_PERSONALS = $"{HOST}/bolsa/lstDniApellido.jsp";

        public static List<DepartamentoCod> departamentoCod = new List<DepartamentoCod>()
        {
            new DepartamentoCod() { Clave = "Alicante", Valor = "ALI"},
            new DepartamentoCod() { Clave = "Alcoy", Valor = "ALY"},
            new DepartamentoCod() { Clave = "Arnau", Valor = "ARN"},
            new DepartamentoCod() { Clave = "Castellon", Valor = "CAS"},
            new DepartamentoCod() { Clave = "Clinico", Valor = "CLI"},
            new DepartamentoCod() { Clave = "Denia", Valor = "DEN"},
            new DepartamentoCod() { Clave = "Elda", Valor = "ELD"},
            new DepartamentoCod() { Clave = "Elx", Valor = "ELX"},
            new DepartamentoCod() { Clave = "Gandia", Valor = "GAN"},
            new DepartamentoCod() { Clave = "General", Valor = "GEN"},
            new DepartamentoCod() { Clave = "La Fe", Valor = "LFE"},
            new DepartamentoCod() { Clave = "Marina", Valor = "MBA"},
            new DepartamentoCod() { Clave = "Orihuela", Valor = "ORI"},
            new DepartamentoCod() { Clave = "Peset", Valor = "PES"},
            new DepartamentoCod() { Clave = "La Plana", Valor = "PLA"},
            new DepartamentoCod() { Clave = "Requena", Valor = "REQ"},
            new DepartamentoCod() { Clave = "Ribera", Valor = "RIB"},
            new DepartamentoCod() { Clave = "SA", Valor = "SA"},
            new DepartamentoCod() { Clave = "Sagunto", Valor = "SAG"},
            new DepartamentoCod() { Clave = "SES Castelló", Valor = "SC"},
            new DepartamentoCod() { Clave = "Serveis Centrals", Valor = "SCC"},
            new DepartamentoCod() { Clave = "S.P. Alacant", Valor = "SPA"},
            new DepartamentoCod() { Clave = "S.P. Castelló", Valor = "SPC"},
            new DepartamentoCod() { Clave = "S.P. Valencia", Valor = "SPV"},
            new DepartamentoCod() { Clave = "S.P. Alcoy", Valor = "SPY"},
            new DepartamentoCod() { Clave = "SV", Valor = "SV"},
            new DepartamentoCod() { Clave = "Torrevieja", Valor = "TRV"},
            new DepartamentoCod() { Clave = "Vinaroz", Valor = "VIN"},
            new DepartamentoCod() { Clave = "Xativa", Valor = "XAT"},

        };

        public static List<DepartamentoCod> categoriaCod = new List<DepartamentoCod>()
        {
            new DepartamentoCod() { Clave ="Enginyer D'Aplicacions I Sistemes", Valor = "0001"},
            new DepartamentoCod() { Clave ="Analista Programador I De Sistemes", Valor = "0002"},
            new DepartamentoCod() { Clave ="Metge Conductes Addictives", Valor = "0004"},
            new DepartamentoCod() { Clave ="Metge Unitat De Curta Estada", Valor = "0006"},
            new DepartamentoCod() { Clave ="Metge Unitat De Prevenció Càncer De Mama", Valor = "0007"},
            new DepartamentoCod() { Clave ="Metge Unitat Hospitalitzaciò A Domicili", Valor = "0008"},
            new DepartamentoCod() { Clave ="Tècnic D'Informatica", Valor = "0009"},
            new DepartamentoCod() { Clave ="Metge Documentació Clínica I Admissió", Valor = "0010"},
            new DepartamentoCod() { Clave ="Auxiliar Administratiu", Valor = "0011"},
            new DepartamentoCod() { Clave ="Tècnic De Manteniment", Valor = "0015"},
            new DepartamentoCod() { Clave ="T.E. Medicina Nuclear", Valor = "0016"},
            new DepartamentoCod() { Clave ="T.E. Radioteràpia", Valor = "0017"},
            new DepartamentoCod() { Clave ="Metge Planificació Familiar", Valor = "0018"},
            new DepartamentoCod() { Clave ="Farmacèutic D'Àrea", Valor = "0019"},
            new DepartamentoCod() { Clave ="Metge Equip Mòbil", Valor = "0020"},
            new DepartamentoCod() { Clave ="F. Esp. Bioquímica Clínica", Valor = "0037"},
            new DepartamentoCod() { Clave ="Treballador Social", Valor = "0057"},
            new DepartamentoCod() { Clave ="Administratiu", Valor = "0087"},
            new DepartamentoCod() { Clave ="Metge De Familia E.A.P.", Valor = "0244"},
            new DepartamentoCod() { Clave ="Infermera/Er Especialista Obstétrico-Ginecològica", Valor = "0246"},
            new DepartamentoCod() { Clave ="F. Esp. Psiquiatria", Valor = "0257"},
            new DepartamentoCod() { Clave ="T.E. Laboratori", Valor = "0258"},
            new DepartamentoCod() { Clave ="F. Esp. Inmunologia", Valor = "0259"},
            new DepartamentoCod() { Clave ="Conductor D Sense Limitació Radi Acció", Valor = "0260"},
            new DepartamentoCod() { Clave ="Tècnic/A En Cures Auxiliars D'Infermeria", Valor = "0275"},
            new DepartamentoCod() { Clave ="Fisioterapeuta", Valor = "0276"},
            new DepartamentoCod() { Clave ="Zelador", Valor = "0277"},
            new DepartamentoCod() { Clave ="Odontòlegs De Primària", Valor = "0279"},
            new DepartamentoCod() { Clave ="T.E. Radiodiagnòstic", Valor = "0280"},
            new DepartamentoCod() { Clave ="Infermera/Er", Valor = "0285"},
            new DepartamentoCod() { Clave ="F. Esp. Medicina Interna", Valor = "0302"},
            new DepartamentoCod() { Clave ="F. Esp. Reumatologia", Valor = "0303"},
            new DepartamentoCod() { Clave ="F. Esp. Neurologia", Valor = "0304"},
            new DepartamentoCod() { Clave ="F. Esp. Endocrinologia I Nutrició", Valor = "0305"},
            new DepartamentoCod() { Clave ="F. Esp. Aparell Digestiu / Medicina Digestiva", Valor = "0306"},
            new DepartamentoCod() { Clave ="F. Esp. Neumologia", Valor = "0307"},
            new DepartamentoCod() { Clave ="F. Esp. Cardiologia", Valor = "0308"},
            new DepartamentoCod() { Clave ="F. Esp. Dermatologia M-Q Y Venereologia", Valor = "0310"},
            new DepartamentoCod() { Clave ="F. Esp. Urologia", Valor = "0311"},
            new DepartamentoCod() { Clave ="F. Esp. Oftalmologia", Valor = "0312"},
            new DepartamentoCod() { Clave ="F. Esp. Otorrinolaringologia", Valor = "0313"},
            new DepartamentoCod() { Clave ="F. Esp. Traumatologia I Cirurgia Ortopèdica", Valor = "0314"},
            new DepartamentoCod() { Clave ="F. Esp. Obstetricia / Ginecologia", Valor = "0315"},
            new DepartamentoCod() { Clave ="F. Esp. Anàlisis Cliniques", Valor = "0317"},
            new DepartamentoCod() { Clave ="F. Esp. Farmàcia Clinica", Valor = "0350"},
            new DepartamentoCod() { Clave ="F. Esp. Farmàcia Hospitalaria", Valor = "0362"},
            new DepartamentoCod() { Clave ="F. Esp. Medicina Preventiva I Salut Publica", Valor = "0363"},
            new DepartamentoCod() { Clave ="F. Esp. Anatomia Patològica", Valor = "0364"},
            new DepartamentoCod() { Clave ="F. Esp. Radiodiagnòstic", Valor = "0365"},
            new DepartamentoCod() { Clave ="F. Esp. Microbiologia I Parasitologia", Valor = "0366"},
            new DepartamentoCod() { Clave ="F. Esp. Rehabilitació", Valor = "0367"},
            new DepartamentoCod() { Clave ="F. Esp. Medicina Intensiva", Valor = "0368"},
            new DepartamentoCod() { Clave ="F. Esp. Pediatria I Àrees Especifiques", Valor = "0369"},
            new DepartamentoCod() { Clave ="F. Esp. Cirurgia General I De L'Aparell Digestiu", Valor = "0370"},
            new DepartamentoCod() { Clave ="F. Esp. Anestesiologia / Reanimació", Valor = "0371"},
            new DepartamentoCod() { Clave ="F. Esp. Radiofísica Hospitàlaria", Valor = "0375"},
            new DepartamentoCod() { Clave ="Terapeuta Ocupacional", Valor = "0382"},
            new DepartamentoCod() { Clave ="F. Esp. Rafiofarmàcia", Valor = "0400"},
            new DepartamentoCod() { Clave ="Locutor C.I.C.U.", Valor = "0402"},
            new DepartamentoCod() { Clave ="Governanta", Valor = "0404"},
            new DepartamentoCod() { Clave ="Conductor", Valor = "0415"},
            new DepartamentoCod() { Clave ="F. Esp. Neurofisiologia Clínica", Valor = "0441"},
            new DepartamentoCod() { Clave ="Veterinari Salut Pública", Valor = "0442"},
            new DepartamentoCod() { Clave ="F. Esp. Al.Lergologia", Valor = "0443"},
            new DepartamentoCod() { Clave ="F. Esp. Nefrologia", Valor = "0444"},
            new DepartamentoCod() { Clave ="F. Esp. Oncologia Medica", Valor = "0446"},
            new DepartamentoCod() { Clave ="F. Esp. Cirurgia Pediàtrica", Valor = "0449"},
            new DepartamentoCod() { Clave ="F. Esp. Cirurgia Cardiovascular", Valor = "0450"},
            new DepartamentoCod() { Clave ="F. Esp. Cirurgia Maxil.Lofacial", Valor = "0451"},
            new DepartamentoCod() { Clave ="F. Esp. Neurocirurgia", Valor = "0452"},
            new DepartamentoCod() { Clave ="T.E. Anatomia Patològica", Valor = "0455"},
            new DepartamentoCod() { Clave ="F. Esp. Oncologia Radioterapica", Valor = "0457"},
            new DepartamentoCod() { Clave ="F. Esp. Angiologia I Cirurgia Vascular", Valor = "0459"},
            new DepartamentoCod() { Clave ="F. Esp. Geriatria", Valor = "0460"},
            new DepartamentoCod() { Clave ="F. Esp. Hematologia I Hemoterapia", Valor = "0463"},
            new DepartamentoCod() { Clave ="F. Esp. Cirurgia Plàstica I Reparadora", Valor = "0473"},
            new DepartamentoCod() { Clave ="F. Esp. Medicina Nuclear", Valor = "0476"},
            new DepartamentoCod() { Clave ="Pediatria Ap", Valor = "0477"},
            new DepartamentoCod() { Clave ="Tècnic De Funció Administrativa", Valor = "0483"},
            new DepartamentoCod() { Clave ="Gestió Funció Administrativa", Valor = "0484"},
            new DepartamentoCod() { Clave ="F. Esp. Cirurgia Toràcica", Valor = "0486"},
            new DepartamentoCod() { Clave ="Enginyer Tècnic", Valor = "0516"},
            new DepartamentoCod() { Clave ="Metge Urgència Hospitalaria", Valor = "0557"},
            new DepartamentoCod() { Clave ="Higienista Dental", Valor = "1001"},
            new DepartamentoCod() { Clave ="Gestió Seguretat Alimentaria I Laboratori", Valor = "1014"},
            new DepartamentoCod() { Clave ="Seguretat Alimentària", Valor = "1015"},
            new DepartamentoCod() { Clave ="Laboratori Analisis Microbiològiques", Valor = "1019"},
            new DepartamentoCod() { Clave ="Laboratori D'Analisi Químic", Valor = "1020"},
            new DepartamentoCod() { Clave ="Especialista Salut Pública", Valor = "1022"},
            new DepartamentoCod() { Clave ="Farmacèutic Admó Sanitària I Salut Pública", Valor = "1024"},
            new DepartamentoCod() { Clave ="Farmacèutic D'Administració Sanitària", Valor = "1025"},
            new DepartamentoCod() { Clave ="Metge D'Admó Sanitària I Salut Pública", Valor = "1026"},
            new DepartamentoCod() { Clave ="Anàlisis Epidemiològiques I Estadístiques Sa", Valor = "1027"},
            new DepartamentoCod() { Clave ="Infermera/Er Gestió Sanitària I Salut Pública", Valor = "1028"},
            new DepartamentoCod() { Clave ="Infermera/Er Especialista Infermeria Familiar I Comunitaria", Valor = "1050"},
            new DepartamentoCod() { Clave ="Infermera/Er Especialista Infermeria Del Treball", Valor = "1051"},
            new DepartamentoCod() { Clave ="Dietista-Nutricionista", Valor = "1052"},
            new DepartamentoCod() { Clave ="Òptic-Optometrista", Valor = "1053"},
            new DepartamentoCod() { Clave ="Podòleg/Oga", Valor = "1054"},
            new DepartamentoCod() { Clave ="Tècnic Especialista En Audologia-Protèsica", Valor = "1055"},
            new DepartamentoCod() { Clave ="Tècnic Emergencies Sanitarias", Valor = "1056"},
            new DepartamentoCod() { Clave ="Auxiliar De Farmàcia", Valor = "1057"},
            new DepartamentoCod() { Clave ="Superior D'Administració General Sanitaria", Valor = "1058"},
            new DepartamentoCod() { Clave ="Sanitat Ambiental (A1-S03-04)", Valor = "1059"},
            new DepartamentoCod() { Clave ="Metge Administració Sanitària", Valor = "1060"},
            new DepartamentoCod() { Clave ="Gestió Administració Sanitària De La Generalitat", Valor = "1061"},
            new DepartamentoCod() { Clave ="Superior Gestió Sanitat Ambiental (A2-S03-03)", Valor = "1062"},
            new DepartamentoCod() { Clave ="Infermera/Er Samu", Valor = "2000"},
            new DepartamentoCod() { Clave ="Metge Samu", Valor = "2001"},
            new DepartamentoCod() { Clave ="Infermera/Er Especialista En Infermeria De Salut Mental", Valor = "3001"},
            new DepartamentoCod() { Clave ="Facultatiu Especilista En Medicina Del Treball", Valor = "3002"},
            new DepartamentoCod() { Clave ="Logopeda", Valor = "3003"},
            new DepartamentoCod() { Clave ="Tècnic Intermedi En Prevenció De Riscos Laborals", Valor = "3004"},
            new DepartamentoCod() { Clave ="Tècnic Superior En Higiene Del Treball", Valor = "3005"},
            new DepartamentoCod() { Clave ="Tècnic Superior En Seguretat En El Treball", Valor = "3006"},
            new DepartamentoCod() { Clave ="Tècnic Superior En Psicosociologia I Ergonomia En El Treball", Valor = "3007"},
            new DepartamentoCod() { Clave ="Tècnic Especialista En Documentació Sanitaria", Valor = "3008"},
            new DepartamentoCod() { Clave ="Infermera/Er Inspector", Valor = "3100"},
            new DepartamentoCod() { Clave ="Fac. Esp. Psicología Clínica", Valor = "3101"},
            new DepartamentoCod() { Clave ="Farmacèutic Inspector", Valor = "3102"},
            new DepartamentoCod() { Clave ="Inspector Metge", Valor = "3103"},
            new DepartamentoCod() { Clave ="Infermer/A Especialista Pediatria", Valor = "3200"},
            new DepartamentoCod() { Clave ="Infermer/A/Er Especilista En Infermeria Geriàtrica", Valor = "3201"},
            new DepartamentoCod() { Clave ="Periodista", Valor = "3202"},
            new DepartamentoCod() { Clave ="Operador/A Cambra Hiperbàrica", Valor = "3203"},
            new DepartamentoCod() { Clave ="Enginyer/A Superior", Valor = "3204"},

        };

    }
}
