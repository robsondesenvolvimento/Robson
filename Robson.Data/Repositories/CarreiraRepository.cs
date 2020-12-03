using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Robson.Data.Repositories
{
    public class CarreiraRepository : ICarreiraRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CarreiraRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AlterarAsync(Carreira carreira)
        {
            try
            {
                _databaseContext.Carreiras.Update(carreira);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar carreira.", e);
            }
        }

        public async Task ExcluirAsync(int id)
        {
            try
            {
                var carreira = await PesquisarIdAsync(id);
                _databaseContext.Carreiras.Remove(carreira);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir carreira.", e);
            }
        }

        public async Task<int> IncluirAsync(Carreira carreira)
        {
            try
            {
                await _databaseContext.Carreiras.AddAsync(carreira);
                await _databaseContext.SaveChangesAsync();
                return carreira.Id;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir carreira.", e);
            }
        }

        public async Task<int> IncluirListaAsync(IEnumerable<Carreira> carreiras)
        {
            try
            {
                await _databaseContext.Carreiras.AddRangeAsync(carreiras);
                var alteracoes = await _databaseContext.SaveChangesAsync();
                return alteracoes;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir carreiras.", e);
            }
        }

        public async Task<Carreira> PesquisarAsync(Expression<Func<Carreira, bool>> expression)
        {
            try
            {
                return await _databaseContext.Carreiras.FirstOrDefaultAsync(expression);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar carreira.", e);
            }

        }

        public async Task<Carreira> PesquisarIdAsync(int id)
        {
            try
            {
                return await _databaseContext.Carreiras.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar id carreira.", e);
            }
        }

        public async Task<IEnumerable<Carreira>> Todos()
        {
            try
            {
                return await _databaseContext.Carreiras.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisar carreiras.", e);
            }
        }
    }
}
