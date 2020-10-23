using System;

namespace Robson.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime Nascimento { get; private set; }

        public Pessoa(int id, string nome, DateTime nascimento)
        {
            this.Id = id;
            this.Nome = nome;
            this.Nascimento = nascimento;
        }
    }
}
