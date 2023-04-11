using AutoMapper;
using EmpresaAPI.DTOs;
using EmpresaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.Controllers
{
    [ApiController]
    [Route("api/sectores")]
    public class SectoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SectoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(SectorCreacionDTO sectorCreacion)
        {
            var sector = mapper.Map<Sector>(sectorCreacion);
            context.Add(sector);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> Get()
        {
            return await context.Sectores.ToListAsync();
        }
        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Sector>>> Get(string nombre)
        {
            // forma 1. Trae los datos de exactamente el nombre que se da. Si por ej tenes Arquitectura yalgomás y buscar solo Arquitectura, devolvera una lista vacia
            return await context.Sectores.Where(s => s.Nombre == nombre).ToListAsync();
        }
        [HttpGet("nombre/v2")]
        public async Task<ActionResult<IEnumerable<Sector>>> GetV2(string nombre)
        {
            // forma 2. trae datos de todas las filas que contengan ese nombre
            return await context.Sectores.Where(s => s.Nombre.Contains(nombre)).ToListAsync();
        }

        [HttpPut("{id:int}")]      //actualizar sectores.  //Esto es un modelo desconectado. Aqui creo OTRA instancia del objeto Sector
        public async Task<ActionResult> Put(int id, SectorCreacionDTO sectorCreacionDTO) //se puede usar tanto SectorCreacionDTO como alguno otro que hayamos creado para actualizar
        {
            var sector = mapper.Map<Sector>(sectorCreacionDTO);
            sector.Id = id;
            context.Update(sector);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id:int}")]      //Forma anterior de borrar un registro. Esta la nueva de .Net 7, en la que se hace solo 1 consulta: se busca el id y en el momento se borra.
        //En esta forma, primero se consulta el id, y luego otra consulta para removerlo
        // Esta forma es usada en caso de que yo necesito tomar/procesar algo de ese registro ANTES de borrarlo. De la forma nueva no podria porque al encontrarlo lo borra al momento
        public async Task<ActionResult> Delete(int id)               
        {
            var sector = await context.Sectores.FirstOrDefaultAsync(s => s.Id == id);
            if (sector is null)
            {
                return NotFound();
            }
            context.Remove(sector);
            await context.SaveChangesAsync();      //Para q el registro sea efectivam removido de la DB
            return NoContent();
        }
    }
}   
        
