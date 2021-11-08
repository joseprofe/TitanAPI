using AutoMapper;
using Titan.Core.DTO;
using Titan.DAL.Entities;

namespace Titan.Core.AutomapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>(); 
        }
    }
}
