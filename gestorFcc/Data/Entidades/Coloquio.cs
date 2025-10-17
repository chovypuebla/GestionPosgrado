using System.ComponentModel.DataAnnotations;
namespace gestorFcc.Data.Entidades
{
    public class Coloquio
    {
        [Key]
        public string? id_coloquio { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fecha { get; set; }
        public string? lugar { get; set; }
        public TimeSpan? hora { get; set; }


    }
}
