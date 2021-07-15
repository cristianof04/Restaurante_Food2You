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
using System.Net.Mail;
using System.Net;

namespace lab.Controllers
{
    public class UserController : Controller
    {

        public readonly labContext _context;
        private readonly ILogger<RestauranteController> _logger;
        private readonly IHostEnvironment _he;

        public UserController(labContext context, ILogger<RestauranteController> logger, IHostEnvironment e)
        {
            _context = context;
            _logger = logger;
            _he = e;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Username,PassWord")] Utilizador utilizador)
        {
            Utilizador UserLogado = _context.Utilizador.Where(x => x.Username == utilizador.Username && x.PassWord == utilizador.PassWord).FirstOrDefault();

            if (UserLogado == null)
            {
                ViewBag.Message = "Os dados inseridos não estão corretos";
                return View();
            }

            Bloquear b = _context.Bloquear.SingleOrDefault(u => u.UsernameUtilizador == utilizador.Username);
            if (b != null)
            {
                string motivo = _context.Bloquear.SingleOrDefault(u => u.UsernameUtilizador == utilizador.Username).Motivo.ToString();
                ViewBag.Message = "O utilizador foi bloqueado";
                ViewBag.AlertMessage = "O utilizador foi bloqueado. Motivo: " +Convert.ToString(motivo) +"!";
                return View();
            }


            Cliente c = _context.Cliente.SingleOrDefault(u => u.Username == utilizador.Username);

            Restaurante r = _context.Restaurante.SingleOrDefault(u => u.Username == utilizador.Username);
            Administrador a = _context.Administrador.SingleOrDefault(u => u.Username == utilizador.Username);

            if (c != null)
            {
                if (UserLogado.ContaConfirmada == false)
                {
                    ViewBag.AlertMessage = "A conta ainda nao foi confirmada!";
                    return View("Login");
                }
                HttpContext.Session.SetString("Role", "Cliente");
            }
            else if (r != null)
            {
                if (r.QuemAprovou == null)
                {
                    ViewBag.AlertMessage = "O seu restaurante ainda nao foi aprovado!";
                    return View("Login");
                }

                HttpContext.Session.SetString("Role", "Restaurante");
            }
            else if (a != null)
            {
                HttpContext.Session.SetString("Role", "Administrador");
            }
            HttpContext.Session.SetString("Username", UserLogado.Username);
            return RedirectToAction("Menu", "Restaurante");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
        }

        public ActionResult Registar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registar([Bind("Nome,Email,Username,PassWord,ConfirmPassword,Foto")] Utilizador utilizador, IFormFile Foto)
        {
            Utilizador u = _context.Utilizador.SingleOrDefault(u => u.Username == utilizador.Username);

            if (u == null)
            {
                if (ModelState.IsValid)
                {
                    if (Path.GetExtension(Foto.FileName) == ".jpg" || Path.GetExtension(Foto.FileName) == ".jpeg" || Path.GetExtension(Foto.FileName) == ".png")
                    {
                        string destination = Path.Combine(
                            _he.ContentRootPath, "wwwroot/Imagens_Utilizador/", Path.GetFileName(Foto.FileName)
                            );

                        FileStream fs = new FileStream(destination, FileMode.Create);
                        Foto.CopyTo(fs);
                        fs.Close();
                    }

                    utilizador.ContaConfirmada = false;
                    utilizador.Foto = Foto.FileName;
                    _context.Add(utilizador);
                    await _context.SaveChangesAsync();

                    var cliente = new Cliente
                    {
                        Username = utilizador.Username,
                    };

                    _context.Add(cliente);
                    await _context.SaveChangesAsync();

                    SmtpClient client = new SmtpClient()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential()
                        {
                            // email
                            UserName = "food2youlab@gmail.com",
                            Password = "labgrupo2"
                        }
                    };


                    MailAddress FromEmail = new MailAddress("food2youlab@gmail.com", "Food2You");
                    MailAddress ToEmail = new MailAddress(Convert.ToString(utilizador.Email));
                    MailMessage Message = new MailMessage()
                    {
                        From = FromEmail,
                        Subject = "Confirmação da conta na plataforma Food2You",
                        Body = "https://" + HttpContext.Request.Host.ToString() + "/User/AtivarCliente/" + Base64Encode(utilizador.Username)
                    };
                    Message.To.Add(ToEmail);
                    try
                    {
                        client.Send(Message);
                    }
                    catch (Exception ex)
                    {

                    }

                    ViewBag.AlertMessage = "Falta confirmar a conta pelo email!(verifique o spam)";

                    return View("Login");
                }
            }
            else
            {
                ModelState.AddModelError("utilizador.Username", "Esse username já existe na base de dados!");
            }

            ViewBag.AlertMessage = null;
            return View(utilizador);
        }

        public ActionResult TipoRegisto()
        {
            return View();
        }

        public IActionResult Ajuda()
        {
            return View();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public IActionResult AtivarCliente(string UserName)
        {
            var act = _context.Utilizador.SingleOrDefault(u => u.Username == Base64Decode(UserName));
            if (act != null)
            {
                act.ContaConfirmada = true;
                _context.Update(act);
                _context.SaveChanges();
            }
            return RedirectToAction("Login", "User");
        }
    }
}