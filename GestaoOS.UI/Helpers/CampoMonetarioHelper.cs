using System;
using System.Linq;
using System.Windows.Forms;

namespace GestaoOS.UI.Helpers {
    public static class CampoMonetarioHelper {
        public static void Formatar(TextBox textBox) {
            string numeros = new string(
                textBox.Text.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(numeros)) {
                textBox.Text = "";
                return;
            }

            decimal valor = decimal.Parse(numeros) / 100;

            textBox.Text = valor.ToString("N2");
            textBox.SelectionStart = textBox.Text.Length;
        }

        public static decimal ObterValor(TextBox textBox) {
            decimal valor;

            if (!decimal.TryParse(textBox.Text, out valor))
                throw new Exception("Valor monetário inválido.");

            return valor;
        }
    }
}
