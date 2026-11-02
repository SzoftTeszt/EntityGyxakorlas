using System;
using Termekek.Data;
using Termekek.Models;

namespace Termekek
{
    public class Program
    {
        private static void seed(TermekContext db)
        {
            //Console.WriteLine(AppContext.BaseDirectory);
            string[] sorok = File.ReadAllLines("termekek.csv");
            
            if (db.Termekek.Any()) return;
            
            foreach (var sor in sorok.Skip(1))
            {                
                db.Termekek.Add(new Termek(sor));
            }
            db.SaveChanges();

        }

        static void Main(string[] args)
        {
            using var context = new TermekContext();
            seed(context);
            Console.WriteLine("Termékek száma: " + context.Termekek.Count());

        }


    }
}

