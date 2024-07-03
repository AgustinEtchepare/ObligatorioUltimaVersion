using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObligatorioVer1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ObligatorioVer1.Controllers
{
    public class AccountController : Controller
    {
        private readonly OblDbContext _context;

        public AccountController(OblDbContext context)
        {
            _context = context;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Buscar el usuario por email y contraseña
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == model.email && u.Contrasena == model.contrasena);

                if (usuario != null)
                {
                    // Crear las reclamaciones del usuario
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Email),
                        // Puedes añadir más reclamaciones según tus necesidades
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Crear el principal y el ticket de autenticación
                    var principal = new ClaimsPrincipal(identity);
                    

                    // Iniciar sesión
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home"); // Redirigir a la página de inicio o a la página deseada
                }

                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
            }

            // Si llegamos aquí, algo falló, volver a mostrar el formulario con errores
            return View(model);
        }

        // POST: Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); // Redirigir a la página de inicio o a la página deseada
        }
    }
}
