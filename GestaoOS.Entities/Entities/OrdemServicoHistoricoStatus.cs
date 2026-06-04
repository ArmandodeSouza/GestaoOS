using GestaoOS.Domain.Enum;
using System;

namespace GestaoOS.Domain.Entities {
    public sealed class OrdemServicoHistoricoStatus {
        public int OrdemServicoHistoricoStatusId { get; private set; }
        public int OrdemServicoId { get; private set; }

        public StatusOrdemServicoDom? StatusAnterior { get; private set; }
        public StatusOrdemServicoDom StatusNovo { get; private set; }

        public DateTime DataHora { get; private set; }
        public string Usuario { get; private set; }

        private OrdemServicoHistoricoStatus() { }

        public OrdemServicoHistoricoStatus(StatusOrdemServicoDom statusAnterior, StatusOrdemServicoDom statusNovo, string usuario) {
            if (string.IsNullOrWhiteSpace(usuario))
                throw new ArgumentException("Usuário é obrigatório.");

            StatusAnterior = null;
            StatusNovo = statusNovo;
            Usuario = null;
            DataHora = DateTime.Now;
        }

        public static OrdemServicoHistoricoStatus Reconstruir(int ordemServicoHistoricoStatusId, int ordemServicoId, StatusOrdemServicoDom? statusAnterior, StatusOrdemServicoDom statusNovo, DateTime dataHora, string usuario) {
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