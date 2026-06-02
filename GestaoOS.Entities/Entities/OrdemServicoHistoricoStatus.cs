using GestaoOS.Entities.Enum;
using System;

namespace GestaoOS.Domain.Entities {
    public sealed class OrdemServicoHistoricoStatus {
        public int OrdemServicoHistoricoStatusId { get; private set; }
        public int OrdemServicoId { get; private set; }

        public StatusOrdemServico? StatusAnterior { get; private set; }
        public StatusOrdemServico StatusNovo { get; private set; }

        public DateTime DataHora { get; private set; }
        public string Usuario { get; private set; }

        private OrdemServicoHistoricoStatus() { }

        public OrdemServicoHistoricoStatus(StatusOrdemServico statusAnterior, StatusOrdemServico statusNovo, string usuario) {
            if (string.IsNullOrWhiteSpace(usuario))
                throw new ArgumentException("Usuário é obrigatório.");

            StatusAnterior = null;
            StatusNovo = statusNovo;
            Usuario = null;
            DataHora = DateTime.Now;
        }

        public static OrdemServicoHistoricoStatus Reconstruir(int ordemServicoHistoricoStatusId, int ordemServicoId, StatusOrdemServico? statusAnterior, StatusOrdemServico statusNovo, DateTime dataHora, string usuario) {
            return new OrdemServicoHistoricoStatus {
                OrdemServicoHistoricoStatusId = ordemServicoHistoricoStatusId,
                OrdemServicoId = ordemServicoId,
                StatusAnterior = statusAnterior,
                StatusNovo = statusNovo,
                DataHora = dataHora,
                Usuario = usuario
            };
        }

    }
}