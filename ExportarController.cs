using Microsoft.AspNetCore.Mvc;
using gestorFcc.Data;
using gestorFcc.Data.Entidades;
using gestorFcc.Models;
using gestorFcc.Servicios;


namespace gestorFcc.Controllers
{
    public class ExportarController : Controller
    {
        private readonly ExcelExportarServicio _exportService;

        public ExportarController(ExcelExportarServicio exportService)
        {
            _exportService = exportService;
        }

        public IActionResult ExportarExcel()
        {
            try
            {
                var excelData = _exportService.ExportarTodosDatos();
                var fileName = $"Backup_Completo_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al exportar los datos: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
