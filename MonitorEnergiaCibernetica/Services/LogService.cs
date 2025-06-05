using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MonitorEnergiaCibernetica.Services
{
    public static class LogService
    {
        private static readonly string caminhoLog = "logs/eventos.log";

        public static void Registrar(string mensagem)
        {
            Directory.CreateDirectory("logs");

            string entrada = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} | {mensagem}";
            File.AppendAllText(caminhoLog, entrada + Environment.NewLine);
        }

        public static string[] LerLogs()
        {
            if (!File.Exists(caminhoLog))
                return new string[] { "Nenhum log encontrado." };

            return File.ReadAllLines(caminhoLog);
        }
    }
}
