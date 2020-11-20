using System;
using System.Collections.Generic;
using System.Text;

namespace Robson.Repository.Repositories
{
    public interface IEscritaRepository<T>
    {
        void Incluir(T objeto);
    }
}
