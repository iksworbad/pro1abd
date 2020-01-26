using System;
using System.Collections.Generic;

namespace s15733.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }
        public string Pizza1 { get; set; }
        public int SkladnikId { get; set; }

        public Skladnik Skladnik { get; set; }
        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
