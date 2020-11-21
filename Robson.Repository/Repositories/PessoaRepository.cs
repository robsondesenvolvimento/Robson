using Robson.Domain.Entities;
using Robson.Repository.Context;
using System;
using System.Threading.Tasks;

namespace Robson.Repository.Repositories
{
    public class PessoaRepository : IPessoaRepository<Pessoa>
    {
        private readonly DatabaseContext _databaseContext;

        public PessoaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<int> Incluir(Pessoa pessoa)
        {
            try
            {
                await _databaseContext.AddAsync(pessoa);
                await _databaseContext.SaveChangesAsync();
                return pessoa.Id;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir pessoa.", e);
            }
        }

        public async Task<Pessoa> PesquisaId(int id)
        {
            try
            {
                return await _databaseContext.FindAsync<Pessoa>(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar pessoa.", e);
            }
        }
    }
}
