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

            string valasz = string.Empty;

            do
            {
                switch (valasz)
                {
                    case "0":
                        return;
                        
                    case "1":
                        foreach (var termek in context.Termekek)
                        {
                            Console.WriteLine(termek);
                        }
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("0 - Kilépés");
                Console.WriteLine("1 - Összes termék listázása");

                valasz = Console.ReadLine();
                Console.Clear();
               

            } while (true);

        }

       

    }
}

