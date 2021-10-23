using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class Drzava : BaseEntity
    {
        public Drzava()
        {
            Gradovi = new HashSet<Grad>();
        }

        public string Naziv { get; set; }

        public virtual ICollection<Grad> Gradovi { get; set; }
    }
}
