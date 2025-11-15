using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using gestorFcc.Data.Entidades;

namespace gestorFcc.Controllers
{
    public class ImprimirController : Controller
    {
        private readonly ContextoAplicacionBD _context;
        public ImprimirController(ContextoAplicacionBD context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = new PrintViewModel
            {
                Alumno = await _context.Alumno.ToListAsync(),
                Docente = await _context.Docente.ToListAsync(),
                Curso = await _context.Curso.ToListAsync(),
                DocenteCurso = await _context.DocenteCurso.ToListAsync(),
                AlumnoCurso = await _context.AlumnoCurso.ToListAsync(),
                Coordinador = await _context.Coordinador.ToListAsync(),
                Coloquio = await _context.Coloquio.ToListAsync(),
                FechaGeneracion = DateTime.Now
            };

            return View(model);
        }
    }

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
