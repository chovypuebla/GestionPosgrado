using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class DocenteCurso
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El número identificador del curso es necesario")]
        public string? id_curso { get; set; }

        [Required(ErrorMessage = "Debe registrar el número del docente")]
        [StringLength(10, ErrorMessage = "No puede exceder más de 10 caracteres")]
        public string id_docente { get; set; }

        public DateTime? fechaRegistro { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El período académico es obligatorio")]
        public string periodo { get; set; }

        public DateTime? fechaAsignacion { get; set; }
    }
}
