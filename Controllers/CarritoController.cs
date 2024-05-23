using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BladeRunner2077.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BladeRunner2077.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ILogger<CarritoController> _logger;

        public CarritoController(ILogger<CarritoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var producto  = Util.SessionExtensions.Get<Producto>(HttpContext.Session,"MiUltimoProducto");
            return View("UltimoProducto",producto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}