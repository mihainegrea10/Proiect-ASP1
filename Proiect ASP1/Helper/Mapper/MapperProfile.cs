using AutoMapper;
using Proiect_ASP.Models;
using Proiect_ASP1.Models.DTOs;

namespace Proiect_ASP1.Helper.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Antrenor, AntrenorDTO>();

            
        }  
    }
}
