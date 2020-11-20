using Robson.Domain.Entities;
using Robson.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robson.Testes.Repositories
{
    public class PessoaRepositoryTeste
    {
        [Fact]
        public void PessoaRepositoryIncluir()
        {
            var pessoaRepository = new PessoaRepository();

            var pessoa = new Pessoa { 
                Nome = "Robson Candido dos Santos Alves", 
                Nascimento = DateTime.Parse("1980-08-29") 
            };

            var retornoTesteExcecao = Assert.Throws<NotImplementedException>(() => pessoaRepository.Incluir(pessoa));
            Assert.IsType<NotImplementedException>(retornoTesteExcecao);
        }
    }
}
