using Robson.Domain.Contracts;
using Robson.Domain.Entities;

namespace Robson.Data.Repositories
{
    public interface ICarreiraRepository : IEscritaRepository<Carreira>, ILeituraRepository<Carreira>
    {
    }
}
