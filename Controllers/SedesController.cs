using AutoMapper;
using EmpresaAPI.DTOs;
using EmpresaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaAPI.Controllers
{
    [ApiController]
    [Route("api/sedes")]
    public class SedesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SedesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post(SedeCreacionDTO sedeCreacion)
        {
            var sede = mapper.Map<Sede>(sedeCreacion);
            context.Add(sede);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("ColocarVarios")]
        public async Task<ActionResult> Post(SedeCreacionDTO[] sedesCreacionDTO)
        {
            var sedes = mapper.Map<Sede[]>(sedesCreacionDTO);
            context.AddRange(sedes);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
