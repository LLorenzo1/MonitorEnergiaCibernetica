using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorEnergiaCibernetica.Models
{
    public class Alerta
    {
        public DateTime DataHora { get; set; }
        public string Mensagem { get; set; }
        public string Nivel { get; set; } // Ex: "Moderado", "Crítico"

        public override string ToString()
        {
            return $"{DataHora:dd/MM/yyyy HH:mm} | {Nivel} | {Mensagem}";
        }
    }
}
