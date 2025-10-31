using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using gestorFcc.Models;
using gestorFcc.Data.Entidades;
using System.Linq.Expressions;

namespace gestorFcc.Controllers
{
    public class DocenteCursoController : Controller
    {
        private readonly ContextoAplicacionBD _context;

        //Inyección de dependencias del contexto de la base de datos
        public DocenteCursoController (ContextoAplicacionBD context)
        {
            _context = context;
        }

        //asignar un curso a un docente (get)

        public async Task<IActionResult> AsignarCurso()
        {
            ViewBag.Docente = await _context.Docente.ToListAsync();
            ViewBag.Curso = await _context.Curso.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AsignarCurso(string id_docente, string id_curso, string periodo)
        {
            var existe = await _context.DocenteCurso
                .AnyAsync(ac => ac.id_docente == id_docente && ac.id_curso == id_curso);

            if (!existe)
            {
                var asignacion = new DocenteCurso
                {
                    id_docente = id_docente,
                    id_curso = id_curso,
                    periodo = periodo,
                    fechaAsignacion = DateTime.Now
                };

                _context.DocenteCurso.Add(asignacion);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Curso asignado al docente correctamente.";
            }
            else
            {
                TempData["Error"] = "El docente ya tiene asignado ese curso.";
            }
            return RedirectToAction("AsignarCurso");
        }

        //get : asignaciones realizadas

        public async Task<IActionResult> Asignaciones()
        {
            var asignaciones = await _context.DocenteCurso.ToListAsync();
            return View(asignaciones);
        }

    }
}
