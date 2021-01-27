using Robson.Domain.Contracts;

namespace Robson.Data.Repositories
{
    public interface ICarreiraRepository<T> : IEscritaRepository<T>, ILeituraRepository<T>
    {
    }
}
