using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BladeRunner2077.Data;
using BladeRunner2077.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BladeRunner2077.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _context;

        public AccountController(ILogger<AccountController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Acción para listar todas las cuentas
        public IActionResult Index()
        {
            var accounts = _context.Accounts.ToList();
            return View(accounts);
        }

        // Acción GET para mostrar el formulario de creación de cuenta
        public IActionResult Create()
        {
            return View();
        }

        // Acción POST para manejar el envío del formulario de creación de cuenta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerName,AccountNumber,AccountType,InitialDeposit")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}