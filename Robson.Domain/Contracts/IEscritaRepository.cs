using System.Collections.Generic;
using System.Threading.Tasks;

namespace Robson.Domain.Contracts
{
    public interface IEscritaRepository<T>
    {
        Task<bool> IncluirAsync(T objeto);
        Task<bool> IncluirListaAsync(IEnumerable<T> objeto);
        Task<bool> AlterarAsync(T objeto);
        Task<bool> ExcluirAsync(int id);
    }
}
