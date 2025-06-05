using System;
using System.Windows.Forms;
using MonitorEnergiaCibernetica.Models;
using MonitorEnergiaCibernetica.Services;

namespace MonitorEnergiaCibernetica.Forms
{
    public class RegistroForm : Form
    {
        private readonly RegistroService _registroService = new RegistroService();

        private DateTimePicker dtpDataHora;
        private TextBox txtLocal;
        private NumericUpDown numDuracao;
        private ComboBox cmbTipoFalha;
        private Button btnRegistrar;
        private Button btnCancelar;

        public RegistroForm()
        {
            this.Text = "Registro de Falha de Energia";
            this.ClientSize = new System.Drawing.Size(420, 360);
            this.StartPosition = FormStartPosition.CenterScreen;

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            Label lblData = new Label { Text = "Data e Hora:", Top = 20, Left = 20, Width = 100 };
            dtpDataHora = new DateTimePicker { Top = 40, Left = 20, Width = 200 };

            Label lblLocal = new Label { Text = "Local:", Top = 80, Left = 20, Width = 100 };
            txtLocal = new TextBox { Top = 100, Left = 20, Width = 300 };

            Label lblDuracao = new Label { Text = "Duração (min):", Top = 140, Left = 20, Width = 120 };
            numDuracao = new NumericUpDown { Top = 160, Left = 20, Width = 100, Minimum = 1, Maximum = 1440 };

            Label lblTipo = new Label { Text = "Tipo de Falha:", Top = 200, Left = 20, Width = 120 };
            cmbTipoFalha = new ComboBox { Top = 220, Left = 20, Width = 200 };
            cmbTipoFalha.Items.AddRange(new string[] { "Programada", "Acidental", "Pane total" });
            cmbTipoFalha.SelectedIndex = 0;

            btnRegistrar = new Button { Text = "Registrar Falha", Top = 280, Left = 20, Width = 130 };
            btnCancelar = new Button { Text = "Cancelar", Top = 280, Left = 170, Width = 100 };

            btnRegistrar.Click += BtnRegistrar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblData, dtpDataHora,
                lblLocal, txtLocal,
                lblDuracao, numDuracao,
                lblTipo, cmbTipoFalha,
                btnRegistrar, btnCancelar
            });
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string local = txtLocal.Text.Trim();
                int duracao = (int)numDuracao.Value;
                string tipo = cmbTipoFalha.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(local))
                    throw new Exception("O campo 'Local' não pode estar vazio.");

                if (duracao <= 0)
                    throw new Exception("A duração deve ser maior que zero.");

                if (string.IsNullOrEmpty(tipo))
                    throw new Exception("Tipo de falha não selecionado.");

                var falha = new QuedaEnergia
                {
                    DataHora = dtpDataHora.Value,
                    Local = local,
                    DuracaoMinutos = duracao,
                    TipoFalha = tipo,
                    Simulada = false
                };

                _registroService.AdicionarFalha(falha);
                LogService.Registrar($"Falha registrada no local '{local}' com duração de {duracao} minutos.");

                MessageBox.Show("Falha registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar falha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
