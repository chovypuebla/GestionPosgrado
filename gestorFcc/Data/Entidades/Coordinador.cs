using System.ComponentModel.DataAnnotations;

namespace gestorFcc.Data.Entidades
{
    public class Coordinador
    {
        [Key]
        public string id_coordinador { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public string contrasenia { get; set; }
        public string rol { get; set; }
    }
}
