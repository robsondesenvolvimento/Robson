using Robson.Repository.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Robson.Repository.Services
{
    public static class PessoaSeedingService
    {
        public static async Task InicializandoBaseDedDados(DatabaseContext databaseContext)
        {
            await databaseContext.Database.EnsureCreatedAsync();

            if (!databaseContext.Pessoas.Any())
            {
                await databaseContext.Pessoas.AddAsync(
                    new()
                    {
                        Nome = "Robson Candido dos Santos Alves",
                        Nascimento = DateTime.Parse("1980-08-29"),
                        Celular = "(41) 98827-07693",
                        Cep = "80050-205",
                        Rua = "Rua Do Herval, 378",
                        Complemento = "Apto. 3",
                        Bairro = "Cristo Rei",
                        Cidade = "Curitiba",
                        Estado = "Paraná",
                        Pais = "Brasil"
                    }
                );

                await databaseContext.SaveChangesAsync();
            }
        }
    }
}
