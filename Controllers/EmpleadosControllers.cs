using AutoMapper;
using EmpresaAPI.DTOs;
using EmpresaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.Controllers
{
    [ApiController]
    [Route("api/roles/{rolId:int}/empleados")]
    public class EmpleadosControllers : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EmpleadosControllers(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(int rolId, EmpleadoCreacionDTO empleadoCreacion)
        {
            var empleado = mapper.Map<Empleado>(empleadoCreacion);
            empleado.RolId = rolId;                        
            context.Add(empleado);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
