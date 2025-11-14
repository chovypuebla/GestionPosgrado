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
            return View("AsignacionDocente");
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
            var asignacionesConInfo = await _context.DocenteCurso
                .Join(_context.Docente,
                    dc => dc.id_docente,
                    d => d.id_docente,
                    (dc, d) => new { dc, d })
                .Join(_context.Curso,
                    joined => joined.dc.id_curso,
                    c => c.id_curso,
                    (joined, c) => new { joined.dc, joined.d, c })
                .OrderBy(x => x.d.nombre)
                .ThenBy(x => x.d.apellidoPaterno)
                .ThenBy(x => x.d.apellidoMaterno)
                .Select(x => new gestorFcc.Models.DocenteCursoViewModel
                {
                    Id = x.dc.id,
                    IdDocente = x.dc.id_docente,
                    NombreDocente = (x.d.nombre ?? "") + " " + (x.d.apellidoPaterno ?? "") + " " + (x.d.apellidoMaterno ?? ""),
                    IdCurso = x.dc.id_curso,
                    NombreCurso = x.c != null ? x.c.nombre : x.dc.id_curso,
                    Periodo = x.dc.periodo,
                    FechaAsignacion = x.dc.fechaAsignacion
                })
                .ToListAsync();

            return View(asignacionesConInfo);
        }

    }
}
