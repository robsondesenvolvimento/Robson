using Robson.Domain.Entities;

namespace Robson.Repository.Repositories
{
    public interface ICarreiraRepository : IEscritaRepository<Carreira>, ILeituraRepository<Carreira>
    {
    }
}
