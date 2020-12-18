using System;

namespace Robson.Domain.Entities
{
    public class Formacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public int InstituicaoId { get; set; }
        public Instituicao Instituicoes { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
