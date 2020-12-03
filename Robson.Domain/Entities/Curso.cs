using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Robson.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do curso é obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Código da instituição é obrigatório")]
        
        public int InstituicaoId { get; set; }
        public Instituicao Instituicoes { get; set; }

        public DateTime DataConclusao { get; set; }

    }
}
