using Robson.Services.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Robson.WebApplication.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaViewModel>> GetPessoas();
        Task<PessoaViewModel> GetPessoa(int id);
    }
}
