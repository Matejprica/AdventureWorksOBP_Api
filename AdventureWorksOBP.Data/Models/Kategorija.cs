using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class Kategorija : BaseEntity
    {
        public Kategorija()
        {
            Potkategorije = new HashSet<Potkategorija>();
        }

        public string Naziv { get; set; }

        public virtual ICollection<Potkategorija> Potkategorije { get; set; }
    }
}
