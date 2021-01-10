using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Robson.Common
{
    public static class CpfValidate
    {
        private static List<int> _digitosCpf = new List<int>();
        private static string _cpfCompleto;

        public static bool IsValid(string cpf)
        {
            _cpfCompleto = cpf
                .Replace(".", "")
                .Replace("-", "");

            var primeirosDigitos = _cpfCompleto.Substring(1, 9);

            Set9DigitosIniciais(primeirosDigitos);

            return _cpfCompleto == cpf;
        }

        private static void Set9DigitosIniciais(string digitos)
        {
            if (digitos.Trim().Length != 9)
                throw new ArgumentException("Número de digitos deve ser igual a 9");

            if (Regex.IsMatch(digitos, ".*[a-zA-Z]+.*"))
                throw new ArgumentException("Só números são válidos no CPF");

            digitos.ToList().ForEach(digito =>
            {
                var digitoAtual = Int32.Parse(digito.ToString());
                _digitosCpf.Add(digitoAtual);
            }
            );

            _cpfCompleto = digitos;
        }

        private static string GerarCpf()
        {
            var multiplicador = 10;
            var soma = 0;

            _digitosCpf.ForEach(digito =>
            {
                soma += digito * multiplicador;
                multiplicador--;
            });

            var decimoDigito = 11 - (soma % 11);

            if (decimoDigito > 9)
                decimoDigito = 0;

            _digitosCpf.RemoveAt(0);
            _digitosCpf.Add(decimoDigito);

            multiplicador = 10;
            soma = 0;

            _digitosCpf.ForEach(digito =>
            {
                soma += digito * multiplicador;
                multiplicador--;
            });

            var decimoPrimeiroDigito = 11 - (soma % 11);

            if (decimoPrimeiroDigito > 9)
                decimoPrimeiroDigito = 0;

            return $"{_cpfCompleto}{decimoDigito}{decimoPrimeiroDigito}";
        }
    }
}
