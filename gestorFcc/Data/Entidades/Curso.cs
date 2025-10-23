using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Curso

    {
        [Key]
        [Required (ErrorMessage = "El campo Id Curso es obligatorio")]
        public string? id_curso { get; set; }
        [Required (ErrorMessage = "Este campo es obligatorio")]
        public string? nombre { get; set; }

        public string? periodo { get; set; }
        [DataType(DataType.Date)]
        public DateTime? anio { get; set; }
        [DataType(DataType.Date)]
        [Required (ErrorMessage = "Debe registrar la fecha de registro del curso")]
        public DateTime? fechaRegistroCurso { get; set; }
    }
}
