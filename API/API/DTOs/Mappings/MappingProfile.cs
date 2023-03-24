using API.Models;
using AutoMapper;

namespace API.DTOs.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Cidade,CidadeDTO>().ReverseMap();
        }
    }
}
