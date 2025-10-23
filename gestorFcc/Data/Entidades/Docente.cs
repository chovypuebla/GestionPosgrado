using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Docente
    {
        [Key]
        [Required (ErrorMessage = "La matrícula es un campo obligatorio")]
        [StringLength (10, ErrorMessage = "No puede exceder más de 10 caracteres")]
        public string? id_docente { get; set; }


        [Required (ErrorMessage = "El nombre es obligatorio ")]
        [StringLength(100, ErrorMessage = "No puede exceder más de 100 caracteres")]
        public string? nombre { get; set; }


        [Required (ErrorMessage = "Debe registrar al menos el apellido paterno")]
        [StringLength(100, ErrorMessage = "No puede exceder más de 100 caracteres")]
        public string? apellidoPaterno { get; set; }

        [StringLength(100, ErrorMessage = "No puede exceder más de 100 caracteres")]
        public string? apellidoMaterno { get; set; }


        [StringLength(15, ErrorMessage = "No puede exceder más de 15 caracteres")]
        public string? telefono { get; set; }


        [Required (ErrorMessage = "Debe registrar al menos el télefono celular")]
        [StringLength(15, ErrorMessage = "No puede exceder más de 15 caracteres")]
        public string? celular { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required (ErrorMessage = "Debe registrar la fecha de nacimiento")]
        public DateTime? nacimiento { get; set; }


        [Required (ErrorMessage = "Indique la adscripción del docente")]
        [StringLength(100, ErrorMessage = "No puede exceder más de 100 caracteres")]
        public string? adscripcion { get; set; }

        [Required (ErrorMessage = "Indique la ubicación del cubículo del docente")]
        [StringLength(100, ErrorMessage = "No puede exceder más de 100 caracteres")]
        public string? cubiculo { get; set; }


        [EmailAddress (ErrorMessage = "Correo Electrónico no válido")]
        [Required (ErrorMessage = "El correo BUAP es obligatorio")]
        public string? correoBuap { get; set; }


        [EmailAddress (ErrorMessage = "Correo Electrónico no válido")]
        public string? correoViep { get; set; }
        public string? tesista { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? fechaRegistro { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? fechaActualizacion { get; set; }
    }
}
