using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}