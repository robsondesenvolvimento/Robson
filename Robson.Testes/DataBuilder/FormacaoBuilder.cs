using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robson.Testes.DataBuilder
{
    public class FormacaoBuilder : IBuilder<Formacao>
    {
        private List<Formacao> _formacao;

        public FormacaoBuilder()
        {
            _formacao = new();
        }

        public List<Formacao> BuildListState()
        {
            _formacao.Clear();

            _formacao.AddRange(
                new List<Formacao>
                {
                    new()
                    {
                        Nome = "Curso de Desenvolvimento C#",
                        Descricao = "Curso de Desenvolvimento C#",
                        InstituicaoId = 1,
                        DataInicio = DateTime.Parse("2020-12-12"),
                        DataConclusao = DateTime.Parse("2020-12-12")
                    },
                    new()
                    {
                        Nome = "Curso de Desenvolvimento Asp.Net Core",
                        Descricao = "Curso de Desenvolvimento Asp.Net Core",
                        InstituicaoId = 1,
                        DataInicio = DateTime.Parse("2020-12-12"),
                        DataConclusao = DateTime.Parse("2020-11-12")
                    },
                    new()
                    {
                        Nome = "Curso de Desenvolvimento C++",
                        Descricao = "Curso de Desenvolvimento C++",
                        InstituicaoId = 1,
                        DataInicio = DateTime.Parse("2020-12-12"),
                        DataConclusao = DateTime.Parse("2020-11-12")
                    }
                }
            );

            return _formacao;
        }

        public Formacao BuildSingleState()
        {
            return new()
            {
                Nome = "Curso de Desenvolvimento C#",
                Descricao = "Curso de Desenvolvimento C#",
                InstituicaoId = 1,
                DataInicio = DateTime.Parse("2020-12-12"),
                DataConclusao = DateTime.Parse("2020-12-12")
            };
        }

        public void Reset()
        {
            _formacao.Clear();
        }
    }
}
