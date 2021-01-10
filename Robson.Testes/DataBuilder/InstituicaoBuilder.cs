using Robson.Domain.Entities;
using System.Collections.Generic;

namespace Robson.Testes.DataBuilder
{
    public class InstituicaoBuilder : IBuilder<Instituicao>
    {
        private List<Instituicao> _instituicao;

        public InstituicaoBuilder()
        {
            _instituicao = new();
        }

        public Instituicao BuildSingleState()
        {
            return new()
            {
                Nome = "Alura"
            };
        }

        public List<Instituicao> BuildListState()
        {
            _instituicao.Clear();

            _instituicao.AddRange(
                new List<Instituicao>
                {
                    new()
                    {
                        Nome = "Alura"
                    },
                    new()
                    {
                        Nome = "Udemy"
                    }
                }
            );

            return _instituicao;
        }

        public void Reset()
        {
            _instituicao.Clear();
        }
    }
}
