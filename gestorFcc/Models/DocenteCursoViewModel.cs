namespace gestorFcc.Models
{
    public class DocenteCursoViewModel
    {
        public int Id { get; set; }
        public string? IdDocente { get; set; }
        public string? NombreDocente { get; set; }
        public string? IdCurso { get; set; }
        public string? NombreCurso { get; set; }
        public string? Periodo { get; set; }
        public DateTime? FechaAsignacion { get; set; }
    }
}