using APIFARMACIA.Dtos;
using AutoMapper;
using Core.Entities;

namespace APIFARMACIA.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Ciudad, CiudadDto>().ReverseMap();
        }
    }
}