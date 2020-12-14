using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Robson.Data.Repositories
{
    public class FormacaoRepository : IFormacaoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public FormacaoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AlterarAsync(Formacao formacao)
        {
            try
            {
                _databaseContext.Formacoes.Update(formacao);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar formacao.", e);
            }
        }

        public async Task ExcluirAsync(int id)
        {
            try
            {
                var formacao = await PesquisarIdAsync(id);
                _databaseContext.Formacoes.Remove(formacao);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir formção.", e);
            }
        }

        public async Task<int> IncluirAsync(Formacao formacao)
        {
            try
            {
                await _databaseContext.Formacoes.AddAsync(formacao);
                await _databaseContext.SaveChangesAsync();
                return formacao.Id;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir formação.", e);
            }
        }

        public async Task<int> IncluirListaAsync(IEnumerable<Formacao> formacoes)
        {
            try
            {
                await _databaseContext.Formacoes.AddRangeAsync(formacoes);
                var alteracoes = await _databaseContext.SaveChangesAsync();
                return alteracoes;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir formações.", e);
            }
        }

        public async Task<Formacao> PesquisarAsync(Expression<Func<Formacao, bool>> expression)
        {
            try
            {
                return await _databaseContext.Formacoes.FirstOrDefaultAsync(expression);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar formações.", e);
            }
        }

        public async Task<Formacao> PesquisarIdAsync(int id)
        {
            try
            {
                return await _databaseContext.Formacoes.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar id formação.", e);
            }
        }

        public async Task<IEnumerable<Formacao>> Todos()
        {
            try
            {
                return await _databaseContext.Formacoes.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar formações.", e);
            }
        }
    }
}
