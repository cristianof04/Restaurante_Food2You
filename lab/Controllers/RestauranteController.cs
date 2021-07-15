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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace lab.Controllers
{
    public class RestauranteController : Controller
    {

        public readonly labContext _context;
        private readonly ILogger<RestauranteController> _logger;
        private readonly IHostEnvironment _he;

        public RestauranteController(labContext context, ILogger<RestauranteController> logger, IHostEnvironment e)
        {
            _context = context;
            _logger = logger;
            _he = e;
        }

        public IActionResult Menu()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }
            Utilizador UserLogado = _context.Utilizador.Where(x => x.Username == HttpContext.Session.GetString("Username")).FirstOrDefault();
            ViewBag.Foto = UserLogado.Foto;
            return View();
        }

        public IActionResult Registar()
        {
            if (HttpContext.Session.GetString("Username") != null)
            { 
                return RedirectToAction("Logout", "User");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registar(string email, string password, string cPassword, [Bind("Username,Nome,Morada,Telefone,Gps,Horario,DiaDescanso,TipoServico,Foto")] Restaurante restaurante, IFormFile Foto)
        {
            Utilizador u = _context.Utilizador.SingleOrDefault(u => u.Username == restaurante.Username);

            if (u == null)
            {
                restaurante.Foto = Foto.FileName;
                if (ModelState.IsValid)
                {
                    if (password == cPassword)
                    {
                        //restaurante.Username = HttpContext.Session.GetString("Username");

                        if (Path.GetExtension(Foto.FileName) == ".jpg" || Path.GetExtension(Foto.FileName) == ".jpeg" || Path.GetExtension(Foto.FileName) == ".png")
                        {
                            //restaurante.Foto = HttpContext.Session.GetString("Username");

                            string destination = Path.Combine(
                                _he.ContentRootPath, "wwwroot/Imagens_Restaurante/", Path.GetFileName(Foto.FileName)
                                );

                            FileStream fs = new FileStream(destination, FileMode.Create);
                            Foto.CopyTo(fs);
                            fs.Close();
                        }

                        var utilizador = new Utilizador
                        {
                            Username = restaurante.Username,
                            PassWord = password,
                            Nome = restaurante.Nome,
                            Foto = restaurante.Foto,
                            Email = email,
                            ContaConfirmada = true 
                        };
                        _context.Add(utilizador);
                        await _context.SaveChangesAsync();
                        
                        restaurante.Foto = Foto.FileName;
                        restaurante.QuemAprovou = null;
                        _context.Add(restaurante);
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction(nameof(Menu));
                }
            }
            else
            {
                ModelState.AddModelError("username", "Esse username já existe na base de dados!");
            }

            //return RedirectToAction("Registar","Restaurante");
            return View();
        }

        public async Task<ActionResult> MostrarRestaurantes()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (HttpContext.Session.GetString("Role") == "Cliente")
            {
                string[] UsernameRestaurantes = _context.RestaurantesFavoritos.Where(u => u.UsernameCliente == HttpContext.Session.GetString("Username")).Select(u => u.UsernameRestaurante).ToArray();

                ViewBag.fav = UsernameRestaurantes;
            }

            var restaurante_Context = await _context.Restaurante.ToListAsync();
            return PartialView("MostrarRestaurantes",restaurante_Context);
        }

        public async Task<IActionResult> AdicionarFavoritos(string Username)
        {
            if (HttpContext.Session.GetString("Role") != "Cliente")
            {
                return RedirectToAction("Login", "User");
            }
            else if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            string[] UsernameRestaurantes = _context.RestaurantesFavoritos.Where(p => p.UsernameCliente == HttpContext.Session.GetString("Username")).Select(p => p.UsernameRestaurante).ToArray();

            if (UsernameRestaurantes == null || !UsernameRestaurantes.Contains(Username))
            {
                RestaurantesFavoritos r = new RestaurantesFavoritos();
                r.UsernameRestaurante = Username;
                r.UsernameCliente = HttpContext.Session.GetString("Username");

                _context.RestaurantesFavoritos.Add(r);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Menu");
        }
        public async Task<IActionResult> EliminarFavoritos(string Username)
        {
            if (HttpContext.Session.GetString("Role") != "Cliente")
            {
                return RedirectToAction("Login", "User");
            }
            else if(HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            string[] UsernameRestaurantes = _context.RestaurantesFavoritos.Where(p => p.UsernameCliente == HttpContext.Session.GetString("Username")).Select(p => p.UsernameRestaurante).ToArray();

            if (UsernameRestaurantes.Contains(Username))
            {
                RestaurantesFavoritos r = _context.RestaurantesFavoritos.Where(p => p.UsernameCliente == HttpContext.Session.GetString("Username")).Where(p=>p.UsernameRestaurante == Username).FirstOrDefault();
                _context.RestaurantesFavoritos.Remove(r);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Menu");
        }

        public IActionResult AdicionarPrato()
        {
           

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarPrato(DateTime data,[Bind("Nome,Tipo,Preco,Descricao,Foto")] PratoDia PratoDia,IFormFile Foto)
        {
            if (ModelState.IsValid)
                {
                        if (Path.GetExtension(Foto.FileName) == ".jpg" || Path.GetExtension(Foto.FileName) == ".jpeg" || Path.GetExtension(Foto.FileName) == ".png")
                        {
                            string destination = Path.Combine(
                                _he.ContentRootPath, "wwwroot/Img/", Path.GetFileName(Foto.FileName)
                                );

                            FileStream fs = new FileStream(destination, FileMode.Create);
                            Foto.CopyTo(fs);
                            fs.Close();
                        }

                        PratoDia.Foto = Foto.FileName;
                        PratoDia.Id = Convert.ToInt32(_context.PratoDia.Count());
                        _context.Add(PratoDia);
                        await _context.SaveChangesAsync();
                        var possuir = new Possuir
                        {
                            IdPrato = PratoDia.Id,
                            UsernameRestaurante = HttpContext.Session.GetString("Username"),
                            DataPratoDia = data

                        };
                        _context.Add(possuir);
                        await _context.SaveChangesAsync();

                    
                    return RedirectToAction(nameof(Menu));
                }

            return View();
        }

        public async Task<IActionResult> MostrarPratos(string RestauranteUsername)
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            int[] Id = _context.Possuir.Where(u => u.UsernameRestaurante == RestauranteUsername && u.DataPratoDia >= DateTime.Today).Select(u => u.IdPrato).ToArray<int>(); 

            ViewBag.Id = Id;

            if (HttpContext.Session.GetString("Role") == "Cliente")
            {
                int[]  idPratos = _context.PratosFavoritos.Where(u => u.UsernameCliente == HttpContext.Session.GetString("Username")).Select(u=>u.IdPrato).ToArray();

                ViewBag.fav = idPratos;
            }

            DateTime[] Datas;
            Datas = _context.Possuir.Where(u =>Id.Contains(u.IdPrato)).Select(u => u.DataPratoDia).ToArray<DateTime>();

            var i = 0;
            List<string> list = new List<string>();

            //string format = "dd/mm/yyyy";
            foreach (DateTime date in Datas)
            {
                var day = date.Day;
                var month = date.Month;
                var year = date.Year;

                if (month < 10) month = Convert.ToInt32("0") + Convert.ToInt32(month);
                if (day < 10) day = Convert.ToInt32("0") + Convert.ToInt32(day);

                string data = Convert.ToString(day + "/" + month + "/" + year);

                list.Add(data);
                if (i < Id.Length)
                {
                    i++;
                }
            }

            string[] DataPratos = list.ToArray<string>();

            ViewBag.DataPratos = DataPratos;

            var restaurante_Context = await _context.PratoDia.Where(u=>Id.Contains(u.Id)).ToListAsync();
            return View(restaurante_Context);
        }

    }
}