using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestorFcc.Data.Entidades
{
    public class Expediente
    {
        [Key]
        public string? id_expediente { get; set; }
        public string? ine { get; set; }
        public string? cartaCompromiso { get; set; }
        public string? cartaRecomendacion1 { get; set; }
        public string? cartaRecomendacion2 { get; set; }
        public string? protocolo { get; set; }
        public string? comprobanteToefl { get; set; }
        public string? exani { get; set; }
        public string? tituloLicenciatura { get; set; }
        public string? tituloMaestria { get; set; }
        public string? cedulaLicenciatura { get; set; }
        public string? cedulaMaestria { get; set; }
        public string? curriculumVitae { get; set; }
        public string? publicaciones { get; set; }
        public string? kardexSemestral { get; set; }
        public string? pagoInscripcion { get; set; }

        //Auditorias
        [Required]
        public DateTime? fechaCreacion { get; set; }
        [Required]
        public DateTime? fechaActualizacion { get; set; }

        public Alumno alumno { get; set; }












    }
}
