namespace Robson.Domain.Entities
{
    public class Departamento
    {
        private readonly string _nome;
        private readonly Escola _escola;

        internal Departamento(Escola escola, string nome)
        {
            this._escola = escola;
            this._nome = nome;
        }

        public Escola Escola()
        {
            return _escola;
        }

        public string NomeDepartamento()
        {
            return _nome;
        }
    }
}
