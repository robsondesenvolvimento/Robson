using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robson.Domain.Entities
{
    public class Instituicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}
