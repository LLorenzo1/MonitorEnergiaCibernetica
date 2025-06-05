using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorEnergiaCibernetica.Services;
using MonitorEnergiaCibernetica.Models;

namespace MonitorEnergiaCibernetica.Forms
{
    public partial class RelatorioForm : Form
    {
        private Label lblResumo;
        private ListBox listRelatorio;
        private readonly RegistroService _registroService;

        public RelatorioForm()
        {
            this.Text = "Relatório de Falhas";
            this.Width = 600;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;

            _registroService = new RegistroService();

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            lblResumo = new Label
            {
                Top = 20,
                Left = 20,
                Width = 540,
                Height = 100,
                Font = new System.Drawing.Font("Consolas", 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            listRelatorio = new ListBox
            {
                Top = 140,
                Left = 20,
                Width = 540,
                Height = 300,
                Font = new System.Drawing.Font("Consolas", 10)
            };

            this.Controls.Add(lblResumo);
            this.Controls.Add(listRelatorio);

            this.Load += RelatorioForm_Load;
        }

        private void RelatorioForm_Load(object sender, EventArgs e)
        {
            var falhas = _registroService.CarregarFalhas();
            listRelatorio.Items.Clear();

            if (!falhas.Any())
            {
                lblResumo.Text = "Nenhuma falha registrada.";
                return;
            }

            int total = falhas.Count;
            int simuladas = falhas.Count(f => f.Simulada);
            int reais = total - simuladas;
            double mediaDuracao = falhas.Average(f => f.DuracaoMinutos);

            lblResumo.Text =
                $"Total de falhas:        {total}\n" +
                $"Falhas reais:           {reais}\n" +
                $"Falhas simuladas:       {simuladas}\n" +
                $"Duração média (min):    {mediaDuracao:N1}";

            foreach (var f in falhas.OrderByDescending(f => f.DataHora))
            {
                string linha = $"{f.DataHora:dd/MM HH:mm} | {f.Local,-15} | {f.DuracaoMinutos,3} min | {f.TipoFalha,-10} | Alerta: {f.NivelAlerta}";
                listRelatorio.Items.Add(linha);
            }
        }
    }
}
