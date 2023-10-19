using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioFundamentos.Helpers
{
    public class ValidatorHelper
    {
        public static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa) || placa.Length != 8)
                return false;

            placa = placa.Replace("-", "").Trim();

            if (char.IsLetter(placa, 4))
            {
                var regexMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return regexMercosul.IsMatch(placa);
            }

            var regexAntigo = new Regex("[a-zA-Z]{3}[0-9]{4}");
            return regexAntigo.IsMatch(placa);
        }

        public static bool ValidarQuantidadeHoras(string horas)
        {
            return int.TryParse(horas, out _);
        }

        public static bool ValidarPrecoInicial(string preco)
        {
            return decimal.TryParse(preco, out _);
        }

        public static bool ValidarPrecoHora(string preco)
        {
            return decimal.TryParse(preco, out _);
        }
    }
}