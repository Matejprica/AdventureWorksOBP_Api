using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class Potkategorija : BaseEntity
    {
        public Potkategorija()
        {
            Proizvodi = new HashSet<Proizvod>();
        }

        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<Proizvod> Proizvodi { get; set; }
    }
}
