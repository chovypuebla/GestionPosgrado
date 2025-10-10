using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Alumno
    {
        [Key]
        public string matricula { get; set; }
        [Required]
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        [EmailAddress]
        public string correo { get; set; }

    }
}
