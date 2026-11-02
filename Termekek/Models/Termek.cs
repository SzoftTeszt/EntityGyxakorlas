using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termekek.Models
{
    public class Termek
    {
        public Termek()
        {
        }

        public Termek(string sor)
        {
            var mezok = sor.Split(';');
            Nev = mezok[0];
            Kategoria = mezok[1];
            Ar = int.Parse(mezok[2]);
            Keszlet = int.Parse(mezok[3]);
        }

        public override string? ToString()
        {
            return $" {Nev,-20} - {Kategoria,-13} /{Ar,8} Ft/ {Keszlet} db";
        }

        public int Id { get; set; }
        public string Nev { get; set; } = string.Empty;
        public string Kategoria { get; set; } = string.Empty;
        public int Ar { get; set; }
        public int Keszlet { get; set; }
       
        
       
    }
}
