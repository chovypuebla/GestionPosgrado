using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using gestorFcc.Models;
using gestorFcc.Data.Entidades;


namespace gestorFcc.Controllers
{
    public class DocenteController : Controller
    {
        //Inyección de dependencias del contexto de la base de datos
        private readonly ContextoAplicacionBD _context;

        public DocenteController(ContextoAplicacionBD context) 
        {
            _context = context;
        }

        //Listar todos los docentes registrados en la bd
        public async Task<IActionResult> Index()
        {
            try
            {
                var docente = await _context.Docente.Select(a => new Docente
                {
                    id_docente = a.id_docente ?? "N/A",
                    nombre = a.nombre ?? "Sin nombre",
                    apellidoPaterno = a.apellidoPaterno ?? "",
                    apellidoMaterno = a.apellidoMaterno ?? "",
                    telefono = a.telefono ?? "Sin teléfono",
                    celular = a.celular ?? "Sin celular",
                    nacimiento = a.nacimiento,
                    adscripcion = a.adscripcion ?? "Sin adscripción",
                    cubiculo = a.cubiculo ?? "Sin cubículo",
                    correoBuap = a.correoBuap ?? "Sin correo BUAP",
                    correoViep = a.correoViep ?? "Sin correo VIEP",
                    tesista = a.tesista ?? "No especificado",
                    fechaRegistro = a.fechaRegistro,
                    fechaActualizacion = a.fechaActualizacion



                }).ToListAsync();
                return View(docente);
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                Console.WriteLine($"Error al cargar docentes: {ex.Message}");
                // Carga alternativa segura
                return await CargarDocentesSeguro();
            }
        }
        // Método auxiliar para carga segura

        private async Task<IActionResult> CargarDocentesSeguro()
        {
            var docentesRaw = await _context.Docente.ToListAsync();

            try
            {
                foreach (var docente in docentesRaw)
                {
                    docentesRaw.Add(new Docente
                    {
                        id_docente = docente.id_docente ?? "N/A",
                        nombre = docente.nombre ?? "Sin nombre",
                        apellidoPaterno = docente.apellidoPaterno ?? "",
                        apellidoMaterno = docente.apellidoMaterno ?? "",
                        telefono = docente.telefono ?? "Sin teléfono",
                        celular = docente.celular ?? "Sin celular",
                        nacimiento = docente.nacimiento,
                        adscripcion = docente.adscripcion ?? "Sin adscripción",
                        cubiculo = docente.cubiculo ?? "Sin cubículo",
                        correoBuap = docente.correoBuap ?? "Sin correo BUAP",
                        correoViep = docente.correoViep ?? "Sin correo VIEP",
                        tesista = docente.tesista ?? "No especificado",
                        fechaRegistro = docente.fechaRegistro,
                        fechaActualizacion = docente.fechaActualizacion
                    });
                }
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                Console.WriteLine($"Error al procesar docentes: {ex.Message}");
            }

            return View(docentesRaw);

        }


        //Mostrar formulario
        public IActionResult Create()
        {
            return View();
        }

        //Guardar nuevo registro de docente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_docente, nombre, apellidoPaterno, apellidoMaterno, telefono, celular, nacimiento, adscripcion, cubiculo, correoBuap, correoViep, tesista, fechaRegistro")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Docente.AnyAsync(a => a.id_docente == docente.id_docente))
                {
                    
                    ViewBag.Error = "Ya existe un docente con esa matrícula.";
                    return View(docente);
                }

                if (docente.fechaRegistro == null)
                {
                    docente.fechaRegistro = DateTime.Now;
                }
                _context.Add(docente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(docente);
        }

        //Mostrar formulario para editar
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var docente = await _context.Docente.FindAsync(id);
            if (docente == null)
            {
                return NotFound();
            }
            return View(docente);
        }

        //Actualizar el registro del docente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_docente, nombre, apellidoPaterno, apellidoMaterno, telefono, celular, nacimiento, adscripcion, cubiculo, correoBuap, correoViep, tesista")] Docente docente)
        {
            if (id != docente.id_docente)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (docente.fechaActualizacion == null)
                {
                    docente.fechaActualizacion = DateTime.Now;
                }

                try
                {
                    _context.Update(docente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocenteExists(docente.id_docente))
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
            return View(docente);
        }

        //Eliminar registro de un docente
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var docente = await _context.Docente
                .FirstOrDefaultAsync(m => m.id_docente == id);
            if (docente == null)
            {
                return NotFound();
            }
            return View(docente);
        }

        //Confirmar eliminación
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var docente = await _context.Docente.FindAsync(id);
            if (docente != null)
            {
                _context.Docente.Remove(docente);
                await _context.SaveChangesAsync();
                TempData["Succes"] = "Docente eliminado exitosamente";
            }
            return RedirectToAction(nameof(Index));
        }

        //metodo para verificar que un docente esta registrado
        private bool DocenteExists(string id)
        {
            return _context.Docente.Any(e => e.id_docente == id);
        }
    }
}
