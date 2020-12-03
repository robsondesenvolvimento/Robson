using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Robson.Domain.Entities
{
    public class Instituicao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da instituição é obrigatório")]
        public string Nome { get; set; }

        public ICollection<Curso> Cursos { get; set; }
    }
}
