using Robson.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Robson.Testes.DataBuilder
{
    public class CarreiraBuilder : IBuilder<Carreira>
    {
        private List<Carreira> _carreiras;

        public CarreiraBuilder()
        {
            _carreiras = new();
        }

        public List<Carreira> BuildListState()
        {
            _carreiras.Clear();

            _carreiras.AddRange(
                new List<Carreira>
                {
                    new()
                    {
                        Empresa = "Zylix Automação Industrial",
                        Funcao = "Desenvolvedor .NET",
                        Descricao = "Desenvolvimento de soluções de automação no setor de combustiveis",
                        DataInicio = DateTime.Parse("2000-02-02"),
                        DataSaida = DateTime.Parse("2005-04-01")
                    },
                    new()
                    {
                        Empresa = "Escriba",
                        Funcao = "Desenvolvedor Delphi",
                        Descricao = "Desenvolvimento de aplicações para cartórios",
                        DataInicio = DateTime.Parse("2000-02-02"),
                        DataSaida = DateTime.Parse("2005-04-01")
                    },
                    new()
                    {
                        Empresa = "View Financial Systems",
                        Funcao = "Desenvolvedor .NET e Delphi",
                        Descricao = "Desenvolvimento de soluções no setor bancario",
                        DataInicio = DateTime.Parse("2000-02-02"),
                        DataSaida = DateTime.Parse("2005-04-01")
                    }
                });

            return _carreiras;
        }

        public Carreira BuildSingleState()
        {
            return new()
            {
                Empresa = "Zylix Automação Industrial",
                Funcao = "Desenvolvedor .NET",
                Descricao = "Desenvolvimento de soluções de automação no setor de combustiveis",
                DataInicio = DateTime.Parse("2000-02-02"),
                DataSaida = DateTime.Parse("2005-04-01")
            };
        }

        public void Reset()
        {
            _carreiras.Clear();
        }
    }
}
