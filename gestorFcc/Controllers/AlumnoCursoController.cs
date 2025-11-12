using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using gestorFcc.Models;
using gestorFcc.Data.Entidades;
using System.Linq.Expressions;

namespace gestorFcc.Controllers
{
    public class AlumnoCursoController : Controller
    {
        private readonly ContextoAplicacionBD _context;

        //Inyección de dependencias del contexto de la base de datos
        public AlumnoCursoController(ContextoAplicacionBD context)
        {
            _context = context;
        }

        //asignar un curso a un alumno (get)

        public async Task<IActionResult> AsignarCurso()
        {
            ViewBag.Alumno = await _context.Alumno.ToListAsync();
            ViewBag.Curso = await _context.Curso.ToListAsync();
            return View("AsignacionAlumno");
        }

        [HttpPost]
        public async Task<IActionResult> AsignarCurso (string matricula, string id_curso, string periodo)
        {
            var existe = await _context.AlumnoCurso
                .AnyAsync(ac=> ac.matricula == matricula && ac.id_curso == id_curso);

            if (!existe)
            {
                var asignacion = new AlumnoCurso
                {
                    
                    matricula = matricula,
                    id_curso = id_curso,
                    periodo = periodo,
                    fechaAsignacion = DateTime.Now
                };

                _context.AlumnoCurso.Add(asignacion);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Curso asignado al alumno correctamente.";
            }
            else
            {
                TempData["Error"] = "El alumno ya tiene asignado ese curso.";
            }
            return RedirectToAction("AsignarCurso");
        }

        //get : asignaciones realizadas

        public async Task<IActionResult> Asignaciones()
        {
            var asignaciones = await (from ac in _context.AlumnoCurso
                                      join a in _context.Alumno on ac.matricula equals a.matricula into gj
                                      from a in gj.DefaultIfEmpty()
                                      select new AlumnoCurso
                                      {
                                          id = ac.id,
                                          matricula = ac.matricula,
                                          id_curso = ac.id_curso,
                                          periodo = ac.periodo,
                                          fechaAsignacion = ac.fechaAsignacion,
                                          nombre = a != null ? a.nombre : null,
                                          apellidoPaterno = a != null ? a.apellidoPaterno : null,
                                          apellidoMaterno = a != null ? a.apellidoMaterno : null
                                      }).ToListAsync();

            return View(asignaciones);
        }

    }
}
