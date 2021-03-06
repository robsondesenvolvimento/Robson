﻿using Robson.Domain.Contracts;

namespace Robson.Data.Repositories
{
    public interface IPessoaRepository<T> : IEscritaRepository<T>, ILeituraRepository<T>
    {
    }
}
