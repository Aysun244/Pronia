using Microsoft.AspNetCore.Mvc;


namespace Pronia_BB104.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        return Ok("Done");
    }
}
