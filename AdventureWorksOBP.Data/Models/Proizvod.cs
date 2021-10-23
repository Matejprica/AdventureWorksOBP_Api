using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class Proizvod : BaseEntity
    {
        public Proizvod()
        {
            Stavke = new HashSet<Stavka>();
        }

        public string Naziv { get; set; }
        public string BrojProizvoda { get; set; }
        public string Boja { get; set; }
        public short MinimalnaKolicinaNaSkladistu { get; set; }
        public decimal CijenaBezPdv { get; set; }
        public int? PotkategorijaId { get; set; }

        public virtual Potkategorija Potkategorija { get; set; }
        public virtual ICollection<Stavka> Stavke { get; set; }
    }
}
