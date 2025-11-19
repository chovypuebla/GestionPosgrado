using gestorFcc.Data;
using gestorFcc.Data.Entidades;
using gestorFcc.Models;
using gestorFcc.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace gestorFcc.Controllers
{
    public class ExportarController : Controller
    {
        private readonly ExcelExportarServicio _exportService;
        private readonly ILogger<ExportarController> _logger;

        public ExportarController(ExcelExportarServicio exportService, ILogger<ExportarController> logger)
        {
            _exportService = exportService;
            _logger = logger;
        }

        public IActionResult ExportarExcel()
        {
            try
            {
                _logger.LogInformation("Iniciando exportación a Excel...");

                var excelData = _exportService.ExportarTodosDatos();
                var fileName = $"Backup_Completo_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                _logger.LogInformation($"Archivo {fileName} generado exitosamente. Tamaño: {excelData.Length} bytes");

                // Forzar descarga
                Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");

                return File(excelData,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al exportar los datos a Excel");
                TempData["Error"] = $"Error al exportar los datos: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
