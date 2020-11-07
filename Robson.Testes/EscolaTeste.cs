using Robson.Domain.Entities;
using System.Linq;
using Xunit;

namespace Robson.Testes
{
    public class EscolaTeste
    {
        [Fact]
        public void AdicionarEscolaComDepartamento()
        {
            Escola escola = new Escola("Alura Cursos On-line");
            escola.AdicionarDepartamento("Desenvolvimento");

            var dep = escola.Departamento.FirstOrDefault();

            Assert.Equal("Alura Cursos On-line", dep.Escola().Nome);
            Assert.Equal("Desenvolvimento", dep.NomeDepartamento());
        }
    }
}
