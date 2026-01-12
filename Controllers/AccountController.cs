using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportPlus.Models;
using SportPlus.Services;
using System.Security.Claims;


public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly IWebHostEnvironment _env;

    public AccountController(IUserService userService, IWebHostEnvironment env)
    {
        _userService = userService;
        _env = env;
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = (await _userService.GetAllAsync())
            .FirstOrDefault(u => u.Email == model.Email && u.Parola == model.Parola);

        if (user == null)
        {
            ModelState.AddModelError("", "Email sau parolă incorecte.");
            return View(model);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Nume),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Rol ?? "User")
        };

        var identity = new ClaimsIdentity(claims, "AuthCookie");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("AuthCookie", principal);
        return RedirectToAction("Index", "Cont"); // redirecționează către pagina contului
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        string? fileName = null;

        if (model.PozaProfil != null && model.PozaProfil.Length > 0)
        {
            var uploads = Path.Combine(_env.WebRootPath, "images/users");
            Directory.CreateDirectory(uploads);

            fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.PozaProfil.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await model.PozaProfil.CopyToAsync(stream);
        }

        var user = new User
        {
            Nume = model.Nume,
            Email = model.Email,
            Parola = model.Parola,
            Adresa = model.Adresa,
            Telefon = model.Telefon,
            Rol = "ADMIN",
            PozaProfil = fileName
        };

        await _userService.CreateAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Nume),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Rol ?? "User")
        };

        var identity = new ClaimsIdentity(claims, "AuthCookie");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("AuthCookie", principal);

        return RedirectToAction("Index", "Cont");
    }
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("AuthCookie");
        return RedirectToAction("Login");
    }

}
