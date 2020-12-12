using Robson.Domain.Entities;

namespace Robson.Data.Repositories
{
    public interface ICursoRepository : ILeituraRepository<Curso>, IEscritaRepository<Curso>
    {
    }
}
