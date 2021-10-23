﻿using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorksOBP.Data.Dtos.KupacDtos
{
    public class ReadKupacDto : Dto
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public GradDto Grad { get; set; }
        public ICollection<RacunDto> Racuni { get; set; }
    }
}
