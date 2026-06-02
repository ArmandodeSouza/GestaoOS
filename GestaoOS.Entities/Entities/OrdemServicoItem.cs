using GestaoOS.Entities.Entities;
using System;

namespace GestaoOS.Domain.Entities {
    public sealed class OrdemServicoItem {
        public int OrdemServicoItemId { get; private set; }
        public int OrdemServicoId { get; private set; }
        public int ServicoId { get; private set; }

        public decimal Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal PercentualImpostoAplicado { get; private set; }
        public decimal ValorTotalItem { get; private set; }

        public OrdemServicoItem(int servicoId, decimal quantidade, decimal valorUnitario, decimal percentualImpostoAplicado, decimal valorTotalItem) {

            if (servicoId <= 0)
                throw new ArgumentException("Serviço inválido.");

            ServicoId = servicoId;

            AtualizarValores(quantidade, valorUnitario, percentualImpostoAplicado);
        }

        public OrdemServicoItem(int servicoId, decimal quantidade, decimal valorUnitario, decimal percentualImpostoAplicado) {
            if (servicoId <= 0)
                throw new ArgumentException("Serviço inválido.");

            ServicoId = servicoId;

            AtualizarValores(quantidade, valorUnitario, percentualImpostoAplicado);
        }

        public static OrdemServicoItem Reconstruir(int ordemServicoItemId, int ordemServicoId, int servicoId, decimal quantidade, decimal valorUnitario, decimal percentualImpostoAplicado, decimal valorTotalItem) {
            var item = new OrdemServicoItem(servicoId, quantidade, valorUnitario, percentualImpostoAplicado, valorTotalItem);
            item.OrdemServicoItemId = ordemServicoItemId;
            item.OrdemServicoId = ordemServicoId;
            return item;
        }

        public void AtualizarQuantidade(decimal quantidade) {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            Quantidade = quantidade;
            RecalcularTotal();
        }

        public void AtualizarValores(decimal quantidade, decimal valorUnitario, decimal percentualImpostoAplicado) {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            if (valorUnitario < 0)
                throw new ArgumentException("Valor unitário inválido.");

            if (percentualImpostoAplicado < 0 || percentualImpostoAplicado > 100)
                throw new ArgumentException("Percentual de imposto inválido.");

            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            PercentualImpostoAplicado = percentualImpostoAplicado;

            RecalcularTotal();
        }

        private void RecalcularTotal() {
            var subtotal = Quantidade * ValorUnitario;
            var imposto = subtotal * (PercentualImpostoAplicado / 100m);

            ValorTotalItem = subtotal + imposto;
        }


    }
}