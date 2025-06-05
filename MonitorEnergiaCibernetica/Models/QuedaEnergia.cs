using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorEnergiaCibernetica.Models
{
    public class QuedaEnergia
    {
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public int DuracaoMinutos { get; set; } // duração da queda
        public string TipoFalha { get; set; }   // programada, acidental, pane total
        public bool Simulada { get; set; }      // se foi uma falha simulada ou real

        public override string ToString()
        {
            return $"{DataHora:dd/MM/yyyy HH:mm} | {Local} | {DuracaoMinutos} min | {TipoFalha} | Simulada: {Simulada}";
        }

        public string NivelAlerta
        {
            get
            {
                if (DuracaoMinutos >= 30)
                    return "Crítico";
                else if (DuracaoMinutos >= 15)
                    return "Moderado";
                else
                    return "Leve";
            }
        }

    }
}