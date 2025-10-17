using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Curso
    {
        [Key]
        public string? id_curso { get; set; }
        [Required]
        public string? nombre { get; set; }
        public string? periodo { get; set; }
        [DataType(DataType.Date)]
        public DateTime? anio { get; set; }
    }
}
