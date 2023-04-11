using AutoMapper;
using EmpresaAPI.DTOs;
using EmpresaAPI.Entidades;

namespace EmpresaAPI.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SedeCreacionDTO, Sede>();
            CreateMap<SectorCreacionDTO, Sector>();
            CreateMap<RolCreacionDTO, Rol>();
            CreateMap<EmpleadoCreacionDTO, Empleado>();

        }
    }
}
