using AutoMapper;
using HealthCare_API.Content.Cliente.DTO;
using HealthCare_API.Content.Cliente.Entity;

namespace HealthCare_API.Mappers;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<ClienteDTO, Cliente>();
        CreateMap<Cliente, ClienteDTO>();
        CreateMap<ClienteCreateDTO, Cliente>();
    }
}
 