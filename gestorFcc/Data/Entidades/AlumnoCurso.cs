using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "El nombre del alumno es necesario")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Necesario un apellido al menos")]
        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }
        public DateTime? fechaAsignacion { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Debe asignar el periodo del curso")]
        public string periodo { get; set; }

    }
}
