using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Alumno
    {
        [Key]
        [Required (ErrorMessage = "La matricula es obligatoria")]
        [StringLength (10, ErrorMessage = "No puede exceder más de 10 caracteres")]
        public string? matricula { get; set; }


        [Required (ErrorMessage = "El nombre es obligatorio")]
        [StringLength (100, ErrorMessage = "No puede exceder más de 100 caracteres")]
        public string? nombre { get; set; }


        [Required (ErrorMessage = "Debe por lo menos registrarse un apellido")]
        [StringLength(100, ErrorMessage = "No puede exceder más de 100 caracteres")]
        public string? apellidoPaterno { get; set; }


        [StringLength(100, ErrorMessage = "No puede exceder más de 100 caracteres")]
        public string? apellidoMaterno { get; set; }


        public string? direccion { get; set; }


        [StringLength(15, ErrorMessage = "No puede exceder más de 15 caracteres")]
        public string? telefono { get; set; }


        [Required (ErrorMessage = "Debe por lo menos resgistrar un número de contacto")]
        [StringLength(15, ErrorMessage = "No puede exceder más de 15 caracteres")]
        public string? celular { get; set; }


        [EmailAddress (ErrorMessage = "Correo Electrónico no válido")]
        [Required (ErrorMessage = "El correo es obligatorio")]
        public string? correo { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? fechaRegistro { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? fechaActualizacion { get; set; }
    }
}
