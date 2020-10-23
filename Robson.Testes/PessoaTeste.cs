using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Robson.Testes
{
    public class PessoaTeste
    {
        public static readonly object[][] Pessoa =
        {
            new object[] { 1, "Robson Candido dos Santos ALves", DateTime.Parse("1980-08-29") }
        };

        [Theory]
        [MemberData(nameof(Pessoa))]
        public void CriarPessoa(int id, string nome, DateTime nascimento)
        {
            Pessoa pessoa = new Pessoa(id, nome, nascimento);
            var idade = DateTime.Parse("2020-10-22").Year - pessoa.Nascimento.Year;
            Assert.Equal(40, idade);
        }
    }
}
