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
            var docente = await _context.Docente.ToListAsync();
            return View(docente);
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
