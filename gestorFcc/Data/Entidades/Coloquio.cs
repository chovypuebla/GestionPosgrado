using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Coloquio
    {
        [Required (ErrorMessage = "Debe asignar un número de identificación")]
        [Key]
        public string? id_coloquio { get; set; }

        [Required (ErrorMessage = "Debe asignar un título")]
        public string? titulo { get; set; }

        [Required (ErrorMessage = "Debe asignar una fecha")]
        [DataType(DataType.Date)]
        public DateTime? fecha { get; set; }

        [Required (ErrorMessage = "Debe asignar un lugar")]
        public string? lugar { get; set; }

        [Required (ErrorMessage = "Debe asignar una hora")]
        [DataType(DataType.Time)]
        public TimeSpan? hora { get; set; }

        public DateTime? fechaRegistro { get; set; } = DateTime.Now;

    }
}
