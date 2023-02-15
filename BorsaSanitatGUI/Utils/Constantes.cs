namespace BorsaSanitatGUI.Utils
{
    public static class Constantes
    {
        private const string HOST = "https://www2.san.gva.es";
        public const string URL_SITUACIO = $"{HOST}/bolsa/lstSituacionCandidatos.jsp";
        public const string URL_PUNTUACIO = $"{HOST}/bolsa/lstCandidatosListaOperativa.jsp";
        public const string URL_DADES_PERSONALS = $"{HOST}/bolsa/lstDniApellido.jsp";
        
        public const string CLAVE_EDICION_LISTADO_PUNTUACION = "ListadoPuntuacion";
        public const string CLAVE_EDICION_DATOS_PERSONALES = "DatosPersonales";

        public const string CLAVE_SERVICIOS_PRESTADOS = "ServiciosPrestados";
        public const string CLAVE_SERVICIOS_IIS_PUBLICAS_MISMA_CATEGORIA = "ServiciosIISSPublicasMismaCategoria";
        public const string CLAVE_SERVICIOS_IIS_DISTINTA_CATEGORIA = "ServiciosIISSPublicasDistintaCategoria";
        public const string CLAVE_SERVICIOS_MILITARES_PENITENCIARIOS_SOCIO_SANITARIO = "ServiciosMilitaresPenitenciariosSocioSaniratio";
        public const string CLAVE_SERVICIOS_CONCERTADOS_MUTUAS = "ServiciosConcertadosMutuas";
        public const string CLAVE_NOTA_OPOSICION = "NotaOposicion";
        public const string CLAVE_VALENCIANO = "Valenciano";
        public const string CLAVE_FORMACION_ESPECIALIZADA = "FormacionEspecializada";
        public const string CLAVE_FORMACION_CONTINUA_Y_CONTINUADA = "FormacionContinuaYContinuada";
        public const string CLAVE_SERVICIOS_DIVERSIDAD_FUNCIONAL = "DiversidadFuncional";
        public const string CLAVE_SERVICIOS_TOTAL = "Total";

    }
}
