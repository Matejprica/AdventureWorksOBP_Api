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
    public class GradService : IGradService
    {
        private readonly IRepository<Grad> gradRepository;

        public GradService(IRepository<Grad> gradRepository)
        {
            this.gradRepository = gradRepository;
        }

        public async Task<IEnumerable<Grad>> ReadAllGradovi(int skip, int count)
            => await gradRepository.ReadAll(skip, count).ToListAsync();

        public async Task<Grad> ReadGrad(int id)
            => await gradRepository.Read(g => g.Id == id).FirstOrDefaultAsync();
    }
}
