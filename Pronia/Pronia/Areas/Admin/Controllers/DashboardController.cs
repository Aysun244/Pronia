using Microsoft.AspNetCore.Mvc;
using Pronia_BB104.Repositories.Implementations;

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
        SliderRepository repository = new();

        await repository.AddAsync(new() { Title = "Emiliya", Description = "Sakit dur", Price = 10, ImagePath = "1-1-120x120.webp" });


        return Ok("Done");
    }
}
