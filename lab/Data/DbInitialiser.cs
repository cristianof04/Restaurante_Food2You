using lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Data
{
    public class DbInitialiser
    {
        public static void Initialize(labContext context)
        {
            context.Database.EnsureCreated();
            if (context.Utilizador.Any() && context.Administrador.Any())
            {
                return;
            }
            var utilizadores = new Utilizador[]
            {
                new Utilizador{Nome="Master",Email="master@gmail.com", Username="master", PassWord="labgrupo2", Foto="master.png",ContaConfirmada = true},

            };
            foreach (Utilizador u in utilizadores)
                {
                    context.Utilizador.Add(u);
                }
            context.SaveChanges();

            var admin = new Administrador[]
{
                new Administrador{Username="master"},

};
            foreach (Administrador u in admin)
            {
                context.Administrador.Add(u);
            }
            context.SaveChanges();
        }
    }
}
