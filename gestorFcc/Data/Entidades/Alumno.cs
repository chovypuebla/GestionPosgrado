using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Alumno
    {
        [Key]
        public string? matricula { get; set; }
        [Required]
        public string? nombre { get; set; }
        [Required]
        public string? apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public string? celular { get; set; }
        [EmailAddress]
        public string? correo { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? fechaRegistro { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? fechaActualizacion { get; set; }
    }
}
