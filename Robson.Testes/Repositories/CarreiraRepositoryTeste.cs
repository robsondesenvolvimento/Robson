using Robson.Repository.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Repositories
{
    [TestCaseOrderer("Robson.Testes.PriorityOrderer", "Robson.Testes")]
    public class CarreiraRepositoryTeste
    {
        private readonly CarreiraRepository _carreiraRepository;
        private static int _carreiraId;

        public CarreiraRepositoryTeste()
        {
            _carreiraRepository = new CarreiraRepository(new());
        }

        [Fact, TestPriority(0)]
        public async Task CarreiraRepositoryIncluir()
        {
            _carreiraId = await _carreiraRepository.IncluirAsync(
                new()
                {
                    Empresa = "Alfa Tech Treinamentos",
                    Funcao = "Instrutor de programação, hardware, web design",
                    Descricao = "Instrutor de programação, hardware, web design",
                    DataInicio = DateTime.Parse("2000-02-02"),
                    DataSaida = DateTime.Parse("2005-04-01")
                }
            );

            Assert.True(_carreiraId > 0);
        }

        [Fact, TestPriority(1)]
        public async Task CarreiraRepositoryPesquisarId()
        {
            var pesquisaCarreira = await _carreiraRepository.PesquisarIdAsync(_carreiraId);
            Assert.Equal("Alfa Tech Treinamentos", pesquisaCarreira.Empresa);
        }

        [Fact, TestPriority(2)]
        public async Task CarreiraRepositoryPesquisarNome()
        {
            var pesquisaCarreira = await _carreiraRepository.PesquisarAsync(pessoa => pessoa.Empresa == "Alfa Tech Treinamentos");
            Assert.Equal("Alfa Tech Treinamentos", pesquisaCarreira.Empresa);
        }

        [Fact, TestPriority(3)]
        public async Task CarreiraRepositoryAlterarPessoa()
        {
            var pesquisaCarreira = await _carreiraRepository.PesquisarIdAsync(_carreiraId);
            pesquisaCarreira.Empresa = "Alfa Tech Treinamentos X";

            await _carreiraRepository.AlterarAsync(pesquisaCarreira);

            pesquisaCarreira = await _carreiraRepository.PesquisarIdAsync(_carreiraId);
            Assert.Equal("Alfa Tech Treinamentos X", pesquisaCarreira.Empresa);
        }

        [Fact, TestPriority(4)]
        public async Task CarreiraRepositoryExcluirPessoa()
        {
            await _carreiraRepository.ExcluirAsync(_carreiraId);

            var pesquisaCarreira = await _carreiraRepository.PesquisarIdAsync(_carreiraId);
            Assert.Null(pesquisaCarreira);
        }
    }
}
