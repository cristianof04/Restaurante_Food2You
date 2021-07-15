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

namespace lab.Controllers
{
    public class AdminController : Controller
    {
        public readonly labContext _context;
        private readonly ILogger<RestauranteController> _logger;
        private readonly IHostEnvironment _he;

        public AdminController(labContext context, ILogger<RestauranteController> logger, IHostEnvironment e)
        {
            _context = context;
            _logger = logger;
            _he = e;
        }

        public IActionResult Bloquear()
        {
            if(HttpContext.Session.GetString("Role") != "Administrador")
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Bloquear([Bind("UsernameUtilizador, Motivo")] Bloquear bloq)
        {
            Utilizador u = _context.Utilizador.SingleOrDefault(u => u.Username == bloq.UsernameUtilizador);
            Administrador a = _context.Administrador.SingleOrDefault(a => a.Username == bloq.UsernameUtilizador);
            Bloquear b = _context.Bloquear.SingleOrDefault(a => a.UsernameUtilizador == bloq.UsernameUtilizador);
            DateTime Data;
            Data = DateTime.Now;

            if (u != null && a == null && b == null)
            {
                if (ModelState.IsValid)
                {
                    bloq.DataBloqueio = Data;
                    bloq.UsernameAdministrador = HttpContext.Session.GetString("Username");

                    _context.Add(bloq);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Menu","Restaurante");
                }
            }

            return View();
        }
        public IActionResult Eleger()
        {
            if (HttpContext.Session.GetString("Role") != "Administrador")
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Eleger(string nome, string email, string password, string cPassword, string username)
        {
            Utilizador u = _context.Utilizador.SingleOrDefault(u => u.Username == username);
            DateTime Data;
            Data = DateTime.Now;

            if (u == null)
            {
                if (password == cPassword)
                {

                    if (ModelState.IsValid)
                    {
                        Utilizador user = new Utilizador();
                        user.Nome = nome;
                        user.Email = email;
                        user.PassWord = password;
                        user.Username = username;
                        user.Foto = "master.png";
                        user.ContaConfirmada = true;
                        _context.Add(user);
                        await _context.SaveChangesAsync();

                        Administrador admin = new Administrador();
                        admin.Username = username;
                        _context.Add(admin);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Menu", "Restaurante");
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> AprovarRestaurantes()
        {
            if (HttpContext.Session.GetString("Role") != "Administrador")
            {
                return RedirectToAction("Login", "User");
            }

            var restaurante_Context = await _context.Restaurante.ToListAsync();
            return View(restaurante_Context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AprovarRestaurantes(string RestauranteUsername)
        {
            if (HttpContext.Session.GetString("Role") != "Administrador")
            {
                return RedirectToAction("Login", "User");
            }
            else if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            Restaurante r = _context.Restaurante.Where(c => c.Username == RestauranteUsername).FirstOrDefault();

            r.QuemAprovou = Convert.ToString(HttpContext.Session.GetString("Username"));

            _context.Restaurante.Update(r);//atualizar base de dados
            await _context.SaveChangesAsync();

            return RedirectToAction("AprovarRestaurantes", "Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> NaoAprovar(string RestauranteUsername)
        {
            if (HttpContext.Session.GetString("Role") != "Administrador")
            {
                return RedirectToAction("Login", "User");
            }
            else if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            Restaurante r = _context.Restaurante.Where(c => c.Username == RestauranteUsername).FirstOrDefault();
            Utilizador c = _context.Utilizador.Where(c => c.Username == RestauranteUsername).FirstOrDefault();
          

            _context.Restaurante.Remove(r);//atualizar base de dados
            _context.SaveChanges();
            _context.Utilizador.Remove(c);//atualizar base de dados
            _context.SaveChanges();

            return RedirectToAction("AprovarRestaurantes", "Admin");
        }

    }
}
