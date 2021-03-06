﻿using Robson.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Robson.Testes.DataBuilder
{
    public class PessoaBuilder : IBuilder<Pessoa>
    {
        private List<Pessoa> _pessoas;

        public PessoaBuilder()
        {
            _pessoas = new();
        }

        public Pessoa BuildSingleState()
        {
            return new()
            {
                Nome = "Robson Candido dos Santos Alves",
                Nascimento = DateTime.Parse("1980-08-29"),
                Celular = "(41) 0000-00",
                Cep = "80050-205",
                Rua = "Rua do Herval, 0000",
                Complemento = "Apto. 1",
                Bairro = "Cristo Rei",
                Cidade = "Curitiba",
                Estado = "Paraná",
                Pais = "Brasil"
            };
        }

        public List<Pessoa> BuildListState()
        {
            _pessoas.Clear();

            _pessoas.AddRange(
                new List<Pessoa>
                {
                    new()
                    {
                        Nome = "Robson Candido dos Santos Alves",
                        Nascimento = DateTime.Parse("1980-08-29"),
                        Celular = "(41) 0000-0000",
                        Cep = "80050-205",
                        Rua = "Rua do Herval, 0000",
                        Complemento = "Apto. 1",
                        Bairro = "Cristo Rei",
                        Cidade = "Curitiba",
                        Estado = "Paraná",
                        Pais = "Brasil"
                    },
                    new()
                    {
                        Nome = "Henrique Casagrande dos Santos Alves",
                        Nascimento = DateTime.Parse("2019-07-21"),
                        Celular = "(41) 1111-1111",
                        Cep = "80050-205",
                        Rua = "Rua do Herval, 1111",
                        Complemento = "Apto. 1",
                        Bairro = "Cristo Rei",
                        Cidade = "Curitiba",
                        Estado = "Paraná",
                        Pais = "Brasil"
                    },
                    new()
                    {
                        Nome = "Ana Julia Casagrande da Silva",
                        Nascimento = DateTime.Parse("1990-03-19"),
                        Celular = "(41) 2222-2222",
                        Cep = "80050-205",
                        Rua = "Rua do Herval, 2222",
                        Complemento = "Apto. 1",
                        Bairro = "Cristo Rei",
                        Cidade = "Curitiba",
                        Estado = "Paraná",
                        Pais = "Brasil"
                    },
                    new()
                    {
                        Nome = "Gabriel Casagrande da Lima",
                        Nascimento = DateTime.Parse("2005-03-19"),
                        Celular = "(41) 3333-3333",
                        Cep = "80050-205",
                        Rua = "Rua do Herval, 3333",
                        Complemento = "Apto. 1",
                        Bairro = "Cristo Rei",
                        Cidade = "Curitiba",
                        Estado = "Paraná",
                        Pais = "Brasil"
                    }
                }
            );

            return _pessoas;
        }

        public void Reset()
        {
            _pessoas.Clear();
        }
    }
}
