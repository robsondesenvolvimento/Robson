using AutoMapper;
using Robson.Domain.Entities;
using Robson.Services.Common.Models;

namespace Robson.Api.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PessoaViewModel, Pessoa>();
        }
    }
}
