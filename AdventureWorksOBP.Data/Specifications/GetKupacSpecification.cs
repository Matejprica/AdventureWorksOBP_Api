using AdventureWorksOBP.Data.Bases;
using AdventureWorksOBP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorksOBP.Data.Specifications
{
    public class GetKupacSpecification : BaseSpecification<Kupac>
    {
        public GetKupacSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Grad);
            AddInclude(x => x.Racuni);
        }
    }
}
