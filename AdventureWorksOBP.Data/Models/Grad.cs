using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class Grad : BaseEntity
    {
        public Grad()
        {
            Kupci = new HashSet<Kupac>();
        }

        public string Naziv { get; set; }
        public int? DrzavaId { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Kupac> Kupci { get; set; }
    }
}
