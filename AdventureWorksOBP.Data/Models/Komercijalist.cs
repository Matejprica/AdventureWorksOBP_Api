using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class Komercijalist : BaseEntity
    {
        public Komercijalist()
        {
            Racuni = new HashSet<Racun>();
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool? StalniZaposlenik { get; set; }

        public virtual ICollection<Racun> Racuni { get; set; }
    }
}
