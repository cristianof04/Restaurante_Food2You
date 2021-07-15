using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using lab.Models;
using lab.Data;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;


namespace lab.Controllers
{
    public class ClienteController : Controller
    {

        public readonly labContext _context;
        private readonly ILogger<RestauranteController> _logger;
        private readonly IHostEnvironment _he;

        public ClienteController(labContext context, ILogger<RestauranteController> logger, IHostEnvironment e)
        {
            _context = context;
            _logger = logger;
            _he = e;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Favoritos()
        {
            return View();
        }

        public async Task<IActionResult> RestaurantesFavoritos()
        {
            if(HttpContext.Session.GetString("Role") != "Cliente")
            {
                return RedirectToAction("Login", "User");
            }
            string user = HttpContext.Session.GetString("Username");
            string[] UsernameRestaurantes = _context.RestaurantesFavoritos.Where(p => p.UsernameCliente == HttpContext.Session.GetString("Username")).Select(p => p.UsernameRestaurante).ToArray();
            ViewBag.Message = UsernameRestaurantes;

            var restaurante_Context = await _context.Restaurante.ToListAsync();
            return PartialView(restaurante_Context);
        }

        public async Task<IActionResult> AdicionarPratosFavoritos(int ID)
        {
            if (HttpContext.Session.GetString("Role") != "Cliente")
            {
                return RedirectToAction("Login", "User");
            }
            else if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            int[] idpratos = _context.PratosFavoritos.Where(p => p.UsernameCliente == HttpContext.Session.GetString("Username")).Select(p => p.IdPrato).ToArray();
                

            if (idpratos == null || !idpratos.Contains(ID))
            { 
                PratosFavoritos p = new PratosFavoritos();
                p.IdPrato = ID;
                p.UsernameCliente = HttpContext.Session.GetString("Username");

                _context.PratosFavoritos.Add(p);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Menu","Restaurante");
        }

        public async Task<IActionResult> EliminarPratosFavoritos(int ID)
        {
            if (HttpContext.Session.GetString("Role") != "Cliente")
            {
                return RedirectToAction("Login", "User");
            }
            else if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            int[] idpratos = _context.PratosFavoritos.Where(p => p.UsernameCliente == HttpContext.Session.GetString("Username")).Select(p => p.IdPrato).ToArray();


            if (idpratos.Contains(ID))
            {
                PratosFavoritos p = _context.PratosFavoritos.Where(p => p.UsernameCliente == HttpContext.Session.GetString("Username")).Where(p => p.IdPrato == ID).FirstOrDefault();

                _context.PratosFavoritos.Remove(p);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Menu", "Restaurante");

        }

        public async Task<IActionResult> PratosFavoritos()
        {
            if (HttpContext.Session.GetString("Role") != "Cliente")
            {
                return RedirectToAction("Login", "User");
            }

            string user = HttpContext.Session.GetString("Username");
            int[] idpratos = _context.PratosFavoritos.Where(p => p.UsernameCliente == HttpContext.Session.GetString("Username")).Select(p => p.IdPrato).ToArray();
            ViewBag.Message = idpratos;

            string[] UsernameRestaurantes = null;
            string[] NomeRestaurantes = null;

            int i = 0;
            for(i=0; i< idpratos.Length; i++)
            {
                UsernameRestaurantes = _context.Possuir.Where(p => p.IdPrato == idpratos[i]).Select(p => p.UsernameRestaurante).ToArray();
                NomeRestaurantes = _context.Restaurante.Where(p => p.Username == UsernameRestaurantes[i]).Select(p => p.Nome).ToArray();
            }

            ViewBag.NomeRestaurantes = NomeRestaurantes;

            var pratodia_Context = await _context.PratoDia.Where(u=>idpratos.Contains(u.Id)).ToListAsync();
            return PartialView(pratodia_Context);
        }

        public async Task<ActionResult> MostrarAvaliacoesPratos()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            string UserRestaurante = null;

            int IdPrato = Convert.ToInt32(ViewBag.IdPrato);

            UserRestaurante = _context.Possuir.Where(x => x.IdPrato == IdPrato).FirstOrDefault().UsernameRestaurante.ToString();

            string NomeRestaurante = null;

            NomeRestaurante = _context.Restaurante.Where(x => x.Username == UserRestaurante).FirstOrDefault().Nome.ToString();

            ViewBag.NomeRestaurante = NomeRestaurante;

            string NomePrato = _context.PratoDia.Where(x => x.Id == IdPrato).FirstOrDefault().Nome.ToString();

            ViewBag.NomePrato = NomePrato;

            string FotoPrato = _context.PratoDia.Where(x => x.Id == IdPrato).FirstOrDefault().Foto.ToString();

            ViewBag.FotoPrato = FotoPrato;

            string[] UsernameClientes = null;
            UsernameClientes = _context.AvaliarPratos.Where(x => x.IdPrato == IdPrato).Select(u=>u.UsernameCliente).ToArray<string>();

            string[] NomeClientes = null;
            NomeClientes = _context.Utilizador.Where(x => UsernameClientes.Contains(x.Username)).Select(u => u.Nome).ToArray<string>();

            ViewBag.NomeClientes = NomeClientes;

            var avaliacoes_context = await _context.AvaliarPratos.Where(x=>x.IdPrato == IdPrato).ToListAsync();
            return PartialView("MostrarAvaliacoesPratos", avaliacoes_context);
        }

        [HttpGet]
        public IActionResult AvaliarPratos(int Id)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.IdPrato = Id;

            string user = HttpContext.Session.GetString("Username");
            AvaliarPratos P = _context.AvaliarPratos.Where(x => x.UsernameCliente == user && x.IdPrato == Id).FirstOrDefault();

            if (P != null)
            {
                ViewBag.jaAvaliouP = "true";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AvaliarPratos([Bind("UsernameCliente,Avaliacao,Comentario")] AvaliarPratos AvaliarPratos)
        {
            string user = HttpContext.Session.GetString("Username");

            int Id = Convert.ToInt32(ViewBag.IdPrato);

            AvaliarPratos P = _context.AvaliarPratos.Where(x => x.UsernameCliente == user && x.IdPrato == Id).FirstOrDefault();

            if (P != null)
            {
                ViewBag.jaAvaliouP = "true";
                return RedirectToAction("AvaliarPratos");
            }

            if (ModelState.IsValid)
            {

                var avaliarPratos = new AvaliarPratos
                {
                    IdPrato = Id,
                    UsernameCliente = HttpContext.Session.GetString("Username"),
                    Avaliacao = AvaliarPratos.Avaliacao,
                    Comentario = Convert.ToString(AvaliarPratos.Comentario)
                };
                _context.Add(avaliarPratos);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction("AvaliarPratos");
        }

        public async Task<ActionResult> MostrarAvaliacoes(string UsernameRestaurante)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.UsernameRestaurante = UsernameRestaurante;

            string NomeRestaurante = null;

            NomeRestaurante = _context.Restaurante.Where(x => x.Username == UsernameRestaurante).FirstOrDefault().Nome.ToString();

            ViewBag.NomeRestaurante = NomeRestaurante;

            string FotoRestaurante = _context.Restaurante.Where(x => x.Username == UsernameRestaurante).FirstOrDefault().Foto.ToString();

            ViewBag.FotoRestaurante = FotoRestaurante;

            string[] UsernameClientes = null;
            UsernameClientes = _context.AvaliarRestaurates.Where(x => x.UsernameRestaurante == UsernameRestaurante).Select(u => u.UsernameCliente).ToArray<string>();

            string[] NomeClientes = null;
            NomeClientes = _context.Utilizador.Where(x => UsernameClientes.Contains(x.Username)).Select(u => u.Nome).ToArray<string>();

            ViewBag.NomeClientes = NomeClientes;

            string user = HttpContext.Session.GetString("Username");

            AvaliarRestaurates R = _context.AvaliarRestaurates.Where(x => x.UsernameCliente == user && x.UsernameRestaurante == UsernameRestaurante).FirstOrDefault();

            if (R != null)
            {
                ViewBag.jaAvaliouP = "true";
            }

            var avaliacoes_context = await _context.AvaliarRestaurates.Where(x => x.UsernameRestaurante == UsernameRestaurante).ToListAsync();
            return View(avaliacoes_context);
        }

        [HttpGet]
        public async Task<IActionResult> AvaliarRestaurantes(string UsernameRestaurante)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            var avaliacoes_context = await _context.AvaliarRestaurates.Where(x => x.UsernameRestaurante == UsernameRestaurante).ToListAsync();
            return View("MostrarAvaliacoes",avaliacoes_context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AvaliarRestaurantes(string UsernameRestaurante,[Bind("UsernameCliente,Avaliacao,Comentario")] AvaliarRestaurates AvaliarRestaurates)
        {
            string user = HttpContext.Session.GetString("Username");

            AvaliarRestaurates R = _context.AvaliarRestaurates.Where(x => x.UsernameCliente == user && x.UsernameRestaurante == UsernameRestaurante).FirstOrDefault();

            if (R != null)
            {
                ViewBag.jaAvaliouP = "true";
                return View("MostrarAvaliacoes", UsernameRestaurante);
            }

            if (ModelState.IsValid)
            {

                var avaliarRestaurantes = new AvaliarRestaurates
                {
                    UsernameRestaurante = UsernameRestaurante,
                    UsernameCliente = user,
                    Avaliacao = AvaliarRestaurates.Avaliacao,
                    Comentario = AvaliarRestaurates.Comentario
                };
                _context.Add(avaliarRestaurantes);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("MostrarAvaliacoes", new { UsernameRestaurante = UsernameRestaurante });
        }
    }
}
