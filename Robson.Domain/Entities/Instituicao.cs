using System.Collections.Generic;

namespace Robson.Domain.Entities
{
    public class Instituicao
    {
        public int Id { get; init; }
        public string Nome { get; set; }

        public ICollection<Curso> Cursos { get; set; }
        public ICollection<Formacao> Formacoes { get; set; }
    }
}
