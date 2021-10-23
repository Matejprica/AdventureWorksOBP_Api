using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorksOBP.Data.Dtos.KupacDtos
{
    public class ReadKupciDto : Dto
    {
        public IEnumerable<ReadKupacDto> Kupci { get; set; } = new List<ReadKupacDto>();
    }
}
