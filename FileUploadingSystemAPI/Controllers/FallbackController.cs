using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;


public class FallbackController : Controller
{
    public IActionResult Index() => PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
        "wwwroot", "index.html"), "text/HTML");
}
