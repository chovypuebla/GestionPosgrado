using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using gestorFcc.Models;
using gestorFcc.Data.Entidades;

namespace gestorFcc.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ContextoAplicacionBD _context;

        //Inyección de dependencias del contexto de la base de datos
        public AlumnoController(ContextoAplicacionBD context)
        {
            _context = context;
        }

        //Listar todos los alumnos registrados
        public async Task<IActionResult> Index()
        {
            try
            {
                // SOLUCIÓN: Carga segura con manejo explícito de NULLs
                var alumnos = await _context.Alumno.Select(a => new Alumno
                    {
                        matricula = a.matricula ?? "N/A",
                        nombre = a.nombre ?? "Sin nombre",
                        apellidoPaterno = a.apellidoPaterno ?? "",
                        apellidoMaterno = a.apellidoMaterno ?? "",
                        direccion = a.direccion ?? "Sin dirección",
                        telefono = a.telefono ?? "Sin teléfono",
                        celular = a.celular ?? "Sin celular",
                        correo = a.correo ?? "Sin correo",
                        fechaRegistro = a.fechaRegistro,
                        fechaActualizacion = a.fechaActualizacion
                    })
                    .ToListAsync();

                return View(alumnos);
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                Console.WriteLine($"Error al cargar alumnos: {ex.Message}");

                // Carga alternativa segura
                return await CargarAlumnosSeguro();
            }
        }

        // Método auxiliar para carga segura
        private async Task<IActionResult> CargarAlumnosSeguro()
        {
            var alumnosSeguros = new List<Alumno>();

            try
            {
                var alumnosRaw = await _context.Alumno.ToListAsync();

                foreach (var alumno in alumnosRaw)
                {
                    alumnosSeguros.Add(new Alumno
                    {
                        matricula = alumno.matricula ?? "N/A",
                        nombre = alumno.nombre ?? "Sin nombre",
                        apellidoPaterno = alumno.apellidoPaterno ?? "",
                        apellidoMaterno = alumno.apellidoMaterno ?? "",
                        direccion = alumno.direccion ?? "Sin dirección",
                        telefono = alumno.telefono ?? "Sin teléfono",
                        celular = alumno.celular ?? "Sin celular",
                        correo = alumno.correo ?? "Sin correo",
                        fechaRegistro = alumno.fechaRegistro,
                        fechaActualizacion = alumno.fechaActualizacion
                    });
                }
            }
            catch (Exception ex)
            {
                // Si incluso esto falla, mostrar vista vacía con mensaje
                TempData["Error"] = "Error al cargar los alumnos: " + ex.Message;
            }

            return View(alumnosSeguros);
        }

        //Mostrar formulario
        public IActionResult Create()
        {
            return View();
        }

        //Guardar nuevo registro de alumno
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("matricula, nombre, apellidoPaterno, apellidoMaterno, direccion, telefono, celular, correo, fechaRegistro")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                if(await _context.Alumno.AnyAsync(a => a.matricula == alumno.matricula))
                {
                    //Ya existe un alumno con esa matrícula
                    ViewBag.Error = "Ya existe un alumno con esa matrícula.";
                    return View(alumno);
                }

                if (alumno.fechaRegistro == null)
                {
                   alumno.fechaRegistro = DateTime.Now;
                }
                _context.Add(alumno);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(alumno);
        }

        //Mostrar formulario para editar
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var alumno = await _context.Alumno.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        //Actualizar el registro del alumno
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("matricula, nombre, apellidoPaterno, apellidoMaterno, direccion, telefono, celular, correo, fechaActualizacion")] Alumno alumno)
        {
            if (id != alumno.matricula)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                if (alumno.fechaActualizacion == null)
                {
                    alumno.fechaActualizacion = DateTime.Now;
                }
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!alumnoExists(alumno.matricula))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        //Eliminar registro de un alumno
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var alumno = await _context.Alumno
                .FirstOrDefaultAsync(m => m.matricula == id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        //Confirmar eliminación
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var alumno = await _context.Alumno.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumno.Remove(alumno);
                await _context.SaveChangesAsync();
                TempData["Succes"] = "Alumno eliminado exitosamente";
            }
            return RedirectToAction(nameof(Index));
        }

        //metodo para verificar que un alumno esta registrado
        private bool alumnoExists(string id)
        {
            return _context.Alumno.Any(e => e.matricula == id);
        }
    }
}
