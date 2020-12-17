using Robson.Domain.Contracts;
using Robson.Domain.Entities;

namespace Robson.Data.Repositories
{
    public interface IFormacaoRepository : ILeituraRepository<Formacao>, IEscritaRepository<Formacao>
    {
    }
}
