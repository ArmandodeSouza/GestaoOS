using GestaoOS.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoOS.Domain.Entities {
    public sealed class OrdemServico {
        private readonly List<OrdemServicoItem> _itens = new List<OrdemServicoItem>();
        private readonly List<OrdemServicoHistoricoStatus> _historicos = new List<OrdemServicoHistoricoStatus>();

        public int OrdemServicoId { get; private set; }
        public int ClienteId { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public DateTime? DataConclusao { get; private set; }
        public StatusOrdemServicoDom Status { get; private set; }
        public string Observacao { get; private set; }
        public decimal ValorTotal { get; private set; }
        public int Versao { get; private set; }

        public IReadOnlyCollection<OrdemServicoItem> Itens {
            get { return _itens.AsReadOnly(); }
        }

        private OrdemServico() { }

        public OrdemServico(int clienteId, string observacao) {
            if (clienteId <= 0)
                throw new ArgumentException("Cliente inválido.");

            ClienteId = clienteId;
            Observacao = observacao == null ? null : observacao.Trim();
            DataAbertura = DateTime.Now;
            Status = StatusOrdemServicoDom.Aberta;
            Versao = 1;
            ValorTotal = 0;
        }

        public static OrdemServico Reconstruir(int ordemServicoId, int clienteId, DateTime dataAbertura, DateTime? dataConclusao, StatusOrdemServicoDom status, string observacao, decimal valorTotal, int versao) {
            return new OrdemServico {
                OrdemServicoId = ordemServicoId,
                ClienteId = clienteId,
                DataAbertura = dataAbertura,
                DataConclusao = dataConclusao,
                Status = status,
                Observacao = observacao,
                ValorTotal = valorTotal,
                Versao = versao
            };
        }

        internal void AdicionarItemCarregado(OrdemServicoItem item) {
            if (item == null)
                throw new ArgumentNullException("item");

            _itens.Add(item);
        }

        internal void AdicionarHistoricoCarregado(OrdemServicoHistoricoStatus historico) {
            if (historico == null)
                throw new ArgumentNullException("historico");
            _historicos.Add(historico);
        }

        public void AdicionarItem(OrdemServicoItem item) {
            ValidarPermiteAlteracao();

            if (item == null)
                throw new ArgumentNullException("item");

            _itens.Add(item);
            RecalcularTotal();
        }

        public void RemoverItem(OrdemServicoItem item) {
            ValidarPermiteAlteracao();

            if (item == null)
                throw new ArgumentNullException("item");

            _itens.Remove(item);
            RecalcularTotal();
        }

        public void AtualizarObservacao(string observacao) {
            ValidarPermiteAlteracao();

            Observacao = observacao == null ? null : observacao.Trim();
        }

        public void Iniciar(string usuario) {
            if (Status != StatusOrdemServicoDom.Aberta)
                throw new InvalidOperationException("Somente OS aberta pode ser iniciada.");

            AlterarStatus(StatusOrdemServicoDom.EmAndamento);
        }

        public void Concluir(string usuario) {
            if (Status == StatusOrdemServicoDom.Cancelada)
                throw new InvalidOperationException("OS cancelada não pode ser concluída.");

            if (!_itens.Any())
                throw new InvalidOperationException("Não é possível concluir uma OS sem itens.");

            RecalcularTotal();

            if (ValorTotal <= 0)
                throw new InvalidOperationException("Não é possível concluir uma OS com valor total zerado.");

            AlterarStatus(StatusOrdemServicoDom.Concluida);
            DataConclusao = DateTime.Now;
        }

        public void Cancelar(string usuario) {
            if (Status == StatusOrdemServicoDom.Concluida)
                throw new InvalidOperationException("OS concluída não pode ser cancelada.");

            AlterarStatus(StatusOrdemServicoDom.Cancelada);
        }

        private void RecalcularTotal() {
            ValorTotal = _itens.Sum(x => x.ValorTotalItem);
        }

        private void ValidarPermiteAlteracao() {
            if (Status == StatusOrdemServicoDom.Concluida)
                throw new InvalidOperationException("Não é permitido alterar uma OS concluída.");

            if (Status == StatusOrdemServicoDom.Cancelada)
                throw new InvalidOperationException("Não é permitido alterar uma OS cancelada.");
        }
        public IReadOnlyCollection<OrdemServicoHistoricoStatus> Historicos {
            get { return _historicos.AsReadOnly(); }
        }

        public void IncrementarVersao() {
            Versao++;
        }

        public void AtualizarItem(int servicoId, decimal quantidade, decimal valorUnitario, decimal percentualImpostoAplicado) {
            ValidarPermiteAlteracao();

            var item = _itens.FirstOrDefault(x => x.ServicoId == servicoId);

            if (item == null)
                throw new InvalidOperationException("Item não encontrado.");

            item.AtualizarValores(quantidade, valorUnitario, percentualImpostoAplicado);

            RecalcularTotal();
        }

        private void AlterarStatus(StatusOrdemServicoDom novoStatus) {

            var statusAnterior = Status;

            if (statusAnterior == novoStatus)
                return;

            Status = novoStatus;

            _historicos.Add(new OrdemServicoHistoricoStatus(statusAnterior, novoStatus));
        }

        public void Reabrir() {
            if (Status != StatusOrdemServicoDom.Cancelada &&
                Status != StatusOrdemServicoDom.Concluida)
                throw new InvalidOperationException("A OS só pode ser reaberta se estiver cancelada ou concluída.");

            var statusAnterior = Status;

            Status = StatusOrdemServicoDom.Aberta;
            DataConclusao = null;

            _historicos.Add(new OrdemServicoHistoricoStatus(statusAnterior, StatusOrdemServicoDom.Aberta));
        }
    }
}