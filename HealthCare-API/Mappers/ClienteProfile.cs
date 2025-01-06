using AutoMapper;
using HealthCare_API.Content.Cliente.DTO;
using HealthCare_API.Content.Cliente.Entity;

namespace HealthCare_API.Mappers;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<ClienteDTO, Cliente>()
            .ForMember(dest => dest.ProblemasDeSaude, opt => opt.MapFrom(src => src.ProblemasDeSaude)); 
        CreateMap<Cliente, ClienteDTO>();
        CreateMap<ClienteCreateDTO, Cliente>();
    }
}
 