using Microsoft.AspNetCore.Mvc;

public class ContactController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string name, string email, string message)
    {
        // Poți adăuga logică de trimitere email sau salvare în DB
        ViewBag.Message = "Mesajul a fost trimis cu succes!";
        return View();
    }
}