using System.Collections.Generic;
using System.Threading.Tasks;

namespace Robson.Domain.Contracts
{
    public interface IEscritaRepository<T>
    {
        Task<int> IncluirAsync(T objeto);
        Task<int> IncluirListaAsync(IEnumerable<T> objeto);
        Task AlterarAsync(T objeto);
        Task ExcluirAsync(int id);
    }
}
