using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class DocenteCurso
    {
        [Key]
        public int id { get; set; } //Iteración

        public string? id_curso { get; set; }

        public string? id_docente { get; set; }

        public DateTime? fechaRegistro { get; set; } = DateTime.Now;
        public string? periodo { get; set; }
        public DateTime? fechaAsignacion { get; set; }
    }
}
