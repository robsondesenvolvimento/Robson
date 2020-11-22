using System.Threading.Tasks;

namespace Robson.Repository.Repositories
{
    public interface IEscritaRepository<T>
    {
        Task<int> IncluirAsync(T objeto);
        Task AlterarAsync(T objeto);
        Task ExcluirAsync(int id);
    }
}
