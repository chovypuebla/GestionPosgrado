using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestorFcc.Data.Entidades
{
    public class Expediente
    {
        [Key]
        public string? id_expediente { get; set; }

        [Required]
        public string? matricula { get; set; }

        [Required (ErrorMessage = "Debe exportar el archivo:")]
        public string? ine { get; set; }

        [Required(ErrorMessage = "Debe exportar el archivo:")]
        public string? cartaCompromiso { get; set; }

        [Required(ErrorMessage = "Debe exportar el archivo:")]
        public string? cartaRecomendacion1 { get; set; }

        public string? cartaRecomendacion2 { get; set; }

        [Required (ErrorMessage = "Debe exportar el archivo:")]
        public string? protocolo { get; set; }

        public string? comprobanteToefl { get; set; }

        [Required (ErrorMessage = "Debe exportar el archivo:")]
        public string? exani { get; set; }

        [Required (ErrorMessage = "Debe exportar el archivo:")]
        public string? tituloLicenciatura { get; set; }

        public string? tituloMaestria { get; set; }

        [Required (ErrorMessage = "Debe exportar el archivo:")]
        public string? cedulaLicenciatura { get; set; }

        public string? cedulaMaestria { get; set; }

        [Required (ErrorMessage = "Debe exportar el archivo:")]
        public string? curriculumVitae { get; set; }

        public string? publicaciones { get; set; }

        [Required (ErrorMessage = "Debe exportar el archivo:")]
        public string? kardexSemestral { get; set; }

        public string? pagoInscripcion { get; set; }

        //Auditorias
        [Required]
        public DateTime? fechaCreacion  { get; set; } = DateTime.Now;
        [Required]
        public DateTime? fechaActualizacion { get; set; } 

        //Esto solo es en caso de que existan llaves foraneas
        //public Alumno alumno { get; set; }

    }
}
