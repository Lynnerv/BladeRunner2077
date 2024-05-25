using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BladeRunner2077.Integration.galletafortuna;
using BladeRunner2077.Integration.galletafortuna.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BladeRunner2077.Controllers
{
     
    public class GalletaController : Controller
    {
        private readonly ILogger<GalletaController> _logger;
        private readonly GalletaFortunaApiIntegration _apiIntegration;

        public GalletaController(ILogger<GalletaController> logger, GalletaFortunaApiIntegration apiIntegration)
        {
            _logger = logger;
            _apiIntegration = apiIntegration ?? throw new ArgumentNullException(nameof(apiIntegration));
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var galletaMensaje = await _apiIntegration.ObtenerGalletaDeLaFortunaAsync();
                var galleta = new Galleta { Mensaje = galletaMensaje };
                return View(galleta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Index action.");
                return View("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}