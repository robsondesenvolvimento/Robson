using System;

namespace Robson.Domain.Entities
{
    public class Pessoa
    {
        public string Nome { get; private set; }
        public DateTime Nascimento { get; private set; }

        public Pessoa(string nome, DateTime nascimento)
        {
            this.Nome = nome;
            this.Nascimento = nascimento;
        }
    }
}
