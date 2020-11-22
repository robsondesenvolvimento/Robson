using Microsoft.EntityFrameworkCore;
using Robson.Domain.Entities;
using Robson.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task AlterarAsync(Pessoa pessoa)
        {
            try
            {
                _databaseContext.Pessoas.Update(pessoa);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar pessoa.", e);
            }
        }

        public async Task ExcluirAsync(int id)
        {
            try
            {
                var pessoa = await PesquisarIdAsync(id);
                _databaseContext.Pessoas.Remove(pessoa);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir pessoa.", e);
            }
        }

        public async Task<int> IncluirAsync(Pessoa pessoa)
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
