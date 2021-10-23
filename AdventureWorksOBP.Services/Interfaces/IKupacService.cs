using AdventureWorksOBP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksOBP.Services.Interfaces
{
    public interface IKupacService
    {
        //Task CreateKupac(Kupac kupac);
        Task<Kupac> ReadKupac(int id);
        Task<IEnumerable<Kupac>> ReadAllKupci(int skip, int count);
        //Task UpdateKupac(Kupac kupac);
        //Task DeleteKupac(Kupac kupac);
    }
}
