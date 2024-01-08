using AutoMapper;
using Proiect_ASP.Models;
using Proiect_ASP1.Models;
using Proiect_ASP1.Models.DTOs;

namespace Proiect_ASP1.Helper.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Antrenor, AntrenorDTO>();

            CreateMap<Antrenor, AntrenorDTO>()
                .ForMember(dest=>dest.AntrenorId,
                opts => opts.MapFrom(source=>source.Id));
            CreateMap<Impresar, ImpresarResultDTO>().ReverseMap();
        }
        
    }
}
