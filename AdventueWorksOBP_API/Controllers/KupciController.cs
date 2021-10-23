using AdventureWorksOBP.Data.Dtos;
using AdventureWorksOBP.Data.Dtos.KupacDtos;
using AdventureWorksOBP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventueWorksOBP_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KupacController : ControllerBase
    {
        private readonly IKupacService kupacService;
        private readonly IGradService gradService;

        public KupacController(IKupacService kupacService, IGradService gradService)
        {
            this.kupacService = kupacService;
            this.gradService = gradService;
        }

        [HttpGet]
        [Route("ReadKupac")]
        public async Task<ActionResult<ReadKupacDto>> ReadKupac(int id)
        {
            var result = await kupacService.ReadKupac(id);

            if (result == null)
                return NotFound();

            var grad = await gradService.ReadGrad((int)result.GradId);

            return new ReadKupacDto
            {
                Id = result.Id,
                Ime = result.Ime,
                Prezime = result.Prezime,
                Email = result.Email,
                Telefon = result.Telefon,
                Grad = new GradDto { 
                    Id = grad.Id,
                    Naziv = grad.Naziv
                },
                Racuni = null
            };
        }

        [HttpGet]
        [Route("ReadKupci")]
        public async Task<ActionResult<ReadKupciDto>> ReadKupci(int skip, int count)
        {
            try
            {
                var result = await kupacService.ReadAllKupci(skip, count);

                if (result == null)
                    return NotFound();

                return new ReadKupciDto
                {
                    Kupci = result.Select(k => new ReadKupacDto
                    {
                        Id = k.Id,
                        Ime = k.Ime,
                        Prezime = k.Prezime,
                        Email = k.Email,
                        Telefon = k.Telefon,
                        Grad = null,
                        Racuni = null
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
