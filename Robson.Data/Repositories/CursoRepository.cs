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
    public class CursoRepository : ICursoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CursoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> AlterarAsync(Curso curso)
        {
            try
            {
                _databaseContext.Cursos.Update(curso);
                return await _databaseContext.SaveChangesAsync() == 1;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar curso.", e);
            }
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            try
            {
                var curso = await PesquisarIdAsync(id);
                _databaseContext.Cursos.Remove(curso);
                return await _databaseContext.SaveChangesAsync() == 1;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir curso.", e);
            }
        }

        public async Task<bool> IncluirAsync(Curso curso)
        {
            try
            {
                await _databaseContext.Cursos.AddAsync(curso);
                return await _databaseContext.SaveChangesAsync() == 1;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir curso.", e);
            }
        }

        public async Task<bool> IncluirListaAsync(IEnumerable<Curso> cursos)
        {
            try
            {
                await _databaseContext.Cursos.AddRangeAsync(cursos);
                return await _databaseContext.SaveChangesAsync() == cursos.ToList().Count;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir cursos.", e);
            }
        }

        public async Task<Curso> PesquisarAsync(Expression<Func<Curso, bool>> expression)
        {
            try
            {
                return await _databaseContext.Cursos.FirstOrDefaultAsync(expression);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar cursos.", e);
            }
        }

        public async Task<Curso> PesquisarIdAsync(int id)
        {
            try
            {
                return await _databaseContext.Cursos.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar id curso.", e);
            }
        }

        public async Task<IEnumerable<Curso>> Todos()
        {
            try
            {
                return await _databaseContext.Cursos.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar curso.", e);
            }
        }
    }
}
