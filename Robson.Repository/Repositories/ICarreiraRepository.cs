using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robson.Repository.Repositories
{
    public interface ICarreiraRepository : IEscritaRepository<Carreira>, ILeituraRepository<Carreira>
    {
    }
}
