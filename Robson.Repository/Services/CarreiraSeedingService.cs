using Robson.Domain.Entities;
using Robson.Repository.Context;
using Robson.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robson.Repository.Services
{
    public static class CarreiraSeedingService
    {
        public static async Task InicializandoBaseDedDados(DatabaseContext databaseContext)
        {
            await databaseContext.Database.EnsureCreatedAsync();

            if (!databaseContext.Carreiras.Any())
            {
                List<Carreira> carreiras = new()
                {
                    new()
                    {
                        Empresa = "Alfa Tech Treinamentos",
                        Funcao = "Instrutor de programação, hardware, web design",
                        Descricao = "Instrutor de programação, hardware, web design",
                        DataInicio = DateTime.Parse("2000-02-02"),
                        DataSaida = DateTime.Parse("2005-04-01")
                    },

                    new()
                    {
                        Empresa = "Softpar",
                        Funcao = "Desenvolvedor Delphi",
                        Descricao = "Desenvolvimento de aplicações financeiras em Delphi",
                        DataInicio = DateTime.Parse("2005-04-01"),
                        DataSaida = DateTime.Parse("2008-11-30")
                    },

                    new()
                    {
                        Empresa = "View Financial Systems",
                        Funcao = "Desenvolvedor Delphi",
                        Descricao = "Desenvolvimento de aplicações financeiras em Delphi e resposável de TI",
                        DataInicio = DateTime.Parse("2008-12-01"),
                        DataSaida = DateTime.Parse("2019-06-18")
                    },

                    new()
                    {
                        Empresa = "Escriba",
                        Funcao = "Desenvolvedor Delphi",
                        Descricao = "Desenvolvimento de aplicações notariais em Delphi",
                        DataInicio = DateTime.Parse("2019-08-19"),
                        DataSaida = DateTime.Parse("2020-07-06")
                    },

                    new()
                    {
                        Empresa = "Zylix Automação Industrial",
                        Funcao = "Desenvolvedor .Net e resposável de TI",
                        Descricao = "Desenvolvimento de aplicações notariais em Delphi",
                        DataInicio = DateTime.Parse("2020-07-13")
                    }
                };

                var carreiraRepository = new CarreiraRepository(databaseContext);
                await carreiraRepository.IncluirListaAsync(carreiras);
            }
        }
    }
}
