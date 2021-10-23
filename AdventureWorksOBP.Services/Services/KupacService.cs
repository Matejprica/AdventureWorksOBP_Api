using AdventureWorksOBP.Data.Interfaces;
using AdventureWorksOBP.Data.Models;
using AdventureWorksOBP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksOBP.Services.Services
{
    public class KupacService : IKupacService
    {
        private readonly IRepository<Kupac> kupacRepository;

        public KupacService(IRepository<Kupac> kupacRepository)
        {
            this.kupacRepository = kupacRepository;
        }

        public async Task<IEnumerable<Kupac>> ReadAllKupci(int count)
        => await kupacRepository
            .ReadAll(count)
            .ToListAsync();


        public async Task<Kupac> ReadKupac(int id)
        => await kupacRepository
            .Read(k => k.Id == id)
            .FirstOrDefaultAsync();
    }
}
