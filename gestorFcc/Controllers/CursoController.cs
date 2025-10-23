using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using gestorFcc.Models;
using gestorFcc.Data.Entidades;

/*
 * Esta versión del controlador
 * Solo despliega la información de los cursos
 * en la base de datos que ya fueron registrados
 * El coordinador solo tiene permiso para consultar
 * no tiene permiso para agregar, editar o eliminar cursos
 * *
 */

namespace gestorFcc.Controllers
{
    public class CursoController : Controller
    {
        private readonly ContextoAplicacionBD _context;

        //inyección de la dependencia

        public CursoController(ContextoAplicacionBD context)
        {
            _context = context;
        }

        //Listar todos los cursos registrados
        public async Task<IActionResult> Index()
        {
            try
            {
                var cursos = await _context.Curso.Select(a => new Curso
                {
                    id_curso = a.id_curso ?? "Sin registrar",
                    nombre = a.nombre ?? "Sin nombre",
                    periodo = a.periodo ?? "Sin periodo",
                    anio = a.anio,
                    fechaRegistroCurso = a.fechaRegistroCurso

                }).ToListAsync();

                return View(cursos);
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                Console.WriteLine($"Error al cargar cursos: {ex.Message}");
                // Carga alternativa segura
                return await CargarCursosSeguro();
            }
        }
        // Método auxiliar para carga segura
        private async Task<IActionResult> CargarCursosSeguro()
        {
            var cursosSeguros = new List<Curso>();

            try
            {
                var cursosRaw = await _context.Curso.ToListAsync();

                foreach (var curso in cursosRaw)
                {
                    cursosSeguros.Add(new Curso
                    {
                        id_curso = curso.id_curso ?? "Sin registrar",
                        nombre = curso.nombre ?? "Sin nombre",
                        periodo = curso.periodo ?? "Sin periodo",
                        anio = curso.anio,
                        fechaRegistroCurso = curso.fechaRegistroCurso
                    });
                }
            }
            catch (Exception ex)
            {
                // Si incluso esto falla, mostrar vista vacía con mensaje
                TempData["Error"] = "Error al cargar los cursos: " + ex.Message;
            }

            return View(cursosSeguros);
        }


    }
}
