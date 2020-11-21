using System.Threading.Tasks;

namespace Robson.Repository.Repositories
{
    public interface ILeituraRepository<T>
    {
        Task<T> PesquisaId(int id);
    }
}
