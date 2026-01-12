using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportPlus.Services;
using System.Security.Claims;

[Authorize]
public class ContController : Controller
{
    private readonly IUserService _userService;

    public ContController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var user = (await _userService.GetAllAsync()).FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        return View(user);
    }
    
}