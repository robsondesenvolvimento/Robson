using System;
using System.ComponentModel.DataAnnotations;

namespace Robson.Domain.Entities
{
    public class Carreira
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da empresa é obrigatório")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "Nome da função é obrigatório")]
        public string Funcao { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data de inicio é obrigatório")]
        public DateTime DataInicio { get; set; }

        public DateTime DataSaida { get; set; }
    }
}
