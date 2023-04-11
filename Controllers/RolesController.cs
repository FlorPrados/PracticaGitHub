using AutoMapper;
using EmpresaAPI.DTOs;
using EmpresaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RolesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(RolCreacionDTO rolCreacion)
        {
            var rol = mapper.Map<Rol>(rolCreacion);
            //if (rol.Empleados is not null)
            //{
            //    foreach (var empleado in rol.Empleados)
            //    {
            //        context.Entry(rol).State = EntityState.Unchanged;       //Unchaged representa que el objeto esta registrado en la BD y no se le ha hicho ningun cambio
            //    }
            //}           //Para que cuanbdo yo le pase un sector, no tenga que crearlos, sino q utilice los ya existentes
            context.Add(rol);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
