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
        
        public KupacController(IKupacService kupacService, IGradService gradService)
        {
            this.kupacService = kupacService;
        }

        [HttpGet]
        [Route("ReadKupac")]
        public async Task<ActionResult<ReadKupacDto>> ReadKupac(int id)
        {
            try
            {
                var result = await kupacService.ReadKupac(id);

                if (result == null)
                    return NotFound();

                var projected = new ReadKupacDto
                {
                    Id = result.Id,
                    Ime = result.Ime,
                    Prezime = result.Prezime,
                    Email = result.Email,
                    Telefon = result.Telefon,
                    Grad = new GradDto
                    {
                        Id = result.Grad.Id,
                        Naziv = result.Grad.Naziv
                    },
                    Racuni = result.Racuni.Select(r => new RacunDto
                    {
                        BrojRacuna = r.BrojRacuna,
                        DatumIzdavanja = r.DatumIzdavanja,
                        Komentar = r.Komentar
                    }).ToList()
            };

                return Ok(projected);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

                var projected = new ReadKupciDto
                {
                    Kupci = result.Select(k => new ReadKupacDto
                    {
                        Id = k.Id,
                        Ime = k.Ime,
                        Prezime = k.Prezime,
                        Email = k.Email,
                        Telefon = k.Telefon,
                        Grad = new GradDto
                        {
                            Id = k.Grad.Id,
                            Naziv = k.Grad.Naziv
                        },
                        Racuni = k.Racuni.Select(r => new RacunDto
                        {
                            BrojRacuna = r.BrojRacuna,
                            DatumIzdavanja = r.DatumIzdavanja,
                            Komentar = r.Komentar
                        }).ToList()
                    }).ToList()
                };

                return Ok(projected);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
