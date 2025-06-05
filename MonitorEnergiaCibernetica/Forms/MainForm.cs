using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorEnergiaCibernetica.Forms;

namespace MonitorEnergiaCibernetica.Forms
{
    public partial class MainForm : Form
    {
        private Button btnRegistrar;
        private Button btnSimular;
        private Button btnRelatorios;
        private Button btnLogs;
        private Button btnSair;

        public MainForm()
        {
            this.Text = "Monitor de Energia Cibernética";
            this.Width = 500;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            btnRegistrar = new Button { Text = "Registrar Falha", Top = 30, Left = 30, Width = 200 };
            btnSimular = new Button { Text = "Simular Falha", Top = 80, Left = 30, Width = 200 };
            btnRelatorios = new Button { Text = "Relatórios", Top = 130, Left = 30, Width = 200 };
            btnLogs = new Button { Text = "Ver Logs", Top = 180, Left = 30, Width = 200 };
            btnSair = new Button { Text = "Sair", Top = 230, Left = 30, Width = 200 };

            btnRegistrar.Click += (s, e) => new RegistroForm().ShowDialog();
            btnSimular.Click += (s, e) => new SimulacaoForm().ShowDialog();
            btnRelatorios.Click += (s, e) => new RelatorioForm().ShowDialog();
            btnLogs.Click += (s, e) => new LogsForm().ShowDialog();
            btnSair.Click += (s, e) => Application.Exit();

            this.Controls.AddRange(new Control[]
            {
                btnRegistrar,
                btnSimular,
                btnRelatorios,
                btnLogs,
                btnSair
            });
        }
    }
}