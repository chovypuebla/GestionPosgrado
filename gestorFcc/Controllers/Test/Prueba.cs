using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gestorFcc.Data;

public class Prueba : Controller
{
    private readonly ContextoAplicacionBD _context;
    public Prueba(ContextoAplicacionBD context)
    {
        _context = context;
    }
    
    public ActionResult Index()
    {
        try
        {
            //prueba 1: ¿Se puede conectar?
            var puedeConectar = _context.Database.CanConnect();
            ViewBag.Conexion = puedeConectar ? "Conexión exitosa a la base de datos." : "No se pudo conectar a la base de datos.";

            //prueba 2 ¿Puede acceder a las tablas?
            var totalCoordinadores = _context.Coordinador.Count();
            ViewBag.TotalCoordinadores = totalCoordinadores;
            ViewBag.Tablas = "Acceso a tablas exitoso";

            //prueba 3 Ver estructura de tablas
            var tablas = _context.Model.GetEntityTypes();
            ViewBag.Entidades = string.Join(", ", tablas.Select(t => t.ClrType.Name));

            return View();
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Error: " + ex.Message;
            return View();
        }
        
    }
}