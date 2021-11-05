using AdventureWorksOBP.Data.Bases;
using AdventureWorksOBP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorksOBP.Data.Specifications
{
    public class GetAllKupciBySpec : BaseSpecification<Kupac>
    {
        public GetAllKupciBySpec() : base(x=> x.Id != 0)
        {
            AddInclude(x => x.Grad);
            AddInclude(x => x.Racuni);
        }
    }
}
