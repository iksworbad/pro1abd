using System;
using System.Collections.Generic;

namespace s15733.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Nrtel { get; set; }
        public string Address { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
