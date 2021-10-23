using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class Racun : BaseEntity
    {
        public Racun()
        {
            Stavke = new HashSet<Stavka>();
        }

        public DateTime DatumIzdavanja { get; set; }
        public string BrojRacuna { get; set; }
        public int KupacId { get; set; }
        public int? KomercijalistId { get; set; }
        public int? KreditnaKarticaId { get; set; }
        public string Komentar { get; set; }

        public virtual Komercijalist Komercijalist { get; set; }
        public virtual KreditnaKartica KreditnaKartica { get; set; }
        public virtual Kupac Kupac { get; set; }
        public virtual ICollection<Stavka> Stavke { get; set; }
    }
}
