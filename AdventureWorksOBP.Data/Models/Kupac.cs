using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class Kupac : BaseEntity
    {
        public Kupac()
        {
            Racuni = new HashSet<Racun>();
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int? GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Racun> Racuni { get; set; }
    }
}
