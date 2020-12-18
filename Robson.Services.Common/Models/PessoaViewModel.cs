using System;

namespace Robson.Services.Common.Models
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}
