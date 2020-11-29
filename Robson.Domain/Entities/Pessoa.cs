using System;
using System.ComponentModel.DataAnnotations;

namespace Robson.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "Número do celular é obrigatório")]
        [Phone]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Endereço de email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        public string Cep { get; set; }

        [Required(ErrorMessage = "Nome da rua é obrigatório")]
        public string Rua { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Nome do bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Nome da cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Nome do estado é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Nome do pais é obrigatório")]
        public string Pais { get; set; }
    }
}
