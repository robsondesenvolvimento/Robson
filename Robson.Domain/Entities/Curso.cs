using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Robson.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do curso é obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Nome da instituição é obrigatório")]
        public Instituicao Instituicao { get; set; }

        public DateTime DataConclusao { get; set; }

    }
}
