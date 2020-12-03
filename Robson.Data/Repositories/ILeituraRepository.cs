using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Robson.Data.Repositories
{
    public interface ILeituraRepository<T>
    {
        Task<IEnumerable<T>> Todos();
        Task<T> PesquisarIdAsync(int id);
        Task<T> PesquisarAsync(Expression<Func<T, bool>> expression);
    }
}
