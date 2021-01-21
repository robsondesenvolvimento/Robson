using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Robson.Data.Context;
using Robson.Data.Repositories;
using Robson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robson.Api.Services
{
    public static class SeedingService
    {
        public static async Task PessoaSeedingServiceStart(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var databaseContext = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                await databaseContext.Database.EnsureCreatedAsync();

                if (!databaseContext.Pessoas.Any())
                {
                    Pessoa pessoa = new()
                    {
                        Nome = "Robson Candido dos Santos Alves",
                        Nascimento = DateTime.Parse("1980-08-29"),
                        Celular = "(41) 98827-07693",
                        Email = "robsondesenvolvimento@gmail.com",
                        Cep = "80050-205",
                        Rua = "Rua Do Herval, 000",
                        Complemento = "Apto. 40",
                        Bairro = "Cristo Rei",
                        Cidade = "Curitiba",
                        Estado = "Paraná",
                        Pais = "Brasil"
                    };

                    var pessoaRepository = new PessoaRepository(databaseContext);
                    await pessoaRepository.IncluirAsync(pessoa);
                }
            }
        }

        public static async Task CarreiraSeedingServiceStart(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var databaseContext = serviceScope.ServiceProvider.GetService<DatabaseContext>();

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
}
