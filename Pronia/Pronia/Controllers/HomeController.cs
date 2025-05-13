using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_BB104.Context;
using Pronia_BB104.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pronia_BB104.Controllers;

public class HomeController(ProniaDbContext _context) : Controller
{

    public class HomeModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {

       
        var services = await _context.Services.ToListAsync();
        var sliders = await _context.Sliders.ToListAsync();
        HomeModel model = new()
        {
            Sliders = sliders,
            Services = services,
        };



        return View(model);
    }



}
