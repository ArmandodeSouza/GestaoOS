using System;
using Microsoft.Extensions.DependencyInjection;
using WinFormsApp = System.Windows.Forms.Application;
namespace GestaoOS.UI {
    internal static class Program {
        [STAThread]
        static void Main() {

            var provider = DependencyInjectionConfig.Register();

            WinFormsApp.EnableVisualStyles();
            WinFormsApp.SetCompatibleTextRenderingDefault(false);

            WinFormsApp.Run(provider.GetRequiredService<FrmMain>());
        }
    }
}