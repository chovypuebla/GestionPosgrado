using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Docente
    {
        [Key]
        public string? id_docente { get; set; }
        [Required]
        public string? nombre { get; set; }
        [Required]
        public string? apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }


        public string? telefono { get; set; }
        [Required]
        public string? celular { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? nacimiento { get; set; }
        [Required]
        public string? adscripcion { get; set; }
        [Required]
        public string? cubiculo { get; set; }
        [EmailAddress]
        public string? correoBuap { get; set; }
        [EmailAddress]
        public string? correoViep { get; set; }
        public string? tesista { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? fechaRegistro { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? fechaActualizacion { get; set; }
    }
}
