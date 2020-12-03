using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robson.Data.Repositories
{
    public interface ICursoRepository : ILeituraRepository<Curso>, IEscritaRepository<Curso>
    {
    }
}
