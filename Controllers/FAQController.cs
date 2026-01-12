using Microsoft.AspNetCore.Mvc;

public class FaqController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}