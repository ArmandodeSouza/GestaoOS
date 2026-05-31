using System;
using System.IO;

namespace GestaoOS.Infrastructure.Logging {
    public sealed class FileLogger {
        private readonly string _path;

        public FileLogger() {
            _path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "logs");

            Directory.CreateDirectory(_path);
        }

        public void Log(Exception ex) {
            try {
                var file = Path.Combine(
                    _path,
                    $"log_{DateTime.Now:yyyyMMdd}.txt");

                var texto = $@"
[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]

TIPO:
{ex.GetType().Name}

MENSAGEM:
{ex.Message}

STACK TRACE:
{ex.StackTrace}

INNER EXCEPTION:
{ex.InnerException?.Message}

--------------------------------------------------
";

                File.AppendAllText(file, texto);
            } catch {
            }
        }

        public void Log(string mensagem) {
            try {
                var file = Path.Combine(
                    _path,
                    $"log_{DateTime.Now:yyyyMMdd}.txt");

                var texto = $@"
[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]

MENSAGEM:
{mensagem}

--------------------------------------------------
";

                File.AppendAllText(file, texto);
            } catch {
            }
        }
    }
}