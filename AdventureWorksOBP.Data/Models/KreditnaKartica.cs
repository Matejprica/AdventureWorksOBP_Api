using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class KreditnaKartica : BaseEntity
    {
        public KreditnaKartica()
        {
            Racuni = new HashSet<Racun>();
        }

        public string Tip { get; set; }
        public string Broj { get; set; }
        public byte IstekMjesec { get; set; }
        public short IstekGodina { get; set; }

        public virtual ICollection<Racun> Racuni { get; set; }
    }
}
