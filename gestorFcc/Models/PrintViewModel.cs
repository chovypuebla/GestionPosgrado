using gestorFcc.Data.Entidades;

namespace gestorFcc.Models
{
    public class PrintViewModel
    {
        public List<Alumno> Alumno { get; set; }
        public List<Docente> Docente { get; set; }
        public List<Curso> Curso { get; set; }
        public List<DocenteCurso> DocenteCurso { get; set; }
        public List<AlumnoCurso> AlumnoCurso { get; set; }
        public List<Coordinador> Coordinador { get; set; }
        public List<Coloquio> Coloquio { get; set; }
        public DateTime FechaGeneracion { get; set; }
    }

}
