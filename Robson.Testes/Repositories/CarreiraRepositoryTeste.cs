using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Repositories
{
    [TestCaseOrderer("Robson.Testes.PriorityOrderer", "Robson.Testes")]
    public class CarreiraRepositoryTeste
    {
        private readonly CarreiraRepository _carreiraRepository;

        public CarreiraRepositoryTeste()
        {
            DbContextOptionsBuilder<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseInMemoryDatabase("CarreiraRepositoryTeste");
            _carreiraRepository = new CarreiraRepository(new(options.Options));
        }

        [Fact, TestPriority(0)]
        public async Task CarreiraRepositoryIncluir()
        {
            var _carreiraId = await _carreiraRepository.IncluirAsync(
                new()
                {
                    Empresa = "Teste de Unidade Carreira",
                    Funcao = "Teste de Unidade Carreira",
                    Descricao = "Teste de Unidade Carreira",
                    DataInicio = DateTime.Parse("2000-02-02"),
                    DataSaida = DateTime.Parse("2005-04-01")
                }
            );

            Assert.Equal(1, _carreiraId);
        }

        [Fact, TestPriority(1)]
        public async Task CarreiraRepositoryPesquisarId()
        {
            var pesquisaCarreira = await _carreiraRepository.PesquisarIdAsync(1);
            Assert.Equal("Teste de Unidade Carreira", pesquisaCarreira.Empresa);
        }

        [Fact, TestPriority(2)]
        public async Task CarreiraRepositoryPesquisarNome()
        {
            var pesquisaCarreira = await _carreiraRepository.PesquisarAsync(pessoa => pessoa.Empresa == "Teste de Unidade Carreira");
            Assert.Equal("Teste de Unidade Carreira", pesquisaCarreira.Empresa);
        }

        [Fact, TestPriority(3)]
        public async Task CarreiraRepositoryAlterarPessoa()
        {
            var pesquisaCarreira = await _carreiraRepository.PesquisarIdAsync(1);
            pesquisaCarreira.Empresa = "Teste de Unidade Carreira X";

            await _carreiraRepository.AlterarAsync(pesquisaCarreira);

            pesquisaCarreira = await _carreiraRepository.PesquisarIdAsync(1);
            Assert.Equal("Teste de Unidade Carreira X", pesquisaCarreira.Empresa);
        }

        [Fact, TestPriority(4)]
        public async Task CarreiraRepositoryExcluirPessoa()
        {
            await _carreiraRepository.ExcluirAsync(1);

            var pesquisaCarreira = await _carreiraRepository.PesquisarIdAsync(1);
            Assert.Null(pesquisaCarreira);
        }
    }
}
