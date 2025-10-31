using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using gestorFcc.Models;
using gestorFcc.Data.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace gestorFcc.Controllers
{
    public class ExpedienteController : Controller
    {
        //BD:
        private readonly ContextoAplicacionBD _context;
        //Acceder a las carpetas para cargar los archivos del expediente
        private readonly IWebHostEnvironment _environment;

        public ExpedienteController(ContextoAplicacionBD context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        //Seleccionar la matrícula y cargar info del alumno

        public async Task<IActionResult> SeleccionarAlumno()
        {
            //Cargar alumnos para el dropdown
            var alumno = await _context.Alumno
                .Select(a => new { a.matricula, nombreCompleto = $"{a.nombre} {a.apellidoPaterno} {a.apellidoMaterno}" })
                .ToListAsync();

            ViewBag.Alumno = new SelectList(alumno, "matricula", "nombreCompleto");
            return View();
        }

        //Metodo POST Redirigir a cargar los archivos para el expediente del alumno
        [HttpPost]
        public IActionResult SeleccionarAlumno(string matricula)
        {
            return RedirectToAction("CrearExpediente", new { matricula });
        }

        //Metodos de subir archivos

        public async Task<IActionResult> CrearExpediente(string matricula)
        {
            // Validar matrícula
            if (string.IsNullOrEmpty(matricula))
            {
                TempData["Error"] = "Matrícula no proporcionada";
                return RedirectToAction("SeleccionarAlumno");
            }

            // El alumno existe?
            var alumno = await _context.Alumno
                .Where(a => a.matricula == matricula)
                .Select(a => new {
                    a.matricula,
                    a.nombre,
                    a.apellidoPaterno,
                    a.apellidoMaterno
                }).FirstOrDefaultAsync();

            if (alumno == null)
            {
                TempData["Error"] = "Alumno no encontrado";
                return RedirectToAction("SeleccionarAlumno");
            }

            ViewBag.Alumno = alumno;

            // Verificar si existe expediente - CON MANEJO DE ERRORES
            try
            {
                var expedienteExistente = await _context.Expediente
                    .FirstOrDefaultAsync(e => e.matricula == matricula);

                if (expedienteExistente != null)
                {
                    TempData["Info"] = "Ya hay un expediente para este alumno, puede actualizar si lo desea";
                }

                ViewBag.ExpedienteExistente = expedienteExistente != null;
            }
            catch (Exception ex)
            {
                // Si hay error, asumir que no existe expediente
                Console.WriteLine($"Error al verificar expediente: {ex.Message}");
                ViewBag.ExpedienteExistente = false;
                TempData["Warning"] = "No se pudo verificar expedientes existentes";
            }

            return View();
        }

        //Guardar expediente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearExpediente(string matricula, IFormFile ine, IFormFile cartaCompromiso, IFormFile cartaRecomendacion1, IFormFile cartaRecomendacion2, IFormFile protocolo, IFormFile comprobanteToefl, IFormFile exani, IFormFile tituloLicenciatura, IFormFile tituloMaestria, IFormFile cedulaLicenciatura, IFormFile cedulaMaestria, IFormFile curriculumVitae, IFormFile publicaciones, IFormFile kardexSemestral, IFormFile pagoInscripcion)
        {
            var alumnoExiste = await _context.Alumno.AnyAsync(a => a.matricula == matricula);

            if (!alumnoExiste)
            {
                TempData["Error"] = "Alumno no encontrado";
                return RedirectToAction("SeleccionarAlumno");
            }

            //Verificar si ya hay expediente
            var expedienteExiste = await _context.Expediente.FirstOrDefaultAsync(e => e.matricula == matricula);

            var expediente = expedienteExiste ?? new Expediente {matricula = matricula };

            //Procesar cada archivo
            if (ine != null && ine.Length > 0)
                expediente.ine = await GuardarArchivo(ine, matricula, "INE");

            if (cartaCompromiso != null && cartaCompromiso.Length > 0)
                expediente.cartaCompromiso = await GuardarArchivo(cartaCompromiso, matricula, "Carta Compromiso");

            if (cartaRecomendacion1 != null && cartaRecomendacion1.Length > 0)
                expediente.cartaRecomendacion1 = await GuardarArchivo(cartaRecomendacion1, matricula, "Carta de Recomendación 1");

            if (cartaRecomendacion2 != null && cartaRecomendacion2.Length > 0)
                expediente.cartaRecomendacion2 = await GuardarArchivo(cartaRecomendacion2, matricula, "Carta Recomendación 2");

            if (protocolo != null && protocolo.Length > 0)
                expediente.protocolo = await GuardarArchivo(protocolo, matricula, "Protocolo");

            if (comprobanteToefl != null && comprobanteToefl.Length > 0)
                expediente.comprobanteToefl = await GuardarArchivo(comprobanteToefl, matricula, "Comprobante Toefl");

            if (exani != null && exani.Length > 0)
                expediente.exani = await GuardarArchivo(exani, matricula, "EXANI");

            if (tituloLicenciatura != null && tituloLicenciatura.Length > 0)
                expediente.tituloLicenciatura = await GuardarArchivo(tituloLicenciatura, matricula, "Título de Licenciatura");

            if (tituloMaestria != null && tituloMaestria.Length > 0)
                expediente.tituloMaestria = await GuardarArchivo(tituloMaestria, matricula, "Título de Maestría");

            if (cedulaLicenciatura != null && cedulaLicenciatura.Length > 0)
                expediente.cedulaLicenciatura = await GuardarArchivo(cedulaLicenciatura, matricula, "Cédula de Licenciatura");

            if (cedulaMaestria != null && cedulaMaestria.Length > 0)
                expediente.cedulaMaestria = await GuardarArchivo(cedulaMaestria, matricula, "Cédula de Maestría");

            if (curriculumVitae != null && curriculumVitae.Length > 0)
                expediente.curriculumVitae = await GuardarArchivo(curriculumVitae, matricula, "Currículum Vitae");

            if (publicaciones != null && publicaciones.Length > 0)
                expediente.publicaciones = await GuardarArchivo(publicaciones, matricula, "Publicaciones");

            if (kardexSemestral != null && kardexSemestral.Length > 0)
                expediente.kardexSemestral = await GuardarArchivo(kardexSemestral, matricula, "Kardex Semestral");

            if (pagoInscripcion != null && pagoInscripcion.Length > 0)
                expediente.pagoInscripcion = await GuardarArchivo(pagoInscripcion, matricula, "Pago de Inscripción");

            expediente.fechaActualizacion = DateTime.Now;

            if (expedienteExiste == null)
            {
                expediente.id_expediente = Guid.NewGuid().ToString();
                expediente.fechaCreacion = DateTime.Now;
                _context.Expediente.Add(expediente);
            }
            else
            {
                _context.Expediente.Update(expediente);
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = "Expediente guardado correctamente.";
            return RedirectToAction("SeleccionarAlumno");
        }

        private async Task<string> GuardarArchivo(IFormFile archivo, string matricula, string tipoDocumento)
        {
            var carpeta = Path.Combine(_environment.WebRootPath, "expediente", matricula);

            Directory.CreateDirectory(carpeta);

            var extension = Path.GetExtension(archivo.FileName);
            var nombreArchivo = $"{tipoDocumento}_{DateTime.Now:yyyyMMddHHmmss}{extension}";

            var rutaCompleta = Path.Combine(carpeta, nombreArchivo);

            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            }

            return $"/expediente/{matricula}/{nombreArchivo}";
        }



    }
}
