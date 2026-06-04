using GestaoOS.Application.Interface;
using GestaoOS.Application.Services;
using GestaoOS.Infra.Repositories;
using GestaoOS.Infrastructure.Data;
using GestaoOS.Infrastructure.Repositories;
using GestaoOS.Services.Interface;
using GestaoOS.Services.Services;
using GestaoOS.UI.UiCliente;
using GestaoOS.UI.UiOrdemServicoCadastro;
using GestaoOS.UI.UiServico;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoOS.UI {
    public static class DependencyInjectionConfig {
        public static ServiceProvider Register() {
            var services = new ServiceCollection();

            // Database Connection Factory
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            // Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();


            // Application Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<IOrdemServicoService, OrdemServicoService>();

            // UI Forms
            services.AddTransient<FrmMain>();
            services.AddTransient<FrmCliente>();
            services.AddTransient<FrmCadastroCliente>();
            services.AddTransient<FrmServico>();
            services.AddTransient<FrmCadastroServico>();
            services.AddTransient<FrmOrdemServicoCadastro>();


            return services.BuildServiceProvider();
        }
    }
}