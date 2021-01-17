using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Robson.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository<Pessoa>
    {
        private readonly DatabaseContext _databaseContext;

        public PessoaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> AlterarAsync(Pessoa pessoa)
        {
            try
            {
                _databaseContext.Pessoas.Update(pessoa);
                return await _databaseContext.SaveChangesAsync() == 1;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar pessoa.", e);
            }
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            try
            {
                var pessoa = await PesquisarIdAsync(id);
                _databaseContext.Pessoas.Remove(pessoa);
                return await _databaseContext.SaveChangesAsync() == 1;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir pessoa.", e);
            }
        }

        public async Task<bool> IncluirAsync(Pessoa pessoa)
        {
            try
            {
                await _databaseContext.Pessoas.AddAsync(pessoa);
                return await _databaseContext.SaveChangesAsync() == 1;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir pessoa.", e);
            }
        }

        public async Task<bool> IncluirListaAsync(IEnumerable<Pessoa> pessoa)
        {
            try
            {
                await _databaseContext.Pessoas.AddRangeAsync(pessoa);
                return await _databaseContext.SaveChangesAsync() == pessoa.ToList().Count;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir pessoa.", e);
            }
        }

        public async Task<Pessoa> PesquisarAsync(Expression<Func<Pessoa, bool>> expression)
        {
            try
            {
                return await _databaseContext.Pessoas.FirstOrDefaultAsync(expression);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar pessoa.", e);
            }

        }

        public async Task<Pessoa> PesquisarIdAsync(int id)
        {
            try
            {
                return await _databaseContext.Pessoas.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar id pessoa.", e);
            }
        }

        public async Task<IEnumerable<Pessoa>> Todos()
        {
            try
            {
                return await _databaseContext.Pessoas.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar pessoas.", e);
            }
        }
    }
}
