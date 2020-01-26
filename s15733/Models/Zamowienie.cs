using System;
using System.Collections.Generic;

namespace s15733.Models
{
    public partial class Zamowienie
    {
        public int Id { get; set; }
        public int KlientId { get; set; }
        public int PizzaId { get; set; }
        public string Status { get; set; }

        public Klient Klient { get; set; }
        public Pizza Pizza { get; set; }
    }
}
