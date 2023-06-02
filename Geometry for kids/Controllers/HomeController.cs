using Geometry_for_kids.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Geometry_for_kids.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CalculateArea(string shape, Dimensions dimensions)
        {
            double area = 0;

            switch (shape)
            {
                case "Rectangle":
                    area = dimensions.Length * dimensions.Width;
                    break;
                case "Triangle":
                    area = 0.5 * dimensions.Base * dimensions.Height;
                    break;
                case "Circle":
                    area = Math.PI * Math.Pow(dimensions.Radius, 2);
                    break;
                case "Trapezoid":
                    area = 0.5 * (dimensions.Base1 + dimensions.Base2) * dimensions.Height;
                    break;
                case "Ellipse":
                    area = Math.PI * dimensions.MajorAxis * dimensions.MinorAxis;
                    break;
                default:
                    break;
            }

            ViewBag.Result = $"The surface area of the {shape.ToLower()} is: {area}";

            return PartialView("_Result");
        }
    }

    public class Dimensions
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Base { get; set; }
        public double Height { get; set; }
        public double Radius { get; set; }
        public double Base1 { get; set; }
        public double Base2 { get; set; }
        public double MajorAxis { get; set; }
        public double MinorAxis { get; set; }
    }

}
