using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestorFcc.Data;
using System.Linq.Expressions;
using Microsoft.Identity.Client;
namespace gestorFcc.Controllers
{
    public class AccountController : Controller
    {
        private readonly ContextoAplicacionBD _context;
        public AccountController(ContextoAplicacionBD context)
        {
            _context = context;
        }

        // método get / Account /Login
        public IActionResult Login()
        {
            return View();
        }
        //método post / Account /Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string usuario, string contrasenia)
        {
            try
            {
                //Validar que tengan los datos
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia))
                {
                    ViewBag.Error = "Debe ingresar usuario y contraseña";
                    return View();
                }

                //Buscar al usuario en la base de datos
                var coordinador = await _context.Coordinador.FirstOrDefaultAsync(c => c.usuario == usuario && c.contrasenia == contrasenia);

                if (coordinador == null)
                {
                    //Login fallido
                    ViewBag.Error = "Usuario o contraseña incorrectos";
                    return View();
                }
                else
                {
                    //Login exitoso
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                //Error en la base de datos
                ViewBag.Error = "Error en el sistema. Intente más tarde.";
                return View();
            }
        }
        //Cerrar sesión
        public IActionResult Logout()
        {
            //Aquí se podría limpiar la sesión o las cookies si se estuviera usando autenticación
            return RedirectToAction("Login");
        }

        //Version de Prueba sin vista
        //public IActionResult TestLogin()
        //{
        //    //Simular un login exitoso
        //    var usuario = "201921492";
        //    var contrasenia = "rodorm24";

        //    var usuarioEncontrado = _context.Coordinador
        //        .FirstOrDefault(c=> c.usuario == usuario && c.contrasenia == contrasenia);
        //    if (usuarioEncontrado == null)
        //    {
        //        //login fallido
        //        return Content("Login fallido: Usuario o contraseña incorrectos");

        //    }
        //    //login exitoso
        //    else {
        //        return Content("Login exitoso. Bienvenido " + usuarioEncontrado.usuario);
        //    }
        //}
    }
}
