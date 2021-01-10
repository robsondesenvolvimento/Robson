using Robson.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Robson.Testes.DataBuilder
{
    public class CursoBuilder : IBuilder<Curso>
    {
        private List<Curso> _cursos;

        public CursoBuilder()
        {
            _cursos = new();
        }

        public List<Curso> BuildListState()
        {
            _cursos.Clear();

            _cursos.AddRange(
                new List<Curso>
                {
                    new()
                    {
                        Nome = "Curso de Desenvolvimento C#",
                        Descricao = "Curso de Desenvolvimento C#",
                        InstituicaoId = 1,
                        DataConclusao = DateTime.Parse("2020-12-12")
                    },
                    new()
                    {
                        Nome = "Curso de Desenvolvimento Asp.Net Core",
                        Descricao = "Curso de Desenvolvimento Asp.Net Core",
                        InstituicaoId = 1,
                        DataConclusao = DateTime.Parse("2020-11-12")
                    },
                    new()
                    {
                        Nome = "Curso de Desenvolvimento C++",
                        Descricao = "Curso de Desenvolvimento C++",
                        InstituicaoId = 1,
                        DataConclusao = DateTime.Parse("2020-11-12")
                    }
                });

            return _cursos;
        }

        public Curso BuildSingleState()
        {
            return new()
            {
                Nome = "Curso de Desenvolvimento C#",
                Descricao = "Curso de Desenvolvimento C#",
                InstituicaoId = 1,
                DataConclusao = DateTime.Parse("2020-12-12")
            };
        }

        public void Reset()
        {
            _cursos.Clear();
        }
    }
}
