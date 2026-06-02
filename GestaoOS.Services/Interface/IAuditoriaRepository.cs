using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.Interface {
    public interface IAuditoriaRepository {

        Task RegistrarAsync(string entidade, int idRegistro, string operacao, string usuario, string snapshotJson);

    }
}
