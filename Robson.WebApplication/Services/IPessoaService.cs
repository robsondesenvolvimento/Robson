using Robson.Services.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robson.WebApplication.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaViewModel>> GetPessoas();
    }
}
