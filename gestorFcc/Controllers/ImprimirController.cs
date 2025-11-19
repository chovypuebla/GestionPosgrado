using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using gestorFcc.Data.Entidades;
using gestorFcc.Models;

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
            try
            {
                // Cargar SOLO propiedades que sabemos que EXISTEN
                var model = new PrintViewModel
                {
                    Alumno = await _context.Alumno
                        .Select(a => new Alumno 
                        { 
                            matricula = a.matricula,
                            nombre = a.nombre,
                            celular = a.celular,
                            correo = a.correo,
                            telefono = a.telefono,
                            direccion = a.direccion
                            // EXCLUIR: apellidoPaterno, apellidoMaterno (no existen en BD)
                        })
                        .ToListAsync(),
                        
                    Docente = await _context.Docente
                        .Select(d => new Docente 
                        { 
                            id_docente = d.id_docente,
                            nombre = d.nombre,
                            celular = d.celular,
                            correoBuap = d.correoBuap,
                            telefono = d.telefono,
                            adscripcion = d.adscripcion,
                            cubiculo = d.cubiculo
                            // EXCLUIR: apellidoPaterno, apellidoMaterno (no existen en BD)
                        })
                        .ToListAsync(),
                        
                    Curso = await _context.Curso
                        .Select(c => new Curso 
                        { 
                            id_curso = c.id_curso,
                            nombre = c.nombre,
                            periodo = c.periodo
                        })
                        .ToListAsync(),
                        
                    Coloquio = await _context.Coloquio
                        .Select(col => new Coloquio 
                        { 
                            id_coloquio = col.id_coloquio,
                            titulo = col.titulo,
                            fecha = col.fecha,
                            lugar = col.lugar,
                            hora = col.hora
                        })
                        .ToListAsync(),
                        
                    // Opcionales - solo si existen datos
                    AlumnoCurso = new List<AlumnoCurso>(),
                    DocenteCurso = new List<DocenteCurso>(),
                    Coordinador = new List<Coordinador>(),
                    
                    FechaGeneracion = DateTime.Now
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar datos: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}