using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using MonitorEnergiaCibernetica.Models;

namespace MonitorEnergiaCibernetica.Services
{
    public class RegistroService
    {
        private static readonly string caminhoArquivo = "dados/falhas.json";

        public List<QuedaEnergia> CarregarFalhas()
        {
            if (!File.Exists(caminhoArquivo))
                return new List<QuedaEnergia>();

            string json = File.ReadAllText(caminhoArquivo);
            return JsonConvert.DeserializeObject<List<QuedaEnergia>>(json) ?? new List<QuedaEnergia>();
        }

        public void SalvarFalhas(List<QuedaEnergia> falhas)
        {
            string json = JsonConvert.SerializeObject(falhas, Formatting.Indented);
            Directory.CreateDirectory("dados");
            File.WriteAllText(caminhoArquivo, json);
        }

        public void AdicionarFalha(QuedaEnergia novaFalha)
        {
            var falhas = CarregarFalhas();
            falhas.Add(novaFalha);
            SalvarFalhas(falhas);
        }
    }
}