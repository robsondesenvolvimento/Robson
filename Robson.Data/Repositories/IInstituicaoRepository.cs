using Robson.Domain.Contracts;
using Robson.Domain.Entities;

namespace Robson.Data.Repositories
{
    public interface IInstituicaoRepository : ILeituraRepository<Instituicao>, IEscritaRepository<Instituicao>
    {
    }
}
