using AutoMapper;
using Robson.Domain.Entities;
using Robson.Services.Common.Models;

namespace Robson.Api.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>();
            CreateMap<Carreira, CarreiraViewModel>();
        }
    }
}
