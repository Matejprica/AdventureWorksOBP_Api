using AdventureWorksOBP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksOBP.Services.Interfaces
{
    public interface IGradService 
    {
        //Task CreateGrad(Grad grad);
        Task<Grad> ReadGrad(int id);
        Task<IEnumerable<Grad>> ReadAllGradovi(int count);
        //Task UpdateKupac(Grad grad);
        //Task DeleteKupac(Grad grad);
    }
}
