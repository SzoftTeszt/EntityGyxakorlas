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

            foreach (var sor in sorok)
            {
                db.Termekek.Add(new Termek(sor));
            }
            db.SaveChanges();

        }
        private static void Kiiratas(IEnumerable<Termek> termekek)
        {
            Console.WriteLine("");
            foreach (var termek in termekek)            
                Console.WriteLine(termek);
            
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
                        Kiiratas(context.Termekek);
                        break;

                    case "2":
                        Kiiratas(context.Termekek.OrderBy(t => t.Nev));
                        break;

                    case "3":
                        Kiiratas(context.Termekek.OrderByDescending(t => t.Ar));
                        break;

                    case "4":
                        Kiiratas(context.Termekek.Where(x => x.Kategoria == "Elektronika"));
                        break;

                    case "5":
                        Kiiratas(context.Termekek.Where(x => x.Ar > 100000));
                        break;

                    case "6":
                        Kiiratas(context.Termekek.Where(x => x.Keszlet < 10));
                        break;

                    case "7":
                        Kiiratas(context.Termekek.Where(x => x.Kategoria == "Elektronika" && x.Ar < 20000));
                        break;

                    case "8":
                        Console.Write("Keresett névrészlet: ");
                        string nevReszlet = Console.ReadLine() ?? "";
                        Kiiratas(context.Termekek.Where(x => x.Nev.Contains(nevReszlet)));
                        break;

                    case "9":
                        //Console.Write("Keresett névrészlet: ");
                        //nevReszlet = Console.ReadLine() ?? "";

                        //Kiiratas(context.Termekek.Where(x=>x.Nev.Contains(nevReszlet)));

                        //Console.WriteLine();

                        //Console.WriteLine(context.Termekek.FirstOrDefault(x => x.Nev.Contains(nevReszlet)));

                        Console.WriteLine(context.Termekek.FirstOrDefault(x => x.Nev == "Toll"));

                        //Console.WriteLine("ID");
                        //Console.WriteLine(context.Termekek.Find(1)); // Id szerinti keresés

                        break;

                    case "10":
                        bool van = context.Termekek.Any(x => x.Keszlet == 0);
                        Console.WriteLine(van ? "Van készlethiányos termék" : "Nincs készlethiányos termék");
                        break;

                    case "11":

                        Console.WriteLine("Összes: " + context.Termekek.Count() + " db");

                        Console.WriteLine("Elektronika: " + context.Termekek.Count(t => t.Kategoria == "Elektronika") + " db");

                        Console.WriteLine("Elektronika: " + context.Termekek.Where(t => t.Kategoria == "Elektronika").Count() + " db");

                        break;
                    case "12":

                        Console.WriteLine($"Átlag: {context.Termekek.Average(x => x.Ar):0}");
                        Console.WriteLine("Min: "+context.Termekek.Min(x=>x.Ar));
                        Console.WriteLine("Max: "+context.Termekek.Max(x=>x.Ar));

                        break;

                    case "13":
                        var termekekAr = context.Termekek.Select(x => new { x.Nev, x.Ar, x.Keszlet }).OrderBy(t=>t.Keszlet)   ;
                        foreach (var termek in termekekAr)
                        {
                            Console.WriteLine(termek);
                            //Console.WriteLine($"{termek.Nev} --- {termek.Ar}");
                        }




                        break;

                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine(" 0 - Kilépés");
                Console.WriteLine(" 1 - Összes termék listázása");
                Console.WriteLine(" 2 - Összes termék névsorban");
                Console.WriteLine(" 3 - Összes termék csökkenő ár");
                Console.WriteLine(" 4 - Elektronikai termékek");
                Console.WriteLine(" 5 - 100eFt-nál drágább");
                Console.WriteLine(" 6 - Lassan elfogy");
                Console.WriteLine(" 7 - Olcsó elektronikai cikk");
                Console.WriteLine(" 8 - Névrészlet keresés");
                Console.WriteLine(" 9 - Laptop(Toll) keresése");
                Console.WriteLine(" 10 - Készlethiány");
                Console.WriteLine(" 11 - Elektronika db");
                Console.WriteLine(" 12 - Átlag/Min/Max");
                Console.WriteLine(" 13 - Név és Ár");
                Console.WriteLine();

                valasz = Console.ReadLine();
                Console.Clear();
               

            } while (true);

        }

       

    }
}

