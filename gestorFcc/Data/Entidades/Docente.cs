using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Docente
    {
        [Key]
        public string id_docente { get; set; }
        [Required]
        public string nombre { get; set; }
        public string telefono { get; set; }
        [Required]
        public string celular { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime nacimiento { get; set; }
        [Required]
        public string adscripcion { get; set; }
        [Required]
        public string cubiculo { get; set; }
        [EmailAddress]
        public string correoBuap { get; set; }
        [EmailAddress]
        public string correoViep { get; set; }
        public string tesista { get; set; }
    }
}
