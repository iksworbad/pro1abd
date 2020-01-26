using System;
using System.Collections.Generic;

namespace s15733.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public string Skladnik1 { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}
