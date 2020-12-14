using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robson.Domain.Entities
{
    public class Formacao
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        [Required(ErrorMessage = "Código da instituição é obrigatório")]

        public string Descricao { get; set; }

        public int InstituicaoId { get; set; }
        public Instituicao Instituicoes { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataConclusao { get; set; }
    }
}
