using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace lab.Controllers
{
    public class PratosController : Controller
    {
        public readonly labContext _context;
        private readonly ILogger<PratosController> _logger;
        private readonly IHostEnvironment _he;

        public PratosController(labContext context, ILogger<PratosController> logger, IHostEnvironment e)
        {
            _context = context;
            _logger = logger;
            _he = e;
        }

        public async Task<IActionResult> Filtrar()
        {
            if(HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Filtrar(string tipo)
        {
            ViewBag.Tipo = tipo;

            int[] IdPratos = _context.PratoDia.Where(u => u.Tipo == Convert.ToString(tipo)).Select(u => u.Id).ToArray<int>();

            string[] UsernameRestaurantes = _context.Possuir.Where(u => IdPratos.Contains(u.IdPrato)).Select(u => u.UsernameRestaurante).ToArray<string>();

            string[] NomeRestaurantes = _context.Restaurante.Where(u => UsernameRestaurantes.Contains(u.Username)).Select(u => u.Nome).ToArray<string>();

            ViewBag.NomeRestaurantes = NomeRestaurantes;

            var PratoDoTipo = await _context.PratoDia.Where(u => u.Tipo == Convert.ToString(tipo)).ToListAsync();
            return View(PratoDoTipo);
        }

        public async Task<IActionResult> MostrarPratosDoTipo()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            string tipo = ViewBag.Tipo;

            int[] IdPratos = _context.PratoDia.Where(u => u.Tipo == Convert.ToString(tipo)).Select(u => u.Id).ToArray<int>();

            string[] UsernameRestaurantes = _context.Possuir.Where(u => IdPratos.Contains(u.IdPrato)).Select(u => u.UsernameRestaurante).ToArray<string>();

            string[] NomeRestaurantes = _context.Restaurante.Where(u => UsernameRestaurantes.Contains(u.Username)).Select(u => u.Nome).ToArray<string>();

            ViewBag.NomeRestaurantes = NomeRestaurantes;

            var PratoDoTipo = await _context.PratoDia.Where(u => u.Tipo == Convert.ToString(tipo)).ToListAsync();
            return PartialView(PratoDoTipo);
        }
    }
}
