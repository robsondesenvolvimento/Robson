using System.Collections.Generic;

namespace Robson.Domain.Entities
{
    public class Escola
    {
        public string Nome { get; private set; }
        public List<Departamento> Departamento { get; private set; }

        public Escola(string nome)
        {
            Nome = nome;
            Departamento = new List<Departamento>();
        }

        public void AdicionarDepartamento(string nome)
        {
            // Composição
            Departamento.Add(new Departamento(this, nome));
        }
    }
}
