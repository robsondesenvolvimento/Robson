using System.Threading.Tasks;

namespace Robson.Repository.Repositories
{
    public interface IEscritaRepository<T>
    {
        Task<int> Incluir(T objeto);
    }
}
