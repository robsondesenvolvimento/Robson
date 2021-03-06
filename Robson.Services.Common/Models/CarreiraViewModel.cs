﻿using System;

namespace Robson.Services.Common.Models
{
    public class CarreiraViewModel
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Funcao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
