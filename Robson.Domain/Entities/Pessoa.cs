﻿using System;

namespace Robson.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; init; }
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
        public string Sobre { get; set; }
    }
}
