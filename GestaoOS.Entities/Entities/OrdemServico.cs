using GestaoOS.Entities.Enum;
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
        public StatusOrdemServico Status { get; private set; }
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
            Status = StatusOrdemServico.Aberta;
            Versao = 1;
            ValorTotal = 0;
        }

        public static OrdemServico Reconstruir(int ordemServicoId, int clienteId, DateTime dataAbertura, DateTime? dataConclusao, StatusOrdemServico status, string observacao, decimal valorTotal, int versao) {
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
            if (Status != StatusOrdemServico.Aberta)
                throw new InvalidOperationException("Somente OS aberta pode ser iniciada.");

            AlterarStatus(StatusOrdemServico.EmAndamento, usuario);
        }

        public void Concluir(string usuario) {
            if (Status == StatusOrdemServico.Cancelada)
                throw new InvalidOperationException("OS cancelada não pode ser concluída.");

            if (!_itens.Any())
                throw new InvalidOperationException("Não é possível concluir uma OS sem itens.");

            RecalcularTotal();

            if (ValorTotal <= 0)
                throw new InvalidOperationException("Não é possível concluir uma OS com valor total zerado.");

            AlterarStatus(StatusOrdemServico.Concluida, usuario);
            DataConclusao = DateTime.Now;
        }

        public void Cancelar(string usuario) {
            if (Status == StatusOrdemServico.Concluida)
                throw new InvalidOperationException("OS concluída não pode ser cancelada.");

            AlterarStatus(StatusOrdemServico.Cancelada, usuario);
        }

        private void RecalcularTotal() {
            ValorTotal = _itens.Sum(x => x.ValorTotalItem);
        }

        private void ValidarPermiteAlteracao() {
            if (Status == StatusOrdemServico.Concluida)
                throw new InvalidOperationException("Não é permitido alterar uma OS concluída.");

            if (Status == StatusOrdemServico.Cancelada)
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

        private void AlterarStatus(StatusOrdemServico novoStatus, string usuario) {
            if (string.IsNullOrWhiteSpace(usuario))
                throw new ArgumentException("Usuário é obrigatório.");

            var statusAnterior = Status;

            if (statusAnterior == novoStatus)
                return;

            Status = novoStatus;

            _historicos.Add(new OrdemServicoHistoricoStatus(statusAnterior, novoStatus, usuario));
        }
    }
}