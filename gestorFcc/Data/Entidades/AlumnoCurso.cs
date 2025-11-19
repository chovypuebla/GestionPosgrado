using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestorFcc.Data.Entidades
{
    public class AlumnoCurso
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El número identificador del curso es necesario")]
        public string? id_curso { get; set; }

        [Required(ErrorMessage = "La matricula del alumno debe registrarse")]
        [StringLength(10, ErrorMessage = "No puede exceder más de 10 caracteres")]
        public string? matricula { get; set; }

        // Campos usados solo en la UI: no mapearlos a la BD
        [NotMapped]
        public string? nombre { get; set; }

        [NotMapped]
        public string? apellidoPaterno { get; set; }

        [NotMapped]
        public string? apellidoMaterno { get; set; }

        public DateTime? fechaAsignacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Debe asignar el periodo del curso")]
        public string periodo { get; set; }
    }
}
