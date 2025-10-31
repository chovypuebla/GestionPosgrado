using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using gestorFcc.Models;
using gestorFcc.Data.Entidades;

namespace gestorFcc.Controllers
{
    public class ColoquioController : Controller
    {
        private readonly ContextoAplicacionBD _context;

        public ColoquioController(ContextoAplicacionBD context)
        {
            _context = context;
        }

        //Listar todos los coloquios registrados
        
        public async Task<IActionResult> Index()
        {
            try
            {
                // SOLUCIÓN: Carga segura con manejo explícito de NULLs
                var coloquio = await _context.Coloquio.Select(a => new Coloquio
                {
                    titulo = a.titulo ?? "Sin asignar",
                    id_coloquio = a.id_coloquio ?? "Sin ID",
                    fecha = a.fecha,
                    lugar = a.lugar ?? "Sin lugar asignado",
                    hora = a.hora
                })
                    .ToListAsync();

                return View(coloquio);
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                Console.WriteLine($"Error al cargar coloquios: {ex.Message}");

                // Carga alternativa segura
                return await CargarColoquioSeguro();
            }
        }

        // Método auxiliar para carga segura
        private async Task<IActionResult> CargarColoquioSeguro()
        {
            var coloquioSeguro = new List<Coloquio>();

            try
            {
                var coloquioRaw = await _context.Coloquio.ToListAsync();

                foreach (var coloquio in coloquioRaw)
                {
                    coloquioSeguro.Add(new Coloquio
                    {
                        id_coloquio = coloquio.id_coloquio ?? "Sin ID",
                        titulo = coloquio.titulo ?? "Sin asignar",
                        fecha = coloquio.fecha,
                        lugar = coloquio.lugar ?? "Sin lugar asignado",
                        hora = coloquio.hora
                    });
                }
            }
            catch (Exception ex)
            {
                // Si incluso esto falla, mostrar vista vacía con mensaje
                TempData["Error"] = "Error al cargar los coloquios: " + ex.Message;
            }

            return View(coloquioSeguro);
        }

        //Mostrar formulario
        public IActionResult Create()
        {
            return View();
        }

        //Guardar nuevo registro de coloquio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_coloquio, titulo, fecha, lugar, hora")] Coloquio coloquio)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Coloquio.AnyAsync(a => a.id_coloquio == coloquio.id_coloquio))
                {
                    //Ya existe un coloquio con esa matrícula
                    ViewBag.Error = "Ya existe un coloquio registrado con ese ID.";
                    return View(coloquio);
                }

                if (coloquio.fecha == null || coloquio.hora == null)
                {
                    coloquio.hora = TimeSpan.Zero;
                    coloquio.fecha = DateTime.Now;
                }
                _context.Add(coloquio);
                coloquio.fechaRegistro = DateTime.Now;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(coloquio);
        }

        //Mostrar formulario para editar
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var coloquio = await _context.Coloquio.FindAsync(id);
            if (coloquio == null)
            {
                return NotFound();
            }
            return View(coloquio);
        }

        //Actualizar el registro del coloquio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_coloquio, titulo, fecha, lugar, hora")] Coloquio coloquio)
        {
            if (id != coloquio.id_coloquio)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                if (coloquio.fecha == null || coloquio.hora == null)
                {
                    coloquio.hora = TimeSpan.Zero;
                    coloquio.fecha = DateTime.Now;
                }
                try
                {
                    _context.Update(coloquio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!coloquioExists(coloquio.id_coloquio))
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
            return View(coloquio);
        }

        //Eliminar registro de un coloquio
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var coloquio = await _context.Coloquio
                .FirstOrDefaultAsync(m => m.id_coloquio == id);
            if (coloquio == null)
            {
                return NotFound();
            }
            return View(coloquio);
        }

        //Confirmar eliminación
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var coloquio = await _context.Coloquio.FindAsync(id);
            if (coloquio != null)
            {
                _context.Coloquio.Remove(coloquio);
                await _context.SaveChangesAsync();
                TempData["Succes"] = "Coloquio eliminado exitosamente";
            }
            return RedirectToAction(nameof(Index));
        }

        //metodo para verificar que un coloquio esta registrado
        private bool coloquioExists(string id)
        {
            return _context.Coloquio.Any(e => e.id_coloquio == id);
        }
    }
}

