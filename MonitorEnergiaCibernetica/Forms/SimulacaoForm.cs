using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorEnergiaCibernetica.Models;
using MonitorEnergiaCibernetica.Services;

namespace MonitorEnergiaCibernetica.Forms
{
    public partial class SimulacaoForm : Form
    {
        private Button btnSimular;
        private Label lblResultado;
        private readonly RegistroService _registroService;

        public SimulacaoForm()
        {
            this.Text = "Simulação de Falha";
            this.Width = 400;
            this.Height = 200;
            this.StartPosition = FormStartPosition.CenterScreen;

            _registroService = new RegistroService();

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            btnSimular = new Button
            {
                Text = "Simular Falha de Energia",
                Top = 30,
                Left = 20,
                Width = 300
            };
            btnSimular.Click += BtnSimular_Click;

            lblResultado = new Label
            {
                Text = "",
                Top = 80,
                Left = 20,
                Width = 350,
                AutoSize = true
            };

            this.Controls.Add(btnSimular);
            this.Controls.Add(lblResultado);
        }

        private void BtnSimular_Click(object sender, EventArgs e)
        {
            var falha = new QuedaEnergia
            {
                DataHora = DateTime.Now,
                Local = "Servidor Principal",
                DuracaoMinutos = 12,
                TipoFalha = "Pane total",
                Simulada = true
            };

            _registroService.AdicionarFalha(falha);
            LogService.Registrar($"Falha simulada automaticamente no local '{falha.Local}'.");

            lblResultado.Text = "Falha simulada com sucesso às " + falha.DataHora.ToString("HH:mm:ss");
        }
    }
}