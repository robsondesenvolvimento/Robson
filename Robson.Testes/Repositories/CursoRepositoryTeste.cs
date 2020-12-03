using Microsoft.EntityFrameworkCore;
using Robson.Data.Context;
using Robson.Data.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Repositories
{
    [TestCaseOrderer("Robson.Testes.PriorityOrderer", "Robson.Testes")]
    public class CursoRepositoryTeste
    {
        private readonly CursoRepository _cursoRepository;
        private readonly InstituicaoRepository _instituicaoRepository;

        public CursoRepositoryTeste()
        {
            DbContextOptionsBuilder<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseInMemoryDatabase("CursoRepositoryTeste");
            var dataBase = new DatabaseContext(options.Options);
            _cursoRepository = new CursoRepository(dataBase);
            _instituicaoRepository = new InstituicaoRepository(dataBase);
        }

        [Fact, TestPriority(0)]
        public async Task CursoRepositoryIncluir()
        {
            var _instituicaoId = await _instituicaoRepository.IncluirAsync(
                new()
                {
                    Nome = "Alura"
                }
            );

            var _cursoId = await _cursoRepository.IncluirAsync(
                new()
                {
                    Nome = "Desenvolvimento",
                    InstituicaoId = 2
                }
            ); ;

            Assert.Equal(1, _cursoId);
        }

        [Fact, TestPriority(1)]
        public async Task CursoRepositoryPesquisarId()
        {
            var pesquisaCurso = await _cursoRepository.PesquisarIdAsync(1);
            Assert.Equal("Desenvolvimento", pesquisaCurso.Nome);
        }

        [Fact, TestPriority(2)]
        public async Task CursoRepositoryPesquisarNome()
        {
            var pesquisaInstituicao = await _cursoRepository.PesquisarAsync(curso => curso.Nome == "Desenvolvimento");
            Assert.Equal("Desenvolvimento", pesquisaInstituicao.Nome);
        }

        [Fact, TestPriority(3)]
        public async Task CursoRepositoryAlterarCurso()
        {
            var pesquisaCurso = await _cursoRepository.PesquisarIdAsync(1);
            pesquisaCurso.Nome = "Desenvolvimento X";

            await _cursoRepository.AlterarAsync(pesquisaCurso);

            pesquisaCurso = await _cursoRepository.PesquisarIdAsync(1);
            Assert.Equal("Desenvolvimento X", pesquisaCurso.Nome);
        }

        [Fact, TestPriority(4)]
        public async Task CursoRepositoryExcluirInstituicao()
        {
            await _cursoRepository.ExcluirAsync(1);

            var pesquisaCurso = await _cursoRepository.PesquisarIdAsync(1);
            Assert.Null(pesquisaCurso);
        }
    }
}
