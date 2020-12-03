using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Robson.Data.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public InstituicaoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AlterarAsync(Instituicao instituicao)
        {
            try
            {
                _databaseContext.Instituicoes.Update(instituicao);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar instituicao.", e);
            }
        }

        public async Task ExcluirAsync(int id)
        {
            try
            {
                var instituicao = await PesquisarIdAsync(id);
                _databaseContext.Instituicoes.Remove(instituicao);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir instituicao.", e);
            }
        }

        public async Task<int> IncluirAsync(Instituicao instituicao)
        {
            try
            {
                await _databaseContext.Instituicoes.AddAsync(instituicao);
                await _databaseContext.SaveChangesAsync();
                return instituicao.Id;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir instituicao.", e);
            }
        }

        public async Task<int> IncluirListaAsync(IEnumerable<Instituicao> instituicao)
        {
            try
            {
                await _databaseContext.Instituicoes.AddRangeAsync(instituicao);
                var alteracoes = await _databaseContext.SaveChangesAsync();
                return alteracoes;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir instituicoes.", e);
            }
        }

        public async Task<Instituicao> PesquisarAsync(Expression<Func<Instituicao, bool>> expression)
        {
            try
            {
                return await _databaseContext.Instituicoes.FirstOrDefaultAsync(expression);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar instituicoes.", e);
            }

        }

        public async Task<Instituicao> PesquisarIdAsync(int id)
        {
            try
            {
                return await _databaseContext.Instituicoes.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar id instituicao.", e);
            }
        }

        public async Task<IEnumerable<Instituicao>> Todos()
        {
            try
            {
                return await _databaseContext.Instituicoes.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar instituicao.", e);
            }
        }
    }
}
