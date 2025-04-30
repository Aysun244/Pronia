using Microsoft.AspNetCore.Mvc;
using Pronia_BB104.Models;
using Pronia_BB104.Repositories.Implementations;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pronia_BB104.Controllers;

public class HomeController : Controller
{

    public class HomeModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {

        SliderRepository sliderRepository = new();
        ServiceRepository serviceRepository = new();

        var sliders = await sliderRepository.GetAllAsync();
        var services = await serviceRepository.GetAllAsync();
        //ViewData["Sliders"] = sliders;
        //ViewData["Sliders"] = "salam";

        HomeModel model = new()
        {
            Sliders = sliders,
            Services = services.Take(3).ToList()
        };



        return View(model);
    }



}
